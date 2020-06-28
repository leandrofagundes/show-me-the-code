using WebApi.CalculadoraDeJuros.Interfaces;

namespace WebApi.CalculadoraDeJuros.Services
{
    public class ShowMeTheCodeService
        : IShowMeTheCode
    {
        public string GetUrl()
        {
            return "https://github.com/leandrofagundes/show-me-the-code";
        }
    }
}
