using WebApi.CalculadoraDeJuros.Domain.Exceptions;
using WebApi.CalculadoraDeJuros.Domain.ValueObjects;
using Xunit;

namespace WebApi.CalculadoraDeJuros.Tests.UnitTests
{
    public class CalculadoraJurosMesesTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(9)]
        public void CalculadoraJurosDecimalPositivoComSucesso(int valor)
        {
            var jurosMeses = new CalculadoraJurosMeses(valor);
            var valorEsperado = valor;

            Assert.Equal(valorEsperado, jurosMeses.ToInt());
            Assert.Equal(valorEsperado.ToString(), jurosMeses.ToString());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-5)]
        [InlineData(-9)]
        public void CalculadoraJurosDecimalPositivoComErro(int valor)
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new CalculadoraJurosMeses(valor));
        }

        [Fact]
        public void CalculadoraJurosDecimalPositivoComArithmeticOverFlow()
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new CalculadoraJurosMeses(unchecked((int)2147483648)));
        }
    }
}
