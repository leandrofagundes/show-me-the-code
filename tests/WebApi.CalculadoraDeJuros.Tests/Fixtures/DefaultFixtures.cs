using WebApi.CalculadoraDeJuros.Interfaces;
using WebApi.CalculadoraDeJuros.Services;
using WebApi.CalculadoraDeJuros.Tests.MockServices;

namespace WebApi.CalculadoraDeJuros.Tests.Fixtures
{
    public sealed class DefaultFixtures
    {
        public ICalculadoraJuros CalculadoraJurosService { get; private set; }
        public IShowMeTheCode ShowMeTheCode { get; private set; }
        public ITaxaJurosAPI TaxaJurosAPIWebService { get; private set; }

        public DefaultFixtures()
        {
            this.TaxaJurosAPIWebService = new MockTaxaJurosAPIWebService();
            this.ShowMeTheCode = new ShowMeTheCodeService();
            this.CalculadoraJurosService = new CalculadoraJurosCompostoService(TaxaJurosAPIWebService);

        }
    }
}
