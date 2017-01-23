using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Sesion;
using System.Data.SqlClient;
using FOReserva.Servicio;
using Newtonsoft.Json;

using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.Domain;
using System.Net;

namespace FOReserva.Controllers
{
    public class registro_autenticacionController : Controller
    {
        public String nombre;
        public String apellido;
        public String correo;
        public String clave;
        public int id;
        public String fCreacion;

        public ActionResult Registro()
        {
            if (Session["usuario_almacenado"] != null)
            {
                Session.Remove("usuario_almacenado");
                ViewData["msg"] = "No Se ha registrado con exito :(";
            }
            return PartialView();
        }

        public ActionResult Login()
        {

            if (Session["usuario_almacenado"] != null)
            {
                Session.Remove("usuario_almacenado");
                ViewData["msg"] = "Se ha registrado con exito :)";
            }
            return PartialView();
        }


        public ActionResult guardarUsuario(CAgregarUsuario model)
        {
            Entidad nuevoUsuario = FabricaEntidad.InstanciarUsuario(model.Nombre, model.Apellido, model.Correo, model.Clave0,
                                                                    Int32.Parse(model.PreguntaRespuesta0.Pregunta), model.PreguntaRespuesta0.Respuesta,
                                                                    Int32.Parse(model.PreguntaRespuesta1.Pregunta), model.PreguntaRespuesta1.Respuesta,
                                                                    Int32.Parse(model.PreguntaRespuesta2.Pregunta), model.PreguntaRespuesta2.Respuesta);

            Command<String> comando2 = FabricaComando.crearM14AgregarUsuario(nuevoUsuario);
            if (comando2.ejecutar() == "1")
            {
                Session["usuario_almacenado"] = true;
                return RedirectToAction("Login", this);
            }
            //aqui va un mensaje de error de que ya existe el correo
            ViewData["msg"] = "El correo ya existe";
            Session["usuario_almacenado"] = false;
            return RedirectToAction("Registro", this);
        }

        [HttpPost]
        public ActionResult consultarUsuarioLogin(CAgregarUsuario model)
        {

            Entidad nuevoUsuario = FabricaEntidad.InstanciarUsuario(model.Nombre, model.Apellido, model.Correo, model.Clave0,
                                                                    Int32.Parse(model.PreguntaRespuesta0.Pregunta), model.PreguntaRespuesta0.Respuesta,
                                                                    Int32.Parse(model.PreguntaRespuesta1.Pregunta), model.PreguntaRespuesta1.Respuesta,
                                                                    Int32.Parse(model.PreguntaRespuesta2.Pregunta), model.PreguntaRespuesta2.Respuesta);
            //con la fabrica instancie al usuario.
            Command<String> comando = FabricaComando.M14VerificarCorreo(nuevoUsuario);
            if (comando.ejecutar() == "1")
            {

                Session["usuario_almacenado"] = true;
                return RedirectToAction("Registro", this);

            }

            ViewData["msg"] = "correo o contraseña invalida";
            Session["usuario_almacenado"] = false;
            return RedirectToAction("Registro", this);



        }

        [HttpPost]
        public ActionResult Login(Usuario1 cliente)
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (cliente.correo.Contains("=") || cliente.correo.Contains("'"))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }
            else if (cliente.clave0.Contains("=") || cliente.clave0.Contains("'"))
            {
                ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                return View();
            }

            else if (cliente.clave0.Length < 6)
            {
                ViewData["error"] = "Error, clave menor a 6."; ; // clave < 6
                return View(cliente);
            }
            else
            {
                try
                {
                    Session["sesion_activa"] = "sesion_activa";
                    Session["id_usuario"] = cliente.id;
                    Session["correo"] = cliente.correo;
                    Session["nombre"] = cliente.nombre;
                    Session["apellido"] = cliente.apellido;
                    Session["clave"] = cliente.clave0;

                    Entidad _cliente = FabricaEntidad.InstanciarUsuario(cliente);
                    Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosAutenticacion(FabricaComando.comandosGeneralesAutenticacion.INICIARSESION, _cliente);

                    Command<Entidad> comando2 = (Command<Entidad>)FabricaComando.comandosAutenticacion(FabricaComando.comandosGeneralesAutenticacion.BUSCARUSUARIO, _cliente);


                    if (comando.ejecutar())
                    {

                        Entidad usu = comando2.ejecutar();

                        Session["nombre"] = ((Usuario1)usu).nombre;
                        Session["apellido"] = ((Usuario1)usu).apellido;

                        //return (Json(true, JsonRequestBehavior.AllowGet));
                        return RedirectToAction("Perfil", "registro_autenticacion");
                        //return RedirectToAction("Perfil", this);
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        string error = "Error modificando al iniciar sesion.";
                        return Json(error);
                    }
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
                    ViewData["error"] = "Error, al conectarse a la BD";
                    return View(cliente);
                }
                catch (Exception e)
                {
                    ViewData["error"] = "Error, al conectarse a la BD";
                    return View(cliente);
                }
            }

