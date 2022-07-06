using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Notification.Senders
{
    internal class ProductToCartSender
    {
        public event Action<ProductVM>? ProductInCartUpdated;

        public void UpdateProductInCart(ProductVM productVM)
        {
            ProductInCartUpdated?.Invoke(productVM);
        }
    }
}
