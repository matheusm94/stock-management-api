namespace Stock.Management.Api.DTOs;

public class CustomerInvestmentGetDto
{
    public int InvestmentId { get; set; }
    public int Customerid { get; set; }
    public int Productid { get; set; }
    public decimal Amount { get; set; }
    public decimal investmentValue { get; set; }
}
