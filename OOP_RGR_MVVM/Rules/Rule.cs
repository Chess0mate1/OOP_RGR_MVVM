using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Rules
{
    internal abstract class Rule
    {
        protected string _message;

        public virtual string Message
        {
            get => _message;
            protected set
            {
                _message = value;
            }
        }

        public Rule(string message)
        {
            if (message is null)
                ValidateOnNullInputs(message);

            _message = message;
        }

        public abstract bool IsValid(object value);

        private void ValidateOnNullInputs(string input)
        {   
            if (input is null) 
                throw new ArgumentNullException(nameof(input));            
        }   
    }
}
