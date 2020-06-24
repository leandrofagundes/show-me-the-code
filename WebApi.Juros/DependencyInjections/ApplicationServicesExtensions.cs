using Microsoft.Extensions.DependencyInjection;
using WebApi.Juros.Services;

namespace WebApi.Juros.DependencyInjections
{
    public static class ApplicationServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TaxaJurosService>();
        }
    }
}
