using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_roles;
using BOReserva.Models.gestion_aviones;
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
            //sql.insertarRol();

            //            CListaGenerica<CModulo_detallado> listaPermisos= new CListaGenerica<CModulo_detallado>();

            //            CModulo_detallado hola = new CModulo_detallado("Agregar rol", "prueba");
            //            CModulo_detallado hola2 = new CModulo_detallado("Modificar rol", "prueba 2");
            // CModulo_detallado hola3 = new CModulo_detallado("Consultar rol", "prueba 3");



            // listaPermisos.agregarElemento(hola);
            //listaPermisos.agregarElemento(hola2);
            //listaPermisos.agregarElemento(hola3);

  //             CRoles pruebaRol = new CRoles();
//               pruebaRol.Nombre_rol = "Cliente";

               // sql.insertarPermisosRol(pruebaRol, listaPermisos);


            return PartialView(rol);
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
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

            System.Diagnostics.Debug.WriteLine("Asginrar json"+json);
            // creo un item para guardar el Json 
            var _permisos=JArray.Parse(json);

            //Creo un objeto rol  y le paso el primer valor 
            if (_permisos.Count() >= 0 ) {
            System.Diagnostics.Debug.WriteLine("Entro en el if");

            pruebaRol.Nombre_rol = _permisos[0].ToString();
                try
                {
                    sql.insertarRol(pruebaRol);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Sino puedo insertar");

                }
            }

            // Si es mayor que uno , Significa que hay al menos un permiso 
            if (_permisos.Count() >= 1) {

                for (int i=1; i < _permisos.Count(); i++)
                {
                    System.Diagnostics.Debug.WriteLine("CUantos permisos tienes ");

                    sql.insertarPermisosRol(pruebaRol.Nombre_rol, _permisos[i].ToString());

                }
                    
            }
                       
            //La posicion 0 devolvera el Rol a insertar

            foreach (var detalle in _permisos)
            {
                System.Diagnostics.Debug.WriteLine("Asginrar foreach");
                System.Diagnostics.Debug.WriteLine("Asginrar foreach" + _permisos.Count);
                System.Diagnostics.Debug.WriteLine("Asginrar foreach" + _permisos[1]);

            }
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