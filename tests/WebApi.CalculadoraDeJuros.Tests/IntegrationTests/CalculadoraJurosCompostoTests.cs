using System;
using System.Threading.Tasks;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using WebApi.CalculadoraDeJuros.Tests.Fixtures;
using Xunit;

namespace WebApi.CalculadoraDeJuros.Tests.IntegrationTests
{
    public class CalculadoraJurosCompostoTests : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public CalculadoraJurosCompostoTests(DefaultFixtures fixtures)
        {
            this._fixtures = fixtures;
        }

        [Fact]
        public async Task CalcularTaxaJurosCompostoComSucesso()
        {
            var valorFinalComJuros = await _fixtures.CalculadoraJurosService.CalculaJurosAsync(
                new CalculadoraJurosValorInicial(100),
                 new CalculadoraJurosMeses(5));

            var valorObtido = valorFinalComJuros.ToString();
            var valorEsperado = "105,10";

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(100, 5, "105,10")]
        [InlineData(100, 10, "110,46")]
        [InlineData(1100, 10, "1215,08")]
        [InlineData(1100, 5, "1156,11")]
        public async Task CalcularTaxaJurosCompostoEmLista(decimal valorInicial, int numeroMeses, string valorEsperado)
        {
            var valorFinalComJuros = await _fixtures.CalculadoraJurosService.CalculaJurosAsync(
                new CalculadoraJurosValorInicial(valorInicial),
                new CalculadoraJurosMeses(numeroMeses));

            var taxaJuros = await _fixtures.TaxaJurosAPIWebService.ObterTaxaJuros();

            Assert.Equal(valorFinalComJuros.ToString(), valorEsperado);
        }
    }
}
