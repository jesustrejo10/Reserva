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
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

        /// <summary>
        /// Método para el acceso a la interfaz de agregación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Agregar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

        /// <summary>
        /// Método para el acceso a la interfaz de modificación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Modificar(int id)
        {
            var bd = new manejadorSQL();
            var respuesta = bd.consultarRestaurante(id);
            var modelo = new CRestauranteModeloVista
            {
                _id = respuesta._id,
                _idLugar = respuesta._idLugar,
                _nombre = respuesta._nombre,
                _direccion = respuesta._direccion,
                _descripcion = respuesta._descripcion,
                _horarioApertura = respuesta._horarioApertura,
                _horarioCierre = respuesta._horarioCierre
            };
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

        /// <summary>
        /// Método para el acceso a la interfaz de eliminación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Eliminar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
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
                _nombre = model._nombre,
                _direccion = model._direccion,
                _descripcion = model._descripcion,
                _horarioApertura = model._horarioApertura,
                _horarioCierre = model._horarioCierre,
                _idLugar = model._idLugar
            };
            bool resultado = sql.insertarRestaurante(salida);
            if (resultado)
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
                _id = model._id,
                _nombre = model._nombre,
                _direccion = model._direccion,
                _descripcion = model._descripcion,
                _horarioApertura = model._horarioApertura,
                _horarioCierre = model._horarioCierre,
                _idLugar = model._idLugar
            };
            bool resultado = sql.modificarRestaurante(salida);
            if (resultado)
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
            manejadorSQL sql = new manejadorSQL();
            bool resultado = sql.eliminarRestaurante(id);
            if (resultado)
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