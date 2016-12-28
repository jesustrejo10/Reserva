using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;
using System.Diagnostics;
using System.Net;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase Controladora del modulo 9, Gestion de Hoteles por ciudad
    /// </summary>
    public class gestion_hotelesController : Controller
    {
        public static String _ciudad;
        public static String _pais;
        public static String sciudad;

        public static String ciudad;

        /// <summary>
        /// Método de la vista parcial M09_AgregarHotel
        /// </summary>
        /// <returns>Retorna la vista parcial M09_AgregarHotel en conjunto del Modelo de dicha vista</returns>
        public ActionResult M09_AgregarHotel()
        {
            CAgregarHotel model = new CAgregarHotel();
            return PartialView(model);
        }

        /// <summary>
        /// Método que retorna la lista de ciudades
        /// </summary>
        /// <param name="pais">Nombre del país del cual se desea conocer las ciudades disponibles</param>
        /// <returns>Retorna un ActionResult que contiene las ciudades disponibles para el país solicitado</returns>
        [HttpPost]
        public ActionResult listaciudades(String pais)
        {
            List<String> objcity = new List<String>();
            _pais = pais;
            manejadorSQL listaciudades = new manejadorSQL();
            int fk = listaciudades.MIdpaisesBD(pais);
            objcity = listaciudades.MListarciudadesBD(fk);
            ciudad = objcity.First();
            return Json(objcity);
        }

        /// <summary>
        /// Método que guarda en una variable la ciudad seleccionada
        /// </summary>
        /// <param name="_ciudad">Nombre de la ciudad a guardar</param>
        [HttpPost]
        public void getCity(String _ciudad)
        {
            ciudad = _ciudad;
        }


        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            CHotel crear = new CHotel()
            {
                _listapaises = new List<SelectListItem>(pais())
            };

            return PartialView(crear);
        }

        public ActionResult M09_GestionHoteles_ModificarHotel(int id)
        {
            CManejadorSQL_Hoteles buscarhotel = new CManejadorSQL_Hoteles();
            CHotel hot = buscarhotel.MMostrarhotelBD(id); //BUSCA EL HOTEL A MOSTRAR

            //CHotel hotel = new CHotel();
            CGestionHoteles_EditarHotel hotel = new CGestionHoteles_EditarHotel();
            hotel._id = hot._id;
            hotel._nombre = hot._nombre;
            hotel._paginaweb = hot._paginaweb;
            hotel._email = hot._email;
            hotel._canthabitaciones = hot._canthabitaciones;
            hotel._pais = hot._pais;
            hotel._ciudad = hot._ciudad;
            hotel._direccion = hot._direccion;
            hotel._estrellas = hot._estrellas;
            hotel._puntuacion = hot._puntuacion;
            hotel._disponibilidad = hot._disponibilidad;
            return PartialView(hotel);
        }

        [HttpPost]
        public JsonResult crearhotel(CHotel crear)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult editarhotel(CGestionHoteles_EditarHotel model)
        {
            Debug.WriteLine("El id del hotel es " + model._id);
            int id = model._id;
            String nombre = model._nombre;
            Debug.WriteLine("El nombre del hotel es " + model._nombre);
            String paginaweb = model._paginaweb;
            String email = model._email;
            int canthabitaciones = model._canthabitaciones;
            String pais = model._pais;
            String ciudad = model._ciudad;
            String direccion = model._direccion;
            int estrellas = model._estrellas;
            float puntuacion = model._puntuacion;
            int disponibilidad = model._disponibilidad;
            CHotel hotel = new CHotel(id, nombre, paginaweb, email, canthabitaciones, direccion, ciudad, pais, estrellas,
            puntuacion, disponibilidad);
            CManejadorSQL_Hoteles hot = new CManejadorSQL_Hoteles();
            String modifico_si_no = hot.MModificarhotelBD(hotel, nombre, paginaweb);
            //return Json(true, JsonRequestBehavior.AllowGet);
            return (Json(modifico_si_no));
        }

        /// <summary>
        /// Metodo para que el Hotel NO este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema</returns>
        [HttpPost]
        public JsonResult deshabilitarHotel(int id)
        {
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            Boolean resultado = sql.deshabilitarHotelBD(id);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

        public static List<SelectListItem> pais()
        {
            CManejadorSQL_Hoteles pais = new CManejadorSQL_Hoteles();
            List<SelectListItem> _pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();

            _pais.Add(new SelectListItem
            {
                Text = "Seleccione País",
                Value = ""
            });

            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _pais.Add(new SelectListItem
                    {
                        Text = paises[i].ToString(),
                        Value = paises[i].ToString()

                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _pais;
        }

        public ActionResult M09_GestionHoteles_Visualizar()
        {
            CManejadorSQL_Hoteles buscarhoteles = new CManejadorSQL_Hoteles();
            List<CHotel> listahoteles = buscarhoteles.MListarHotelesBD();  //AQUI SE BUSCAN TODO LOS HOTELES QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA       
            return PartialView(listahoteles);
        }

        public List<SelectListItem> ciudadalista(string pais)
        {
            Debug.WriteLine("CIUDAD A LISTA");
            List<SelectListItem> _ciudades = new List<SelectListItem>();
            CManejadorSQL_Hoteles ciudad = new CManejadorSQL_Hoteles();
            string[] ciudadesBD = ciudad.MListarciudadesBD(pais);

            _ciudades.Add(new SelectListItem
            {
                Text = "Seleccione Ciudad",
                Value = ""
            });

            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _ciudades.Add(new SelectListItem
                    {
                        Text = _ciudades[i].ToString(),
                        Value = _ciudades[i].ToString()
                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }

            return _ciudades;
        }

        [HttpPost]
        public JsonResult guardarHotel(CHotel model)
        {

            Debug.WriteLine(model._direccion);
            Debug.WriteLine(model._email);
            Debug.WriteLine(model._estrellas.ToString());
            Debug.WriteLine(model._canthabitaciones.ToString());
            Debug.WriteLine(model._paginaweb);
            Debug.WriteLine("Pais " + model._pais);
            Debug.WriteLine(model._nombre);
            Debug.WriteLine(model._ciudad);
            model._ciudad = _ciudad;
            model._pais = _pais;
            Debug.WriteLine("ciudad " + model._ciudad);

            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._canthabitaciones == 0) || (model._direccion == null) || (model._nombre == null)
                || (model._email == null) || (model._estrellas == 0) || (model._paginaweb == null) || (model._pais == null))
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campo obligatorio vacio";
                //Retorno el error
                return Json(error);
            }
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            //realizo el insert
            bool resultado = sql.insertarHotel(model);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD";
                return Json(error);
            }
        }

        /// <summary>
        /// Metodo que carga la vista para modificar el Hotel 
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> ActionResult con los datos de un Hotel </returns>
        public ActionResult ConsultarHotel(int id)
        {
            Debug.WriteLine("CONSULTAR HOTEL CONTROLLER");
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            CHotel hotel = new CHotel();
            hotel = sql.consultarHotel(id);
            Debug.WriteLine(hotel._nombre);
            CGestionHoteles_EditarHotel modelo = new CGestionHoteles_EditarHotel();
            Debug.WriteLine(modelo._nombre);
            Debug.WriteLine("MODELO EITAR HOTEL");
            return PartialView("M09_GestionHoteles_ModificarHotel", modelo);
        }

        /// Metodo para que el hotel este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema </returns>
        [HttpPost]
        public JsonResult habilitarHotel(int id)
        {
            CManejadorSQL_Hoteles sql = new CManejadorSQL_Hoteles();
            Boolean resultado = sql.activarHotelBD(id);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos";
                //Retorno el error  
                return Json(error);
            }
        }

        /// <summary>
        /// Método que guarda en una variable la ciudad seleccionada
        /// </summary>
        /// <param name="_ciudad">Nombre de la ciudad a guardar</param>
        [HttpPost]
        public void getciudad(String ciudad)
        {
            _ciudad = ciudad;
            Debug.WriteLine("DEBUG GET CIUDAD" + _ciudad);
        }

    }
}