using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Rules;
using OOP_RGR_MVVM.Validation;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace OOP_RGR_MVVM.ViewModels
{
    delegate void CustomerRegisteredEventHandler(LoginInfo loginInfo);

    internal class RegistrationVM : ValidationVM
    {
        private LoginInfo _loginInfo = new();

        private string _newEmail = "";
        private string _newPassword = "";
        private string _newNickName = "";

        private RelayCommand? _registerCommand;

        public string NewEmail
        {
            get => _newEmail;
            set
            {
                _newEmail = value;
                OnPropertyChanged();
            }
        }
        public string NewPassword
        {
            get => _newPassword;
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }
        public string NewNickName
        {
            get => _newNickName;
            set
            {
                _newNickName = value;
                OnPropertyChanged();
            }
        }
        protected override Dictionary<string, List<Rule>> PropertiesRules
        {
            get
            {
                int minEmailLength = 6;
                int minPasswordLength = 4;
                int minNickNameLength = minPasswordLength;

                string minStringErrorMessage = "Минимальная длина";

                return new()
                {
                    [nameof(NewEmail)] = new(_loginInfo.PropertiesRules[nameof(LoginInfo.Email)])
                    {
                        new MinStringLengthRule(minEmailLength, $"{minStringErrorMessage} {minEmailLength}")
                    },
                    [nameof(NewPassword)] = new(_loginInfo.PropertiesRules[nameof(LoginInfo.Password)])
                    {
                        new MinStringLengthRule(minPasswordLength, $"{minStringErrorMessage} {minPasswordLength}")
                    },
                    [nameof(NewNickName)] = new(_loginInfo.PropertiesRules[nameof(LoginInfo.NickName)])
                    {
                        new MinStringLengthRule(minNickNameLength, $"{minStringErrorMessage} {minNickNameLength}")
                    },
                };
            }
        }

        public RelayCommand RegisterCommand
            => _registerCommand ??= new RelayCommand(Register, Validator.AreAllPropertiesValid);

        public event Action<LoginInfo>? LoginInfoCreated;

        private void Register(object parameter)
        {
            _loginInfo = new(NewEmail, NewPassword, NewNickName);

            MessageBox.Show($"NickName: {_loginInfo.NickName}\n" +
                $"Email: {_loginInfo.Email}\n" +
                $"Password: {_loginInfo.Password}\n");

            LoginInfoCreated?.Invoke(_loginInfo);

            ResetEneteredData();



            void ResetEneteredData()
            {
                NewEmail = "";
                NewPassword = "";
                NewNickName = "";
            }
        }
    }
}
