using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_aviones;
using System.Net;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    public class gestion_avionesController : Controller
    {
        //
        // GET: /gestion_aviones/

        public ActionResult M02_GestionAviones()
        {
            CGestion_avion model = new CGestion_avion();
            return PartialView(model);
        }

        public ActionResult M02_AgregarAvion()
        {
            CAgregarAvion model = new CAgregarAvion();
            return PartialView(model);
        }


        [HttpPost]
        public JsonResult guardarAvion(CAgregarAvion model)
        {
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._matriculaAvion == null) || (model._modeloAvion == null) || (model._capacidadEquipaje == 0) || (model._capacidadMaximaCombustible == 0)
                || (model._distanciaMaximaVuelo == 0) || (model._capacidadPasajerosEjecutiva == 0) || (model._capacidadPasajerosVIP == 0) ||
                (model._capacidadPasajerosTurista == 0) || (model._velocidadMaximaDeVuelo == 0)) 
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error! campo obligatorio vacío";
                //Retorno el error
                return Json(error);
            }
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.insertarAvion(model);
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


        public ActionResult M02_VisualizarAviones()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CAvion> aviones = new List<CAvion>();
            aviones = sql.listarAvionesEnBD();
            return PartialView(aviones);
        }

        public ActionResult M02_ConsultarAvion(int id)
        {
            manejadorSQL sql = new manejadorSQL();
            CAvion avion = new CAvion();
            avion = sql.consultarAvion(id);
            CModificarAvion modelo = new CModificarAvion(avion);
            return PartialView("M02_ModificarAvion",modelo);
        }

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
                String error = "Error en la base de datos";
                //Retorno el error
                return Json(error);
            }
            
        }

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


    }
}
