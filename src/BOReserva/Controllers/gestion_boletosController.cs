using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_boletos;

namespace BOReserva.Controllers
{
    public class gestion_boletosController : Controller
    {

        public ActionResult M05_CrearBoleto()
        {
            /*//instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            List<string> resultado = sql.buscarCiudades();*/
            CBuscarVuelo model = new CBuscarVuelo();
            //model._ciudadDestinoList = resultado;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult buscarVuelos(CBuscarVuelo model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCiudadIdOrigen;
            int sel2 = model.SelectedCiudadIdDestino;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        public ActionResult M05_VerVuelos()
        {
            return PartialView();
        }

        public ActionResult M05_DetalleVuelo()
        {
            return PartialView();
        }

        public ActionResult M05_DatosUsuario()
        {
            return PartialView();
        }
        public ActionResult M05_DetalleBoleto()
        {
            return PartialView();
        }


    }
}
