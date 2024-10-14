using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class AdminCalendar
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }
}
