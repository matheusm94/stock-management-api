using AutoMapper;
using Stock.Management.Api.Database;
using Stock.Management.Api.Database.Entities;
using Stock.Management.Api.DTOs;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Service.Interfaces;
using Stock.Management.Api.Utils;

namespace Stock.Management.Api.Service;

public class CustomerInvestmentService(ICustomerInvestmentRepository customerInvestmentRepository,
                                       IMapper mapper,
                                       IUnitOfWork unitOfWork,
                                       IProductRepository productRepository) : ICustomerInvestmentService
{
    private readonly ICustomerInvestmentRepository _customerInvestmentRepository = customerInvestmentRepository;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ServiceResult<bool>> CreateCustomerInvestmentAsync(CustomerInvestmentDto customerinvestmentDto)
    {
        var result = new ServiceResult<bool>();

        var product = await _productRepository.GetProductByIdAsync(customerinvestmentDto.Productid);

        decimal totalInvestingValueByProduct = customerinvestmentDto.Amount * product.Price;

        var currentInvestments = await _customerInvestmentRepository.GetCustomerInvestmentByProductAndCustomerIdAsync(customerinvestmentDto.Productid, customerinvestmentDto.Customerid);
        if (!currentInvestments.Any())
        {
            var customerInvestment = _mapper.Map<Customerinvestment>(customerinvestmentDto);

            customerInvestment.Purchasedate = DateTime.UtcNow;
            customerInvestment.investmentValue = totalInvestingValueByProduct;

            await _customerInvestmentRepository.InsertCustomerInvestmentAsync(customerInvestment);
        }
        else
        {
            decimal totalAmount = currentInvestments.Where(x => x.Productid == customerinvestmentDto.Productid).Select(x => x.Amount).Sum();
            decimal totalInvestmentValue = currentInvestments.Where(x => x.Productid == customerinvestmentDto.Productid).Select(x => x.investmentValue).Sum();

            customerinvestmentDto.Amount += totalAmount;
            totalInvestingValueByProduct += totalInvestmentValue;

           await _customerInvestmentRepository.UpdateInvestmentAsync(customerinvestmentDto, totalInvestingValueByProduct);
        }

        await _unitOfWork.CommitAsync();

        result.SetSuccess();

        return result;
    }

    public async Task<ServiceResult<IEnumerable<CustomerInvestmentGetDto>>> GetInvestmentByCustomerIdAsync(int customerId)
    {
        var result = new ServiceResult<IEnumerable<CustomerInvestmentGetDto>>();

        var investments = await _customerInvestmentRepository.GetInvestmentByCustomerIdAsync(customerId);

        return result.SetSuccess(investments);

    }
}
