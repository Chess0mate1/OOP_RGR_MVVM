using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Factory;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class CartProductsVM : ProductsBaseVM
    {
        private PaymentPriceSender _paymentPriceSender;

        public CartProductsVM(ProductToCartSender productSender, PaymentPriceSender paymentPriceSender, RemovedProductsSender removedProductsSender)
            : base(productSender, removedProductsSender) 
        {
            productSender.ProductInCartUpdated += OnProductChangedInCart;
            _paymentPriceSender = paymentPriceSender;
        }

        private void OnProductChangedInCart(ProductVM transferedProductVM)
        {
            var productVMToUpdate = TryGetSelectedProductInCart();

            if (NeedToAddToCart())
            {
                Products.Add(transferedProductVM);
            }
            else if (NeedToRemoveFromCart())
            {
                Products.Remove(productVMToUpdate);
            }

            UpdatePaymentPrice();

            ProductVM? TryGetSelectedProductInCart()
            {
                return Products
                      .Where(product => product.Id == transferedProductVM.Id)
                      .SingleOrDefault();
            }
            bool NeedToAddToCart() => productVMToUpdate is null;
            bool NeedToRemoveFromCart() => transferedProductVM.SelectedCount is 0;
        }

        private void UpdatePaymentPrice()
        {
            _paymentPriceSender.UpdatePaymentPrice(this);
        }
    }
}
