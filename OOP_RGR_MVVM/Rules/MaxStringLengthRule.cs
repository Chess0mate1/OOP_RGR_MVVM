using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal class MaxStringLengthRule : Rule
    {
        private readonly int _maxLength;

        public MaxStringLengthRule(int maxLength, string message)
            : base(message)
        {
            _maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            return value is string @string && @string.Length <= _maxLength;
            //    throw new FormatException($"value - {value} is not int");
        }
    }
}
