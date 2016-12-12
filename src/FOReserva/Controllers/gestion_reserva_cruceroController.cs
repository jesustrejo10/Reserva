using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Cruceros;
using FOReserva.Servicio;


namespace FOReserva.Controllers
{
    public class gestion_reserva_cruceroController : Controller
    {
        //
        // GET: /gestion_reserva_crucero/

        public ActionResult gestion_reserva_crucero()
        {
            CVista_Cruceros model = new CVista_Cruceros();
            return PartialView(model);
        }

        public ActionResult gestion_reserva_cruceroImagenes()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult buscarCruceros(CVista_Cruceros model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCrucero;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

    }
}
