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
            CAgregarRuta ruta = new CAgregarRuta();
            return PartialView(ruta);
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
