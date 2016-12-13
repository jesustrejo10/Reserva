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
        public ActionResult M13_AgregarRol()
        {
            manejadorSQL sql = new manejadorSQL();
            CRoles rol = new CRoles();
            rol.Menu = sql.consultarLosModulos();

            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CRoles> listaroles = sql.consultarListaroles();
            foreach (var item in listaroles)
            {
                System.Diagnostics.Debug.WriteLine(item.Nombre_rol);
                foreach (var item2 in item.Permisos)
                {
                    System.Diagnostics.Debug.WriteLine(item2.Nombre);
                }
            }
            return PartialView(listaroles);
        }
        
                    public ActionResult M13_ModificarRol()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CRoles> listaroles = sql.consultarListaroles();
            foreach (var item in listaroles)
            {
                System.Diagnostics.Debug.WriteLine(item.Nombre_rol);
                foreach (var item2 in item.Permisos)
                {
                    System.Diagnostics.Debug.WriteLine(item2.Nombre);
                }
            }
            return PartialView(listaroles);
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
        //Metodo para asignar permisos a los roles
        [HttpPost]
        public JsonResult asignarpermisos(string json)
        {

            manejadorSQL sql = new manejadorSQL();

            CRoles pruebaRol = new CRoles();
            CListaGenerica<CModulo_detallado> listaPermisosAsignar = new CListaGenerica<CModulo_detallado>();

            // creo un item para guardar el Json 
            var _permisos=JArray.Parse(json);


            // Si es mayor que uno , Significa que hay al menos un permiso 
            if (_permisos.Count() >= 1) {

                for (int i=1; i < _permisos.Count(); i++)
                {

                    sql.insertarPermisosRol(pruebaRol.Nombre_rol, _permisos[i].ToString());

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

 

	}
}