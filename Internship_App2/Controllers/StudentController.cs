using Internship_App2.AppDbContext;
using Internship_App2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Net.Mail;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace Internship_App2.Controllers
{
	
	public class StudentController : Controller
	{
		public IActionResult AddInternship(string data)
		{
			ViewBag.StudentNo = data;
			return View();
		}

		[HttpPost]
		public IActionResult AddInternship(StudentModel model, IFormFile myfile, IFormFile file, int days,int Number)
		{
			using (var db = new InternshipDb2Context())
			{
				if (model.InternshipApplication.InternshipType == "Mandatory")
				{
					if (days == 20 || days == 40)
					{
						// Geçerli zorunlu staj süresi
					}
					else
					{
						ModelState.AddModelError("InternshipDuration", "Zorunlu staj 20 veya 40 iş günü olmalıdır.");
						return View(model);
					}
				}

				if (file != null)
				{
					var extension = Path.GetExtension(file.FileName);
					var newFileName = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newFileName);
					var stream = new FileStream(location, FileMode.Create);
					file.CopyTo(stream);
					model.Student.ProfilePhoto = newFileName;
				}

				model.Student.StudentNo = Number.ToString();
				db.Students.Add(model.Student);
				db.SaveChanges();
				model.InternshipApplication.StudentId = model.Student.StudentId;

				if (myfile != null)
				{
					var extension = Path.GetExtension(myfile.FileName);
					var newFileName = Guid.NewGuid() + extension;
					var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/", newFileName);
					var stream = new FileStream(location, FileMode.Create);
					myfile.CopyTo(stream);
					model.InternshipApplication.RequiredDocuments = newFileName;
				}

				model.InternshipApplication.Duration = days;
				model.InternshipApplication.ApplicationStatus = 0;

				db.InternshipApplications.Add(model.InternshipApplication);
				db.SaveChanges();

			
				try
				{
					var fromAddress = new MailAddress("cerendem2003@gmail.com", "Ayşenur");
					var toAddress = new MailAddress(model.InternshipApplication.AdvisorEmail);
					const string fromPassword = "uqqj hwqs akvs kngf";
				
				
					const string subject = "Öğrenci Staj Başvuru Sayfasından Mesajınız Var.";
					string body = "Sayın yetkili,<br/><br/>" +
					 model.Student.FirstName + " " + model.Student.LastName +
					 " kişisinden gelen başvurunun değerlendirilmesi gerekmektedir.<br/><br/>" +
					 "İyi çalışmalar.";


					var smtp = new SmtpClient
					{

						Host = "smtp.gmail.com",
						Port = 587,
						EnableSsl = true,
						DeliveryMethod = SmtpDeliveryMethod.Network,
						UseDefaultCredentials = false,
						Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
					};

					using (var message = new MailMessage(fromAddress, toAddress)
					{
						Subject = subject,
						Body = body,
						IsBodyHtml = true
					})
					{
						smtp.Send(message);
					}
				}
				catch (Exception ex)
				{
					// Hataları burada ele al
					Console.WriteLine("Email gönderme hatası: " + ex.Message);
				}



				return Redirect("/student/AddInternship?data=" + model.Student.StudentNo);
			}
		}

		public JsonResult CalculateTotalWorkDays(string startDate,string finishDate)
		{
			using (var db=new InternshipDb2Context())
			{
				var start = DateTime.ParseExact(startDate, "yyyy-MM-dd",CultureInfo.InvariantCulture);
				var finish = DateTime.ParseExact(finishDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
				int totalWorkDays = 0;

				foreach (var entry in db.Calendars.Where(i => i.Date >= start && i.Date <= finish))
				{
					if (entry.IsWorkDay==true)
					{
						totalWorkDays++;
					}
				}

				return Json(totalWorkDays);
			}
		}


	}
}

