using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_hotelesController : Controller
    {
        // GET: gestion_hoteles
        public ActionResult M09_GestionHoteles_Crear()
        {
            return PartialView();
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