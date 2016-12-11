using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    public class gestion_ruta_comercialController : Controller
    {
        //
        // GET: gestion_ruta_comercial/AgregarRutasComerciales
        public ActionResult AgregarRutasComerciales()
        {
            List<String> lista = new List<string>();
            
            manejadorSQL sql = new manejadorSQL();                       

            lista = sql.listarLugares();

            List<SelectListItem> list = lista.ConvertAll(a =>
                                {
                                    return new SelectListItem()
                                    {
                                        Text = a.ToString(),
                                        Value = a.ToString(),
                                        Selected = false
                                    };
                                
                                });
            
            
            CAgregarRuta ruta = new CAgregarRuta();
            ruta._lorigenRuta = list;
            ruta._ldestinoRuta = list;
            return PartialView(ruta);
        }

        public JsonResult cargarOrigenes(String tipo) {
            List<SelectListItem> origenes = new List<SelectListItem>();



            return Json(new SelectList(origenes, "Value", "Text"));
        
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
            CGestion_ruta ruta = new CGestion_ruta();
            return PartialView(ruta);
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
            
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.InsertarRuta(model);

            return null;
        }

    }
}
