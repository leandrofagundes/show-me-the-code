using System;
using WebApi.Calculadora.Interfaces;

namespace WebApi.Calculadora.Services
{
    internal sealed class CalculadoraJurosCompostoService
        : ICalculadoraJuros
    {
        public double CalculaJuros(decimal valorInicial, int numeroMeses, decimal taxaJuros)
        {
            double taxaJurosFator = Convert.ToDouble(1 + taxaJuros);
            double jurosCompostoAoMes = Math.Pow(taxaJurosFator, numeroMeses);
            double valorFinal = (double)valorInicial * jurosCompostoAoMes;

            return valorFinal;
        }
    }
}
