using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP_RGR_MVVM.Commands
{
    internal class RelayCommand : CommandBase
    {
        private Action<object>? _onExecute;
        private Func<object, bool>? _canExecute;

        public RelayCommand(Action<object> onExecute, Func<object, bool>? canExecute = null)
        {
            _onExecute = onExecute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter = null)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object? parameter = null)
        {
            _onExecute?.Invoke(parameter);
        }
    }
}
