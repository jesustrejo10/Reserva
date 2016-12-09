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
            try
            {
                IEnumerable<ListarUsuario> lista = p.ListaUsuarios();
                return PartialView("M12_Index", lista);
            }
            catch (ExceptionM12Reserva ex)
            {
                IEnumerable<ListarUsuario> lista = new List<ListarUsuario>();
                ModelState.AddModelError("", ex.Message);
                return PartialView("M12_Index", lista);
            }
            catch (Exception ex)
            {
                IEnumerable<ListarUsuario> lista = new List<ListarUsuario>();
                ModelState.AddModelError("", ex.Message);
                return PartialView("M12_Index", lista);
            }
        }


        public ActionResult M12_AgregarUsuario()
        {
            Response.Write("<script>alert('" + "apestas" + "');</script>");
            return PartialView();
        }

        [HttpPost]
        public ActionResult M12_AgregarUsuario(AgregarUsuario usuario)
        {   
            if (ModelState.IsValid) 
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.AgregarUsuario(usuario.toClass());
                    return RedirectToAction("M12_Index");
                }
                catch (ExceptionM12Reserva ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View("M12_AgregarUsuario", "_Layout");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View("M12_AgregarUsuario", "_Layout");
                }
            } 
            else {
                return View("M12_AgregarUsuario", "_Layout");    
            } 
 
            
        }

       [HttpPost]
        public ActionResult M12_ModificarUsuario(AgregarUsuario usuario)
        {
            if (ModelState.IsValid)
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.ModificarUsuario(usuario.toClass(), usuario.idUsuario);
                    return RedirectToAction("M12_Index");
                }
                catch (ExceptionM12Reserva ex)
                {
                    
                    //ModelState.AddModelError("", ex.Message);
                    return View("M12_ModificarUsuario", usuario);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View("M12_ModificarUsuario", usuario);
                }
            } 

            return PartialView("M12_Index", "_Layout");
        }



       public ActionResult ModificarUsuario(int? usuID)
        {

            if (usuID.HasValue)
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    AgregarUsuario  usuario = new AgregarUsuario(p.consultarUsuario(usuID.Value));
                    return PartialView("M12_ModificarUsuario", usuario);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return PartialView("M12_Index", "_Layout");
                }
            }
            else
                return RedirectToAction("M12_Index");

        }

        
        public RedirectToRouteResult EliminarUsuario(int usuID)
        {
            
            PersistenciaUsuario p = new PersistenciaUsuario();
            p.eliminarUsuario(usuID);
            return RedirectToAction("M12_Index");
        }
        
    }
}