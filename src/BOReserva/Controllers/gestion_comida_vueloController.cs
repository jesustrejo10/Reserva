using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_comida_vuelo;

namespace BOReserva.Controllers
{
    public class gestion_comida_vueloController : Controller
    {
        // GET: /gestion_comida_vuelo/
        public ActionResult M06_AgregarComida()
        {
            CAgregarComida model = new CAgregarComida();
            return PartialView(model);
        }

        public ActionResult M06_AgregarPorVuelo()
        {
           return PartialView();
        }

        public ActionResult M06_EditarComida()
        {
            return PartialView();
        }

       
	}
}