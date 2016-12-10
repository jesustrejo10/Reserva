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
                // contraseña = Encriptar.CrearHash(contraseña);
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
                        TempData["Mensaje"] = "Su usuario ha sido bloqueado. Por favor contacte al administrador.";
                        return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
                    }
                }
                else
                {
                    TempData["Mensaje"] = "Su usuario ha sido bloqueado. Por favor contacte al administrador.";
                    return RedirectToAction("M01_Login", "gestion_seguridad_ingreso");
                }
            }
            catch (Cvalidar_usuario_Exception e)
            {
                TempData["Mensaje"] = e.Message;
            }
            catch (SqlException)
            {
                TempData["Mensaje"] = "Conexion fallida a Base de Datos Contacte Administrador";
            }
            catch (Exception e) { } //exception importante cuando haya problemas con la bd de no conexion colocan un mensaje error de bases de datos 
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

        public ActionResult M01_RecuperarContrasenna()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return PartialView(model);
        }

        public ActionResult M01_Landing()
        {
            Cgestion_seguridad_ingreso model = new Cgestion_seguridad_ingreso();
            return View("M01_Landing", "~/Views/Shared/_Layout.cshtml",model);
        }
















        //
        // GET: /gestion_seguridad_ingreso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /gestion_seguridad_ingreso/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /gestion_seguridad_ingreso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /gestion_seguridad_ingreso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /gestion_seguridad_ingreso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
