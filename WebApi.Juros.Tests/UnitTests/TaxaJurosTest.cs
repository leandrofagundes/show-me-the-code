using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WebApi.Juros.Controllers;
using WebApi.Juros.Domain.Exceptions;
using WebApi.Juros.Domain.ValueObjects;
using Xunit;

namespace WebApi.Juros.Tests.UnitTests
{
    public class TaxaJurosTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        [InlineData(100)]
        [InlineData(100.1)]
        [InlineData(100.2)]
        [InlineData(100.5)]
        [InlineData(100.9)]
        public void CriarTaxaJurosComSucesso(decimal valor)
        {
            var taxaJuros = new TaxaJuros(valor);
            var valorEsperado = (decimal)valor;


            var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");

            Assert.Equal(valorEsperado, taxaJuros.ToDecimal());
            Assert.Equal(valorEsperado.ToString("0.00", cultureInfo), taxaJuros.ToString());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(0.2)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        [InlineData(100)]
        [InlineData(100.1)]
        [InlineData(100.2)]
        [InlineData(100.5)]
        [InlineData(100.9)]
        public void CriarTaxaJurosDeDoubleComSucesso(double valor)
        {
            var taxaJuros = new TaxaJuros(valor);
            var valorEsperado = (decimal)valor;


            var cultureInfo = CultureInfo.GetCultureInfo("pt-BR");

            Assert.Equal(valorEsperado, taxaJuros.ToDecimal());
            Assert.Equal(valorEsperado.ToString("0.00", cultureInfo), taxaJuros.ToString());
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(-0.2)]
        [InlineData(-0.5)]
        [InlineData(-0.9)]
        [InlineData(-100)]
        [InlineData(-100.1)]
        [InlineData(-100.2)]
        [InlineData(-100.5)]
        [InlineData(-100.9)]
        public void CriarTaxaJurosComErro(decimal valor)
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new TaxaJuros(valor));
        }

        [Fact]
        public void CriarTaxaJurosComArithmeticOverFlow()
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new TaxaJuros(79228162514264337593543950336.1));
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(-0.2)]
        [InlineData(-0.5)]
        [InlineData(-0.9)]
        [InlineData(-100)]
        [InlineData(-100.1)]
        [InlineData(-100.2)]
        [InlineData(-100.5)]
        [InlineData(-100.9)]
        public void CriarTaxaJurosDeDoubleComErro(double valor)
        {
            Assert.Throws<InvalidValueObjectDataException>(() => new TaxaJuros(valor));
        }
    }
}
