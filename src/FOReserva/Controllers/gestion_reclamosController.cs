using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando;
using System.Net;

namespace FOReserva.Controllers
{
    /// <summary>
    /// Clase encargada de controlar la comunicacion entre la vista y el controlador
    /// </summary>
    public class gestion_reclamosController : Controller
    {
        /// <summary>
        /// Metodo para cargar la ventana de agregar un reclamo
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M16_AgregarReclamo()
        {
            //Esto sera estatico hasta que el modulo de gestion del login proporcione algun metodo para saber el id del usuario en sistema
            int idUsuario = 1; 
            CAgregarReclamo model = new CAgregarReclamo();
            Command<List<Reclamo>> comando = FabricaComando.consultarReclamosDeUsuario(idUsuario);
            model._listaDeReclamos = comando.ejecutar();
            return PartialView(model);
        }

        /// <summary>
        /// Metodo para cargar la ventana de modificar un reclamo
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M16_ModificarReclamo(int _idReclamo)
        {
            //Esto sera estatico hasta que el modulo de gestion del login proporcione algun metodo para saber el id del usuario en sistema
            Reclamo reclamoAModificar = FabricaEntidad.InstanciarReclamo();
            Command<Entidad> comando = FabricaComando.consultarReclamo(_idReclamo);
            reclamoAModificar = (Reclamo) comando.ejecutar();
            String[] fomateadorFecha = reclamoAModificar._fechaReclamo.Split('/');
            if (int.Parse(fomateadorFecha[1])<=9)
            {
                fomateadorFecha[1] = "0" + fomateadorFecha[1];
            }
            reclamoAModificar._fechaReclamo = fomateadorFecha[2] + "-" + fomateadorFecha[1] + "-" + fomateadorFecha[0];
            return PartialView("M16_ModificarReclamo", reclamoAModificar);
        }





        /// <summary>
        /// Método que se utiliza para guardar un reclamo ingresado
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M16_AgregarReclamo</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult guardarReclamo(CAgregarReclamo model)
        {
            model._usuarioReclamo = 1;
            Entidad nuevoReclamo = FabricaEntidad.InstanciarReclamo(model);
            Command<String> comando = FabricaComando.crearM16AgregarReclamo(nuevoReclamo);
            String agrego_si_no = comando.ejecutar();

            return (Json(agrego_si_no));
        }



        /// <summary>
        /// Método que se utiliza para eliminar un reclamo 
        /// </summary>
        /// <param name="seleccion">id del reclamo que se desea eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult eliminarReclamo(int seleccion)
        {
          
            Command<int> comando = FabricaComando.eliminarReclamo(seleccion);
            String respuesta = "";
            int codigo = comando.ejecutar();
            if (codigo==1)
            {
                respuesta = "Se elimino el reclamo exitosamente";
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                respuesta = "Error eliminando el reclamo, contacte con el administrador, Codigo: " + codigo; 
            }

            return (Json(respuesta));
        }


        [HttpPost]
        public JsonResult guardarModificacionReclamo(String titulo, String detalle, String fecha, int id)
        {
            Reclamo reclamoAModificar = FabricaEntidad.InstanciarReclamo();
            reclamoAModificar._tituloReclamo = titulo;
            reclamoAModificar._detalleReclamo = detalle;
            reclamoAModificar._fechaReclamo = fecha;
            reclamoAModificar._idReclamo = id;
            Command<int> comando = FabricaComando.modificarReclamo(reclamoAModificar);
            int respuesta = comando.ejecutar();
            if (respuesta == 1)
            {
                return Json("Modificacion conseguida");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return (Json("Error al modificar Codigo: "+respuesta));
            }
            
        }

    }
}