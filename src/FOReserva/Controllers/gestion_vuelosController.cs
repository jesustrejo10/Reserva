using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Vuelos;

namespace FOReserva.Controllers
{
    public class gestion_vuelosController : Controller
    {
        //
        // GET: /Vuelos/


        public ActionResult gestion_vuelos()
        {
            Cvista_Vuelos model = new Cvista_Vuelos();
            return PartialView(model);
        }

        public ActionResult gestion_vuelosImagenes()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult buscarVuelo(Cvista_Vuelos model)
        {
            String prueba = model._prueba;
            Console.WriteLine(prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

    }
}
