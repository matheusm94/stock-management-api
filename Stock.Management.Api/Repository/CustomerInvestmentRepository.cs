using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Repository.Interfaces;
using System.Data;

namespace Stock.Management.Api.Repository;

public class CustomerInvestmentRepository(DbStockContext context) : ICustomerInvestmentRepository
{
    private readonly DbStockContext _context = context;

    public async Task<IEnumerable<CustomerInvestmentGetDto>> GetInvestmentByCustomerIdAsync(int customerId)
    {
        return await (from c in _context.Customerinvestments
                      where c.Customerid == customerId
                      select new CustomerInvestmentGetDto
                      {
                          InvestmentId = c.Investmentid,
                          Customerid = customerId,
                          Productid = c.Productid,
                          Amount = c.Amount,
                          investmentValue = c.investmentValue,
                      }).ToListAsync().ConfigureAwait(false);

    }

    public async Task InsertCustomerInvestmentAsync(Customerinvestment customerInvestment)
    {
        await _context.AddAsync(customerInvestment);
    }

    public async Task<IEnumerable<CustomerInvestmentGetDto>> GetCustomerInvestmentByProductAndCustomerIdAsync(int productId, int customerId)
    {
        return await (from c in _context.Customerinvestments
                      where c.Customerid == customerId
                      && c.Productid == productId
                      select new CustomerInvestmentGetDto
                      {
                          InvestmentId = c.Investmentid,
                          Customerid = customerId,
                          Productid = c.Productid,
                          Amount = c.Amount,
                          investmentValue = c.investmentValue
                      }).ToListAsync().ConfigureAwait(false);
    }

    public async Task UpdateInvestmentAsync(CustomerInvestmentDto customerInvestmentDto, decimal totalInvestimentValue)
    {
        var customerInvestment = await _context.Customerinvestments.Where(x => x.Customerid == customerInvestmentDto.Customerid
        && x.Productid == customerInvestmentDto.Productid).FirstOrDefaultAsync();

        customerInvestment.Amount = customerInvestmentDto.Amount;
        customerInvestment.investmentValue = totalInvestimentValue;
    }
}
