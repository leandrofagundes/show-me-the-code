using System.Globalization;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using Xunit;

namespace WebApi.CalculadoraDeJuros.Tests.UnitTests
{
    public class CalculadoraJurosTaxaJurosTests
    {
        [Theory]
        [InlineData("0")]
        [InlineData("0,1")]
        [InlineData("0,2")]
        [InlineData("0,5")]
        [InlineData("0,9")]
        [InlineData("100")]
        [InlineData("100,1")]
        [InlineData("100,2")]
        [InlineData("100,5")]
        [InlineData("100,9")]
        public void CalculadoraJurosTaxaJurosComSucesso(string valor)
        {
            var decimalPositivo = new CalculadoraJurosTaxaJuros(valor);
            var valorEsperado = decimal.Parse(valor);

            var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");

            Assert.Equal(valorEsperado, decimalPositivo.ToDecimal());
            Assert.Equal(valorEsperado.ToString("0.00", cultureInfo), decimalPositivo.ToString());
        }

        [Theory]
        [InlineData("-0,1")]
        [InlineData("-0,2")]
        [InlineData("-0.5")]
        [InlineData("-0.9")]
        [InlineData("-100")]
        [InlineData("-100.1")]
        [InlineData("-100.2")]
        [InlineData("-100.5")]
        [InlineData("-100.9")]
        [InlineData("abcde")]
        public void CalculadoraJurosDecimalPositivoComErro(string valor)
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new CalculadoraJurosTaxaJuros(valor));
        }

        [Fact]
        public void CalculadoraJurosDecimalPositivoComArithmeticOverFlow()
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new CalculadoraJurosTaxaJuros("79228162514264337593543950336.1"));
        }
    }
}
