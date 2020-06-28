using System.Globalization;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using Xunit;

namespace WebApi.CalculadoraDeJuros.Tests.UnitTests
{
    public class CalculadoraJurosValorInicialTests
    {
        [Theory]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        [InlineData(100)]
        [InlineData(100.1)]
        [InlineData(100.2)]
        [InlineData(100.5)]
        [InlineData(100.9)]
        public void CalculadoraJurosValorInicialComSucesso(decimal valor)
        {
            var decimalPositivo = new CalculadoraJurosValorInicial(valor);
            var valorEsperado = valor;

            var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");

            Assert.Equal(valorEsperado, decimalPositivo.ToDecimal());
            Assert.Equal(valorEsperado.ToString("0.00", cultureInfo), decimalPositivo.ToString());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(-0.2)]
        [InlineData(-0.5)]
        [InlineData(-0.9)]
        [InlineData(-100)]
        [InlineData(-100.1)]
        [InlineData(-100.2)]
        [InlineData(-100.5)]
        [InlineData(-100.9)]
        public void CalculadoraJurosValorInicialComErro(decimal valor)
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new CalculadoraJurosValorInicial(valor));
        }
    }
}
