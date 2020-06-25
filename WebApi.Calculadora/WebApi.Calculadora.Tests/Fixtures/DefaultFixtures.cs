
using WebApi.Calculadora.Interfaces;
using WebApi.Calculadora.Services;
using WebApi.Calculadora.Tests.MockServices;

namespace WebApi.Calculadora.Tests.Fixtures
{
    public sealed class DefaultFixtures
    {
        public ICalculadoraJuros CalculadoraJurosService { get; private set; }
        public ITaxaJurosAPI TaxaJurosAPIWebService { get; private set; }

        public DefaultFixtures()
        {
            this.TaxaJurosAPIWebService = new MockTaxaJurosAPIWebService();
            this.CalculadoraJurosService = new CalculadoraJurosCompostoService(TaxaJurosAPIWebService);

        }
    }
}
