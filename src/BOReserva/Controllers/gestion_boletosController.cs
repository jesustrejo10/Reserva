using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_boletos;

namespace BOReserva.Controllers
{
    public class gestion_boletosController : Controller
    {

        public ActionResult M05_CrearBoleto()
        {
            CBuscarVuelo model = new CBuscarVuelo();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult buscarVuelos(CBuscarVuelo model)
        {
            bool prueba = model._ida;
            bool prueba2 = model._idaVuelta;
            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        public ActionResult M05_VerVuelos()
        {
            return PartialView();
        }

        public ActionResult M05_DetalleVuelo()
        {
            return PartialView();
        }

        public ActionResult M05_DatosUsuario()
        {
            return PartialView();
        }
        public ActionResult M05_DetalleBoleto()
        {
            return PartialView();
        }


    }
}
