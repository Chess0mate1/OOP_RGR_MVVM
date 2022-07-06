using Microsoft.Win32;

using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Extentions;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class PaymentVM : NotificationObject
    {
        private int _paymentPrice = 0;
        private RemovedProductsSender _removedProductSender;
        private ObservableCollection<ProductVM> _productVMs = new();
        private RelayCommand? _payCommand;

        public int PaymentPrice 
        {
            get => _paymentPrice;
            private set
            {
                _paymentPrice = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsPaymentPriceVisible));
            }
        }
        public bool IsPaymentPriceVisible
            => PaymentPrice is 0 ? false : true;
        public RelayCommand PayCommand =>
            _payCommand ??= new RelayCommand(Pay, IsPaymentEnable);

        public PaymentVM(PaymentPriceSender paymentPriceSender, RemovedProductsSender removedProductSender)
        {
            paymentPriceSender.PaymentPriceUpdated += OnPaymentPriceUpdated;
            _removedProductSender = removedProductSender;
        }

        private void OnPaymentPriceUpdated(CartProductsVM productsVM)
        {
            int paymentPrice = 0;

            _productVMs = productsVM.Products;
            foreach (var product in _productVMs)
            {
                paymentPrice += product.Price * product.SelectedCount;
            }

            PaymentPrice = paymentPrice;
        }
        private void Pay(object parameter)
        {
            PaymentPrice = 0;

            foreach (var product in _productVMs)
            {
                product.Count -= product.SelectedCount; 
                product.SelectedCount = 0;
            }

            _removedProductSender.UpdateRemovedProduct(_productVMs
                                                        .Where(product => product.Count is 0)
                                                        .ToList());
            _productVMs.RemoveRange(product => product.SelectedCount is 0);
        }
        private bool IsPaymentEnable(object parameter)
        {
            return PaymentPrice is not 0;
        }
    }
}
