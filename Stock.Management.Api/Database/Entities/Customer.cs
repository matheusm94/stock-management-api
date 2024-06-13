using System;
using System.Collections.Generic;

namespace Stock.Management.Api.Database.Entities;

public partial class Customer
{
    public int Customerid { get; set; }

    public int Userid { get; set; }

    public virtual ICollection<Customerinvestment> Customerinvestments { get; set; } = new List<Customerinvestment>();

    public virtual User User { get; set; } = null!;
}
