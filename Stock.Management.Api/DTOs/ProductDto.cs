using System.ComponentModel.DataAnnotations;

namespace Stock.Management.Api.DTOs;

public class ProductDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateTime Maturitydate { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public decimal Price { get; set; }
}
