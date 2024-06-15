using Stock.Management.Api.Database.Entities;

namespace Stock.Management.Api.Extensions;

public static class AutoMapperConfig
{
    public static void AddMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Customerinvestment));
    }
}
