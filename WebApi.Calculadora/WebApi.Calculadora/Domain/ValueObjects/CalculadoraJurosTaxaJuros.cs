using System;
using System.Globalization;
using WebApi.Calculadora.Domain.Exceptions;

namespace WebApi.Calculadora.Domain.ValueObjects
{
    public readonly struct CalculadoraJurosTaxaJuros : IEquatable<CalculadoraJurosTaxaJuros>
    {
        private readonly decimal _value;
        private static CultureInfo _cultureInfoBrasil = CultureInfo.GetCultureInfo("pt-BR");

        public CalculadoraJurosTaxaJuros(string value)
        {
            if (!decimal.TryParse(value, NumberStyles.AllowDecimalPoint, _cultureInfoBrasil, out decimal taxaJuros))
                throw new InvalidValueObjectDataException("Taxa de juros não é um decimal válido.", value);
            _value = taxaJuros;
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

        public bool Equals(CalculadoraJurosTaxaJuros other)
        {
            return this._value == other._value;
        }

        public static bool operator ==(CalculadoraJurosTaxaJuros obj1, CalculadoraJurosTaxaJuros obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null)
                return false;
            else if (obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(CalculadoraJurosTaxaJuros obj1, CalculadoraJurosTaxaJuros obj2)
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
