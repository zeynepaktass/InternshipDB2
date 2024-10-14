using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class InternshipApplication
{
    public int ApplicationId { get; set; }

    public string InternshipType { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public string FieldOfActivity { get; set; } = null!;

    public string CompanyPhoneNumber { get; set; } = null!;

    public string CompanyEmail { get; set; } = null!;

    public DateTime InternshipStartDate { get; set; }

    public DateTime InternshipEndDate { get; set; }

    public int Duration { get; set; }

    public string RequiredDocuments { get; set; } = null!;

    public string EmployerName { get; set; } = null!;

    public string EmployerSurname { get; set; } = null!;

    public string EmployerPhone { get; set; } = null!;

    public string EmployerEmail { get; set; } = null!;

    public int StudentId { get; set; }

    public int ApplicationStatus { get; set; }

    public string AdvisorEmail { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
