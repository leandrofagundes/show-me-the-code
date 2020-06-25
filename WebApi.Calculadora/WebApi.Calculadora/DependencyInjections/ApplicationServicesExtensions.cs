﻿using Microsoft.Extensions.DependencyInjection;
using WebApi.Calculadora.Services;

namespace WebApi.Calculadora.DependencyInjections
{
    public static class ApplicationServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<CalculadoraService>();
        }
    }
}