using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stock.Management.Api.Database;
using Stock.Management.Api.Repository;
using Stock.Management.Api.Repository.Interfaces;
using Stock.Management.Api.Service;
using Stock.Management.Api.Service.Interfaces;

namespace Stock.Management.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        internal static IServiceCollection ResolveDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbStockContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("StockDb")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerInvestmentRepository, CustomerInvestmentRepository>();
            services.AddScoped<ICustomerInvestmentService, CustomerInvestmentService>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
