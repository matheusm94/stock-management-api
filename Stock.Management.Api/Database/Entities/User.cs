using System;
using System.Collections.Generic;

namespace Stock.Management.Api.Database.Entities;

public partial class User
{
    public int Userid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Dateofbirth { get; set; }

    public string Cpf { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
