using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Servicio;

namespace BOReserva.Controllers
{
    public class HomeController : Controller
    {
        public static List<string> permisos;
        public ActionResult Index()
        {
            if (Session["Cgestion_seguridad_ingreso"] == null)
            {

                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }

            manejadorSQL sql = new manejadorSQL();
            //aqui debe ir  la variable de session id en vez de 10
            permisos = sql.M13consultarRolesDeUnUsuario("Aqui va el string que almacenda el correo");
            Session["Permisos"] = permisos;

            return View();
        }

    }
}
