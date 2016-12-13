using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.ReservaBoleto;

namespace FOReserva.Controllers
{
    public class gestion_vuelosController : Controller
    {
   
        public ActionResult gestion_vuelos()
        {
            CBuscarVuelo model = new CBuscarVuelo();
            return PartialView(model);
        }

        public ActionResult gestion_vuelosImagenes()
        {
            return PartialView();
        }

        //[HttpPost]
        //public JsonResult buscarVuelos(CBuscarVuelo model)
        //{
        //    String fecha_ida = model._ida;
        //    String fecha_vuelta = model._vuelta;
        //    int sel = model.SelectedCiudadIdOrigen;
        //    int sel2 = model.SelectedCiudadIdDestino;

        //    return (Json(true, JsonRequestBehavior.AllowGet));

        //}

    }
}
