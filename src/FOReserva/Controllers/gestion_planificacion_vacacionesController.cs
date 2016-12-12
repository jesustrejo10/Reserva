using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Itinerario;
using System.Net;
using FOReserva.Servicio;

namespace FOReserva.Controllers
{
    public class gestion_planificacion_vacacionesController : Controller
    {
        //
        // GET: /gestion_planificacion_vacaciones/

        public ActionResult M17_gestion_itinerario_Perfil()
        {
            Cvista_Itinerario model = new Cvista_Itinerario();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult buscarDestino(Cvista_Itinerario model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCiudadIdOrigen;
            int sel2 = model.SelectedCiudadIdDestino;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

    }
}
