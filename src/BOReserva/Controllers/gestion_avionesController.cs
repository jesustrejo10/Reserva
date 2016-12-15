using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_aviones;
using System.Net;
using BOReserva.Servicio;
using System.Data.SqlClient;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase que emite las respuestas de los eventos AJAX
    /// </summary>
    public class gestion_avionesController : Controller
    {
       
       
        /// <summary>
        /// Metodo para guardar el avion, haciendo el insert en la base de datos 
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M02_AgregarAvion()
        {
            CAgregarAvion model = new CAgregarAvion();
            return PartialView(model);
        }

        /// <summary>
        /// Metodo para modificar el avion, haciendo el insert en la base de datos si los datos son correctos
        /// </summary>
        /// <param name="model">CAgregarAvion</param>
        /// <returns> Json </returns>

        [HttpPost]
        public JsonResult guardarAvion(CAgregarAvion model)
        {
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._matriculaAvion == null) || (model._modeloAvion == null) || (model._capacidadEquipaje == 0) || (model._capacidadMaximaCombustible == 0)
                || (model._distanciaMaximaVuelo == 0) || (model._capacidadPasajerosEjecutiva == 0) || (model._capacidadPasajerosTurista == 0)
                || (model._capacidadPasajerosVIP == 0) || (model._velocidadMaximaDeVuelo == 0))
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campos obligatorios vacios";
                //Retorno el error
                return Json(error);
            }
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            try
            {
                bool resultado = sql.insertarAvion(model);
                //envio una respuesta dependiendo del resultado del insert
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }

            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }

            return (Json(true, JsonRequestBehavior.AllowGet));

        }



    
        /// <summary>
        /// Metodo para ver los aviones disponibles
        /// </summary>
        /// <returns>ActionResult que contiene una lista de los aviones en el sistema </returns>
        public ActionResult M02_VisualizarAviones()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CAvion> aviones = new List<CAvion>();
            try
            {
                aviones = sql.listarAvionesEnBD();
                return PartialView(aviones);
            }
            catch (SqlException e)
            {
                return PartialView();
            }
            catch (Exception e)
            {
                return PartialView();
            }
        }

        /// <summary>
        /// Metodo que carga la vista para modificar el avion 
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> ActionResult con los datos de un avion </returns>
        public ActionResult M02_ConsultarAvion(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            CAvion avion = new CAvion();
            avion = sql.consultarAvion(id);
            CModificarAvion modelo = new CModificarAvion(avion);
            return PartialView("M02_ModificarAvion", modelo);
        }

        /// <summary>
        /// Metodo para que el avion este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema </returns>
        [HttpPost]
        public JsonResult habilitarAvion(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.habilitarAvion(id);
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)  
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error  
                String error = "Error en la base de datos.";
                //Retorno el error  
                return Json(error);
            }
        }
       
        /// <summary>
        /// Metodo para que el avion NO este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema</returns>
        [HttpPost]
        public JsonResult deshabilitarAvion(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.deshabilitarAvion(id);
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
        /// Metodo utilizado para enviar una respuesta a la solicitud de eliminar un avion
        /// </summary>
        /// <param name="id">ID correspondiente al avion</param>
        /// <returns>JsonResult con un codigo de exito/error</returns>
        [HttpPost]
        public JsonResult eliminarAvion(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.eliminarAvion(id);
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
        /// Metodo que guarda los cambios realizados a un avion
        /// </summary>
        /// <param name="model"> CModificarAvion </param>
        /// <returns> JsonResult booleano que informa si se ejecuta el cambio </returns>
        [HttpPost]
        public JsonResult modificarAvion(CModificarAvion model)
        {
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._matriculaAvion == null) || (model._modeloAvion == null) || (model._capacidadEquipaje == 0) || (model._capacidadMaximaCombustible == 0)
                || (model._distanciaMaximaVuelo == 0) || (model._velocidadMaximaDeVuelo == 0) || (model._capacidadPasajerosEjecutiva == 0)
                || (model._capacidadPasajerosVIP == 0) || (model._capacidadPasajerosTurista == 0))
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error! campo obligatorio vacío";
                //Retorno el error
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.modificarAvion(model);
            if (resultado)
            {
                return (Json(sql.modificarAvion(model), JsonRequestBehavior.AllowGet));
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
   }
}
