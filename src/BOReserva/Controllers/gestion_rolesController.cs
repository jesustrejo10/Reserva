using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;
using BOReserva.Servicio;
using System.Net;
using Newtonsoft.Json.Linq;

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
            rol.Menu = sql.consultarLosModulos();

            return PartialView(rol);
        }
        /// <summary>
        /// Metodo para llamar la vista parcial M13_VisualizarRol
        /// <returns>returna la lista de roles</returns>
        public ActionResult M13_VisualizarRol()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CRoles> listaroles = sql.consultarListaroles();

            return PartialView(listaroles);
        }
        
        /// <summary>
        /// Metodo para llamar la vista parcial M13_ModificarRol
        /// </summary>
        /// <param name="_rolnombre">pasa el nombre del rol</param>
        /// <returns>Devuelve el objeto del Tipo CRoles</returns>
        public ActionResult M13_ModificarRol(string _rolnombre)
        {

            manejadorSQL sql = new manejadorSQL();
            CRoles _rol = new CRoles();
            _rol.Nombre_rol = _rolnombre;
            _rol.Permisos = sql.consultarLosPermisosAsignados(_rol);

           
            return PartialView(_rol);
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
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //Realizo el insert y Guardo la respuesta de mi metodo sql en un bool
            bool respuesta= sql.insertarRol(model);
            //envio una respuesta dependiendo del resultado del insert
            return (Json(respuesta, JsonRequestBehavior.AllowGet));

        
        }
        //Metodo para modifcar nombre roles
        [HttpPost]
        public JsonResult modificarrol(string rol, string nombrerolnuevo)
        {


            if (rol == null && nombrerolnuevo == null)
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
            //Realizo el insert y Guardo la respuesta de mi metodo sql en un bool
            bool respuesta = sql.ModificarrRol(rol, nombrerolnuevo);
            //envio una respuesta dependiendo del resultado del insert
            return (Json(respuesta, JsonRequestBehavior.AllowGet));


        }
        //Metodo para asignar permisos a los roles
        [HttpPost]
        public JsonResult asignarpermisos(string json)
        {

            manejadorSQL sql = new manejadorSQL();

            CListaGenerica<CModulo_detallado> listaPermisosAsignar = new CListaGenerica<CModulo_detallado>();

            // creo un item para guardar el Json 
            var _permisos=JArray.Parse(json);


            // Si es mayor que uno , Significa que hay al menos un permiso 
            if (_permisos.Count() >= 1) {

                for (int i=1; i < _permisos.Count(); i++)
                {

                    sql.insertarPermisosRol(_permisos[0].ToString(), _permisos[i].ToString());

                }
                    
            }
                       
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
            //Realizo el consulto y Guardo la respuesta de mi metodo sql 
            //sql.consultarPermisos(_permisos);
 
            //envio el resultado de la consulta
            return (Json(true, JsonRequestBehavior.AllowGet));

        }
        //Metodo para Eliminar permiso a un Rol
        [HttpPost]
        public JsonResult quitarPermisoRol(string _nombrerol, string _nombrepermiso)
        {
            CRoles model = new CRoles();
            model.Nombre_rol = _nombrerol;
            CModulo_detallado permiso = new CModulo_detallado();
            permiso.Nombre = _nombrepermiso;
            //Verifico que todos los campos no sean nulos
            if (model.Nombre_rol == null || permiso.Nombre== null)
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
            //Elimino y Guardo la respuesta de mi metodo sql en un bool
            bool respuesta = sql.quitarPermisoRol(model,permiso);
            //envio una respuesta dependiendo del resultado sql
            return (Json(respuesta, JsonRequestBehavior.AllowGet));


        }       
        //Metodo para Eliminar roles
        [HttpPost]
        public JsonResult eliminarRol(string _nombrerol)
        {
            CRoles model = new CRoles();
            model.Nombre_rol = _nombrerol;

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
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //Elimino y Guardo la respuesta de mi metodo sql en un bool
            bool respuesta = sql.eliminarRol(model);
            //envio una respuesta dependiendo del resultado sql
            return (Json(respuesta, JsonRequestBehavior.AllowGet));


        }
        //Metodo para consultar permisos de modulo
        [HttpPost]
        public JsonResult Consultarpermisos(string json)
        {
            // creo un item para guardar el Json 
            dynamic _item = JObject.Parse(json);
            //guardo el primer argumento del json en una variable
            var _temp = _item.mod;
            //convierto el objeto json en string
            String modulo = _temp.ToString().Trim();
            //Verifico que todos los campos no sean nulos
            if (modulo == null)
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
            //instancio mi clase modulo general
            CListaGenerica<CModulo_detallado> permisos = new CListaGenerica<CModulo_detallado>();
            //coloco el nombre
            
            //Realizo el consulto y Guardo la respuesta de mi metodo sql 
             permisos = sql.consultarPermisos(modulo);
             var _nombrePermiso = new List<object>();
             foreach (var permiso in permisos)
             {
                 _nombrePermiso.Add(permiso.Nombre);
             }
            //envio el resultado de la consulta
             return (Json(_nombrePermiso, JsonRequestBehavior.AllowGet));
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
            //Realizo la consulta y Guardo la respuesta de mi metodo sql 
            _permisos = sql.consultarLosPermisosNoAsignados(_rol);
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