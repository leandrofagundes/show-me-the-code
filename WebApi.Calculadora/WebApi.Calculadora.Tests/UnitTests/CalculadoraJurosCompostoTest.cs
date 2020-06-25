using System;
using System.Threading.Tasks;
using WebApi.Calculadora.Domain.ValueObjects;
using WebApi.Calculadora.Tests.Fixtures;
using Xunit;

namespace WebApi.Calculadora.Tests.UnitTests
{
    public class CalculadoraJurosCompostoTest : IClassFixture<DefaultFixtures>
    {
        private readonly DefaultFixtures _fixtures;

        public CalculadoraJurosCompostoTest(DefaultFixtures fixtures)
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
        [InlineData(100, 5)]
        [InlineData(100, 10)]
        [InlineData(1100, 10)]
        [InlineData(1100, 5)]
        public async Task CalcularTaxaJurosCompostoEmLista(decimal valorInicial, int numeroMeses)
        {
            var valorFinalComJuros = await _fixtures.CalculadoraJurosService.CalculaJurosAsync(
                new CalculadoraJurosValorInicial(valorInicial),
                new CalculadoraJurosMeses(numeroMeses));

            var taxaJuros = await _fixtures.TaxaJurosAPIWebService.ObterTaxaJuros();

            var valorEsperado = CalculaJurosComposto(valorInicial, numeroMeses, taxaJuros.ToDecimal()).ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

            Assert.Equal(valorFinalComJuros.ToString(), valorEsperado);
        }

        private double CalculaJurosComposto(decimal valorInicial, int numeroMeses, decimal taxaJuros)
        {
            double taxaJurosFator = Convert.ToDouble(1 + taxaJuros);
            double jurosCompostoAoMes = Math.Pow(taxaJurosFator, numeroMeses);
            double valorFinal = (double)valorInicial * jurosCompostoAoMes;
            return valorFinal;
        }
    }
}
