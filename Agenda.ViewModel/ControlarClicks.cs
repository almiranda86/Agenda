using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agenda.ViewModel
{
    public sealed class ControlarClicks : ICommand
    {
        private Action _metodo;

        public ControlarClicks(Action metodo_)
        {
            _metodo = metodo_;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _metodo();
        }
    }
}
