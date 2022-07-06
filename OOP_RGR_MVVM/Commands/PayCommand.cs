using OOP_RGR_MVVM.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RGR_MVVM.Commands
{
    internal class PayCommand : CommandBase
    {
        private PaymentVM _paymentVM;

        public PayCommand(PaymentVM paymentVM)
        {
            _paymentVM = paymentVM;
        }

        public override bool CanExecute(object? parameter = null)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
