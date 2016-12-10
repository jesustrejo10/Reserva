using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD

=======
using BOReserva.Models.gestion_roles;
using BOReserva.Models.gestion_aviones;
using BOReserva.Servicio;
using System.Net;
>>>>>>> Develop
namespace BOReserva.Controllers
{
    public class gestion_rolesController : Controller
    {
        //
        // GET: /gestion_roles/
        public ActionResult M13_AgregarRol()
        {
<<<<<<< HEAD
            return PartialView();
=======
            manejadorSQL sql = new manejadorSQL();            
            CRoles rol = new CRoles();
            rol.Menu = sql.consultarLosModulos();           
            return PartialView(rol);
>>>>>>> Develop
        }
        public ActionResult M13_VisualizarRol()
        {
            return PartialView();
        }
<<<<<<< HEAD
=======
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
 

>>>>>>> Develop
	}
}