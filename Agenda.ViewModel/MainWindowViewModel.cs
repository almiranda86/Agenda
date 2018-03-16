using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agenda.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ClickPesquisar = new ControlarClicks(Pesquisar);
            ClickNovo = new ControlarClicks(Novo);
        }

        public ICommand ClickPesquisar { get; set; }
        public ICommand ClickNovo { get; set; }
        public void Novo()
        {
            
        }

        public void Pesquisar()
        {

        }
    }
}
