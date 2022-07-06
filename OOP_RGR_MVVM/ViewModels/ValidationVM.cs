using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Rules;
using OOP_RGR_MVVM.Validation;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_RGR_MVVM.ViewModels
{
    internal abstract class ValidationVM : NotificationObject, IDataErrorInfo/*, IHasPropertiesRules*/
    {
        protected abstract Dictionary<string, List<Rule>> PropertiesRules { get; }

        public readonly PropertiesValidator Validator;
        public Dictionary<string, string?> PropertyErrorCollection => Validator.GetPropertiesErrors();

        public ValidationVM()
        {
            Validator = new(this);
            Validator.AddPropertiesWithRules(PropertiesRules);
        }

        public string? this[string propertyName]
        {
            get
            {
                Validator.Validate(propertyName);
                OnPropertyChanged(nameof(PropertyErrorCollection));

                return Validator.GetPropertyErrors(propertyName);
            }
        }

        string? IDataErrorInfo.Error => null;
    }
}
