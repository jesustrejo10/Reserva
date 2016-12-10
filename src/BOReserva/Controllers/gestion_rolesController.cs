using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        public ActionResult M13_AgregarRol()
        {
            return PartialView();
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
	}
}