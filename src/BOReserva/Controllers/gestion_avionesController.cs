using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_aviones;
using System.Net;
using System.Diagnostics;
using BOReserva.Servicio;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;


namespace BOReserva.Controllers
{

    /// <summary>
    /// Clase que emite las respuestas de los eventos AJAX
    /// /// Clase Controladora del modulo 2, Gestion de Aviones
    /// </summary>
    public class gestion_avionesController : Controller
    {    
        private static int idavion;
        #region M02_AgregarAvion
        /// <summary>
        /// Metodo para guardar el avion, haciendo el insert en la base de datos 
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M02_CrearAvion()
        {
            CAgregarAvion model = new CAgregarAvion();
            return PartialView(model);
        }
        #endregion 

        #region guardarAvion
        /// <summary>
        /// Método que se utiliza para guardar un avion ingresado
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M02_AgregarAvion</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult guardarAvion(CAgregarAvion model)
        {

            Entidad nuevoAvion = FabricaEntidad.InstanciarAvion(model);
            //con la fabrica instancie al avion
            Command<String> comando = FabricaComando.crearM02AgregarAvion(nuevoAvion);
            String agrego_si_no = comando.ejecutar();

            return (Json(agrego_si_no));
        }
        #endregion

        #region M02_DetalleAvion
        /// <summary>
        /// Método de la vista parcial M02_VisualizarAvion
        /// </summary>
        /// <returns>Retorna la vista parcial M02_VisualizarAvion en conjunto del Modelo de dicha vista</returns>
        public ActionResult M02_DetalleAvion(int id)
        {
            Command<Entidad> comando = FabricaComando.crearM02ConsultarAvion(id);
            Entidad avion = comando.ejecutar();
            Avion avionbuscado = (Avion)avion;
            idavion = avionbuscado._id;
            CVerAvion modelovista = new CVerAvion();
            modelovista._matricula = avionbuscado._matricula;
            modelovista._modelo = avionbuscado._modelo;
            modelovista._capacidadTurista = avionbuscado._capacidadTurista;
            modelovista._capacidadEjecutiva = avionbuscado._capacidadEjecutiva;
            modelovista._capacidadVIP = avionbuscado._capacidadVIP;
            modelovista._capacidadEquipaje = avionbuscado._capacidadEquipaje;
            modelovista._distanciaMaximaVuelo = avionbuscado._distanciaMaximaVuelo;
            modelovista._velocidadMaxima = avionbuscado._velocidadMaxima;
            modelovista._capacidadCombustible = avionbuscado._capacidadCombustible;
            modelovista._disponibilidad = avionbuscado._disponibilidad;

            return PartialView(modelovista);
            }
        #endregion

        #region M02_ModificarAvion
        /// <summary>
        /// Método de la vista parcial M02_ModificarAvion
        /// </summary>
        /// <returns>Retorna la vista parcial M02_ModificarAvion en conjunto del Modelo de dicha vista</returns>
        public ActionResult M02_ModificarAvion(int id)
        {
            Command<Entidad> comando = FabricaComando.crearM02ConsultarAvion(id);
            Entidad avion = comando.ejecutar();
            Avion avionbuscado = (Avion)avion;
            idavion = avionbuscado._id;
            CModificarAvion modelovista = new CModificarAvion();
            modelovista._matriculaAvion = avionbuscado._matricula;
            modelovista._modeloAvion = avionbuscado._modelo;
            modelovista._capacidadPasajerosTurista = avionbuscado._capacidadTurista;
            modelovista._capacidadPasajerosEjecutiva = avionbuscado._capacidadEjecutiva;
            modelovista._capacidadPasajerosVIP = avionbuscado._capacidadVIP;
            modelovista._capacidadEquipaje = avionbuscado._capacidadEquipaje;
            modelovista._distanciaMaximaVuelo = avionbuscado._distanciaMaximaVuelo;
            modelovista._velocidadMaximaDeVuelo = avionbuscado._velocidadMaxima;
            modelovista._capacidadMaximaCombustible = avionbuscado._capacidadCombustible;
            modelovista._disponibilidad = avionbuscado._disponibilidad;
            return PartialView(modelovista);
        }
        #endregion

        #region modificarAvion
        /// <summary>
        /// Método que se utiliza para modificar un avion 
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M02_ModificarAvion</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modificarAvion(CModificarAvion model)
            {
          
            Entidad modificarAvion = FabricaEntidad.InstanciarAvion(model);
            //con la fabrica instancie al avion.
            Command<String> comando = FabricaComando.crearM02ModificarAvion(modificarAvion, idavion);
            String agrego_si_no = comando.ejecutar();

            return (Json(agrego_si_no));
        }
        #endregion
       
        #region deleteAvion
        /// <summary>
        /// Método que se utiliza para eliminar un avion existente
        /// </summary>
        /// <param name="id">Identificador del avion a eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult deleteAvion(int id)
            {
            Command<Entidad> comando = FabricaComando.crearM02ConsultarAvion(id);
            Entidad avion = comando.ejecutar();
            Avion avionbuscado = (Avion)avion;
            avionbuscado._id = id;
            Command<String> comando1 = FabricaComando.crearM02EliminarAvion(avionbuscado, id);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
            }
        #endregion

        #region M02_VisualizarAviones
        /// <summary>
        /// Método de la vista parcial M02_VisualizarAvion
        /// </summary>
        /// <returns>Retorna la vista parcial M02_VisualizarAvion en conjunto del Modelo de dicha vista</returns>
        public ActionResult M02_VisualizarAviones()
            {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM02VisualizarAviones();
            Dictionary<int, Entidad> listaAviones = comando.ejecutar();
            return PartialView(listaAviones);
        }
        #endregion

        #region activateAvion
        /// <summary>
        /// Método que se utiliza para cambiar la disponibilidad de un avion existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult activateAvion(int id)
            {
            Command<Entidad> comando = FabricaComando.crearM02ConsultarAvion(id);
            Entidad avion = comando.ejecutar();
            Avion avionbuscado = (Avion)avion;
            avionbuscado._id = id;
            Command<String> comando1 = FabricaComando.crearM02DisponibilidadAvion(avionbuscado,1);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
        }
        #endregion

        #region deactivateAvion
        /// <summary>
        /// Método que se utiliza para cambiar la disponibilidad de un avion existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult deactivateAvion(int id)
            {
           Command<Entidad> comando = FabricaComando.crearM02ConsultarAvion(id);
           Entidad avion = comando.ejecutar();
           Avion avionbuscado = (Avion)avion;
           avionbuscado._id= id;
           Command<String> comando1 = FabricaComando.crearM02DisponibilidadAvion(avionbuscado,0);
           String borro_si_no = comando1.ejecutar();
           return (Json(borro_si_no));
        }
        #endregion
   }
}
