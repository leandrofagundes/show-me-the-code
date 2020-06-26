using Microsoft.Extensions.DependencyInjection;
using WebApi.CalculadoraDeJuros.Interfaces;
using WebApi.CalculadoraDeJuros.Services;

namespace WebApi.CalculadoraDeJuros.DependencyInjections
{
    public static class ApplicationServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculadoraJuros, CalculadoraJurosCompostoService>();
            services.AddScoped<IShowMeTheCode, ShowMeTheCodeService>();
        }
    }
}
