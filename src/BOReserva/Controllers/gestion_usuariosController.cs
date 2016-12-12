using BOReserva.Models.gestion_usuarios;
using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Servicio;
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
                    TempData["message"] = "Usuario Agregado Exitosamente";
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
            //Se resetea intentos en la Tabla Login MO1 Ingreso Seguridad
            Cgestion_seguridad_ingreso ingreso = new Cgestion_seguridad_ingreso();
            ingreso.correoCampoTexto = usuario.correoUsuario;
            

          
            System.Diagnostics.Debug.WriteLine("Correo " + usuario.correoUsuario );

            if (ModelState.IsValid)
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.ModificarUsuario(usuario.toClass(), usuario.idUsuario);
                    ingreso.ResetearIntentos();//Metodo M01_Ingreso_Seguridad
                    TempData["message"] = "Usuario Modficado Exitosamente";
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