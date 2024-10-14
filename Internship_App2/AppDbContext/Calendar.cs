using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Calendar
{
    public DateTime Date { get; set; }

    public int? DayOfWeek { get; set; }

    public bool? IsWorkDay { get; set; }
}
