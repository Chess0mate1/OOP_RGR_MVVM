using OOP_RGR_MVVM.Rules;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_RGR_MVVM.Validation
{
    public enum ValidatorExceptionMode
    {
        NoException,
        FirstException,
        AllExceptions
    }

    internal class PropertiesValidator/*: Notification.NotificationObject*/
    {
        private readonly dynamic _objectToValidate;
        private Dictionary<string, List<Rule>> PropertiesRulesCollection = new();
        private Dictionary<string, string?> PropertyErrorCollection = new();
        private readonly ValidatorExceptionMode _exceptionMode;


        public PropertiesValidator(
            dynamic objectToValidate,
            Dictionary<string, List<Rule>> propertiesRules = null,
            ValidatorExceptionMode exceptionMode = ValidatorExceptionMode.NoException
        ){
            if (objectToValidate is null)
                throw new ArgumentNullException(nameof(objectToValidate));

            _objectToValidate = objectToValidate;

            PropertiesRulesCollection = propertiesRules is not null ? propertiesRules : PropertiesRulesCollection;

            _exceptionMode = exceptionMode;
        }
        //public void AddPropertyWithRules(string propertyName, List<Rule> rules)
        //{
        //    if (PropertiesRulesCollection.ContainsKey(propertyName))
        //        PropertiesRulesCollection[propertyName].AddRange(rules);
        //    else
        //        PropertiesRulesCollection.Add(propertyName, rules);
        //}
        //public void AddPropertyWithRule(string propertyName, Rule rule)
        //{
        //    if (PropertiesRulesCollection.ContainsKey(propertyName))
        //        PropertiesRulesCollection[propertyName].Add(rule);
        //    else
        //        PropertiesRulesCollection.Add(propertyName, new() { rule });
        //}
        public void AddPropertiesWithRules(Dictionary<string, List<Rule>> propertiesRules)
        {
            foreach (var element in propertiesRules)
            {
                if (PropertiesRulesCollection.ContainsKey(element.Key))
                    PropertiesRulesCollection[element.Key].AddRange(element.Value);
                else
                    PropertiesRulesCollection.Add(element.Key, element.Value);            }
        }
        //public void UpdatePropertyRule<T>(string propertyName, T ruleType, dynamic updatedParameter)
        //    where T : Type
        //{
        //    int ruleIndex = 0;

        //    foreach (var propertyRules in PropertiesRulesCollection)
        //    {
        //        foreach (var rule in propertyRules.Value)
        //        {
        //            MessageBox.Show($"{rule.GetType()} {typeof(T)}");
        //            if (rule.GetType() == typeof(T))
        //            {
        //                ruleIndex = PropertiesRulesCollection[propertyName].IndexOf(rule);
        //                ((UpdatableRule)PropertiesRulesCollection[propertyName][ruleIndex]).UpdateComparingValue(updatedParameter);
        //            }
        //        }
        //    }
        //}
        public void UpdatePropertyRule(string propertyName, Rule newRule)
        {
            int ruleIndex = 0;

            foreach (var propertyRules in PropertiesRulesCollection)
                foreach (var rule in propertyRules.Value)
                    if (rule.GetType() == newRule.GetType())
                        ruleIndex = PropertiesRulesCollection[propertyName].IndexOf(rule);

            PropertiesRulesCollection[propertyName][ruleIndex] = newRule;
        }

        public string GetPropertyErrors(string propertyName)
            => PropertyErrorCollection[propertyName];

        public Dictionary<string, string?> GetPropertiesErrors()
            => PropertyErrorCollection;

        public bool IsPropertyValid(object propertyName)
        {
            if (propertyName is not null && propertyName is string)
                return PropertyErrorCollection[(string)propertyName] is null;

            return false;
        }

        public bool AreAllPropertiesValid(object? parameter = null)
            => PropertyErrorCollection.Values.Any(x => x != null) is false;

        public string GetFullErrorMessage()
        {
            string fullErrorMessage = "";

            foreach (var propertyRule in PropertyErrorCollection)
            {
                if (propertyRule.Value is not null)
                {
                    fullErrorMessage += $"\n{propertyRule.Value}";
                }
            }

            return fullErrorMessage.TrimEnd('\n');
        }

        public void Validate(string propertyName)
        {
            //foreach (var prop in PropertiesRulesCollection)
            //    foreach (var p in prop.Value)
            //        MessageBox.Show($"{prop.Key} {p.Message}");
            CheckInvalidPropertyName();

            if (TryFindErrorRules(out List<Rule>? errorRules))
            {
                string propertyErrorMessage = GetFullProperyErrorsMessage(errorRules);

                CheckForExceptionSubs(propertyErrorMessage);
                PropertyErrorCollection[propertyName] = propertyErrorMessage;
            }
            else
            {
                PropertyErrorCollection[propertyName] = null;
            }

            void CheckInvalidPropertyName()
            {
                if (PropertiesRulesCollection.Keys.Contains(propertyName) is false)
                    throw new FormatException(propertyName);
            }
            bool TryFindErrorRules(out List<Rule>? foundedRules)
            {
                foundedRules = new();

                foreach (Rule rule in PropertiesRulesCollection[propertyName])
                    if (rule.IsValid(_objectToValidate.GetType().GetProperty(propertyName).GetValue(_objectToValidate)) is false)
                        foundedRules.Add(rule);

                if (foundedRules.Any())
                    return true;
                else
                    return false;
            }
            string GetFullProperyErrorsMessage(List<Rule>? errorRules)
            {
                string fullErrorMessage = "";

                foreach (var rule in errorRules)
                    fullErrorMessage += $"{rule.Message}\n";

                return fullErrorMessage.TrimEnd('\n');
            }
            void CheckForExceptionSubs(string propertyErrorMessage)
            {
                OnExceptionFound(propertyErrorMessage, ExceptionFoundPlace.FirstException);
            }
        }
        public void ValidateAll()
        {
            foreach (string propertyName in PropertiesRulesCollection.Keys)
                Validate(propertyName);

            OnExceptionFound(GetFullErrorMessage(), ExceptionFoundPlace.AllExceptions);

            string GetFullErrorMessage()
            {
                string fullErrorMessage = "";

                foreach (var propertyRule in PropertyErrorCollection)
                    if (propertyRule.Value is not null)
                        fullErrorMessage += $"\n{propertyRule.Value}";

                return fullErrorMessage.TrimEnd('\n');
            }
        }
        private void OnExceptionFound(string errorMessage, ExceptionFoundPlace place)
        {
            switch (_exceptionMode, place, errorMessage)
            {
                case (ValidatorExceptionMode.FirstException, ExceptionFoundPlace.FirstException, not ""):
                case (ValidatorExceptionMode.AllExceptions, ExceptionFoundPlace.AllExceptions, not ""):
                    throw new Exception(errorMessage);
                default:
                    break;
            }
        }

        private enum ExceptionFoundPlace
        {
            FirstException,
            AllExceptions
        }
    }
}
