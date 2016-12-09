using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ofertas;

namespace BOReserva.Controllers
{
    public class gestion_ofertasController : Controller
    {
        //
        // GET: /gestion_ofertas/
        public ActionResult M11_AgregarPaquete()
        {
            CAgregarPaquete model = new CAgregarPaquete();
            return PartialView();
        }

        public ActionResult M11_AgregarOferta()
        {
            return PartialView();
        }

        public ActionResult M11_ConsultarPaquete()
        {
            return PartialView();
        }

        public ActionResult M11_ConsultarOferta()
        {
            return PartialView();
        }

        public ActionResult M11_ModificarPaquete()
        {
            return PartialView();
        }

        public ActionResult M11_ModificarOferta()
        {
            return PartialView();
        }
	}
}