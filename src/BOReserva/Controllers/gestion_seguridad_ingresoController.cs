using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Models.gestion_usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;


namespace BOReserva.Content.Controllers
{
    public class gestion_seguridad_ingresoController : Controller
    {
        //
        // GET: /gestion_seguridad_ingreso/

           
        [HttpPost]
        public ActionResult M01_Login(string correo, string contraseña)
        {
            Cgestion_seguridad_ingreso ingreso = new Cgestion_seguridad_ingreso();
            TempData["Correo"] = correo;
            TempData["Contraseña"] = contraseña;
            if (correo.Equals("") && contraseña.Equals(""))
            {
                TempData["CorreoVacio"] = "Debe ingresar su correo";
                TempData["ContraseñaVacio"] = "Debe ingresar su contraseña";
                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }
            else if (correo.Equals(""))
            {
                TempData["CorreoVacio"] = "Debe ingresar su correo";
                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }
            else if (contraseña.Equals(""))
            {
                TempData["ContraseñaVacio"] = "Debe ingresar su contraseña";
                return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
            }
            try
            {
           
                System.Diagnostics.Debug.WriteLine("Correo " + correo + " contrasena " + contraseña);
                ingreso = ingreso.verificarUsuario(correo, contraseña);

                if (ingreso.EstaActivo())
                {
                    if (ingreso.VerificarIntentos())
                    {

                        ingreso.ResetearIntentos();
                        Session["Cgestion_seguridad_ingreso"] = ingreso;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ingreso.BloquearUsuario();
                        
                    }
                }
              
            }
            catch (Cvalidar_usuario_Exception e)
            {
                TempData["Mensaje"] = e.Message;
            }
            catch (Cvalidar_bloqueo_exception e)
            {
                ingreso.BloquearUsuario();
                TempData["Mensaje"] = e.Message;
            }
            catch (Cvalidar_status_exception e)
            {
                TempData["Mensaje"] = e.Message;
            }
            catch (SqlException)
            {
                TempData["Mensaje"] = "Conexion fallida a Base de Datos Contacte Administrador";
            }
            catch (Exception e) { } 
            return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
        }


   

        public ActionResult M01_Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }




        public ActionResult M01_Login()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return PartialView(model);
        }

        //public ActionResult M01_RecuperarContrasenna()
        //{
        //    Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
        //    return PartialView(model);
        //}

        public ActionResult M01_Landing()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return View("M01_Landing", "~/Views/Shared/_Layout.cshtml",model);
        }


         
    }
}
