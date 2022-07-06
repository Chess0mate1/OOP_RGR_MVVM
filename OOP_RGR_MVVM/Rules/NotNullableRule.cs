using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal class NotNullableRule : Rule
    {
        public NotNullableRule(string message)
            : base(message) { }

        public override bool IsValid(object value) => value is not null;
    }
}
