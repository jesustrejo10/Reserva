using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;

namespace BOReserva.Controllers
{
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        public ActionResult M13_AgregarRol()
        {
            
            CRoles rol = new CRoles("Administrador");
            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
	}
}