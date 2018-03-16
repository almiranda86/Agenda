using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Model
{
    public sealed class ContatoModel
    {
        public long IdContato { get; set; }
        public string Nome { get; set; }
        public string EmailPessoal { get; set; }
        public string EmailTrabalho { get; set; }
        public string TelefonePessoal { get; set; }
        public string TelefoneTrabalho { get; set; }
        public string Endereco { get; set; }
        public string Empresa { get; set; }
    }
}
