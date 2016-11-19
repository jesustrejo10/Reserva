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

        public ActionResult M02_AgregarAvion()
        {
            CAgregarAvion model = new CAgregarAvion();
            return PartialView(model);
        }


        [HttpPost]
        public JsonResult guardarAvion(CAgregarAvion model)
        {
            String prueba = model._matriculaAvion;

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        /*Metodo para consultar la matricula de un avion para sus estadisticas*/
        [HttpPost]
        public JsonResult consultarEstadisticasAvion(CGestion_avion model)
        {
            String prueba = model._matriculaConsultarEstadisticaAvion;
            return (Json(true, JsonRequestBehavior.AllowGet));
            
        }




    }
}
