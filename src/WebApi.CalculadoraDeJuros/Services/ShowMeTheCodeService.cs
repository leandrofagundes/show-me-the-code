using WebApi.CalculadoraDeJuros.Interfaces;

namespace WebApi.CalculadoraDeJuros.Services
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
