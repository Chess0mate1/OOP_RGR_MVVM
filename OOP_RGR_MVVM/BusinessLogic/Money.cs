using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.BusinessLogic
{
    internal class Money 
    {
        #region Fields
        private decimal _value;
        #endregion

        #region Constructors
        public Money() { }
        public Money(decimal value)
        {
            _value = ToMoneyFormat(value);
        }
        #endregion

        #region Methods
        #region Operator overloads
        #region Arithmetic operators
        public static Money operator +(Money amount1, Money amount2)
        {
            return new (amount1._value + amount2._value);
        }
        public static Money? operator -(Money amount1, Money amount2)
        {
            if (amount1 < amount2)
                return null;

            return new (amount1._value - amount2._value);
        }
        public static Money operator ++(Money amount)
        {
            return new(amount._value++);
        }
        public static Money? operator --(Money amount)
        {
            if (amount._value is 0)
                return null;

            return new(amount._value--);
        }
        #endregion

        #region Comparison operators
        public static bool operator >=(Money amount1, Money amount2)
        {
            return amount1._value >= amount2._value;
        }
        public static bool operator <(Money amount1, Money amount2)
        {
            return !(amount1 >= amount2);
        }
        public static bool operator <=(Money amount1, Money amount2)
        {
            return amount1._value <= amount2._value;
        }
        public static bool operator >(Money amount1, Money amount2)
        {
            return !(amount1 <= amount2);
        }

        public static bool operator ==(Money amount1, Money amount2)
        {
            return amount1._value <= amount2._value;
        }
        public static bool operator !=(Money amount1, Money amount2)
        {
            return !(amount1 == amount2);
        }
        public override bool Equals(object? obj)
        {
            if (obj as Money is null)
                return false;

            if (((Money)obj)._value == _value)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        #endregion
        #endregion

        #region Converters
        public override string ToString()
        {
            return _value.ToString();
        }

        private decimal ToMoneyFormat(decimal value)
        {
            return Math.Round(value, 2);
        }
        #endregion
        #endregion
    }
}
