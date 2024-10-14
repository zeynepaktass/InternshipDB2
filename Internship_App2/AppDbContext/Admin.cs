﻿using System;
using System.Collections.Generic;

namespace Internship_App2.AppDbContext;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual UserProfile AdminNavigation { get; set; } = null!;
}