            return RedirectToAction("Perfil", "registro_autenticacion");
        }


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
                    Usuario1 cliente = new Usuario1();
                    cliente.id = Int32.Parse(Session["id_usuario"].ToString());
                    cliente.nombre = Request.Form["nombre"];
                    cliente.apellido = Request.Form["apellido"];
                    cliente.codigo_area = Request.Form["cod-telefono"];
                    cliente.telefono = Request.Form["num-telefono"];
                    cliente.genero = Request.Form["genero"];
                    cliente.correo = Session["correo"].ToString();

                    Entidad _cliente = FabricaEntidad.InstanciarUsuario(cliente);
                    Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosAutenticacion(FabricaComando.comandosGeneralesAutenticacion.ACTUALIZAR, _cliente);

                    if (comando.ejecutar())
                    {
                        //return (Json(true, JsonRequestBehavior.AllowGet));
                        //return Json(1);
                        return RedirectToAction("Perfil", this);
                    }
                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        string error = "Error modificando el perfil.";
                        return Json(error);
                    }

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

        // vista - 9
        public ActionResult VerPerfil()
        {

            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                String correo = Session["correo"].ToString();

                Entidad _cliente = FabricaEntidad.InstanciarUsuario(correo);
                Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosAutenticacion(FabricaComando.comandosGeneralesAutenticacion.BUSCARUSUARIO, _cliente);

                Entidad usu = comando.ejecutar();


                ViewData["Nombre"] = ((Usuario1)usu).nombre;
                ViewData["Apellido"] = ((Usuario1)usu).apellido;
                ViewData["Genero"] = ((Usuario1)usu).genero;
                ViewData["Codigo_Area"] = ((Usuario1)usu).codigo_area;
                ViewData["Telefono"] = ((Usuario1)usu).telefono;
                ViewData["Correo"] = ((Usuario1)usu).correo;

                Session["nombre"] = ((Usuario1)usu).nombre;
                Session["apellido"] = ((Usuario1)usu).apellido;

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

        public ActionResult Perfil()
        {
            if (Session["sesion_activa"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return PartialView();
        }

        // vista - 7
        public ActionResult CerrarSesion()
        {

            Session.Clear();

            return RedirectToAction("Login", "registro_autenticacion");
        }



        // vista - 2
        [AllowAnonymous]
        public ActionResult ResponderPreguntas()
        {
            if (Session["sesion_activa"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (Request.HttpMethod == "POST")
            {
                if (Request.Form["value_pregunta"].Contains("'") || Request.Form["value_pregunta"].Contains("="))
                {
                    ViewData["error"] = "Error, caracteres no permitidos."; // sin comillas simples ni simbolo de igualdad
                    return RedirectToAction("Login", "registro_autenticacion");
                }

                try
                {
                    //_manejador.ValidarPreguntaRespuesta(Int32.Parse(Session["id_usuario_ref"].ToString()), Session["value_pregunta"].ToString(), Request.Form["respuesta"]);
                }
                catch (RespuestaErroneaException e)
                {
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
                        //_manejador.CambiarClave(Int32.Parse(Session["id_usuario_ref"].ToString()), Request.Form["clave0"]);
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





        [HttpPost]
        public ActionResult BuscarIdPregunta()
        {
            Dictionary<string, string> mapa = new Dictionary<string, string>();
            if (Request.Form["correo"].Contains("'") || Request.Form["correo"].Contains("="))
            {
                mapa["error"] = "Error, caracteres no permitidos.";
                return RedirectToAction("OlvidarClave", this);
            }
            try
            {
                //mapa = _manejador.BuscarIdPregunta(Request.Form["correo"]); // devuelve id_usuario && value_pregunta(random)
            }
            catch (ExisteUsuarioCorreoException e)
            {
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
                        //_manejador.CambiarClave(int.Parse(Session["id_usuario"].ToString()), Request.Form["clave0"]);
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
        //----------------------------------------------fIN Sin patrones--------------------------------






    }




}