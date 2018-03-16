using Agenda.Facade.Business;
using Agenda.Facade.Helper;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoContato()
        {
            ContatoModel model = new ContatoModel();

            return PartialView("_partialNovoContato", model);
        }

        [HttpPost]
        public ActionResult ListaContatos()
        {
            ContatoModel model = new ContatoModel();

            return PartialView("_partialListarContato", model);
        }


        [HttpPost]
        public JsonResult CadastrarNovoContato(ContatoModel novoContato)
        {
            string conteudoRetorno = string.Empty;
            string codigoRetorno = string.Empty;

            var contato = Mapper.Map<ContatoModel, Agenda.Model.ContatoModel>(novoContato);

            if (ContatoBusiness.ValidarCamposObrigatorios(contato))
            {
                var arquivo = ArquivoHelper.LerContato();

                List<ContatoModel> listaContatos = null;

                if (arquivo == string.Empty)
                {
                    listaContatos = new List<ContatoModel>();
                }
                else
                {
                    listaContatos = JsonConvert.DeserializeObject<List<ContatoModel>>(arquivo);
                    if (listaContatos == null)
                    {
                        listaContatos = new List<ContatoModel>();
                    }
                }

                var id = listaContatos.Max(x => x.IdContato);

                novoContato.IdContato = id + 1;

                listaContatos.Add(novoContato);

                var arquivoLista = JsonConvert.SerializeObject(listaContatos);
                ArquivoHelper.GravarContato(arquivoLista);

                codigoRetorno = "0";
                conteudoRetorno = "Contato adicionado com Sucesso!";

            }

            return Json(new
            {
                codigo = codigoRetorno,
                conteudo = conteudoRetorno
            },
          "application/json",
          Encoding.UTF8,
          JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult ListarContatos(ContatoModel contatoPesquisa)
        {
            var listaContatos = lerContatos();
            PesquisaModel model = new PesquisaModel();

            if (String.IsNullOrEmpty(contatoPesquisa.Nome) && String.IsNullOrEmpty(contatoPesquisa.TelefonePessoal) && String.IsNullOrEmpty(contatoPesquisa.TelefoneTrabalho)
                && String.IsNullOrEmpty(contatoPesquisa.EmailPessoal) && String.IsNullOrEmpty(contatoPesquisa.EmailTrabalho))
            {
                model.listaContatos = listaContatos.OrderBy(x => x.Nome).ToList();
            }
            else
            {
                List<ContatoModel> achados = listaContatos;

                if (!String.IsNullOrEmpty(contatoPesquisa.Nome))
                {
                    achados = listaContatos.FindAll(x => x.Nome.Contains(contatoPesquisa.Nome));
                    listaContatos = achados;
                }
                else if (!String.IsNullOrEmpty(contatoPesquisa.TelefonePessoal))
                {
                    achados = listaContatos.FindAll(x => x.TelefonePessoal.Contains(contatoPesquisa.TelefonePessoal));
                    listaContatos = achados;
                }
                else if (!String.IsNullOrEmpty(contatoPesquisa.TelefoneTrabalho))
                {
                    achados = listaContatos.FindAll(x => x.TelefoneTrabalho.Contains(contatoPesquisa.TelefoneTrabalho));
                    listaContatos = achados;
                }
                else if (!String.IsNullOrEmpty(contatoPesquisa.EmailPessoal))
                {
                    achados = listaContatos.FindAll(x => x.EmailPessoal.Contains(contatoPesquisa.EmailPessoal));
                    listaContatos = achados;
                }
                else if (!String.IsNullOrEmpty(contatoPesquisa.EmailTrabalho))
                {
                    achados = listaContatos.FindAll(x => x.EmailTrabalho.Contains(contatoPesquisa.EmailTrabalho));
                    listaContatos = achados;
                }

                model.listaContatos = listaContatos.OrderBy(x=>x.Nome).ToList();
            }

            return PartialView("_partialGridListaContatos", model);
        }

        [HttpPost]
        public ActionResult EditarContato(string codContato)
        {
            var listaContatos = lerContatos();

            ContatoModel model = new ContatoModel();
            model = listaContatos.Find(x => x.IdContato == Convert.ToInt64(codContato));

            return PartialView("_partialEditarContato ", model);
        }

        [HttpPost]
        public JsonResult AtualizarContato(ContatoModel alterarContato)
        {
            string conteudoRetorno = string.Empty;
            string codigoRetorno = string.Empty;

            var listaContatos = lerContatos();

            var contato = listaContatos.Find(x => x.IdContato == alterarContato.IdContato);
            listaContatos.Remove(contato);

            listaContatos.Add(alterarContato);

            var arquivoLista = JsonConvert.SerializeObject(listaContatos);
            ArquivoHelper.GravarContato(arquivoLista);

            codigoRetorno = "0";
            conteudoRetorno = "Contato atualizado com Sucesso!";

            return Json(new
            {
                codigo = codigoRetorno,
                conteudo = conteudoRetorno
            },
          "application/json",
          Encoding.UTF8,
          JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExcluirContato(ContatoModel alterarContato)
        {
            string conteudoRetorno = string.Empty;
            string codigoRetorno = string.Empty;

            var listaContatos = lerContatos();

            var contato = listaContatos.Find(x => x.IdContato == alterarContato.IdContato);
            listaContatos.Remove(contato);

            var arquivoLista = JsonConvert.SerializeObject(listaContatos);
            ArquivoHelper.GravarContato(arquivoLista);

            codigoRetorno = "0";
            conteudoRetorno = "Contato excluido com Sucesso!";

            return Json(new
            {
                codigo = codigoRetorno,
                conteudo = conteudoRetorno
            },
          "application/json",
          Encoding.UTF8,
          JsonRequestBehavior.AllowGet);
        }

        private List<ContatoModel> lerContatos()
        {
            var arquivo = ArquivoHelper.LerContato();
            var listaContatos = JsonConvert.DeserializeObject<List<ContatoModel>>(arquivo);

            return listaContatos;
        }
    }
}