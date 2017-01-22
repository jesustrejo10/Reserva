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
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        /// <summary>
        /// Metodo para llamar la vista parcial M13_AgregarRol
        /// </summary>
        /// <returns>return un objeto de tipo CRoles</returns>
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
        /// <returns>returna la lista de roles</returns>
        public ActionResult M13_VisualizarRol()
        {
            List<Entidad> listaroles;
            //List<Entidad> listapermisos;
            //List<Entidad> listamodulos;
            try
            {
                Command<List<Entidad>> comando = FabricaComando.crearM13_ConsultarRoles();
                listaroles = comando.ejecutar();

                foreach(Rol rol in listaroles)
                {
                    Command<List<Entidad>> comando_permisos = FabricaComando.crearM13_ConsultarPermisos(rol._idRol);
                    rol.listapermisos = comando_permisos.ejecutar();
                    //foreach (Permiso permiso in rol.listapermisos)
                    //{
                    //    Command<Entidad> comando_modulos = FabricaComando.crearM13_ConsultarModulos(permiso._id);
                    //    permiso.modulo = (Modulo)comando_modulos.ejecutar();
                    //}
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
            //CModulo_detallado entrada = new CModulo_detallado();
            //CRoles _rol = new CRoles();
            //_rol.Id_Rol = _idRol;
            //manejadorSQL sql = new manejadorSQL();
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
                //_rol.Permisos = sql.consultarLosPermisosAsignados(_rol);
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
        //Metodo para agregar roles
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
        //Metodo para modifcar nombre roles
        [HttpPost]
        public JsonResult modificarrol(CRoles model)
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
                Entidad modificarRol = FabricaEntidad.InstanciarRolId(model);
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
        //Metodo para asignar permisos a los roles
        [HttpPost]
        public JsonResult asignarpermisos(string json)
        {

            //manejadorSQL sql = new manejadorSQL();
            String agrego_si_no = null;

            CListaGenerica<CModulo_detallado> listaPermisosAsignar = new CListaGenerica<CModulo_detallado>();

            // creo un item para guardar el Json 
            var _permisos=JArray.Parse(json);

                       
            //La posicion 0 devolvera el Rol a insertar

            //Verifico que todos los campos no sean nulos
            if (_permisos == null)
            {
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error               
                String error = "Error, campo obligatorio vacio";
                //Retorno el error                
                return Json(error);
            }
            
            //La posicion 0 devolvera el Rol a insertar
            // Si es mayor que uno , Significa que hay al menos un permiso 
            try{
            if (_permisos.Count() >= 1) {

                for (int i=1; i < _permisos.Count(); i++)
                {
                    Entidad nuevoRol = FabricaEntidad.InstanciarRolPermiso(_permisos[0].ToString(), _permisos[i].ToString());
                    Command<String> comando = FabricaComando.crearM13_AgregarRolPermiso(nuevoRol);
                    agrego_si_no = comando.ejecutar(); 
                    //sql.insertarPermisosRol(_permisos[0].ToString(), _permisos[i].ToString());
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

        //Metodo para Eliminar permiso a un Rol
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
        //Metodo para Eliminar roles
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
        //Metodo para consultar permisos de modulo
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

        //Metodo para consultar permisos que no tiene asignado el rol
        [HttpPost]
        public JsonResult consultarLosPermisosNoAsignados(string nombre_rol)
        {
            //Verifico que todos los campos no sean nulos
            if (nombre_rol == null)
            {
                //Creo el codigo de error de respuesta
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error               
                String error = "Error, campo obligatorio vacio";
                //Retorno el error                
                return Json(error);
            }
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            
            //Instancio y coloco el nombre en el objeto
            CRoles _rol = new CRoles();
            _rol.Nombre_rol = nombre_rol;
            //Instancio y coloco el nombre en el objeto
            CListaGenerica<CModulo_detallado> _permisos= new CListaGenerica<CModulo_detallado>();
            try{
            //Realizo la consulta y Guardo la respuesta de mi metodo sql 
            _permisos = sql.consultarLosPermisosNoAsignados(_rol);
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
            var _nombrePermiso = new List<object>();
            foreach (var permiso in _permisos)
            {
                _nombrePermiso.Add(permiso.Nombre);

            }
            //envio el resultado de la consulta
            return (Json(_nombrePermiso, JsonRequestBehavior.AllowGet));
        }

	}
}