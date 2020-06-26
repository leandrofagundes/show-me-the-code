using System;
using System.Globalization;
using WebApi.Juros.Domain.Exceptions;

namespace WebApi.Juros.Domain.ValueObjects
{
    public readonly struct TaxaJuros : IEquatable<TaxaJuros>
    {
        private readonly decimal _value;
        private static CultureInfo _cultureInfoBrasil = CultureInfo.GetCultureInfo("pt-BR");

        public TaxaJuros(double value)
        {
            if (value < 0)
                throw new InvalidValueObjectDataException("Taxa de Juros não pode ser negativa.", value);

            try
            {
                var decimalValue = Convert.ToDecimal(value);
                _value = decimalValue;
            }
            catch (Exception)
            {
                throw new InvalidValueObjectDataException("Taxa de Juros não é um decimal válido", value);
            }
        }

        public TaxaJuros(decimal value)
        {
            if (value < 0)
                throw new InvalidValueObjectDataException("Taxa de Juros não pode ser negativa.", value);

            _value = value;
        }

        public override string ToString()
        {
            return this._value.ToString("0.00", _cultureInfoBrasil);
        }

        public decimal ToDecimal()
        {
            return this._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(TaxaJuros other)
        {
            return this._value == other._value;
        }

        public static bool operator ==(TaxaJuros obj1, TaxaJuros obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null)
                return false;
            else if (obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(TaxaJuros obj1, TaxaJuros obj2)
        {
            if (obj1 == null && obj2 == null)
                return false;
            else if (obj1 == null)
                return true;
            else if (obj2 == null)
                return true;

            return !obj1.Equals(obj2);
        }
    }
}
