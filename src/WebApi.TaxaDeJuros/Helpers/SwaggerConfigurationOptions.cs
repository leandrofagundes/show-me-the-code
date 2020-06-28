using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.TaxaDeJuros.Helpers
{
    public class SwaggerConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", CreateInfoForApiVersion());
        }

        private static OpenApiInfo CreateInfoForApiVersion()
        {
            var info = new OpenApiInfo()
            {
                Title = "Taxa de Juros API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Leandro Fagundes",
                    Email = "leandro@fagundes.email"
                },
                Description = "Esta documentação refere-se a API para obtenção da Taxa de Juros do Show me The Code."
            };

            return info;
        }
    }
}
