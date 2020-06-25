using System;
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
        public void CalcularTaxaJurosCompostoComSucesso()
        {
            var valorFinalComJuros = _fixtures.CalculadoraJurosService.CalculaJuros(100, 5, (decimal)0.01);

            var valorObtido = valorFinalComJuros.ToString("0.00",System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
            var valorEsperado = "105,10";

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(100, 5, 0.01)]
        [InlineData(100, 10, 0.01)]
        [InlineData(1100, 10, 0.01)]
        [InlineData(1100, 5, 0.01)]
        public void CalcularTaxaJurosCompostoEmLista(decimal valorInicial, int numeroMeses, decimal taxaJuros)
        {
            var valorFinalComJuros = _fixtures.CalculadoraJurosService.CalculaJuros(valorInicial, numeroMeses, taxaJuros).ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
            var valorEsperado = CalculaJurosComposto(valorInicial, numeroMeses, taxaJuros).ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));

            Assert.Equal(valorFinalComJuros, valorEsperado);
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
