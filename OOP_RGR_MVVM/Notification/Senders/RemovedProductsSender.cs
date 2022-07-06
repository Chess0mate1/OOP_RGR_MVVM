using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Notification.Senders
{
    internal class RemovedProductsSender
    {
        public event Action<List<ProductVM>>? RemovedProductsUpdated;

        public void UpdateRemovedProduct(List<ProductVM> productsVM)
        {
            RemovedProductsUpdated?.Invoke(productsVM);
        }
    }
}
