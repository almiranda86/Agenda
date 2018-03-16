using Agenda.Model;
using ContatoFacade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agenda.ViewModel.Modulos.Agenda
{
    public sealed class CadastrarContatoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CadastrarContatoViewModel()
        {
            ClickCadastrar = new ControlarClicks(Cadastrar);
            ClickLimpar = new ControlarClicks(Limpar);
        }

        private String _nome;
        public String Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Nome"));
            }
        }

        private String _emailPessoal;
        public String EmailPessoal
        {
            get { return _emailPessoal; }
            set
            {
                _emailPessoal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailPessoal"));
            }
        }

        private String _emailTrabalho;
        public String EmailTrabalho
        {
            get { return _emailTrabalho; }
            set
            {
                _emailTrabalho = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmailTrabalho"));
            }
        }

        private String _telefonePessoal;
        public String TelefonePessoal
        {
            get { return _telefonePessoal; }
            set
            {
                _telefonePessoal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TelefonePessoal"));
            }
        }


        private String _telefoneTrabalho;
        public String TelefoneTrabalho
        {
            get { return _telefoneTrabalho; }
            set
            {
                _telefoneTrabalho = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TelefoneTrabalho"));
            }
        }


        private String _empresa;
        public String Empresa
        {
            get { return _empresa; }
            set
            {
                _empresa = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Empresa"));
            }
        }


        private String _endereco;
        public String Endereco
        {
            get { return _endereco; }
            set
            {
                _endereco = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Endereco"));
            }
        }


        public ICommand ClickLimpar { get; set; }
        public ICommand ClickCadastrar { get; set; }


        public void Limpar()
        {
            Nome = String.Empty;
            EmailPessoal = String.Empty;
            EmailTrabalho = String.Empty;
            TelefonePessoal = String.Empty;
            TelefoneTrabalho = String.Empty;
            Endereco = String.Empty;
            Empresa = String.Empty;
        }


        public void Cadastrar()
        {
            var novoContato = new ContatoModel();
            novoContato.Nome = Nome;
            novoContato.TelefonePessoal = TelefonePessoal;
            novoContato.TelefoneTrabalho = TelefoneTrabalho;
            novoContato.EmailPessoal = EmailTrabalho;
            novoContato.Endereco = Endereco;
            novoContato.Empresa = Empresa;

            var facadeContato = new ContatoFacade.ContatoFacade();
            facadeContato.IniciarProcessamento(novoContato);
        }
    }
}
