using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Advisor
{
    public int AdvisorId { get; set; }

    public string? StudentInformation { get; set; }

    public string? UpdateStudentInformation { get; set; }

    public string? AdvisorInformation { get; set; }

    public virtual UserProfile AdvisorNavigation { get; set; } = null!;

    public virtual Document? Document { get; set; }
}
