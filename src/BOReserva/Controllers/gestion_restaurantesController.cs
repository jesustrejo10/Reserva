using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_restaurantes;

namespace BOReserva.Controllers
{
    public class gestion_restaurantesController : Controller
    {
        // GET: gestion_restaurantes

        /// <summary>
        /// Método para el acceso a la interfaz de visualización de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Ver()
        {
         //   System.Diagnostics.Debug.WriteLine("Valor del id "+id);
         
            return PartialView();
        }

        /// <summary>
        /// Método para el acceso a la interfaz de agregación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Agregar()
        {
         
            return PartialView();
        }



        [HttpPost]
        public ActionResult M10_GestionRestaurantes_Ver(int id)
        {
            System.Diagnostics.Debug.WriteLine("Estoy en metodo de combo id retornado: "+id);
            return PartialView();
        }
        /// <summary>
        /// Método para el acceso a la interfaz de modificación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Modificar(int id)
        {
           
            var modelo = new CRestauranteModelo
            {
                //id = respuesta.Id,
                //idLugar = respuesta.IdFKLugar,
                //nombre = respuesta,
                //direccion = respuesta._direccion,
                //descripcion = respuesta._descripcion,
                //horarioApertura = respuesta._horarioApertura,
                //horarioCierre = respuesta._horarioCierre
            };
            //modelo._listaCiudades = bd.consultarCiudad();
            return PartialView();
        }

        /// <summary>
        /// Método para el acceso a la interfaz de eliminación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Eliminar()
        {
          
    
            return PartialView();
        }

        /// <summary>
        /// Método para el almacenado de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpPost]
        public JsonResult guardarRestaurante(CRestauranteModeloVista model)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((model._nombre == null) || (model._direccion == null) 
                || (model._horarioApertura == null) || (model._horarioCierre == null) || (model._idLugar == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            var salida = new CRestauranteModelo
            {
                nombre = model._nombre,
                direccion = model._direccion,
                descripcion = model._descripcion,
                horarioApertura = model._horarioApertura,
                horarioCierre = model._horarioCierre,
                idLugar = model._idLugar
            };
         
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando el restaurante.";
                return Json(error);
            }
        }

        /// <summary>
        /// Método para la modificación de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>


        [HttpPost]
        public JsonResult modificarRestaurante(CRestauranteModeloVista model)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((model._id == -1) || (model._nombre == null) || (model._direccion == null)
                || (model._horarioApertura == null) || (model._horarioCierre == null) || (model._idLugar == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            var salida = new CRestauranteModelo
            {
                id = model._id,
                nombre = model._nombre,
                direccion = model._direccion,
                descripcion = model._descripcion,
                horarioApertura = model._horarioApertura,
                horarioCierre = model._horarioCierre,
                idLugar = model._idLugar
            };
          
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error modificando el restaurante.";
                return Json(error);
            }
        }

        /// <summary>
        /// Método para la eliminación de restaurantes, tomando como parámetro un id de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpGet]
        public JsonResult eliminarRestaurante(int id)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((id == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
     
            if (true)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error eliminando el restaurante.";
                return Json(error);
            }
        }
    }
}