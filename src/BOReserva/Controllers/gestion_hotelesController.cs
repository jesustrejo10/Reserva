using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_hoteles;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            cGestionHoteles_CrearHotel crear = new cGestionHoteles_CrearHotel();
            return PartialView(crear);
        }

        [HttpPost]
        public JsonResult crearhotel(cGestionHoteles_CrearHotel crear) {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_ModificarHotel()
        {
            return PartialView();
        }

        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Desactivar()
        {
            return PartialView();
        }
    }


}