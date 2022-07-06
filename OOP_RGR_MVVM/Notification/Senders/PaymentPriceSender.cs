using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Notification.Senders
{
    internal class PaymentPriceSender
    {
        public event Action<CartProductsVM>? PaymentPriceUpdated;

        public void UpdatePaymentPrice(CartProductsVM productVM)
        {
            PaymentPriceUpdated?.Invoke(productVM);
        }
    }
}
