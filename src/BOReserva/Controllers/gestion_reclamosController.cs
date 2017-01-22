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
    public class gestion_reclamosController : Controller
    {
        
        //
        // GET: /gestion_reclamos/
      public ActionResult M16_AgregarReclamo()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            return PartialView(model);
        }

      public ActionResult M16_VisualizarReclamo()
      {
          Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM16VisualizarReclamos();
          Dictionary<int, Entidad> listaReclamos = comando.ejecutar();
          List<Reclamo> lista = FabricaEntidad.InstanciarListaReclamo(listaReclamos);
          return PartialView(lista);
      }

      
      [HttpPost]
      public JsonResult guardarReclamo(CAgregarReclamo model)
      {
          model._usuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          Entidad nuevoReclamo = FabricaEntidad.InstanciarReclamo(model);
          Command<String> comando = FabricaComando.crearM16AgregarReclamo(nuevoReclamo);
          String verificacion = comando.ejecutar();
          return (Json("Se guardó su reclamo exitosamente"));
      }

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
              Response.StatusCode = (int)HttpStatusCode.BadRequest;
              return (Json("Se eliminó el reclamo exitosamente"));
          }
      }

      [HttpPost]
      public JsonResult actualizarReclamo(int idReclamo, int estado)
      {
          Command<String> comando = FabricaComando.crearM16ActualizarReclamo(idReclamo, estado);
          String resultado = comando.ejecutar();
          return (Json("Estado modificado"));
      }

      public ActionResult M16_ModificarReclamo()
      {
          CModificarReclamo model = new CModificarReclamo();
          return PartialView(model);

      }
    }
	
}