using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;
using BOReserva.Servicio;
namespace BOReserva.Controllers
{
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        public ActionResult M13_AgregarRol()
        {
            manejadorSQL sql = new manejadorSQL();            
            CRoles rol = new CRoles("Administrador");
            rol.Menu = sql.consultarLosModulos();
            sql.insertarRol();
            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
	}
}