using WebApi.Juros.Tests.Fixtures;
using Xunit;

namespace WebApi.Juros.Tests.UnitTests
{
    public class TaxaJuroTests : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public TaxaJuroTests(DefaultFixtures fixtures)
        {
            this._fixtures = fixtures;
        }

        [Fact]
        public void ObterTaxaJurosComSucesso()
        {
            var taxaJuros = _fixtures.TaxaJurosService.ObterTaxaJuros();
            double expectedValue = 0.01;

            Assert.Equal(taxaJuros, expectedValue);
        }
    }
}
