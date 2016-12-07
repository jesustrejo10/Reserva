using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Autos;

namespace FOReserva.Controllers
{
    public class gestion_reserva_autoController : Controller
    {
        //
        // GET: /gestion_reserva_autos/

        public ActionResult M19_Reserva_Autos()
        {
            Cvista_ReservaAutos model = new Cvista_ReservaAutos();
            return PartialView(model);
        }

        public ActionResult M19_Reserva_AutosImagenes()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult buscarCarro(Cvista_ReservaAutos model)
        {
            String prueba = model._prueba;
            Console.WriteLine(prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }


    }
}
