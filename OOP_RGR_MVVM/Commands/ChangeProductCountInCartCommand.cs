using OOP_RGR_MVVM.BusinessLogic;
using OOP_RGR_MVVM.Notification.Senders;
using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_RGR_MVVM.Commands
{
    internal abstract class ChangeProductCountInCartCommand : CommandBase
    {
        protected ProductsBaseVM _productsVM;
        protected ProductVM? _currentProductVM;
        protected ProductToCartSender _sender;
        protected abstract int RangeLimit { get; }

        public ChangeProductCountInCartCommand(ProductsBaseVM productsVM, ProductToCartSender sender)
        {
            _productsVM = productsVM;
            _sender = sender;
        }

        public override bool CanExecute(object lastProductIdPassedByCommand)
        {
            _currentProductVM = TryGetSelectedProductVM(lastProductIdPassedByCommand);

            if (_currentProductVM is null)
                return false;

            return IsRangeLimitNotRiched();
        }

        public override void Execute(object lastProductIdPassedByCommand)
        {
            ChangeSelectedCount();          

            _sender.UpdateProductInCart(_currentProductVM);
        }

        protected abstract void ChangeSelectedCount();

        private ProductVM? TryGetSelectedProductVM(object lastProductIdPassedByCommand)
        {
            if (int.TryParse(lastProductIdPassedByCommand.ToString(), out int id))
            {
                return _productsVM.Products
                       .Where(product => product?.Id == id)
                       .SingleOrDefault();
            }

            throw new Exception("Wrong id");
        }
        private bool IsRangeLimitNotRiched()
        {
            return _currentProductVM.SelectedCount != RangeLimit;
        }
    }
}
