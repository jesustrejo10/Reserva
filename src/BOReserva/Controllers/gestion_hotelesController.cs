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
                return (Content(ex.Mensaje));
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
                return (Content(ex.Mensaje));
            }
        }



        /// <summary>
        /// Método que se utiliza para modificar un hotelConNuevosCampos
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
                //con la fabrica instancie al hotelConNuevosCampos.
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
        /// Método que se utiliza para eliminar un hotelConNuevosCampos existente
        /// </summary>
        /// <param name="id">Identificador del hotelConNuevosCampos a eliminar</param>
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
        /// Método que se utiliza para cambiar la disponibilidad de un hotelConNuevosCampos existente
        /// </summary>
        /// <param name="id">Identificador del hotelConNuevosCampos a cambiar</param>
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
        /// Método que se utiliza para cambiar la disponibilidad de un hotelConNuevosCampos existente
        /// </summary>
        /// <param name="id">Identificador del hotelConNuevosCampos a cambiar</param>
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
    }
}