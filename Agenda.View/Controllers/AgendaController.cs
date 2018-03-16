using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda.View.Controllers
{
    public class AgendaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}