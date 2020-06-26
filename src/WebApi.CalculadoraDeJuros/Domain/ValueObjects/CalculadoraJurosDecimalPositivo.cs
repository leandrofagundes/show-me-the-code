using System;
using System.Globalization;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;

namespace WebApi.CalculadoraDeJuros.Domain.ValueObjects
{
    public readonly struct CalculadoraJurosDecimalPositivo : IEquatable<CalculadoraJurosDecimalPositivo>
    {
        private readonly decimal _value;
        private static CultureInfo _cultureInfoBrasil = CultureInfo.GetCultureInfo("pt-BR");

        public CalculadoraJurosDecimalPositivo(double value)
        {
            if (value < 0)
                throw new InvalidValueObjectDataException("Valor não pode ser negativo.", value);

            try
            {
                var decimalValue = Convert.ToDecimal(value);
                _value = decimalValue;
            }
            catch (Exception)
            {
                throw new InvalidValueObjectDataException("Valor informado não um decimal válido", value);
            }
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

        public bool Equals(CalculadoraJurosDecimalPositivo other)
        {
            return this._value == other._value;
        }

        public static bool operator ==(CalculadoraJurosDecimalPositivo obj1, CalculadoraJurosDecimalPositivo obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null)
                return false;
            else if (obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(CalculadoraJurosDecimalPositivo obj1, CalculadoraJurosDecimalPositivo obj2)
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
