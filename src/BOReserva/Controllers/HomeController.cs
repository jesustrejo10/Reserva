using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Cgestion_seguridad_ingreso"] == null)
            {

                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }

            return View();
        }

    }
}
