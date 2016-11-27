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
            return PartialView();
        }
        
        public ActionResult M12_AgregarUsuario()
        {
            return PartialView();
        }

        [HttpPost]
        public ViewResult M12_AgregarUsuario(AgregarUsuario usuario )
        {   
            if (ModelState.IsValid) 
            {        
                return View("M12_AregarUsuario");   
            } 
            else {           
                return View();    
            } 
 
            
        }
    }
}