using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Sesion;
using System.Data.SqlClient;
using FOReserva.Servicio;
using Newtonsoft.Json;

namespace FOReserva.Controllers
{
    public class registro_autenticacionController : Controller
    {
        ManejadorSQLSesion _manejador = new ManejadorSQLSesion();
        // vista - 0
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Session["vista"] != null && Session["vista"].ToString() == "4")
            { // si entra, viene de registro (4).
                ViewData["error"] = "Ha sido registrado sin problema.";
                Session.Remove("vista");
            }
            else if (Session["vista"] != null && Session["vista"].ToString() == "3")
            { // si entra, viene de registro (3).
                ViewData["error"] = "Su clave ha sido cambiada correctamente.";
                Session.Remove("vista");
            }


            return View();
        }

        // vista - 1
        [AllowAnonymous]
        public ActionResult Registro()
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["error"] = null;
            return View();
        }

        // vista - 2
        [AllowAnonymous]
        public ActionResult ResponderPreguntas()
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Request.HttpMethod == "POST") {
                if (Request.Form["value_pregunta"].Contains("'") || Request.Form["value_pregunta"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Login", "registro_autenticacion");
                }

                try
                {
                    _manejador.ValidarPreguntaRespuesta(Int32.Parse(Session["id_usuario_ref"].ToString()), Session["value_pregunta"].ToString(), Request.Form["respuesta"]);
                }
                catch (RespuestaErroneaException e) {
                    Session["error"] = "Error, la respuesta es incorrecto.";
                    return RedirectToAction("OlvidarClave", this);
                }
                catch (SqlException e)
                {
                    Session["error"] = "Error, a la conectarse a la BD.";
                    return RedirectToAction("OlvidarClave", this);
                }
                catch (Exception e)
                {
                    Session["error"] = "Error, a la conectarse a la BD.";
                    return RedirectToAction("OlvidarClave", this);
                }

                return RedirectToAction("CambiarClave", "registro_autenticacion");
            }
            return View();
        }

        // vista - 3
        [AllowAnonymous]
        public ActionResult CambiarClave()
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Request.HttpMethod == "POST")
            {

                if (Request.Form["clave0"].Contains("'") || Request.Form["clave0"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; ; // sin comillas simples ni simbolo de igualdad
                    return View();
                }
                else if (Request.Form["clave1"].Contains("'") || Request.Form["clave1"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return View();
                }
                else if (!Request.Form["clave0"].Equals(Request.Form["clave1"]))
                {
                    ViewData["error"] = "Error, las claves no coinciden."; // las claves no coinciden
                    return View();
                }
                else
                {
                    try
                    {
                        _manejador.CambiarClave(Int32.Parse(Session["id_usuario_ref"].ToString()), Request.Form["clave0"]);
                    }
                    catch (SqlException e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        ViewData["error"] = "Error, al conectarse a la BD"; // error al conectarse a la BD
                        return View();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        ViewData["error"] = "Error, al conectarse a la BD"; // error de conexion
                        return View();
                    }
                }
                Session.Clear();
                Session["vista"] = "3";
                return RedirectToAction("Login", "registro_autenticacion"); // redireccionar inicio de sesion
            }

            return View();
        }

        // vista - 4
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registro(Ccliente cliente)
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (cliente.Nombre.Contains("'") || cliente.Nombre.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.Apellido.Contains("'") || cliente.Apellido.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.Clave0.Contains("'") || cliente.Clave0.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.Clave1.Contains("'") || cliente.Clave1.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.PreguntaRespuesta0.Respuesta.Contains("'") || cliente.PreguntaRespuesta0.Respuesta.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View(cliente);
            }
            else if (cliente.PreguntaRespuesta1.Respuesta.Contains("'") || cliente.PreguntaRespuesta1.Respuesta.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View(cliente);
            }
            else if (cliente.PreguntaRespuesta2.Respuesta.Contains("'") || cliente.PreguntaRespuesta2.Respuesta.Contains("="))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View(cliente);
            }
            else if (!cliente.Clave0.Equals(cliente.Clave1))
            {
                ViewData["error"] = "Error, las claves no coinciden."; // claves no coinciden
                return View(cliente);
            }
            else if (cliente.Clave0.Length < 6)
            {
                ViewData["error"] = "Error, las claves no pueden ser menor a 6."; // clave < 6
                return View(cliente);
            }
            else if ((cliente.Nombre.Length < 4) || (cliente.Apellido.Length < 4) || (cliente.Correo.Length < 4))
            {
                ViewData["error"] = "Error, los campos Nombre, Apellido y  Usuario deben ser mayores a 4"; // < 4
                return View(cliente);
            }

            else
            {
                try
                {
                    _manejador.ValidacionUsuarioCorreo(cliente.Correo);
                    _manejador.ValidacionRegistroCliente(cliente);
                }
                catch (SqlException e)
                {
                    ViewData["error"] = "error en la conexion con la BD"; // error en la conexion con la BD 
                    return View();
                }
                catch (ExisteUsuarioCorreoException e)
                {
                    ViewData["error"] = "Error, el correo ya existe."; // Error SI existe usuario
                    return View();
                }
                catch (Exception e)
                {
                    ViewData["error"] = "error en la conexion con la BD"; // error en la conexion con la BD
                    return View();
                }

                Session["vista"] = "4";
                return RedirectToAction("Login", "registro_autenticacion");
            }
        }

        // vista - 5
        [HttpPost]
        public ActionResult Login(Ccliente cliente)
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (cliente.Correo.Contains("=") || cliente.Correo.Contains("'"))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.Clave0.Contains("=") || cliente.Clave0.Contains("'"))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }

            else if (cliente.Clave0.Length < 6)
            {
                ViewData["error"] = "Error, clave menor a 6."; ; // clave < 6
                return View(cliente);
            }
            else
            {
                try
                {
                    cliente = _manejador.ValidacionLogin(cliente);
                    Session["sesion_activa"] = "sesion_activa";
                    Session["id_usuario"] = cliente.Id;
                    Session["correo"] = cliente.Correo;
                    Session["nombre"] = cliente.Nombre;
                    Session["apellido"] = cliente.Apellido;
                }
                catch (ExisteUsuarioCorreoException e)
                {
                    ViewData["error"] = "Error, el correo no esta registrado."; // Error NO existe usuario
                    return View(cliente);
                }
                catch (ClavesDiferentesException e)
                {
                    ViewData["error"] = "Error, el al ingresar la clave."; // Error NO existe usuario
                    return View(cliente);
                }
                catch (SqlException e)
                {
                    ViewData["error"] = "Error, al conectarse a la BD.";
                    return View(cliente);
                }
                catch (Exception e)
                {
                    ViewData["error"] = "Error, al conectarse a la BD.";
                    return View(cliente);
                }
            }

            return RedirectToAction("Perfil", "registro_autenticacion");
        }

        // vista - 6
        [HttpPost]
        public ActionResult BuscarIdPregunta()
        {
            Dictionary<string, string> mapa = new Dictionary<string, string>();
            if (Request.Form["correo"].Contains("'") || Request.Form["correo"].Contains("=")) {
                mapa["error"] = "Error, caracteres no permitidos.";
                return RedirectToAction("OlvidarClave", this);
            }
            try
            {
                mapa = _manejador.BuscarIdPregunta(Request.Form["correo"]); // devuelve id_usuario && value_pregunta(random)
            }
            catch (ExisteUsuarioCorreoException e) {
                Session["error"] = "Error, el usuario no se encuentra registrado."; // el usuario no se encuentra registrado
                return RedirectToAction("OlvidarClave", this);
            }
            catch (SqlException e)
            {
                Session["error"] = "Error, al conectarse a la BD"; // Error al conectarse a la BD
                return RedirectToAction("OlvidarClave", this);
            }
            catch (Exception e)
            {
                Session["error"] = "Error, al conectarse a la BD"; // Error al conectarse a la BD
                return RedirectToAction("OlvidarClave", this);
            }

            Session["value_pregunta"] = mapa["value_pregunta"];
            Session["id_usuario_ref"] = mapa["id_usuario"];
            Session["correo_ref"] = Request.Form["correo"];
            return RedirectToAction("ResponderPreguntaSeguridad", this);
        }

        //******************************************************
        //******************************************************
        //******************************************************

        // vista - 7
        public ActionResult CerrarSesion()
        {

            Session.Clear();

            return RedirectToAction("Login", "registro_autenticacion");
        }

        // vista - 8
        public ActionResult Perfil()
        {
            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView();
        }

        // vista - 9
        public ActionResult VerPerfil()
        {

            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Ccliente cliente = new Ccliente();
                cliente.Correo = Session["correo"].ToString();

                _manejador.ObtenerCliente(cliente);

                ViewData["Nombre"] = cliente.Nombre;
                ViewData["Apellido"] = cliente.Apellido;
                ViewData["Genero"] = cliente.Genero;
                ViewData["Codigo_Area"] = cliente.Codigo_Area;
                ViewData["Telefono"] = cliente.Telefono;
                ViewData["Correo"] = cliente.Correo;
            }
            catch (ExisteUsuarioCorreoException e)
            {
                ViewData["error"] = "No existe el usuario";
                return RedirectToAction("Perfil", this);
            }
            catch (SqlException e)
            {
                ViewData["error"] = "Error, al conectarse a la BD."; // Error al conectarse a la BD
                return RedirectToAction("Perfil", this);
            }
            catch (Exception e)
            {
                ViewData["error"] = "Error, al conectarse a la BD."; // Error al conectarse a la BD
                return RedirectToAction("Perfil", this);
            }

            return PartialView();
        }

        // vista - 10
        public ActionResult EditarPerfil()
        {
            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Request.HttpMethod == "POST" && Session["id_usuario"] != null)
            {

                if (Request.Form["nombre"].Contains("'") || Request.Form["nombre"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["apellido"].Contains("'") || Request.Form["apellido"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["cod-telefono"].Contains("'") || Request.Form["cod-telefono"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["num-telefono"].Contains("'") || Request.Form["num-telefono"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["genero"].Contains("'") || Request.Form["genero"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["nombre"].Length < 4 || Request.Form["apellido"].Length < 4 || Request.Form["num-telefono"].Length != 7)
                {
                    ViewData["error"] = "Error, al ingresar los caracteres."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }

                try
                {
                    Ccliente cliente = new Ccliente();
                    cliente.Id = Int32.Parse(Session["id_usuario"].ToString());
                    cliente.Nombre = Request.Form["nombre"];
                    cliente.Apellido = Request.Form["apellido"];
                    cliente.Codigo_Area = Request.Form["cod-telefono"];
                    cliente.Telefono = Request.Form["num-telefono"];
                    cliente.Genero = Request.Form["genero"];
                    cliente.Correo = Session["correo"].ToString();
                    _manejador.EditarCliente(cliente);
                }
                catch (SqlException e)
                {
                    ViewData["error"] = "Error, al conectarse a la BD."; // Error al conectarse a la BD
                    return RedirectToAction("Perfil", this);
                }
                catch (Exception e)
                {
                    ViewData["error"] = "Error, al conectarse a la BD."; // Error al conectarse a la BD
                    return RedirectToAction("Perfil", this);
                }
            }
            return RedirectToAction("Perfil", this);
        }

        // vista - 11
        public ActionResult CambiarClavePerfil()
        {
            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["clave0"].Contains("'") || Request.Form["clave0"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (Request.Form["clave1"].Contains("'") || Request.Form["clave1"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Perfil", this);
                }
                else if (!Request.Form["clave0"].Equals(Request.Form["clave1"]))
                {
                    ViewData["error"] = "Error, Las claves no coinciden."; // Error, Las claves no coinciden.
                    return RedirectToAction("Perfil", this);
                }
                else
                {
                    try
                    {
                        _manejador.CambiarClave(int.Parse(Session["id_usuario"].ToString()), Request.Form["clave0"]);
                    }
                    catch (SqlException e)
                    {
                        ViewData["error"] = "Error, al conectarse a la BD."; // Error, al conectarse a la BD.
                        return RedirectToAction("Perfil", this);
                    }
                    catch (Exception e)
                    {
                        ViewData["error"] = "Error, al conectarse a la BD."; // Error, al conectarse a la BD.
                        return RedirectToAction("Perfil", this);
                    }
                    ViewData["error"] = "Clave cambiada correctamente.";
                    return RedirectToAction("Perfil", this);
                }
            }
            return PartialView();
        }

        // vista - 12
        public ActionResult OlvidarClave()
        {
            if (Session["error"] != null)
            {
                ViewData["error"] = Session["error"];
                Session.Clear();
            }
            return PartialView();
        }

        // vista - 13
        public ActionResult ResponderPreguntaSeguridad()
        {

            if (Session["valuePregunta"] != null || Session["valuePregunta"] != null)
            {
                return RedirectToAction("OlvidarClave", this);
            }

            System.Diagnostics.Debug.WriteLine("valuePregunta: " + Session["value_pregunta"]);
            System.Diagnostics.Debug.WriteLine("id_usuario_ref: " + Session["id_usuario_ref"]);

            return PartialView();
        }

    }
}
