using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Document
{
    public int DocumentId { get; set; }

    public bool? IsApproved { get; set; }

    public virtual Advisor DocumentNavigation { get; set; } = null!;
}
