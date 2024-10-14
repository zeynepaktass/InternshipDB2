using Internship_App2.AppDbContext;

namespace Internship_App2.Models
{
    public class StudentModel
    {
        public Student Student { get; set; }
        public InternshipApplication InternshipApplication { get; set; }

        public EmailService? EmailService { get; set; }

        public string? AdSoyad { get; set; }

        public string? Baslik { get; set; }

        public string? İcerik { get; set; }

    }
}
