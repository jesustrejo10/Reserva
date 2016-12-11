using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Autos;
using System.Net;
using FOReserva.Servicio;

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
            
            DateTime fechaini = model.fechaini;
            DateTime fechafin = model.fechafin;
            int sel = model.SelectedCiudadIdOrigen;
            int sel2 = model.SelectedCiudadIdDestino;

            //Console.WriteLine(prueba);
            
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        //[HttpPost]
        public JsonResult InsertarReservaCarro(CAgregarReserva model)
        {

            if (model.raut_automovil == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error= "Error, campo obligatorio vacio";
                return Json(error);          
            }
            ManejadorSQLReservaAutomovil sql = new ManejadorSQLReservaAutomovil();
            bool resultado = sql.InsertarReservaAuto(model);

            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error2 = "Error insertando en la BD";
                return Json(error2); 
            
            
            }
      
        }


    }
}
