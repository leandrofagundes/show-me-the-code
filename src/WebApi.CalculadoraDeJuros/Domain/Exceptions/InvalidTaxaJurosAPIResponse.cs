using System;

namespace WebApi.CalculadoraDeJuros.Domain.Exceptions
{
    public class InvalidTaxaJurosAPIResponse
        : Exception
    {
        public InvalidTaxaJurosAPIResponse(string message) : base(message)
        {
        }
    }
}
