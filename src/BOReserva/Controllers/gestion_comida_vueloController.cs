using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_comida_vueloController : Controller
    {
        //
        // GET: /gestion_comida_vuelo/
        public ActionResult M06_AgregarComida()
        {
            return PartialView();
        }

        public ActionResult M06_AgregarPorVuelo()
        {
           return PartialView();
        }

        public ActionResult M06_EditarComida()
        {
            return PartialView();
        }
        public ActionResult M06_ConsultarComidas()
        {
            return PartialView();
        }
	}
}