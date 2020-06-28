using Microsoft.Extensions.DependencyInjection;
using WebApi.TaxaDeJuros.Services;

namespace WebApi.TaxaDeJuros.DependencyInjections
{
    public static class ApplicationServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TaxaJurosService>();
        }
    }
}
