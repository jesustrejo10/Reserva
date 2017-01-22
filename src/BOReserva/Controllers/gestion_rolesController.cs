using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;
using BOReserva.Servicio;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace BOReserva.Controllers
{
    ///<summary>
    ///Clase que posee los controladores necesarios
    ///para el funcionamiento del modulo de roles
    ///</summary>
    ///<returns>Lista de Entidad</returns>
    public class gestion_rolesController : Controller
    {
        /// <summary>
        /// Metodo para llamar la vista parcial M13_AgregarRol
        /// </summary>
        /// <returns>La vista parcial con el modelo CRoles</returns>
        public ActionResult M13_AgregarRol()
        {
            manejadorSQL sql = new manejadorSQL();
            CRoles rol = new CRoles();
            try
            {
            rol.Permisos = sql.consultarPermisos(rol.Nombre_rol);
                                    }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            return PartialView(rol);
        }

        /// <summary>
        /// Metodo para llamar la vista parcial M13_VisualizarRol
        /// <returns>retorna la lista de roles</returns>
        public ActionResult M13_VisualizarRol()
        {
            List<Entidad> listaroles;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.crearM13_ConsultarRoles();
                listaroles = comando.ejecutar();

                foreach(Rol rol in listaroles)
                {
                    Command<List<Entidad>> comando_permisos = FabricaComando.crearM13_ConsultarPermisos(rol._idRol);
                    rol.listapermisos = comando_permisos.ejecutar();
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error consultando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            return PartialView(listaroles);
        }

        /// <summary>
        /// Metodo para llamar la vista parcial M13_ModificarRol
        /// </summary>
        /// <param name="_idRol">pasa el id del rol</param>
        /// <returns>Devuelve el objeto del Tipo CRoles</returns>
        public ActionResult M13_ModificarRol(int _idRol)
        {

            Rol rolbuscado;
            CRoles modelovista = new CRoles();
            CListaGenerica<CModulo_detallado> md = new CListaGenerica<CModulo_detallado>();
            try
            {
                Command<Entidad> comando = FabricaComando.crearM13_ConsultarRol(_idRol);
                Entidad rol = comando.ejecutar();
                rolbuscado = (Rol)rol;
                rolbuscado._id = _idRol;
                Command<List<Entidad>> comando1 = FabricaComando.crearM13_ConsultarPermisosAsignados(rolbuscado, _idRol);
                rolbuscado.listapermisos = comando1.ejecutar(); 
                foreach (Permiso item in rolbuscado.listapermisos)
                {
                    CModulo_detallado entrada = new CModulo_detallado();
                    entrada.Nombre = item._nombre;
                    entrada.Id = item._idPermiso;
                    md.agregarElemento(entrada);
                }

                modelovista.Id_Rol = rolbuscado._idRol;
                modelovista.Nombre_rol = rolbuscado._nombreRol;
                modelovista.Permisos = md;
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            return PartialView(modelovista);
        }

        ///<summary>
        ///Metodo para agregar roles
        ///</summary>
        ///<returns>JsonResult</returns>
        [HttpPost]
        public JsonResult agregarrol(CRoles model)
        {
            //Verifico que todos los campos no sean nulos
            if (model.Nombre_rol == null)
            {             
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error               
                String error = "Error, campo obligatorio vacio";
                //Retorno el error                
                return Json(error);
            }
            try
            {
                Entidad nuevoRol = FabricaEntidad.InstanciarRol(model);
                Command<String> comando = FabricaComando.crearM13_AgregarRol(nuevoRol);
                String agrego_si_no = comando.ejecutar();
                return (Json(agrego_si_no));
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }       
        }

        ///<summary>
        ///Metodo para modificar roles
        ///</summary>
        ///<returns>Lista de Entidad</returns>
        [HttpPost]
        //public JsonResult modificarrol(CRoles model)
        public JsonResult modificarrol(int id_rol, String nuevo_rol)
        {


            //if (rol == null && nombrerolnuevo == null)
            //{
            //    //Creo el codigo de error de respuesta
            //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    //Agrego mi error               
            //    String error = "Error, campo obligatorio vacio";
            //    //Retorno el error                
            //    return Json(error);
            //}
            String agrego_si_no;
            try
            {
                ////instancio el manejador de sql
                //manejadorSQL sql = new manejadorSQL();
                ////Realizo el insert y Guardo la respuesta de mi metodo sql en un bool
                //bool respuesta = sql.ModificarrRol(rol, nombrerolnuevo);
                CRoles model = new CRoles();
                model.Id_Rol = id_rol;
                model.Nombre_rol = nuevo_rol;
                Entidad modificarRol = FabricaEntidad.InstanciarRolIdNombre(model);
                //con la fabrica instancie al hotel.
                Command<String> comando = FabricaComando.crearM13_ModificarRol(modificarRol, model.Id_Rol);
                agrego_si_no = comando.ejecutar();
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            //envio una respuesta dependiendo del resultado del insert
            return (Json(true, JsonRequestBehavior.AllowGet));


        }

        ///<summary>
        ///Metodo para asignar permisos a roles
        ///</summary>
        ///<returns>JsonResult</returns>
        [HttpPost]
        public JsonResult asignarpermisos(string json)
        {
            String agrego_si_no = null;
            CListaGenerica<CModulo_detallado> listaPermisosAsignar = new CListaGenerica<CModulo_detallado>();
            var _permisos=JArray.Parse(json);
            if (_permisos == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;          
                String error = "Error, campo obligatorio vacio";           
                return Json(error);
            }
            try{
            if (_permisos.Count() >= 1) {

                for (int i=1; i < _permisos.Count(); i++)
                {
                    Entidad nuevoRol = FabricaEntidad.InstanciarRolPermiso(_permisos[0].ToString(), _permisos[i].ToString());
                    Command<String> comando = FabricaComando.crearM13_AgregarRolPermiso(nuevoRol);
                    agrego_si_no = comando.ejecutar(); 
                }
             }
                return (Json(agrego_si_no));
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
        }

        ///<summary>
        ///Metodo para eliminarle permisos a un rol
        ///</summary>
        ///<returns>String</returns>
        [HttpPost]
        public String quitarPermisoRol(int idRol)
        {
            String borro_si_no;
            try
            {
                Command<Entidad> comando = FabricaComando.crearM13_ConsultarRol(idRol);
                Entidad rol = comando.ejecutar();
                Rol rolbuscado = (Rol)rol;
                Command<List<Entidad>> comando_permisos = FabricaComando.crearM13_ConsultarPermisos(idRol);
                rolbuscado.listapermisos = comando_permisos.ejecutar();
                foreach (Permiso item in rolbuscado.listapermisos)
                {
                    Command<String> comando1 = FabricaComando.crearM13_EliminarPermisos(item._idPermiso);
                    borro_si_no = comando1.ejecutar();
                }
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return null;

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return null;
            }
            return "1";
        }

        ///<summary>
        ///Metodo para eliminar roles
        ///</summary>
        ///<returns>JsonResult</returns>
        [HttpPost]
        public JsonResult eliminarRol(int _idRol)
        {
            String borro_si_no;
            try
            {
                Command<Entidad> comando = FabricaComando.crearM13_ConsultarRol(_idRol);
                Entidad rol = comando.ejecutar();
                Rol rolbuscado = (Rol)rol;
                rolbuscado._id = _idRol;
                Command<String> comando1 = FabricaComando.crearM13_EliminarRol(rolbuscado, _idRol);
                borro_si_no = comando1.ejecutar();
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error eliminando de la BD.";
                return Json(error);

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            return (Json(borro_si_no));
        }

        ///<summary>
        ///Metodo para listar permisos
        ///</summary>
        ///<returns>JsonResult</returns>
        public JsonResult Consultarpermisos()
        {
            List<Entidad> listapermisos;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.crearM13_ListarPermisos();
                listapermisos = comando.ejecutar();
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return null;

            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return null;
            }
            var _nombrePermiso = new List<object>();
            foreach (var permiso in listapermisos)
            {
                _nombrePermiso.Add(permiso._id);
            }
            //envio el resultado de la consulta
             return (Json(listapermisos, JsonRequestBehavior.AllowGet)); ;
        }

        ///<summary>
        ///Metodo para consultar los permisos que no tiene asignado un rol
        ///</summary>
        ///<returns>JsonResult</returns>
        [HttpPost]
        public JsonResult consultarLosPermisosNoAsignados(int _idRol)
        {
            if (_idRol == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;         
                String error = "Error, campo obligatorio vacio";                
                return Json(error);
            }
            Rol rolbuscado;
            List<Entidad> listapermisos;
            try
            {
                Command<Entidad> comando = FabricaComando.crearM13_ConsultarRol(_idRol);
                Entidad rol = comando.ejecutar();
                rolbuscado = (Rol)rol;
                rolbuscado._id = _idRol;
                Command<List<Entidad>> comando1 = FabricaComando.crearM13_ConsultarPermisosNoAsociados(rolbuscado, rolbuscado._idRol);
                listapermisos = comando1.ejecutar();
            }
            catch (SqlException e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD.";
                return Json(error);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error desconocido, contacte con el administrador.";
                return Json(error);
            }
            return (Json(listapermisos, JsonRequestBehavior.AllowGet));
        }

	}
}