using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_comida_vuelo;
using System.Net;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    public class gestion_comida_vueloController : Controller
    {
        // GET: /gestion_comida_vuelo/
        public ActionResult M06_AgregarComida()
        {
            CAgregarComida model = new CAgregarComida();
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult guardarPlato(CAgregarComida model)
        {
           // string nombrePlato = model._nombrePlato;
           // string descripcionPlato = model._descripcionPlato;
           // string tipoPlato = model._tipoPlato;
           // string estatusPlato = model._estatusPlato;
           // return(Json(true, JsonRequestBehavior.AllowGet));
          
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._nombrePlato == null) || (model._tipoPlato == null) || (model._estatusPlato == null) || (model._descripcionPlato == null))
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, campo obligatorio vacio";
                //Retorno el error
                return Json(error);
            }
           
                //return (Json(true, JsonRequestBehavior.AllowGet));
                //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.insertarPlato(model);
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


        public ActionResult M06_AgregarPorVuelo()
        {
           return PartialView();
        }

        public ActionResult M06_ConsultarComida(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            CComida comida = new CComida();
            comida = sql.consultarComida(id);
            CEditarComida modelo = new CEditarComida(comida);
            return PartialView("M06_EditarComida", modelo);
        }

        public ActionResult M06_VisualizarComidas()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CComida> comidas = new List<CComida>();
            comidas = sql.listarPlatosEnBD();
            return PartialView(comidas);
            //return PartialView();
        }

        /// <summary>
        /// Metodo para que el avion este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema </returns>
        [HttpPost]
        public JsonResult habilitarPlato(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.habilitarPlato(id);
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
        /// Metodo para que el avion NO este disponible para su uso
        /// </summary>
        /// <param name="id"> int </param>
        /// <returns> JsonResult booleano conteniendo la respuesta del sistema</returns>
        [HttpPost]
        public JsonResult deshabilitarPlato(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            Boolean resultado = sql.deshabilitarPlato(id);
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
       
	}
}