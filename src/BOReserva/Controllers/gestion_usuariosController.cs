using BOReserva.Models.gestion_usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_usuariosController : Controller
    {
        //
        // GET: /gestion_usuario/
        public ActionResult M12_Index()
        {
            PersistenciaUsuario p = new PersistenciaUsuario();
            IEnumerable<ListarUsuario> lista = p.ListaUsuarios();
            return PartialView("M12_Index", lista);
        }


        public ActionResult M12_AgregarUsuario()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult M12_AgregarUsuario(AgregarUsuario usuario)
        {   
            if (ModelState.IsValid) 
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                p.AgregarUsuario(usuario.toClass());
                return RedirectToAction("M12_Index");   
            } 
            else {
                return View("M12_AgregarUsuario", "_Layout");    
            } 
 
            
        }

        public RedirectToRouteResult EliminarUsuario(int usuID)
        {
            
            PersistenciaUsuario p = new PersistenciaUsuario();
            p.eliminarUsuario(usuID);
            return RedirectToAction("M12_Index");
        }
    }
}