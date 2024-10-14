using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class StudentPage
{
    public int InternshipId { get; set; }

    public bool? TypeOfInternship { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? FinishDate { get; set; }

    public int? TotalWorkDays { get; set; }

    public string? InternshipFile { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Department { get; set; }

    public string? No { get; set; }

    public string? Cname { get; set; }

    public string? Cfield { get; set; }

    public string? Cemail { get; set; }

    public string? Cphone { get; set; }

    public string? Caddress { get; set; }

    public string? CrepresentativeName { get; set; }

    public string? CrepresentativeSurname { get; set; }

    public string? CrepresentativeEmail { get; set; }

    public string? CrepresentativePhone { get; set; }
}
