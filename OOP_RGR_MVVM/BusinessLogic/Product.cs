using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Rules;
using OOP_RGR_MVVM.Validation;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_RGR_MVVM.BusinessLogic
{
    internal class Product : ValidationObject
    {
        private int _id;
        private string _image;
        private string _name;
        private int _price;
        private int _count;

        public int Id 
        {
            get => _id;
            set
            {
                _id = value;
                _validator.Validate(nameof(Id));
            }
        }
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                _validator.Validate(nameof(Image));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _validator.Validate(nameof(Name));
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                _validator.Validate(nameof(Price));
            }
        }
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                _validator.Validate(nameof(Count));
            }
        }
        public override Dictionary<string, List<Rule>> PropertiesRules
        {
            get
            {
                string errorMessage = "вернул null";
                string minErrorMessage = "Минимальная значение";
                int minLength = 0;

                return new()
                {
                    [nameof(Id)] = new()
                    {
                        new MinIntValueRule(0, $"{minErrorMessage} {Id}: {minLength}")
                    },
                    [nameof(Price)] = new()
                    {
                        new MinIntValueRule(0, $"{minErrorMessage} {Price}: {minLength}")
                    },
                    [nameof(Count)] = new()
                    {
                        new MinIntValueRule(0, $"{minErrorMessage} {Count}: {minLength}")
                    },
                    [nameof(Name)] = new()
                    {
                        new NotNullableRule($"{nameof(Name)} {errorMessage}")
                    },
                    [nameof(Image)] = new()
                    {
                        new NotNullableRule($"{nameof(Image)} {errorMessage}")
                    },
                };
            }
        }
    }
}
