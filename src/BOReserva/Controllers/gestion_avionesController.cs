using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_aviones;
namespace BOReserva.Controllers
{
    public class gestion_avionesController : Controller
    {
        //
        // GET: /gestion_aviones/

        public ActionResult M02_GestionAviones()
        {
            CGestion_avion model = new CGestion_avion();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult guardarAvion(CGestion_avion model)
        {
            String prueba = model._matriculaAvionAgregar;

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult consultarEstadisticasAvion(CGestion_avion model)
        {
            String prueba = model._matriculaConsultarEstadisticaAvion;
            return (Json(true, JsonRequestBehavior.AllowGet));
        }




    }
}
