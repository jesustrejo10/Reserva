using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Cruceros;
using FOReserva.Servicio;


namespace FOReserva.Controllers
{/**
  * Clase Controlador de Gestion para la Reserva de Crucero
  * 
  * 
  * 
  * **/
    public class gestion_reserva_cruceroController : Controller
    {
        /**
  * Metodo Gestion Reserva Crucero
  * Este devuelve los cruceros en el ComboBox de la vista parcial en el index de la pestaña cruceros
  * 
  * **/
        public ActionResult gestion_reserva_crucero()
        {
            CVista_Cruceros model = null;
            ///Se instancia un try para la consulta a la base de datos
            try { 
            model = new CVista_Cruceros();
            return PartialView(model);
            }
                ///Se atrapa las Exception de Tipo NullReference
            catch (NullReferenceException e)
            {

                return PartialView(model);
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException f)
            {

                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception g)
            {
              
                return PartialView(model);
            }
           }
        /**
  * Metodo Gestion Reserva Crucero Imagenes
  * Este devuelve las imagenes  vista parcial en el index de la pestaña cruceros
  * 
  * **/
        public ActionResult gestion_reserva_cruceroImagenes()
        {
            return PartialView();
        }

        /**
 * Metodo Gestion Reserva Crucero Confirmar
 * Este devuelve si la reserva fue crea con exito
 * 
 * **/
        public ActionResult gestion_reserva_crucero_confirmar(string id_crucero, string id_origen, string id_destino, string id_inicio, string id_fin, string pasajeros_num, string fk_ruta, string fk_crucero)
        {
            CReserva_Cruceros reserva = new CReserva_Cruceros(id_crucero, id_origen, id_destino, fk_crucero, id_inicio, id_fin, pasajeros_num, fk_ruta);
            manejadorSQLCrucero manejador = new manejadorSQLCrucero();
            ///Se instancia un try para la consulta a la base de datos
            try
            {

                manejador.CrearReserva(reserva);
                return View();
            }
            ///Se atrapa las Exception de Tipo NullReference
            catch (NullReferenceException e)
            {

                return View();
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception g)
            {

            }
            return View();

        }
        /**
* Metodo Gestion Reserva Crucero Perfil
* Este metodo llena la datatable que esta contenido en la seccion Mis Cruceros en la pagina de perfil
* 
* **/
        public ActionResult gestion_reserva_crucero_perfil()
        {
            List<CReserva_Cruceros> lista = null;
            manejadorSQLCrucero manejador = new manejadorSQLCrucero();
         
            lista = manejador.buscarReservasCruceros();
            return PartialView(lista);
           
        }
        /**
* Metodo Gestion Reserva Crucero Buscar Crucero
* Este metodo realiza la consulta en la base de datos de los cruceros que son solicitados por el cliente
* 
* **/
        public ActionResult gestion_reserva_crucero_buscar_crucero()
        {


            string crucero = Request.Form["SelectedCrucero"].ToString();
            string fechaida = Request.Form["_ida"].ToString();
            string fechavuelta = Request.Form["_vuelta"].ToString();
            ///Se instancia un try para la consulta a la base de datos
            try {
                List<CReserva_Cruceros> Model = busqueda(crucero, fechaida, fechavuelta);
                 return View(Model);
            }
            ///Se atrapa las Exception de Tipo NullReference
              catch (NullReferenceException e)
            {
                List<CReserva_Cruceros> Model = null;
                return View(Model);
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception g)
            {
                List<CReserva_Cruceros> Model = null;
                return View(Model);
            }
        }


        /**
* Metodo para llenar la Lista que sera retornada para la vista parcial
* Este metodo realiza la consulta en la base de datos de los cruceros que son solicitados por el cliente
* 
* **/

        public List<CReserva_Cruceros> busqueda(string numcrucero, string fechaIda, string fechaVuelta)
        {
            List<CReserva_Cruceros> lista = null;
            var manejador = new manejadorSQLCrucero();
     
            lista = manejador.buscarItinerarios(numcrucero, fechaIda, fechaVuelta);
            Console.WriteLine("Hola Mundo");
            return lista;
          
            
        }
        /**
* Metodo para la Gestion de  Reserva de  Crucero-Resultado
* Este metodo pasa de la ventana  Gestion de  Reserva de  Crucero-Buscar Resultado a la ventana Gestion de  Reserva de  Crucero-Resultado
* 
* **/

        public ActionResult gestion_reserva_crucero_resultado_crucero(string id_crucero, string id_origen, string id_destino, string id_inicio, string id_fin, string fk_ruta, string fk_crucero)
        {
            ///Se instancia un try para la consulta a la base de datos
             try{
            CReserva_Cruceros reserva = new CReserva_Cruceros(fk_crucero, id_origen, id_destino, id_crucero, id_inicio, id_fin, fk_ruta);
            return View(reserva);
             }
             ///Se atrapa las Exception de Tipo NullReference
              catch (NullReferenceException e)
            {
                CReserva_Cruceros reserva = null;
                return View(reserva);
            }
             ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException f)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            
        }
        /**
* Metodo para la Busqueda de Cruceros
* 
* **/

        
        [HttpPost]
        public JsonResult buscarCruceros(CVista_Cruceros model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCrucero;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }
        /**
* Metodo para la Creacion de la reserva 
* 
* **/

        public ActionResult crearReservaCrucero( string fecha, int cantidadPasajeros, int usuario, int crucero, int ruta, string fkfecha, string estatus)
        {
            CReserva_Cruceros reserva = new CReserva_Cruceros(fecha, cantidadPasajeros, usuario, crucero, ruta, fkfecha, estatus);
            ///Se instancia un try para la consulta a la base de datos
            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.CrearReserva(reserva);
                return View(reserva);
            }
            ///Se atrapa las Exception de Tipo NullReference
            catch (ManejadorSQLException e)
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (InvalidManejadorSQLException f)
            {
                reserva = null;
                return View(reserva);
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception e)
            {
                reserva = null;
                return View(reserva);
            }
        }

        /*
         * Metodo para la eliminacion de la reserva de Crucero
         */
        [System.Web.Services.WebMethod]
        public JsonResult eliminarReservaCrucero(int id)
        {///Se instancia un try para la consulta a la base de datos
            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.eliminarReserva(id);
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException e)
            {

                return null;
            }
            ///Se atrapa las Exception de Tipo Invalid ManejadorSQL Exception
            catch (InvalidManejadorSQLException e)
            {
                return null;
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception e)
            {
             
            }
            return Json("exito");
        }
        /*
         * Metodo para la modificacion de la reserva de Crucero
         */
        public JsonResult modificarReservaCrucero(string id_reserva, string cant_pasajero, string estatus)
        {

            ///Se instancia un try para la consulta a la base de datos
            try
            {
                manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                manejador.modificarReserva(id_reserva, cant_pasajero, estatus);
            }
            ///Se atrapa las Exception de Tipo Invalid ManejadorSQL Exception
            catch (ManejadorSQLException e)
            {
               
                return null;
            }
            ///Se atrapa las Exception de Tipo Invalid ManejadorSQL Exception
            catch (InvalidManejadorSQLException e)
            {
               
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception e)
            {
             
                return null;
            }

            return Json("exito");

        }

}
    }

