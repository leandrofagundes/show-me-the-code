using WebApi.TaxaDeJuros.Tests.Fixtures;
using Xunit;

namespace WebApi.TaxaDeJuros.Tests.IntegratedTests
{
    public class TaxaJurosServiceTests : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public TaxaJurosServiceTests(DefaultFixtures fixtures)
        {
            this._fixtures = fixtures;
        }

        [Fact]
        public void ObterTaxaJurosComSucesso()
        {
            var taxaJuros = _fixtures.TaxaJurosService.ObterTaxaJuros();

            string valorEsperado = "0,01";

            Assert.Equal(valorEsperado, taxaJuros.ToString());
        }
    }
}
