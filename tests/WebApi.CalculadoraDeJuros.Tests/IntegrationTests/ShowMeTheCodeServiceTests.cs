using WebApi.CalculadoraDeJuros.Tests.Fixtures;
using Xunit;

namespace WebApi.CalculadoraDeJuros.Tests.IntegrationTests
{
    public class ShowMeTheCodeServiceTests : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public ShowMeTheCodeServiceTests(DefaultFixtures fixtures)
        {
            this._fixtures = fixtures;
        }

        [Fact]
        public void ObterUrlShowMeTheCodeComSucesso()
        {
            var valorObtido = _fixtures.ShowMeTheCode.GetUrl();
            var valorEsperado = "https://dev.azure.com/leandro-fagundes/show-me-the-code";

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
