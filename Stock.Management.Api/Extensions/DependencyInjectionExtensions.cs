namespace Stock.Management.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        internal static IServiceCollection ResolveDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
