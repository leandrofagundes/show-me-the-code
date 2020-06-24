using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Juros.Helpers
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
                Title = "Show me The Code API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Leandro Fagundes",
                    Email = "leandro@fagundes.email"
                },
                Description = "Esta documentação refere-se a API utilizada para a construção do Show me The Code."
            };

            return info;
        }
    }
}
