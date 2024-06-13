namespace Stock.Management.Api.Database.Entities;

public partial class Product
{
    public int Productid { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Maturitydate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Customerinvestment> Customerinvestments { get; set; } = [];
}
