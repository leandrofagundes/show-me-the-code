using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Reflection;

namespace WebApi.Calculadora.DependencyInjections
{
    public static class SwaggerExtensions
    {
        private static string XmlCommentsFilePath
        {
            get
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigurationOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // Um filtro para auxiliar na geração de valores quando não houver. 
                    //options.OperationFilter<SwaggerDefaultValues>(); // TODO: Identificar necessidade

                    // O FullName é necessário pois quando duas classes tiverem o mesmo nome, ele valida pelo namespace completo.
                    options.CustomSchemaIds(x => x.FullName);

                    // Gera o arquivo XML no caminho desejado contendo os summary dos controllers.
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });

            return services;
        }

        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.DocumentTitle = "Show me The Code - Documentação da API";
                    // Constrói uma interface visual do Swagger para cada Endpoint de Versão encontrado na aplicação
                    options.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                });

            return app;
        }
    }
}
