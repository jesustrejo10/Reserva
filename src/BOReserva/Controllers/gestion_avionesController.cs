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
            if ((model._matriculaAvion == null) || (model._modeloAvion == null) || (model._capacidadEquipaje == 0) || (model._capacidadMaximaCombustible == 0) || (model._distanciaMaximaVuelo == 0))
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

        /*Metodo para consultar la matricula de un avion para sus estadisticas*/
        [HttpPost]
        public JsonResult consultarEstadisticasAvion(CGestion_avion model)
        {
            String prueba = model._matriculaConsultarEstadisticaAvion;
            return (Json(true, JsonRequestBehavior.AllowGet));
            
        }




    }
}
