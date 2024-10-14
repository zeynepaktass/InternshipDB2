using Internship_App2.AppDbContext;
using Internship_App2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace Internship_App2.Controllers
{

	public class AdvisorController : Controller
    {
 
        public IActionResult Index()
        {
            using (var db = new InternshipDb2Context())
            {
                var students = db.Students.ToList();
                var model = new List<StudentModel>();
                foreach (var student in students)
                {
                    StudentModel studentModel = new StudentModel();
                    var internship = db.InternshipApplications
                        .Where(i => i.StudentId == student.StudentId).FirstOrDefault();
                    studentModel.Student = student;
                    studentModel.InternshipApplication = internship;
                    model.Add(studentModel);
                }
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult InternshipDetail(int id)
        {
            if (id == 0)
            {
                id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
			}
            else
            {
				HttpContext.Session.SetString("Id", id.ToString());
			}

			using (var db = new InternshipDb2Context())
            {
                var internship = db.InternshipApplications.Where(i => i.ApplicationId == id).FirstOrDefault();
                var student = db.Students.Where(i => i.StudentId == internship.StudentId).FirstOrDefault();

                var model = new StudentModel()
                {
                    InternshipApplication = internship,
                    Student = student
                };
                return View(model);
            }
        }
      
        public IActionResult ChangeStatusApproved(int id)
        {
            using (var db=new InternshipDb2Context())
            {
                var intership = db.InternshipApplications.Where(i => i.ApplicationId == id).FirstOrDefault();
				var student = db.Students.Where(i => i.StudentId == intership.StudentId).FirstOrDefault();
				intership.ApplicationStatus = 1;
                db.SaveChanges();


		
				try
				{
					var fromAddress = new MailAddress("cerendem2003@gmail.com", "Ayşenur");
					var toAddress = new MailAddress(intership.Student.Email);
					const string fromPassword = "uqqj hwqs akvs kngf";


					const string subject = "Staj Başvuru Sayfasından Mesajınız Var.";
					string body = "Sayın öğrencimiz , staj müracaatınız onaylammıştır.";

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
						Body = body
					})
					{
						smtp.Send(message);
					}
				}
				catch (Exception ex)
				{
				
					Console.WriteLine("Email gönderme hatası: " + ex.Message);
				}

				return Redirect("/advisor/InternshipDetail/" + intership.ApplicationId);
            }
        }
		public IActionResult ChangeStatusRejected(int id)
		{
			using (var db = new InternshipDb2Context())
			{
				var intership = db.InternshipApplications.Where(i => i.ApplicationId == id).FirstOrDefault();
				var student = db.Students.Where(i => i.StudentId == intership.StudentId).FirstOrDefault();
				intership.ApplicationStatus = 2;
				db.SaveChanges();

				
				try
				{
					var fromAddress = new MailAddress("cerendem2003@gmail.com", "Ayşenur");
					var toAddress = new MailAddress(student.Email);
					const string fromPassword = "uqqj hwqs akvs kngf";


					const string subject = "Staj Başvuru Sayfasından Mesajınız Var.";
					string body = "Sayın öğrencimiz , staj müracaatınız reddedilmiştir.";

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
						Body = body
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

				return Redirect("/advisor/InternshipDetail/" + intership.ApplicationId);
			}
		}

		[HttpPost]
        public IActionResult UpdateInformation(StudentModel model)
        {
            using (var db=new InternshipDb2Context())
            {
                var internship = db.InternshipApplications.Where(i => i.ApplicationId == model.InternshipApplication.ApplicationId).FirstOrDefault();
                
					internship.CompanyPhoneNumber = model.InternshipApplication.CompanyPhoneNumber;
					internship.CompanyName = model.InternshipApplication.CompanyName;
					internship.CompanyEmail = model.InternshipApplication.CompanyEmail;
					internship.CompanyAddress = model.InternshipApplication.CompanyAddress;
					internship.EmployerEmail = model.InternshipApplication.EmployerEmail;
					internship.EmployerName = model.InternshipApplication.EmployerName;
					internship.InternshipStartDate = model.InternshipApplication.InternshipStartDate;
					internship.InternshipEndDate = model.InternshipApplication.InternshipEndDate;
					internship.FieldOfActivity = model.InternshipApplication.FieldOfActivity;
					internship.InternshipType = model.InternshipApplication.InternshipType;
                    internship.EmployerSurname = model.InternshipApplication.EmployerSurname;
                    internship.EmployerPhone = model.InternshipApplication.EmployerPhone;
					db.InternshipApplications.Update(internship);
					db.SaveChanges();
				
				return Redirect("/advisor/InternshipDetail/" + internship.ApplicationId);
			}
        }

        
		//private readonly global::EmailService _emailService;

		//public AdvisorController(EmailService emailService)
		//{
		//	_emailService = emailService;
		//}

	}
}
