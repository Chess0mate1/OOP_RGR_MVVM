using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal class MaxIntValueRule : UpdatableRule
    {
        private int _max;

        public MaxIntValueRule(/*ref*/ int max, string message)
            : base(message)
        {
            _max = max;
        }

        public override bool IsValid(object value)
        {
            return value is int intValue && intValue <= _max;
        }

        public override void UpdateComparingValue(dynamic value)
        {
            _max = value;
        }
    }
}
