
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal class MinStringLengthRule : Rule
    {
        private int _minLength;

        public MinStringLengthRule(int minLength, string message) 
            : base(message)
        {
            _minLength = minLength;
        }

        public override bool IsValid(object value)
        {
            return value is string @string && @string.Length >= _minLength;
        }
    }
}
