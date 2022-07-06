using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Extentions;
using OOP_RGR_MVVM.Factory;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Notification.Senders;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.ViewModels
{
    internal abstract class ProductsBaseVM : NotificationObject
    {
        public ObservableCollection<ProductVM> Products { get; set; } = new();

        public ProductsBaseVM(ProductToCartSender sender, RemovedProductsSender removedProductsSender)
        {
            AddProductToCartCommand = new(this, sender);
            RemoveProductFromCartCommand = new(this, sender);

            removedProductsSender.RemovedProductsUpdated += OnProductsRemoved;
        }

        public AddProductToCartCommand AddProductToCartCommand { get; set; }
        public RemoveProductFromCartCommand RemoveProductFromCartCommand { get; set; }

        private void OnProductsRemoved(List<ProductVM> product_VMs)
        {
            Products.RemoveRange(product => product.Count is 0);
        }
    }
}
