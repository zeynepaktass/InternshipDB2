using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class UserProfile
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Advisor? Advisor { get; set; }

    public virtual Feedback? Feedback { get; set; }
}
