using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal class MinIntValueRule : UpdatableRule
    {
        private int _min;

        public MinIntValueRule(/*ref*/ int min, string message)
            : base(message)
        {
            _min = min;
        }

        public override bool IsValid(object value)
        {
            return value is int intValue && intValue >= _min;
        }

        public override void UpdateComparingValue(dynamic value)
        {
            _min = value;
        }
    }
}
