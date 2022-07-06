using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.BusinessLogic
{
    internal class Store
    {
        private Customer _activeCustomer = new();
        private List<Customer> _customers = new();
        private List<Product> _products = new();

        public Customer ActiveCustomer
        {
            get => _activeCustomer;
            set
            {
                _activeCustomer = value;
            }
        }

        public void RegistrateCustomer(Customer customer) 
        {
            _customers.Add(customer);
        }
        public List<Customer> AllCustomers => _customers;
        public int CustomersCount => _customers.Count;

        public void AddNewProducts(List<Product> products) 
        {
            _products.AddRange(products);
        }
        public List<Product> Products => _products;
        public int ProductsCount => _products.Count;
    }
}
