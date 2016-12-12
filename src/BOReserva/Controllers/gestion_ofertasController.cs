using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ofertas;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_automoviles;
using BOReserva.Models.gestion_restaurantes;
using System.Collections.Specialized;

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

        public ActionResult M11_VisualizarPaquete()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CPaquete> paquetes = new List<CPaquete>();
            paquetes = sql.listarPaquetes();
            return PartialView(paquetes);
        }

        public ActionResult M11_DetallePaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);
        }

        public ActionResult infoPaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);
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
        
        [HttpPost]
        public JsonResult M11_ListarAutomoviles()
        {
            CAutomovil automovil = new CAutomovil();
            return Json(automovil.MListarvehiculos());
        }

        [HttpPost]
        public JsonResult M11_ListarRestaurantes()
        {
            manejadorSQL sql = new manejadorSQL();
            var restauranteList = new List<CRestauranteModelo>();
            restauranteList = sql.consultarRestaurante();
            return Json(restauranteList);
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
        public JsonResult M11_ListarHoteles()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listHoteles = new List<CConsultar>();
            listHoteles = sql.listarHotelesM11();
            return Json(listHoteles);
        }

        [HttpPost]
        public JsonResult M11_ListarCruceros()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listCruceros = new List<CConsultar>();
            listCruceros = sql.listarCrucerosM11();
            return Json(listCruceros);
        }

        [HttpPost]
        public JsonResult M11_ListarVuelos()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listVuelos = new List<CConsultar>();
            listVuelos = sql.listarVuelosM11();
            return Json(listVuelos);
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
        public JsonResult desactivarPaquete(String ofertaIdStr)
        {
            int paqueteId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.desactivarPaquete(paqueteId);
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
        public JsonResult activarPaquete(String ofertaIdStr)
        {
            int paqueteId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarPaquete(paqueteId);
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

        [HttpPost]
        public JsonResult guardarPaquete(String nombrePaq, String idAuto, int idHotel, int idCrucero, int idRestaurante, 
                                          int idVuelo, String fiAuto, String ffAuto, String fiHotel, String ffHotel,
                                          String fiCrucero, String ffCrucero,String fiRestaurante, String ffRestaurante,
                                          String fiVuelo, String ffVuelo, String precio) // cambiar precio a float
        {
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete = new CPaquete();
            paquete._nombrePaquete = nombrePaq;
            if (idAuto == "00")
                idAuto = null;
            if (idHotel != 0)
                paquete._idHabitacion = idHotel;
            if (idCrucero != 0)
                paquete._idCrucero = idCrucero;
            if (idRestaurante !=0)
                paquete._idRestaurante = idRestaurante;
            if(idVuelo !=0)
                paquete._idVuelo = idVuelo;
            if (fiAuto == "")
                fiAuto = null;
            else
                paquete._fechaIniAuto = DateTime.Parse(fiAuto);
            if (ffAuto == "")
                ffAuto = null;
            else
                paquete._fechaFinAuto = DateTime.Parse(ffAuto);
            if (fiHotel == "")
                fiHotel = null;
            else
                paquete._fechaIniHabi = DateTime.Parse(fiHotel);

            if (ffHotel == "")
                ffHotel = null;
            else
                paquete._fechaFinHabi = DateTime.Parse(ffHotel);

            if (fiCrucero == "")
                fiCrucero = null;
            else
                paquete._fechaIniCruc = DateTime.Parse(fiCrucero);
            
            if (ffCrucero == "")
                ffCrucero = null;
            else
                paquete._fechaFinCruc = DateTime.Parse(ffCrucero);

            if (fiRestaurante== "")
                fiRestaurante = null;
            else
                paquete._fechaIniRest = DateTime.Parse(fiRestaurante);
            if (ffRestaurante == "")
                ffRestaurante = null;
            else
                paquete._fechaFinRest = DateTime.Parse(ffRestaurante);

            if (fiVuelo == "")
                fiVuelo = null;
            else
                paquete._fechaIniVuelo = DateTime.Parse(fiVuelo);

            if (ffVuelo == "")
                ffVuelo = null;
            else
                paquete._fechaFinVuelo = DateTime.Parse(ffVuelo);

                paquete._idAuto = idAuto;
                paquete._precioPaquete = float.Parse(precio);
                sql.agregarPaquete(paquete);

            return Json(true);
        }
	}
}