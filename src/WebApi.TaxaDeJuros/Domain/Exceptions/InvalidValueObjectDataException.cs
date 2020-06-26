using System;

namespace WebApi.TaxaDeJuros.Domain.Exceptions
{
    public class InvalidValueObjectDataException
        : Exception
    {
        public object Value { get; }
        public InvalidValueObjectDataException(string message, object value) : base(message)
        {
            this.Value = value;
        }
    }
}
