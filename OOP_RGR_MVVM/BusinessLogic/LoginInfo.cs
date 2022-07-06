using OOP_RGR_MVVM.Rules;
using OOP_RGR_MVVM.Validation;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.BusinessLogic
{
    internal class LoginInfo : ValidationObject
    {
        private string _email;
        private string _password;
        private string _nickName;

        public string Email 
        {
            get => _email;
            set
            {
                _email = value;
                _validator.Validate(nameof(Email));
            } 
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                _validator.Validate(nameof(Password));
            }
        }
        public string NickName
        {
            get => _nickName;
            set
            {
                _nickName = value;
                _validator.Validate(nameof(Password));
            }
        }
        public override Dictionary<string, List<Rule>> PropertiesRules
        {
            get
            {
                string errorMessage = "вернул null";

                return new()
                {
                    [nameof(Email)] = new() 
                    { 
                        new NotNullableRule($"{nameof(Email)} {errorMessage}") 
                    },
                    [nameof(Password)] = new() 
                    { 
                        new NotNullableRule($"{nameof(Password)} {errorMessage}") 
                    },
                    [nameof(NickName)] = new() 
                    { 
                        new NotNullableRule($"{nameof(NickName)} " + $"{errorMessage}") 
                    }
                };
            }
        }

        public LoginInfo() { }
        public LoginInfo(string email, string password, string nickName)
        {
            Email = email;
            Password = password;
            NickName = nickName;

            _validator.ValidateAll();
        }
    }
}
