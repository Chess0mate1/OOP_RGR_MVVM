using OOP_RGR_MVVM.Rules;
using OOP_RGR_MVVM.Validation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.BusinessLogic
{
    internal class Customer : ValidationObject
    {
        private int _id;
        private LoginInfo _loginInfo;
        //private decimal _cash;

        private List<Product> _cartProducts = new();

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                _validator.Validate(nameof(Id));
            }
        }
        public LoginInfo LoginInfo 
        {
            get => _loginInfo;
            set
            {
                _loginInfo = value;
                _validator.Validate(nameof(LoginInfo));
            }
        }
        //public decimal Cash
        //{
        //    get => _cash;
        //    set
        //    {
        //        _cash = value;
        //        _validator.Validate(nameof(Cash));
        //    }
        ////}

        public void AddProducts(Product product)
        {
            _cartProducts.Add(product);
        }
        public void RemoveProducts(Product product)
        {
            _cartProducts.Remove(product);
        }
        public List<Product> CartProducts => _cartProducts;
        public int CartProductsCount => _cartProducts.Count;
        public override Dictionary<string, List<Rule>> PropertiesRules 
        {
            get
            {
                string minErrorMessage = "Минимальная значение";
                int minLength = 0;

                return new()
                {
                    [nameof(Id)] = new()
                    {
                        new MinIntValueRule(minLength, $"{nameof(Id)} {minErrorMessage}")
                    },
                    [nameof(LoginInfo)] = new()
                    {
                        new NotNullableRule($"{nameof(LoginInfo)} {minErrorMessage}")
                    },
                    //[nameof(Cash)] = new()
                    //{
                    //    new MinIntValueRule(minLength, $"{nameof(Cash)} вернул null")
                    //}
                };
            }
        }

        public Customer() { }
        public Customer(int id, LoginInfo loginInfo)
        {
            Id = id;
            LoginInfo = loginInfo;

            _validator.ValidateAll();
        }

        //public void Pay(decimal cash)
        //{
        //    if (Cash < cash)
        //        throw new Exception($"Not enoth cash!\nYou have {Cash}\nNeed {cash}");

        //    Cash -= cash;
        //}
    }
}
