﻿using BOReserva.Models.gestion_usuarios;
using BOReserva.Models.gestion_seguridad_ingreso;
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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.End();
                IEnumerable<ListarUsuario> lista = new List<ListarUsuario>();
                return PartialView("M12_Index", lista);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.End();
                IEnumerable<ListarUsuario> lista = new List<ListarUsuario>();
                return PartialView("M12_Index", lista);
            }
        }


        public ActionResult M12_AgregarUsuario()
        {
            try { 
                PersistenciaUsuario p = new PersistenciaUsuario();
                List<ListaRoles> lista = p.ListarRoles();
                ViewBag.Roles = new SelectList(lista, "rolID", "rolNombre");
                return PartialView();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.End();
                return Json(ex.Message);
            }
            
        }



        [HttpPost]
        public ActionResult M12_AgregarUsuario(AgregarUsuario usuario)
        {
            //Se resetea intentos en la Tabla Login MO1 Ingreso Seguridad
            Cgestion_seguridad_ingreso ingreso = new Cgestion_seguridad_ingreso();
            ingreso.correoCampoTexto = usuario.correoUsuario;
            
            if (ModelState.IsValid) 
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.AgregarUsuario(usuario.toClass());
                    ingreso.ResetearIntentos();//Metodo M01_Ingreso_Seguridad
                    TempData["message"] = RecursoUsuario.MensajeAgregado;
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
        public ActionResult M12_ModificarUsuario(AgregarUsuario usuario)
        {
            //Se resetea intentos en la Tabla Login MO1 Ingreso Seguridad
            Cgestion_seguridad_ingreso ingreso = new Cgestion_seguridad_ingreso();
            ingreso.correoCampoTexto = usuario.correoUsuario;
            if (ModelState.IsValid)
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                try
                {
                    p.ModificarUsuario(usuario.toClass(), usuario.idUsuario);
                    ingreso.ResetearIntentos();//Metodo M01_Ingreso_Seguridad
                    TempData["message"] = RecursoUsuario.MensajeModificado;
                    //return RedirectToAction("M12_Index");
                }
                catch (ExceptionM12Reserva ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(ex.Message);
                    //return View("M12_ModificarUsuario", usuario);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(ex.Message);
                    //return View("M12_ModificarUsuario", usuario);
                }
            } 
            return Json("true");
            //return RedirectToAction("M12_Index");
            //return PartialView("M12_Index", "_Layout");
        }

 
       
       public ActionResult ModificarUsuario(int? usuID)
        {
            //Se resetea intentos en la Tabla Login MO1 Ingreso Seguridad
            Cgestion_seguridad_ingreso ingreso = new Cgestion_seguridad_ingreso();
            

            if (usuID.HasValue)
            {
                try
                {
                    PersistenciaUsuario p = new PersistenciaUsuario();
                    AgregarUsuario  usuario = new AgregarUsuario(p.consultarUsuario(usuID.Value));
                    ingreso.correoCampoTexto = usuario.correoUsuario;//Metodo M01_Ingreso_Seguridad
                    p = new PersistenciaUsuario();
                    List<ListaRoles> lista = p.ListarRoles();
                    ViewBag.Roles = new SelectList(lista, "rolID", "rolNombre");
                    ingreso.ResetearIntentos();//Metodo M01_Ingreso_Seguridad
                    return PartialView("M12_ModificarUsuario", usuario);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    Response.End();
                    return Json(ex.Message);
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
                TempData["message"] = RecursoUsuario.MensajeEliminado;
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

        public RedirectToRouteResult CambiarStatus(int usuID, string activo)
        {
            try
            {
                PersistenciaUsuario p = new PersistenciaUsuario();
                p.CambiarStatus(usuID, activo);
                TempData["message"] = RecursoUsuario.MensajeStatus;
            }
            catch (ExceptionM12Reserva ex)
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