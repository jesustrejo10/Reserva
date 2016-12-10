using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using FOReserva.Models.Itinerario;

namespace FOReserva.Controllers
{
    public class gestion_planificacion_vacacionesController : Controller
    {
       public ActionResult gestion_itinerario()
        {
            /*//instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            List<string> resultado = sql.buscarCiudades();*/
            CItinerario model = new CItinerario();
            //model._ciudadDestinoList = resultado;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult buscarDestino(CItinerario model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCiudadIdOrigen;
            int sel2 = model.SelectedCiudadIdDestino; 

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        //public ActionResult gestion_itinerario()
        //{
          //  return PartialView();
        //}

    }

    }

