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
            CModulo_general modulo1 = new CModulo_general("Roles");
            CModulo_general modulo2 = new CModulo_general("Aviones");
            CModulo_general modulo3 = new CModulo_general("Automoviles");
            rol.Menu.agregarElemento(modulo1);
            rol.Menu.agregarElemento(modulo2);
            rol.Menu.agregarElemento(modulo3);   
           
            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
	}
}