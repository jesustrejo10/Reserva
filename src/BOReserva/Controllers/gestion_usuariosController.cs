using BOReserva.Models.gestion_usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
           // Response.Write("<script>alert('" + "prueba" + "');</script>");
            ViewBag.Roles = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem {Text = "Administrador", Value = "1"},
                    new SelectListItem {Text = "Normal", Value = "2"},
                    new SelectListItem {Text = "Anonimo", Value = "3"},

                }, "Value", "Text");
            return PartialView();
        }



        [HttpPost]
        public ActionResult M12_AgregarUsuario(AgregarUsuario usuario)
        {
            ViewBag.Roles = new SelectList(new List<SelectListItem>
                {
                    new SelectListItem {Text = "Administrador", Value = "1"},
                    new SelectListItem {Text = "Normal", Value = "2"},
                    new SelectListItem {Text = "Anonimo", Value = "3"},

                }, "Value", "Text");
            if (ModelState.IsValid) 
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.AgregarUsuario(usuario.toClass());
                    TempData["message"] = "Usuario agregado Exitosamente";
                    //return RedirectToAction("M12_Index");
                }
                catch (ExceptionM12Reserva ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(ex.Message);
                }
            }
            return Json("true");
            //return RedirectToAction("M12_Index");
            //return View("M12_AgregarUsuario", "_Layout");    
            
 
            
        }


       [HttpPost]
        public RedirectToRouteResult M12_ModificarUsuario(AgregarUsuario usuario)
        {

            if (ModelState.IsValid)
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.ModificarUsuario(usuario.toClass(), usuario.idUsuario);
                    TempData["message"] = "Usuario modificado Exitosamente";
                    //return RedirectToAction("M12_ModificarUsuario");
                    return RedirectToAction("M12_Index");
                }
                catch (ExceptionM12Reserva ex)
                {

                    TempData["message"] = ex.Message;
                    //return View("M12_ModificarUsuario", usuario);
                }
                catch (Exception ex)
                {
                    TempData["message"] = ex.Message;
                    //return View("M12_ModificarUsuario", usuario);
                }
            }
            return RedirectToAction("M12_Index");
            //return PartialView("M12_Index", "_Layout");
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
                    //ModelState.AddModelError("", ex.Message);
                    TempData["message"] = ex.Message;
                    return PartialView("M12_Index", "_Layout");
                }
            }
            else
                return RedirectToAction("M12_Index");

        }

        
        public RedirectToRouteResult EliminarUsuario(int usuID)
        {
            try
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                p.eliminarUsuario(usuID);
                TempData["message"] = "Usuario Eliminado exitosamente";
            }
            catch(ExceptionM12Reserva ex)
            {
                TempData["message"] = ex.Message;
                
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
            }
            return RedirectToAction("M12_Index");
            
            
        }
        
    }
}