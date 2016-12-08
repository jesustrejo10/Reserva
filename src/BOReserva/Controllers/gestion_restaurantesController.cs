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

        public ActionResult M10_GestionRestaurantes_Modificar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
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
        public JsonResult guardarRestaurante(CRestauranteModelo model)
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
            bool resultado = sql.insertarRestaurante(model);
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
        public JsonResult modificarRestaurante(CRestauranteModelo model)
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
            bool resultado = sql.modificarRestaurante(model);
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

        [HttpPost]
        public JsonResult eliminarRestaurante(CRestauranteModelo model)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((model._id == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }
            manejadorSQL sql = new manejadorSQL();
            bool resultado = sql.eliminarRestaurante(model._id);
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