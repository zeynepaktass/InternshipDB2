using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ProfilePhoto { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string StudentNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<InternshipApplication> InternshipApplications { get; } = new List<InternshipApplication>();
}
