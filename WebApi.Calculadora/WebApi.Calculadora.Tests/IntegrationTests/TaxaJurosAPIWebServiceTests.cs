using System.Threading.Tasks;
using WebApi.Calculadora.Tests.Fixtures;
using Xunit;

namespace WebApi.Calculadora.Tests.IntegrationTests
{

    public class TaxaJurosAPIWebServiceTests : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public TaxaJurosAPIWebServiceTests(DefaultFixtures fixtures)
        {
            this._fixtures = fixtures;
        }

        [Fact]
        public async Task CalcularTaxaJurosCompostoComSucesso()
        {
            var taxaJuros = await _fixtures.TaxaJurosAPIWebService.ObterTaxaJuros();

            var valorObtido = taxaJuros.ToString();
            var valorEsperado = "0,01";

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
