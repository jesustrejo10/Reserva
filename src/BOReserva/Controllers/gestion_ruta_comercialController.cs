using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio.Servicio_Rutas;
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
            
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();                       

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
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();                       


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
            CManejadorSQL_Rutas ruta = new CManejadorSQL_Rutas();
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
            
            CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();
            //realizo el insert

            if (model._origenRuta == null || model._destinoRuta == null)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, no ha seleccionado un origen/destino valido";
                //Retorno el error
                return Json(error);

            }
            else if (model._distanciaRuta <= 0 || model._distanciaRuta == 999999) {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error, distancia de ruta invalida";
                //Retorno el error
                return Json(error);
            }
            else
            {
                bool resultado = sql.InsertarRuta(model);
                return null;
            }
            

            
        }

    }
}
