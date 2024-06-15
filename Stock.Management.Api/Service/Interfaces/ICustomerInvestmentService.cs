using Stock.Management.Api.DTOs;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service.Interfaces;

public interface ICustomerInvestmentService
{
    Task<ServiceResult<bool>> CreateCustomerInvestmentAsync(CustomerInvestmentDto customerinvestmentDto);
    Task<ServiceResult<IEnumerable<CustomerInvestmentGetDto>>> GetInvestmentByCustomerIdAsync(int customerId);
}
