using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Cruceros;

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

        public JsonResult buscarCrucero(CVista_Cruceros model)
        {
            String prueba = model._prueba;
            DateTime fechaida = model._fechaIda;
            DateTime fechavuelta = model._fechaVuelta;

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

    }
}
