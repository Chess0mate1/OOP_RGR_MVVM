using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class MainVM : NotificationObject
    {
        private Store _store { get; set; } = new();

        public ObservableCollection<CustomerVM> Customers { get; set; } = new();

        public LogInVM LogInVM { get; set; } = new();
        public LogOutVM LogOutVM { get; set; } = new();
        public RegistrationVM RegistrationVM { get; set; } = new();

        public ProductTypeSelectionVM ActiveProductTypeSelectionVM { get; set; } = new();
        public StoreProductsVM ActiveStoreProductsVM { get; set; }
        public CartProductsVM ActiveCartProductsVM { get; set; }
        public PaymentVM ActivePaymentVM { get; set; }

        public MainVM()
        {
            //RegistrationVM.LoginInfoCreated += OnLoginInfoCreated;

            ProductToCartSender productSender = new();
            PaymentPriceSender paymentPriceSender = new();
            RemovedProductsSender removedProductSender = new();

            ActiveStoreProductsVM = new(productSender, removedProductSender);
            ActiveCartProductsVM = new(productSender, paymentPriceSender, removedProductSender);
            ActivePaymentVM = new(paymentPriceSender, removedProductSender);
        }

        //public void OnLoginInfoCreated(LoginInfo loginInfo)
        //{
        //    //Customer customer = new()
        //    //{
        //    //    Id = 0, LoginInfo = loginInfo
        //    //};

        //    //ProductToCartSender productSender = new();
        //    //PaymentPriceSender paymentPriceSender = new();
        //    //RemovedProductsSender removedProductSender = new();

        //    //ActiveStoreProductsVM = new(productSender, removedProductSender);
        //    //ActiveCartProductsVM = new(productSender, paymentPriceSender, removedProductSender);
        //    //ActivePaymentVM = new(paymentPriceSender, removedProductSender);
        //}

        //private void OnPaymentMade()
        //{

        //}
    }
}
