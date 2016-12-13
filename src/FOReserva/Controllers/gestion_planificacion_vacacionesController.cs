using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Itinerario;


namespace FOReserva.Controllers
{
    public class gestion_planificacion_vacacionesController : Controller
    {
        //
        // GET: /gestion_itinerario/

        public ActionResult gestion_itinerario()
        {
            //itinerario model = new itinerario();
            return PartialView(/*model*/);
        }

    }
}
