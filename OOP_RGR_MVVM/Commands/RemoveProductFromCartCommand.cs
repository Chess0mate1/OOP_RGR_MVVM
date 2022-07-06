using OOP_RGR_MVVM.Notification.Senders;
using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Commands
{
    internal class RemoveProductFromCartCommand : ChangeProductCountInCartCommand
    {
        protected override int RangeLimit => 0;

        public RemoveProductFromCartCommand(ProductsBaseVM productsVM, ProductToCartSender sender)
            : base(productsVM, sender) { }

        protected override void ChangeSelectedCount()
        {
            _currentProductVM.SelectedCount--;
        }
    }
}
