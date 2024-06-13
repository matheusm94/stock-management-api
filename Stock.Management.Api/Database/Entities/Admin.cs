using System;
using System.Collections.Generic;

namespace Stock.Management.Api.Database.Entities;

public partial class Admin
{
    public int Adminid { get; set; }

    public int Userid { get; set; }

    public virtual User User { get; set; } = null!;
}
