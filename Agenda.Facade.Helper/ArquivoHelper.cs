using Agenda.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Agenda.Facade.Helper
{
    public static class ArquivoHelper
    {
        public static void GravarContato(string arquivo)
        {
            string directoryName = "C:\\AgendaEdenred";
            string fileName = "contatos.json";
            string path = Path.Combine(directoryName, fileName);

            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            File.WriteAllText(path, arquivo);
        }

        public static string LerContato()
        {
            string directoryName = "C:\\AgendaEdenred";
            string fileName = "contatos.json";
            string path = Path.Combine(directoryName, fileName);
            string arquivo = string.Empty;

            if (!Directory.Exists(directoryName))
            {
                return string.Empty;
            }

            if (!File.Exists(path))
            {
                return string.Empty;
            }
            else
            {
                arquivo = File.ReadAllText(path);
            }

            return arquivo;
        }
    }
}
