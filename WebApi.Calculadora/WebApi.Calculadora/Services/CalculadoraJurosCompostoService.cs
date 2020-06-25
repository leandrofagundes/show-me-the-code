using System;
using System.Threading.Tasks;
using WebApi.Calculadora.Domain.ValueObjects;
using WebApi.Calculadora.Interfaces;

namespace WebApi.Calculadora.Services
{
    public sealed class CalculadoraJurosCompostoService
        : ICalculadoraJuros
    {
        private readonly ITaxaJurosAPI _taxaJurosAPIService;

        public CalculadoraJurosCompostoService(ITaxaJurosAPI taxaJurosAPIService)
        {
            _taxaJurosAPIService = taxaJurosAPIService;
        }

        public async Task<CalculadoraJurosDecimalPositivo> CalculaJurosAsync(CalculadoraJurosValorInicial valorInicial, CalculadoraJurosMeses numeroMeses)
        {
            var taxaJuros = await _taxaJurosAPIService.ObterTaxaJuros();

            var valorFinal = CalcularValorDoJurosComposto(valorInicial.ToDouble(), numeroMeses.ToInt(), taxaJuros.ToDecimal());

            return new CalculadoraJurosDecimalPositivo(valorFinal);
        }

        private double CalcularValorDoJurosComposto(double valorInicial, int numeroMeses, decimal taxaJuros)
        {
            double taxaJurosFator = Convert.ToDouble(1 + taxaJuros);
            double jurosCompostoAoMes = Math.Pow(taxaJurosFator, numeroMeses);
            double valorFinal = valorInicial * jurosCompostoAoMes;

            return valorFinal;
        }
    }
}
