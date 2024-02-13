using Microsoft.Extensions.DependencyInjection;

namespace Starbucks.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }
    };
}
