using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Perfil()
        {

            return View("Perfil");
        }

    }
}
