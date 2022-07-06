using OOP_RGR_MVVM.Rules;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Validation
{
    internal abstract class ValidationObject : IHasPropertiesRules
    {
        protected PropertiesValidator _validator;

        public abstract Dictionary<string, List<Rule>> PropertiesRules { get; }

        public ValidationObject()
        {
            _validator = new(this, PropertiesRules, ValidatorExceptionMode.FirstException);
        }
    }
}
