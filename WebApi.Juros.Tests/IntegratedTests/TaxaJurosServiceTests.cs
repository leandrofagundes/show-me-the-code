using WebApi.Juros.Tests.Fixtures;
using Xunit;

namespace WebApi.Juros.Tests.IntegratedTests
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
