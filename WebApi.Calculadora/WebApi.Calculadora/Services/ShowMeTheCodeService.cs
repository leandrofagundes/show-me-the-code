using WebApi.Calculadora.Interfaces;

namespace WebApi.Calculadora.Services
{
    public class ShowMeTheCodeService
        : IShowMeTheCode
    {
        public string GetUrl()
        {
            return "https://dev.azure.com/leandro-fagundes/show-me-the-code";
        }
    }
}
