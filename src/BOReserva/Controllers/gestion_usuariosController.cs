using BOReserva.Models.gestion_usuarios;
using BOReserva.Models.gestion_seguridad_ingreso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace BOReserva.Controllers
{
    public class gestion_usuariosController : Controller
    {
        public static int _rol;
        public static int idUsuario;

        /// <summary>
        /// Método de la vista parcial M12_AgregarUsuario2
        /// </summary>
        /// <returns>Retorna la vista parcial M12_AgregarUsuario2 en conjunto del Modelo de dicha vista</returns>
        public ActionResult M12_AgregarUsuario2()
        {
            try
            {
                CAgregarUsuario model = new CAgregarUsuario();
                
                Command<List<Entidad>> comandrol = FabricaComando.crearM13_ConsultarRoles();
                List<Entidad> roles = comandrol.ejecutar();
                ViewBag.Roles = new SelectList(roles, "_idRol", "_nombreRol");

                return PartialView(model);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.End();
                return Json(ex.Message);
            }

        }

        [HttpPost]
        public JsonResult guardarUsuario(CAgregarUsuario model)
        {
            Entidad nuevoUsuario = FabricaEntidad.InstanciarUsuario(model, model._rol);
            Command<string> comando = FabricaComando.crearM12AgregarUsuario(nuevoUsuario);
            string agrego = comando.ejecutar();

            return (Json(agrego));
        }

        /// <summary>
        /// Método de la vista parcial M12_VisualizarUsuarios
        /// </summary>
        /// <returns>Retorna la vista parcial M12_VisualizarUsuarios en conjunto del Modelo de dicha vista</returns>
        public ActionResult M12_VisualizarUsuarios()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM12VisualizarUsuarios();
            Dictionary<int, Entidad> listaUsuarios = comando.ejecutar();

            return PartialView(listaUsuarios);
        }


        public ActionResult M12_DetalleUsuario(int id)
        {
            Command<Entidad> comando = FabricaComando.crearM12ConsultarUsuario(id);
            Entidad usuario = comando.ejecutar();
            Usuario usuarioBuscado = (Usuario) usuario;
            idUsuario = usuarioBuscado._id;

            CModificarUsuario modelovista = new CModificarUsuario();
            modelovista._correo = usuarioBuscado.correo;
            modelovista._nombre = usuarioBuscado.nombre;
            modelovista._apellido = usuarioBuscado.apellido;
            modelovista.contraseñaUsuario = usuarioBuscado.contrasena;
            modelovista._rol = usuarioBuscado.rolr._idRol;
            modelovista._activo = usuarioBuscado.activo;

            return PartialView(modelovista);
        }

        public ActionResult M12_ModificarUsuario2(int id)
        {
            Command<List<Entidad>> comandrol = FabricaComando.crearM13_ConsultarRoles();
            List<Entidad> roles = comandrol.ejecutar();
            ViewBag.Roles = new SelectList(roles, "_idRol", "_nombreRol");

            Command<Entidad> comando = FabricaComando.crearM12ConsultarUsuario(id);
            Entidad usuario = comando.ejecutar();
            Usuario usuarioBuscado = (Usuario)usuario;
            idUsuario = usuarioBuscado._id;

            CModificarUsuario modelovista = new CModificarUsuario();
            modelovista._correo = usuarioBuscado.correo;
            modelovista._nombre = usuarioBuscado.nombre;
            modelovista._apellido = usuarioBuscado.apellido;
            modelovista.contraseñaUsuario = usuarioBuscado.contrasena;
            modelovista._rol = usuarioBuscado.rolr._idRol;
            modelovista._activo = usuarioBuscado.activo;

            return PartialView(modelovista);
        }

        [HttpPost]
        public JsonResult modificarUsuario(CModificarUsuario model)
        {
            Entidad modificarUsuario = FabricaEntidad.InstanciarUsuario(model, model._rol);
            Command<string> comando = FabricaComando.crearM12ModificarUsuario(modificarUsuario, idUsuario);
            string agrego = comando.ejecutar();

            return (Json(agrego));

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


        /// <summary>
        /// Método que se utiliza para eliminar un usuario existente
        /// </summary>
        /// <param name="id">Identificador del usuario a eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult eliminarUsuario(int usuID)
        {
            Command<Entidad> comando = FabricaComando.crearM12ConsultarUsuario(usuID);
            Entidad usuario = comando.ejecutar();
            Usuario usuariobuscado = (Usuario)usuario;
            usuariobuscado._id = usuID;
            Command<String> comando1 = FabricaComando.crearM12EliminarUsuario(usuariobuscado, usuID);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
        }

        /// <summary>
        /// Método que se utiliza para cambiar el status a ACTIVO de un usuario existente
        /// </summary>
        /// <param name="id">Identificador del usuario a activar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult activarUsuario(int id, string activo)
        {
            Command<Entidad> comando = FabricaComando.crearM12ConsultarUsuario(id);
            Entidad usuario = comando.ejecutar();
            Usuario usuariobuscado = (Usuario)usuario;
            usuariobuscado._id = id;
            Command<String> comando1 = FabricaComando.crearM12StatusUsuario(usuariobuscado, activo);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
        }

        /// <summary>
        /// Método que se utiliza para cambiar el status a INACTIVA de un usuario existente
        /// </summary>
        /// <param name="id">Identificador del usuario a inactivar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult inactivarUsuario(int id, string activo)
        {
            Command<Entidad> comando = FabricaComando.crearM12ConsultarUsuario(id);
            Entidad usuario = comando.ejecutar();
            Usuario usuariobuscado = (Usuario)usuario;
            usuariobuscado._id = id;
            Command<String> comando1 = FabricaComando.crearM12StatusUsuario(usuariobuscado, activo);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
        }
        
    }
}