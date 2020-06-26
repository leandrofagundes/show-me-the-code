using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using WebApi.CalculadoraDeJuros.Interfaces;
using WebApi.CalculadoraDeJuros.WebServices;

namespace WebApi.CalculadoraDeJuros.DependencyInjections
{
    public static class TaxaJurosWebServicesExtensions
    {
        public static void AddTaxaJurosWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(s =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri(configuration["TaxaJurosWebAPI:baseUrl"])
                };
            });

            services.AddScoped<ITaxaJurosAPI, TaxaJurosAPIWebService>();
        }
    }
}
