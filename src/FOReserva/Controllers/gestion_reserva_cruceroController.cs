using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Cruceros;
using FOReserva.Servicio;
using FOReserva.Controllers.PatronComando;
using FOReserva.Controllers;
using FOReserva.DataAccess.Domain;


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
            catch (NullReferenceException)
            {

                return PartialView(model);
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException )
            {

                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
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
            //CReserva_Cruceros reserva = new CReserva_Cruceros(id_crucero, id_origen, id_destino, fk_crucero, id_inicio, id_fin, pasajeros_num, fk_ruta);
            System.Diagnostics.Debug.WriteLine("Se recibio "+id_crucero,id_origen,id_destino, id_inicio,id_fin,pasajeros_num,fk_ruta,fk_crucero);
            DateTime fechaIni = DateTime.Parse(id_inicio);
            int pasaj = Int32.Parse(pasajeros_num);
            int cruc = Int32.Parse(fk_crucero);
            int ruta = Int32.Parse(fk_ruta);
            try
            {
                Entidad e = FabricaEntidad.InstanciarReservaCrucero(pasaj, 1, cruc, ruta, fechaIni, "activo");
                Command<String> comando = FabricaComando.crearM22AgregarReserva(e);
                String respuesta = comando.ejecutar();
            
                return View();
                


            }
            ///Se atrapa las Exception de Tipo NullReference
            catch (NullReferenceException )
            {

                return View();
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException )
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
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
            Command<Dictionary<int, Entidad>> comando = (Command<Dictionary<int, Entidad>>)FabricaComando.crearM22BuscarCrucerosPerfil();
            Dictionary<int, Entidad> listaReserva = comando.ejecutar();
            // CReserva_Cruceros reserva;
            //System.Diagnostics.Debug.WriteLine("holaa");
            //manejadorSQLCrucero manejador = new manejadorSQLCrucero();
         
            //lista = manejador.buscarReservasCruceros();
            return PartialView(listaReserva);
           
        }
        /**
* Metodo Gestion Reserva Crucero Buscar Crucero
* Este metodo realiza la consulta en la base de datos de los cruceros que son solicitados por el cliente
* 
* **/
        public ActionResult gestion_reserva_crucero_buscar_crucero()
        {

            CruceroPerfil cru=null;
            string crucero = Request.Form["SelectedCrucero"].ToString();
            string fechaida = Request.Form["_ida"].ToString();
            string fechavuelta = Request.Form["_vuelta"].ToString();
            ///Se instancia un try para la consulta a la base de datos
            try {
                List<Entidad> Model = busqueda(crucero, fechaida, fechavuelta);
                /*foreach (var item in Model)
                {
                    cru = (CruceroPerfil)item;
                }*/
                return View(Model);
            }
            ///Se atrapa las Exception de Tipo NullReference
              catch (NullReferenceException )
            {
                List<Entidad> Model = null;
                return View(Model);
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException )
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
            {
                List<Entidad> Model = null;
                return View(Model);
            }
        }


        /**
* Metodo para llenar la Lista que sera retornada para la vista parcial
* Este metodo realiza la consulta en la base de datos de los cruceros que son solicitados por el cliente
* 
* **/

        public List<Entidad> busqueda(string numcrucero, string fechaIda, string fechaVuelta)
        {
            List<Entidad> lista = null;
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.crearM22BuscarItinerarios(numcrucero, fechaIda, fechaVuelta);
            lista = comando.ejecutar();
            //var manejador = new manejadorSQLCrucero();
     
            //lista = manejador.buscarItinerarios(numcrucero, fechaIda, fechaVuelta);
            Console.WriteLine("Hola Mundo");
            return lista;
          
            
        }
        /**
* Metodo para la Gestion de  Reserva de  Crucero-Resultado
* Este metodo pasa de la ventana  Gestion de  Reserva de  Crucero-Buscar Resultado a la ventana Gestion de  Reserva de  Crucero-Resultado
* 
* **/

        public ActionResult gestion_reserva_crucero_resultado_crucero(string id_crucero, string id_origen, string id_destino, string id_inicio, string id_fin, string fk_ruta, int fk_crucero)
        {
            ///Se instancia un try para la consulta a la base de datos
             try{
                 System.Diagnostics.Debug.WriteLine("en resultado con "+fk_crucero+id_origen+id_destino+id_inicio+id_fin+fk_ruta+fk_crucero);
            CruceroPerfil reserva = new CruceroPerfil(fk_crucero, id_crucero, id_inicio, id_fin, id_origen, id_destino, fk_ruta);
            return View(reserva);
             }
             ///Se atrapa las Exception de Tipo NullReference
              catch (NullReferenceException )
            {
                CruceroPerfil reserva = null;
                return View(reserva);
            }
             ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (ManejadorSQLException )
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

            DateTime fechaIni = DateTime.Parse(fecha);
            CruceroPerfil reserva = new CruceroPerfil(fecha, cantidadPasajeros, usuario, crucero, ruta, fkfecha, estatus);
            System.Diagnostics.Debug.WriteLine("");
            ///Se instancia un try para la consulta a la base de datos
            try
            {
                Entidad e = FabricaEntidad.InstanciarReservaCrucero(cantidadPasajeros, 1, crucero, ruta, fechaIni, "activo");
                Command<String> comando = FabricaComando.crearM22AgregarReserva(e);
                String respuesta = comando.ejecutar();

                //manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                //manejador.CrearReserva(reserva);
                return View(reserva);
            }
            ///Se atrapa las Exception de Tipo NullReference
            catch (ManejadorSQLException )
            {
                return View("gestion_reserva_crucero_error_conexion");
            }
            ///Se atrapa las Exception de Tipo ManejadorSQL Exception
            catch (InvalidManejadorSQLException )
            {
                reserva = null;
                return View(reserva);
            }
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
            {
                reserva = null;
                return View(reserva);
            }
        }

        /*
         * Metodo para la eliminacion de la reserva de Crucero
         */
        public JsonResult eliminarReserva(int id_reserva)
        {///Se instancia un try para la consulta a la base de datos
            try
            {
                Command<String> comando = FabricaComando.crearM22EliminarReservaCruceros(id_reserva);
                String respuesta = comando.ejecutar();
                System.Diagnostics.Debug.WriteLine("en controller con id " + id_reserva);
                //manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                //manejador.eliminarReservaCrucero(id_reserva);
            }
          
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
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
                //manejadorSQLCrucero manejador = new manejadorSQLCrucero();
                //manejador.modificarReserva(id_reserva, cant_pasajero, estatus);
                
                Command<Entidad> comando = FabricaComando.crearM22ModificarReservaCrucero(id_reserva, cant_pasajero, estatus);
                Entidad respuesta = comando.ejecutar();
            }
            
            ///Se atrapa las Exception de Tipo Exception
            catch (Exception )
            {
             
                return null;
            }

            return Json("exito");

        }

       }
    }

