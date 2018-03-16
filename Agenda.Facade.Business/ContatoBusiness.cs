using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Facade.Business
{
    public static class ContatoBusiness
    {
        public static bool ValidarCamposObrigatorios(ContatoModel contato_)
        {
            bool retorno = false;
            if (!string.IsNullOrWhiteSpace(contato_.Nome))
            {
                retorno = true;
            }

            if (!string.IsNullOrWhiteSpace(contato_.TelefonePessoal))
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
