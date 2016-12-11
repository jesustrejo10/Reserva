using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            CGestionHoteles_CrearHotel crear = new CGestionHoteles_CrearHotel();
            
            return PartialView(crear);
        }

        [HttpPost]
        public JsonResult crearhotel(CGestionHoteles_CrearHotel crear) {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_ModificarHotel()
        {
            CGestionHoteles_EditarHotel modificar = new CGestionHoteles_EditarHotel();
            return PartialView(modificar);
        }

        [HttpPost]
        public JsonResult editarhotel(CGestionHoteles_EditarHotel modificar)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Desactivar()
        {
            return PartialView();
        }

        public static List<SelectListItem> pais() {
            return CGestionHoteles_SelectPaisModel.pais();
        }

        public ActionResult M09_GestionHoteles_Visualizar()
        { 
            CManejadorSQL_Hoteles buscarhoteles = new CManejadorSQL_Hoteles();
            List<CHotel> listahoteles = buscarhoteles.MListarHotelesBD();  //AQUI SE BUSCAN TODO LOS HOTELES QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA       
            return PartialView(listahoteles);
        }

    }


}