using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio;
using System.Net;

namespace BOReserva.Controllers
{
    public class gestion_ruta_comercialController : Controller
    {
        //
        // GET: gestion_ruta_comercial/AgregarRutasComerciales
        public ActionResult AgregarRutasComerciales()
        {
            List<String> lista = new List<string>();
            
            CAgregarRuta ruta = new CAgregarRuta();
            
            CBasededatos_ruta_comercial sql = new CBasededatos_ruta_comercial();                       

            lista = sql.listarLugares();

            ruta._lorigenRuta = lista.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                });         
            return PartialView(ruta);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult cargarDestinos(string ciudadO)
        {
            CAgregarRuta model = new CAgregarRuta();
            List<String> resultado = new List<String>();
            CBasededatos_ruta_comercial sql = new CBasededatos_ruta_comercial();                       


            resultado = sql.consultarDestinos(ciudadO);

            model._ldestinoRuta = resultado.Select(m => new SelectListItem
            {
                Value = m,
                Text = m
            });

            if (resultado != null)
            {
                return (Json(model._ldestinoRuta, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error accediendo a la BD";
                return Json(error);
            }
        }


        // GET: gestion_ruta_comercial/ModificarRutasComerciales
        public PartialViewResult ModificarRutasComerciales()
        {
            CGestion_ruta ruta = new CGestion_ruta();
            return PartialView(ruta);
        }


        // GET: gestion_ruta_comercial/VisualizarRutasComerciales
        public PartialViewResult VisualizarRutasComerciales()
        {
            CBasededatos_ruta_comercial ruta = new CBasededatos_ruta_comercial();
            List<CRuta> listarutas = ruta.MListarRutasBD();
            return PartialView(listarutas);
        }

        // GET: gestion_ruta_comercial/VisualizarRutasComerciales
        public PartialViewResult DetalleRutasComerciales()
        {
            CGestion_ruta ruta = new CGestion_ruta();
            return PartialView(ruta);
        }


        [HttpPost]
        public JsonResult guardarRuta(CAgregarRuta model)
        {
            
            CBasededatos_ruta_comercial sql = new CBasededatos_ruta_comercial();
            //realizo el insert
            bool resultado = sql.InsertarRuta(model);

            return null;
        }

    }
}
