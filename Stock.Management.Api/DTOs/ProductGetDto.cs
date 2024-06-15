namespace Stock.Management.Api.DTOs;

public class ProductGetDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;

    public DateTime Maturitydate { get; set; }
 
    public decimal Price { get; set; }
}
