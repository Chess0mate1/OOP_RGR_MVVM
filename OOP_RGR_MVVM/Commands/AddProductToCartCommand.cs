using OOP_RGR_MVVM.Notification.Senders;
using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Commands
{
    internal class AddProductToCartCommand : ChangeProductCountInCartCommand
    {
        protected override int RangeLimit => _currentProductVM.Count;


        public AddProductToCartCommand(ProductsBaseVM productsVM, ProductToCartSender sender)
            : base(productsVM, sender) { }

        protected override void ChangeSelectedCount()
        {
            _currentProductVM.SelectedCount++;
        }
    }
}
