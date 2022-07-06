using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Commands;
using OOP_RGR_MVVM.Notification;
using OOP_RGR_MVVM.Extentions;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OOP_RGR_MVVM.Factory;
using OOP_RGR_MVVM.Notification.Senders;

namespace OOP_RGR_MVVM.ViewModels
{
    internal class StoreProductsVM : ProductsBaseVM
    {
        public StoreProductsVM(ProductToCartSender sender, RemovedProductsSender removedProductsSender)
            : base(sender, removedProductsSender) 
        {
            ProductVMsCreator creator = new();
            Products.AddRange(creator.Create());
        }
    }
}
