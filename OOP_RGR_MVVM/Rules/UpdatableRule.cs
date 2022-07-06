using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal abstract class UpdatableRule : Rule
    {
        protected UpdatableRule(string message) : base(message) { }

        public abstract void UpdateComparingValue(dynamic value);
    }
}
