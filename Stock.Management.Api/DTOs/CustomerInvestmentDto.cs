using System.ComponentModel.DataAnnotations;

namespace Stock.Management.Api.DTOs;

public class CustomerInvestmentDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Customerid { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public int Productid { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public decimal Amount { get; set; }
}
