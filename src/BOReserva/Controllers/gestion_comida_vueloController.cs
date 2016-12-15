using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_comida_vuelo;
using System.Net;
using BOReserva.Servicio;

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
        [HttpPost]
        public JsonResult guardarPlato(CAgregarComida model)
        {
            string nombrePlato = model._nombrePlato;
            string descripcionPlato = model._descripcionPlato;
            return(Json(true, JsonRequestBehavior.AllowGet));
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