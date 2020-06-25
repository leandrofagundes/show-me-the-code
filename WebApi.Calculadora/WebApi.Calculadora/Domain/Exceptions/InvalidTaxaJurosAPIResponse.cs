using System;

namespace WebApi.Calculadora.Domain.Exceptions
{
    public class InvalidTaxaJurosAPIResponse
        : Exception
    {
        public InvalidTaxaJurosAPIResponse(string message) : base(message)
        {
        }
    }
}
