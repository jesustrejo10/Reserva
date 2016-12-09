using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ofertas;
using System.Net;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    public class gestion_ofertasController : Controller
    {
        //
        // GET: /gestion_ofertas/
        public ActionResult M11_AgregarPaquete()
        {
            CAgregarPaquete model = new CAgregarPaquete();
            return PartialView();
        }

        public ActionResult M11_AgregarOferta()
        {
            return PartialView();
        }

        public ActionResult M11_ConsultarPaquete()
        {
            return PartialView();
        }

        public ActionResult M11_ConsultarOferta()
        {
            return PartialView();
        }

        public ActionResult M11_ModificarPaquete()
        {
            return PartialView();
        }

        public ActionResult M11_ModificarOferta()
        {
            return PartialView();
        }


        [HttpPost]
        public JsonResult guardarOferta(CAgregarOferta model)
        {
           
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._nombreOferta == null) || (model._porcentajeOferta == 0) || (model._fechaIniOferta == null) || (model._fechaFinOferta == null))
            {
                

                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error: Campo obligatorio vacio";
                //Retorno el error
                return Json(error);
            }


            if (model._fechaFinOferta.Date < model._fechaIniOferta.Date)
            {
               Response.StatusCode = (int)HttpStatusCode.BadRequest;
             String Error = "Error: La fecha de Inicio no puede ser igual a la fecha Fin";
            return Json(Error);
            }

            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.agregarOferta(model);
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
	}
}