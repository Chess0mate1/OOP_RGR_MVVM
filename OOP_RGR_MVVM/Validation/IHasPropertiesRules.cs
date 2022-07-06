using OOP_RGR_MVVM.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Validation
{
    internal interface IHasPropertiesRules
    {
        Dictionary<string, List<Rule>> PropertiesRules { get; }
    }
}
