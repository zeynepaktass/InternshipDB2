using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? FeedbackInformation { get; set; }

    public virtual UserProfile FeedbackNavigation { get; set; } = null!;
}
