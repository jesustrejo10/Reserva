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

        public ActionResult M11_VisualizarOferta()
        {
            manejadorSQL sql = new manejadorSQL();
            List<COferta> ofertas = new List<COferta>();
            ofertas = sql.listarOfertasEnBD();
            return PartialView(ofertas);
        }

        public List<COferta> M11_PaquetesPorOferta()
        {
            manejadorSQL sql = new manejadorSQL();
            List<COferta> ofertas = new List<COferta>();
            ofertas = sql.listarOfertasEnBD();
            return (ofertas);
        }

        public ActionResult M11_ModificarPaquete()
        {
            return PartialView();
        }

        public ActionResult M11_ModificarOferta()
        {
            return PartialView();
        }

        //Carga paquetes en el multiselect de agregar oferta
        public JsonResult M11_CargarPaquetesSelect()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CPaquete> paquetesList = new List<CPaquete>();
            paquetesList = sql.listarPaquetesEnBD();
            return Json(paquetesList);
        }

        [HttpPost]
        public JsonResult asociarPaquetesOferta(int[] idsPaquetes)
        {
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.asociarOfertaPaquete(idsPaquetes);
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

        [HttpPost]
        public JsonResult desactivarOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.desactivarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }

        [HttpPost]
        public JsonResult activarOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }


        [HttpPost]
        public JsonResult ConsultarDetalleOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }

        [HttpPost]
        public JsonResult guardarOferta(CAgregarOferta model, string estadoOferta)
        {

            if (estadoOferta == "1")
                model._estadoOferta = true;
            else
                model._estadoOferta = false;
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