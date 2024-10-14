using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Internship_App2.Models;
using Internship_App2.AppDbContext;


namespace Internship_App2.Controllers
{
	public class AccountController : Controller
	{

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(UserDto userDto)
		{
			using (InternshipDb2Context db = new InternshipDb2Context())
			{
				var admin = new Admin
				{
					Username = userDto.Username+ "@admin.tr",
					Password = userDto.Password,
				};
				var existingUserProfile = db.UserProfiles.FirstOrDefault(u => u.Email == userDto.Username);

				if (existingUserProfile != null)
				{
					admin.AdminNavigation = existingUserProfile;
				}
				else
				{
					var maxId = db.UserProfiles.Max(u => u.Id);

					// Yeni Id değerini oluşturma
					var newId = maxId + 1;

					var newUserProfile = new UserProfile
					{
						Id = newId,
						Email = userDto.Username+"@admin.tr",
						UserType = "admin"
					};

					admin.AdminNavigation = newUserProfile;
				}

				db.Admins.Add(admin);
				db.SaveChanges();
			}
			return View("Login");
		}

		public ActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public async Task<ActionResult> Login(UserDto userDto)
        {
            var userType = "";
            if (userDto.Username.Contains("@iku.edu.tr"))
                userType = "Advisor";
            else if (userDto.Username.Contains("@admin.tr"))
                userType = "Admin";
            else
                userType = "Student";

            if (userType == "Admin")
            {
                using (InternshipDb2Context db = new InternshipDb2Context())
                {
                    var admin = db.Admins.FirstOrDefault(x => x.Username == userDto.Username && x.Password == userDto.Password);
                    if (admin == null)
                    {
                        ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                        return View();
                    }

                    TempData["UserType"] = "Admin";

                    return RedirectToAction("Calendar", "Admin");
                }
            }

            if (deneme(userDto))
            {
                TempData["UserType"] = userType;

                if (userType == "Student")
                {
                    ViewBag.StudentNo = userDto.Username;
                    string StudentNo = userDto.Username;
                    return RedirectToAction("AddInternship", "Student", new { data = StudentNo });
                }
                else if (userType == "Advisor")
                {
                    TempData["Username"] = userDto.Username;
                    TempData["LoginDate"] = DateTime.Now;
                    return RedirectToAction("Index", "Advisor");
                }
                else
                {
                    ModelState.AddModelError("", "Bir şeyler yanlış gitti.");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış.");
                return View();
            }
        }


        private bool deneme(UserDto user)
		{
			try
			{

				ChromeDriverService service = ChromeDriverService.CreateDefaultService("C:\\Users\\LENOVO\\Desktop\\3. sınıf\\2. dönem\\Software Engineering");
				service.HideCommandPromptWindow = true;

				var options = new ChromeOptions();

				options.AddArgument("headless");

				IWebDriver _driver = new ChromeDriver(service, options);

				IJavaScriptExecutor ex = (IJavaScriptExecutor)_driver;

				string ikuCatsUrl = "https://cats.iku.edu.tr/portal/xlogin";

				_driver.Navigate().GoToUrl(ikuCatsUrl);

				IWebElement usernameField = _driver.FindElement(By.Id("eid"));
				IWebElement passwordField = _driver.FindElement(By.Id("pw"));

				Thread.Sleep(2000);
				WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(100));
				wait.Until(a => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));

				usernameField.SendKeys(user.Username);
				passwordField.SendKeys(user.Password);

				IWebElement sumbitbutton = _driver.FindElement(By.Id("submit"));

				ex.ExecuteScript("arguments[0].click();", sumbitbutton);

				wait.Until(a => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
				var elementexist = _driver.FindElement(By.Id("toolSubsitesContainer"));

				_driver.Quit();
				return true;

			}
			catch (Exception ex)
			{
				return false;
			}
		}

		

	}
}