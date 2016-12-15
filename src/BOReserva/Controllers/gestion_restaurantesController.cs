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
        public ActionResult M10_GestionRestaurantes_Ver()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

        public ActionResult M10_GestionRestaurantes_Agregar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

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

        public ActionResult M10_GestionRestaurantes_Eliminar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            modelo._listaCiudades = bd.consultarCiudad();
            return PartialView(modelo);
        }

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