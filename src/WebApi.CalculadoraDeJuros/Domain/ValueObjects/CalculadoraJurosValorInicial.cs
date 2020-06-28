using System;
using System.Globalization;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;

namespace WebApi.CalculadoraDeJuros.Domain.ValueObjects
{
    public readonly struct CalculadoraJurosValorInicial : IEquatable<CalculadoraJurosValorInicial>
    {
        private readonly decimal _value;
        public CalculadoraJurosValorInicial(decimal value)
        {
            if (value <= 0)
                throw new InvalidValueObjectDataException("Valor inicial não pode ser menor ou igual a zero.", value);

            _value = value;
        }

        public override string ToString()
        {
            return this._value.ToString("0.00", CultureInfo.GetCultureInfo("pt-BR"));
        }

        public decimal ToDecimal()
        {
            return this._value;
        }

        public double ToDouble()
        {
            return Convert.ToDouble(this._value);
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

        public bool Equals(CalculadoraJurosValorInicial other)
        {
            return this._value == other._value;
        }

        public static bool operator ==(CalculadoraJurosValorInicial obj1, CalculadoraJurosValorInicial obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null)
                return false;
            else if (obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(CalculadoraJurosValorInicial obj1, CalculadoraJurosValorInicial obj2)
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
