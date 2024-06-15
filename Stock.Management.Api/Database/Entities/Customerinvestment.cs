namespace Stock.Management.Api.Database.Entities;

public partial class Customerinvestment
{
    public int Investmentid { get; set; }

    public int Customerid { get; set; }

    public int Productid { get; set; }

    public decimal Amount { get; set; }
    public decimal investmentValue { get; set; }

    public DateTime Purchasedate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
