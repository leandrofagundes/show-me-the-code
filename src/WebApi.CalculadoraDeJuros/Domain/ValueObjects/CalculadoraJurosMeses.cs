using System;
using WebApi.CalculadoraDeJuros.Domain.Exceptions;

namespace WebApi.CalculadoraDeJuros.Domain.ValueObjects
{
    public readonly struct CalculadoraJurosMeses : IEquatable<CalculadoraJurosMeses>
    {
        private readonly int _value;
        public CalculadoraJurosMeses(int value)
        {
            if (value <= 0)
                throw new InvalidValueObjectDataException("Número de meses para cálculo de juros não pode ser menor ou igual a zero.", value);

            _value = value;
        }

        public override string ToString()
        {
            return this._value.ToString();
        }

        public int ToInt()
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

        public bool Equals(CalculadoraJurosMeses other)
        {
            return this._value == other._value;
        }

        public static bool operator ==(CalculadoraJurosMeses obj1, CalculadoraJurosMeses obj2)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null)
                return false;
            else if (obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }

        public static bool operator !=(CalculadoraJurosMeses obj1, CalculadoraJurosMeses obj2)
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
