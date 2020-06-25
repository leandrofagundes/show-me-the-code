
using WebApi.Calculadora.Services;

namespace WebApi.Calculadora.Tests.Fixtures
{
    public sealed class DefaultFixtures
    {
        public CalculadoraJurosCompostoService CalculadoraJurosService { get; private set; }

        public DefaultFixtures()
        {
            this.CalculadoraJurosService = new CalculadoraJurosCompostoService();
        }
    }
}
