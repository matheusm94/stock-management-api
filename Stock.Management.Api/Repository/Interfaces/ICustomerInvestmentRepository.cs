using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;

namespace Stock.Management.Api.Repository.Interfaces;

public interface ICustomerInvestmentRepository
{
    Task<IEnumerable<CustomerInvestmentGetDto>> GetInvestmentByCustomerIdAsync(int customerId);
    Task InsertCustomerInvestmentAsync(Customerinvestment customerInvestment);
    Task<IEnumerable<CustomerInvestmentGetDto>> GetCustomerInvestmentByProductAndCustomerIdAsync(int productId, int customerId);
    Task UpdateInvestmentAsync(CustomerInvestmentDto customerInvestmentDto, decimal totalInvestimentValue);
}
