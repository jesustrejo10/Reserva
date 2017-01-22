using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_reclamos;
using System.Net;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;


namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase controladora del módulo de Gestión de Reclamos
    /// </summary>
    public class gestion_reclamosController : Controller
    {
        private static int idReclamo;
        
        // GET: /gestion_reclamos/
        //Primero están todos los ActionResult y luego todos los JsonResult
 
        /// <summary>
        /// Controlador de la vista Agregar Reclamo
        /// </summary>
        /// <returns>retorna la vista parcial</returns>
      public ActionResult M16_AgregarReclamo()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            return PartialView(model);
        }
        /// <summary>
        /// Controlador de la vista para visualizar todos los reclamos
        /// </summary>
        /// <returns>retorna la vista parcial con el datatable</returns>
      public ActionResult M16_VisualizarReclamo()
      {
          Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM16VisualizarReclamos();
          Dictionary<int, Entidad> listaReclamos = comando.ejecutar();
          List<Reclamo> lista = FabricaEntidad.InstanciarListaReclamo(listaReclamos);
          return PartialView(lista);
      }
        /// <summary>
        /// controlador de la vista para consultar un reclamo a detalle
        /// </summary>
        /// <param name="idReclamo">recibe como parámetro el id del reclamo que se selecccionó</param>
        /// aquí reutilizamos el modelo de la vista Modificar 
        /// <returns>retorna la vista del reclamo a detalle</returns>
      public ActionResult M16_DetalleReclamo(int idReclamo)
      {
          Command<Entidad> comando = FabricaComando.crearM16ConsultarUsuario(idReclamo);
          Reclamo reclamo = (Reclamo)comando.ejecutar();
          CModificarReclamo model = new CModificarReclamo();
          model._tituloReclamo = reclamo._tituloReclamo;
          model._detalleReclamo = reclamo._detalleReclamo;
          model._fechaReclamo = reclamo._fechaReclamo;
          model._estadoReclamo = 1;
          //CModificarReclamo model = new CModificarReclamo();
          return PartialView(model);
      }
        /// <summary>
        /// Controlador para la vista del modificar reclamo
        /// </summary>
        /// <param name="idReclamo">recibe el id del reclamo</param>
        /// <returns>retorna la vista para modificar el reclamo, solo si tú hiciste el reclamo</returns>
      public ActionResult M16_ModificarReclamo(int idReclamo)
      {
          int idUsuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          Command<Entidad> comando = FabricaComando.crearM16ConsultarUsuario(idReclamo);
          Reclamo reclamo = (Reclamo)comando.ejecutar();
          if (idUsuario != reclamo._usuario)
          {
              return PartialView("M16_AlertaError", null);
          }
          else
          {
              CModificarReclamo model = new CModificarReclamo();
              model._idReclamo = reclamo._id;
              model._tituloReclamo = reclamo._tituloReclamo;
              model._detalleReclamo = reclamo._detalleReclamo;
              model._fechaReclamo = reclamo._fechaReclamo;
              model._estadoReclamo = reclamo._estadoReclamo;
              return PartialView(model);
          }
      }
        /// <summary>
        /// controlador para el botón de guardar un reclamo
        /// </summary>
        /// <param name="model">recibe el modelo de la vista Agregar reclamo</param>
        /// <returns>retorna un Json con un mensaje de éxito</returns>
      [HttpPost]
      public JsonResult guardarReclamo(CAgregarReclamo model)
      {
          model._usuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          Entidad nuevoReclamo = FabricaEntidad.InstanciarReclamo(model);
          Command<String> comando = FabricaComando.crearM16AgregarReclamo(nuevoReclamo);
          String verificacion = comando.ejecutar();
          return (Json("1"));
      }
        /// <summary>
        /// Controlador para el boton de modificar un reclamo 
        /// </summary>
        /// <param name="model"> recibe el modelo de la vista para modificar un reclamo</param>
        /// <returns>retorna un json con un mensaje de exito</returns>
      [HttpPost]
      public JsonResult modificarReclamo(CModificarReclamo model)
      {
          int idUsuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          String[] formateadorFecha = model._fechaReclamo.Split('/');
          model._fechaReclamo = formateadorFecha[2] + "-" + formateadorFecha[1] + "-" + formateadorFecha[0];
          Entidad reclamo = FabricaEntidad.InstanciarReclamo(model);
          Command<Entidad> comando = FabricaComando.crearM16ConsultarUsuario(idReclamo);
          Reclamo verificacion = (Reclamo)comando.ejecutar();
          //con la fabrica instancie el reclamo.

          Command<String> comandoMod = FabricaComando.crearM16ModificarReclamo(reclamo, model._idReclamo);
          String resultado = comandoMod.ejecutar();
          return (Json("Se modificó el reclamo exitosamente"));
          

      }
        /// <summary>
        /// controlador del boton para eliminar un reclamo
        /// </summary>
        /// <param name="idReclamo">recibe el id del reclamo</param>
        /// <returns>Json con msj dependiendo de la validación del usuario</returns>
      [HttpPost]
      public JsonResult eliminarReclamo(int idReclamo)
      {
          int idUsuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          Command<Entidad> comando = FabricaComando.crearM16ConsultarUsuario(idReclamo);
          Reclamo verificacion = (Reclamo) comando.ejecutar();
          if(idUsuario!=verificacion._usuario)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return (Json("No está autorizado para eliminar este reclamo"));
          }
          else
          {
              Command<String> comando1 = FabricaComando.crearM16EliminarReclamo(idReclamo);
              String borro_si_no = comando1.ejecutar();
              return (Json("1"));
          }
      }
        /// <summary>
        /// controlador para actualizar un reclamo
        /// </summary>
        /// <param name="idReclamo">recibe el id del reclamo</param>
        /// <param name="estado">y el estado en el que se encuentra</param>
        /// <returns>Json con mensaje de éxito</returns>
      [HttpPost]
      public JsonResult actualizarReclamo(int idReclamo, int estado)
      {
          Command<String> comando = FabricaComando.crearM16ActualizarReclamo(idReclamo, estado);
          String resultado = comando.ejecutar();
          return (Json("Estado modificado"));
      }

    }
	
}