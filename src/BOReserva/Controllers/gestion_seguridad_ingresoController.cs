using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Models.gestion_usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using log4net;
using log4net.Config;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;

namespace BOReserva.Controllers
{
    public class gestion_seguridad_ingresoController : Controller
    {
        //
        // GET: /gestion_seguridad_ingreso/

        private static readonly ILog logger = LogManager.GetLogger(typeof(gestion_seguridad_ingresoController));

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
                ingreso = ingreso.verificarUsuario(correo, contraseña);
               

                if (ingreso.EstaActivo())
                {
                    if (ingreso.VerificarIntentos())
                    {
                        ingreso.ResetearIntentos();
                        Session["Cgestion_seguridad_ingreso"] = ingreso;
                        System.Diagnostics.Debug.WriteLine("Logueado con ID: " + IDUsuarioActual());
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                            ingreso.BloquearUsuario();
                        
                    }
                }
              
            }
            catch(ExceptionReserva e)
            {
                TempData["Mensaje"] = e.Message;
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
            catch (SqlException e)
            {
                TempData["Mensaje"] = "Conexion fallida a Base de Datos Contacte Administrador";
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = "Otra excepcion: " + e.Message;
            } 
            return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
        }

        public ActionResult M01_Logout()
        {
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                " Cierre de sesión del usuario: " + UsuarioActual().correo, 
                System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        #region Metodos Estaticos

        public static Usuario UsuarioActual()
        {
            var estado_sesion = System.Web.HttpContext.Current.Session["Cgestion_seguridad_ingreso"] as Cgestion_seguridad_ingreso;
            if (estado_sesion != null)
            {
                var respuesta = new Usuario()
                {
                    id = estado_sesion.idUsuario,
                    rol = estado_sesion.rolUsuario,
                    nombre = estado_sesion.nombreUsuarioTexto,
                    apellido = estado_sesion.apellidoUsuarioTexto,
                    correo = estado_sesion.correoCampoTexto
                };
                return respuesta;
            }
            else
            {
                return null;
            }
        }

        public static int IDUsuarioActual()
        {
            var estado_sesion = System.Web.HttpContext.Current.Session["Cgestion_seguridad_ingreso"] as Cgestion_seguridad_ingreso;
            if (estado_sesion != null)
            {
                return estado_sesion.idUsuario;
            }
            else
            {
                return -1;
            }
        }

        public static int IDRolUsuarioActual()
        {
            var estado_sesion = System.Web.HttpContext.Current.Session["Cgestion_seguridad_ingreso"] as Cgestion_seguridad_ingreso;
            if (estado_sesion != null)
            {
                return estado_sesion.rolUsuario;
            }
            else
            {
                return -1;
            }
        }

        #endregion

    }
}
