using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Cruceros;
using FOReserva.Servicio;


namespace FOReserva.Controllers
{
    public class gestion_reserva_cruceroController : Controller
    {
        //
        // GET: /gestion_reserva_crucero/

        public ActionResult gestion_reserva_crucero()
        {
            CVista_Cruceros model = null;
            try { 
            model = new CVista_Cruceros();
            return PartialView(model);
            }
            catch (NullReferenceException e)
            {

                return PartialView(model);
            }
            catch (ManejadorSQLException f)
            {

                return View("gestion_reserva_crucero_error_conexion");
            }
            catch (Exception g)
            {
              
                return PartialView(model);
            }
           }

        public ActionResult gestion_reserva_cruceroImagenes()
        {
            return PartialView();
        }
        public ActionResult gestion_reserva_crucero_confirmar(string id_crucero, string id_origen, string id_destino, string id_inicio, string id_fin, string pasajeros_num, string fk_ruta, string fk_crucero)
        {
            CReserva_Cruceros reserva = new CReserva_Cruceros(id_crucero, id_origen, id_destino, fk_crucero, id_inicio, id_fin, pasajeros_num, fk_ruta);
            manejadorSQLCrucero manejador = new manejadorSQLCrucero();
            try
            {

                manejador.CrearReserva(reserva);
                return View();
            }
            catch (NullReferenceException e)
            {

                return View();
            }
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            catch (Exception g)
            {

            }
            return View();

        }
        public ActionResult gestion_reserva_crucero_perfil()
        {
            List<CReserva_Cruceros> lista = null;
            manejadorSQLCrucero manejador = new manejadorSQLCrucero();
         
            lista = manejador.buscarReservasCruceros();
            return PartialView(lista);
           
        }
        public ActionResult gestion_reserva_crucero_buscar_crucero()
        {


            string crucero = Request.Form["SelectedCrucero"].ToString();
            string fechaida = Request.Form["_ida"].ToString();
            string fechavuelta = Request.Form["_vuelta"].ToString();
            try {
                List<CReserva_Cruceros> Model = busqueda(crucero, fechaida, fechavuelta);
                 return View(Model);
            }
              catch (NullReferenceException e)
            {
                List<CReserva_Cruceros> Model = null;
                return View(Model);
            }
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            catch (Exception g)
            {
                List<CReserva_Cruceros> Model = null;
                return View(Model);
            }
        }


        

        private List<CReserva_Cruceros> busqueda(string numcrucero, string fechaIda, string fechaVuelta)
        {
            List<CReserva_Cruceros> lista = null;
            var manejador = new manejadorSQLCrucero();
     
            lista = manejador.buscarItinerarios(numcrucero, fechaIda, fechaVuelta);
            Console.WriteLine("Hola Mundo");
            return lista;
          
            
        }
        

        public ActionResult gestion_reserva_crucero_resultado_crucero(string id_crucero, string id_origen, string id_destino, string id_inicio, string id_fin, string fk_ruta, string fk_crucero)
        {
             try{
            CReserva_Cruceros reserva = new CReserva_Cruceros(fk_crucero, id_origen, id_destino, id_crucero, id_inicio, id_fin, fk_ruta);
            return View(reserva);
             }
              catch (NullReferenceException e)
            {
                CReserva_Cruceros reserva = null;
                return View(reserva);
            }
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            
        }
        
        [HttpPost]
        public JsonResult buscarCruceros(CVista_Cruceros model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCrucero;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        public ActionResult crearReservaCrucero( string fecha, int cantidadPasajeros, int usuario, int crucero, int ruta, string fkfecha, string estatus)
        {
            CReserva_Cruceros reserva = new CReserva_Cruceros(fecha, cantidadPasajeros, usuario, crucero, ruta, fkfecha, estatus);

            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.CrearReserva(reserva);
                return View(reserva);
            }
            catch (ManejadorSQLException e)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            catch (InvalidManejadorSQLException f)
            {
                reserva = null;
                return View(reserva);
            }
            catch (Exception e)
            {
                reserva = null;
                return View(reserva);
            }
        }

        /*
         * Metodo para la eliminacion de la reserva
         */
        [System.Web.Services.WebMethod]
        public JsonResult eliminarReservaCrucero(int id)
        {
            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.eliminarReserva(id);
            }
            catch (ManejadorSQLException e)
            {

                return null;
            }
            catch (InvalidManejadorSQLException e)
            {
                return null;
            }
            catch (Exception e)
            {
             
            }
            return Json("exito");
        }

        public JsonResult modificarReservaCrucero(string id_reserva, string cant_pasajero, string estatus)
        {
         

            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.modificarReserva(id_reserva, cant_pasajero, estatus);
            }
            catch (ManejadorSQLException e)
            {
               
                return null;
            }
            catch (InvalidManejadorSQLException e)
            {
               
            }
            catch (Exception e)
            {
             
                return null;
            }

            return Json("exito");

        }

        /* Metodo que devuelve todas las reservas del usuario */

}
    }

