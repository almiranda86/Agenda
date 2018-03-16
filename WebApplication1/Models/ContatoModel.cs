using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContatoModel
    {

        public long IdContato { get; set; }

        [DisplayName("Nome Contato")]
        public string Nome { get; set; }

        [DisplayName("E-mail Pessoal")]
        public string EmailPessoal { get; set; }

        [DisplayName("E-mail Trabalho")]
        public string EmailTrabalho { get; set; }

        [DisplayName("Telefone Pessoal")]
        public string TelefonePessoal { get; set; }

        [DisplayName("Telefone Trabalho")]
        public string TelefoneTrabalho { get; set; }

        [DisplayName("Endereço Contato")]
        public string Endereco { get; set; }

        [DisplayName("Empresa Contato")]
        public string Empresa { get; set; }
    }


    public class PesquisaModel : ContatoModel
    {
        public List<ContatoModel> listaContatos { get; set; }
    }
}