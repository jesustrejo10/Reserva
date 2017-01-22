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
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.Excepciones.M09;
using System.Data.SqlClient;

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
        private static int idhotel;

        /// <summary>
        /// Método de la vista parcial M09_AgregarHotel
        /// </summary>
        /// <returns>Retorna la vista parcial M09_AgregarHotel en conjunto del Modelo de dicha vista</returns>
        public ActionResult M09_AgregarHotel()
        {
            CAgregarHotel model = new CAgregarHotel();
            Command<Dictionary<int,Entidad>> comando = FabricaComando.crearM09ObtenerPaises();
            model._paises = comando.ejecutar();

            //Aca puedo devolver
            return PartialView(model);
        }



        /// <summary>
        /// Método que guarda en una variable la ciudad seleccionada
        /// </summary>
        /// <param name="_ciudad">Nombre de la ciudad a guardar</param>
        [HttpPost]
        public void getCity(String _ciudad)
        {
            //Aca se debe llamar a un comando
            ciudad = _ciudad;
        }

        /// <summary>
        /// Método que se utiliza para guardar un Hotel ingresado
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M09_AgregarHotel</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult guardarHotel(CAgregarHotel model)
        {
            try
            {
                Entidad ciudadDestino = FabricaEntidad.InstanciarCiudad(ciudad);
                M09_COObtenerPaises command = (M09_COObtenerPaises)FabricaComando.crearM09ObtenerPaises();
                ciudadDestino._id = command.obtenerIdentificadorCiudad(ciudad);
                Entidad nuevoHotel = FabricaEntidad.InstanciarHotel(model, ciudadDestino);
                //con la fabrica instancie al hotel.
                Command<String> comando = FabricaComando.crearM09AgregarHotel(nuevoHotel, model._precioHabitacion);
                String agrego_si_no = comando.ejecutar();
                return (Json(agrego_si_no));
            }
            catch (ReservaExceptionM09 ex){
                return (Json(ex.Mensaje));
            }
        }


        /// <summary>
        /// Método de la vista parcial M09_VisualizarHoteles
        /// </summary>
        /// <returns>Retorna la vista parcial M09_VisualizarHoteles en conjunto del Modelo de dicha vista</returns>
        public ActionResult M09_VisualizarHoteles()
        {
            try
            {
                Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM09VisualizarHoteles();
                Dictionary<int, Entidad> listaHoteles = comando.ejecutar();
                return PartialView(listaHoteles);
            }
            catch (ReservaExceptionM09 ex)
            {
                return PartialView(ex);
            }
        }

        /// <summary>
        /// Método de la vista parcial M09_DetalleHotel
        /// </summary>
        /// <returns>Retorna la vista parcial M09_DetalleHotel en conjunto del Modelo de dicha vista</returns>
        public ActionResult M09_DetalleHotel(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM09ConsultarHotel(id);
                Entidad hotel = comando.ejecutar();
                Hotel hotelbuscado = (Hotel)hotel;
                idhotel = hotelbuscado._id;
                CVerHotel modelovista = new CVerHotel();
                modelovista._capacidadHabitacion = hotelbuscado._capacidad;
                modelovista._ciudad = hotelbuscado._ciudad._nombre;
                modelovista._clasificacion = hotelbuscado._clasificacion;
                modelovista._direccion = hotelbuscado._direccion;
                modelovista._email = hotelbuscado._email;
                modelovista._nombre = hotelbuscado._nombre;
                modelovista._paginaWeb = hotelbuscado._paginaWeb;
                modelovista._pais = hotelbuscado._ciudad._pais._nombre;
                modelovista._precioHabitacion = hotelbuscado._precio;
                return PartialView(modelovista);
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Content("<script>alert('" + ex.Mensaje + "');</script>"));
            }
        }



        /// <summary>
        /// Método de la vista parcial M09_ModificarHotel
        /// </summary>
        /// <returns>Retorna la vista parcial M09_ModificarHotel en conjunto del Modelo de dicha vista</returns>
        public ActionResult M09_ModificarHotel(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM09ConsultarHotel(id);
                Entidad hotel = comando.ejecutar();
                Hotel hotelbuscado = (Hotel)hotel;
                idhotel = hotelbuscado._id;
                CModificarHotel modelovista = new CModificarHotel();
                modelovista._capacidadHabitacion = hotelbuscado._capacidad;
                modelovista._ciudad = hotelbuscado._ciudad._nombre;
                modelovista._clasificacion = hotelbuscado._clasificacion;
                modelovista._direccion = hotelbuscado._direccion;
                modelovista._email = hotelbuscado._email;
                modelovista._nombre = hotelbuscado._nombre;
                modelovista._paginaWeb = hotelbuscado._paginaWeb;
                modelovista._pais = hotelbuscado._ciudad._pais._nombre;
                modelovista._precioHabitacion = hotelbuscado._precio;
                return PartialView(modelovista);
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Content("<script>alert('" + ex.Mensaje + "');</script>"));
            }
        }



        /// <summary>
        /// Método que se utiliza para modificar un hotel
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M09_ModificarHotel</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modificarHotel(CModificarHotel model)
        {
            try
            {
                Entidad ciudadDestino = FabricaEntidad.InstanciarCiudad("nombre");
                ciudadDestino._id = 29;
                Entidad modificarHotel = FabricaEntidad.InstanciarHotel(model, ciudadDestino);
                //con la fabrica instancie al hotel.
                Command<String> comando = FabricaComando.crearM09ModificarHotel(modificarHotel, idhotel);
                String agrego_si_no = comando.ejecutar();

                return (Json(agrego_si_no));
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }


        /// <summary>
        /// Método que se utiliza para eliminar un hotel existente
        /// </summary>
        /// <param name="id">Identificador del hotel a eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult deleteHotel(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM09ConsultarHotel(id);
                Entidad hotel = comando.ejecutar();
                Hotel hotelbuscado = (Hotel)hotel;
                hotelbuscado._id = id;
                Command<String> comando1 = FabricaComando.crearM09EliminarHotel(hotelbuscado, id);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }


        /// <summary>
        /// Método que se utiliza para cambiar la disponibilidad de un hotel existente
        /// </summary>
        /// <param name="id">Identificador del hotel a cambiar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult activateHotel(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM09ConsultarHotel(id);
                Entidad hotel = comando.ejecutar();
                Hotel hotelbuscado = (Hotel)hotel;
                hotelbuscado._id = id;
                Command<String> comando1 = FabricaComando.crearM09DisponibilidadHotel(hotelbuscado, 1);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }


        /// <summary>
        /// Método que se utiliza para cambiar la disponibilidad de un hotel existente
        /// </summary>
        /// <param name="id">Identificador del hotel a cambiar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult deactivateHotel(int id)
        {
            try
            {
                Command<Entidad> comando = FabricaComando.crearM09ConsultarHotel(id);
                Entidad hotel = comando.ejecutar();
                Hotel hotelbuscado = (Hotel)hotel;
                hotelbuscado._id = id;
                Command<String> comando1 = FabricaComando.crearM09DisponibilidadHotel(hotelbuscado, 0);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }


        /// <summary>
        /// Método que retorna la lista de países
        /// </summary>
        /// <returns>Retorna una lista de Items que contiene los países disponibles</returns>
        public static List<SelectListItem> pais()
        {
            Command<Dictionary<int, Entidad>> commandpais = FabricaComando.crearM09ObtenerPaises();
            Dictionary<int, Entidad> _paises = commandpais.ejecutar();
            List<SelectListItem> __pais = new List<SelectListItem>();
            int i = 0;
            bool verdad = true;
            foreach (var item in _paises)
            {
                Pais country = (Pais)item.Value;
                __pais.Add(new SelectListItem
                {
                    Text = country._nombre,
                    Value = Convert.ToString(country._id)
                });
            }
            
            return __pais;
        }



        /// <summary>
        /// Método que retorna la lista de ciudades
        /// </summary>
        /// <param name="pais">Nombre del país del cual se desea conocer las ciudades disponibles</param>
        /// <returns>Retorna un ActionResult que contiene las ciudades disponibles para el país solicitado</returns>
        [HttpPost]
        public ActionResult listaciudades(String pais)
        {
            Command<Dictionary<int, Entidad>> commandpais = FabricaComando.crearM09ObtenerPaises();
            Dictionary<int, Entidad> _paises = commandpais.ejecutar();
            List<String> objcity = new List<String>();
            _pais = pais;
            foreach (var item in _paises)
            {
                Pais country = (Pais)item.Value;
                if (country._nombre.Equals(pais))
                {
                    foreach (var ite in country._ciudades)
                    {
                        Ciudad city = (Ciudad)ite.Value;
                        objcity.Add(city._nombre);
                    }
                }
            }
            ciudad = objcity.First();
            return Json(objcity);
        }
<<<<<<< HEAD










        // GET: gestion_hoteles
        //public ActionResult M09_GestionHoteles_Crear()
        //{
        //    CHotel crear = new CHotel()
        //    {
        //        _listapaises = new List<SelectListItem>(pais())
        //    };

        //    return PartialView(crear);
        //}

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

        public static List<SelectListItem> pais1()
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
        /*
        public ActionResult M09_GestionHoteles_Visualizar()
        {
            CManejadorSQL_Hoteles buscarhoteles = new CManejadorSQL_Hoteles();
            List<CHotel> listahoteles = buscarhoteles.MListarHotelesBD();  //AQUI SE BUSCAN TODO LOS HOTELES QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA       
            return PartialView(listahoteles);
        }
        */
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
        /*METODO DE LAS GEMELAS*/
        /*
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
        */
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

=======
>>>>>>> f8b725c39707cc16098865f4332e749e9bd3a91b
    }
}