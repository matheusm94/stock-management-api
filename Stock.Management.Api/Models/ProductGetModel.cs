namespace Stock.Management.Api.Models;

public class ProductGetModel
{
    public int Productid { get; set; }
    public string Name { get; set; } = null!;

    public DateTime Maturitydate { get; set; }

    public decimal Price { get; set; }
}
