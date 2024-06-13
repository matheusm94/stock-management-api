namespace Stock.Management.Api.Models
{
    public class ProductModel
    {
        public int Productid { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly Maturitydate { get; set; }

        public decimal Price { get; set; }

    }
}
