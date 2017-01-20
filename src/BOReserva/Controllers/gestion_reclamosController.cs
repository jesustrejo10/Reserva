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
          return (Json(verificacion));
      }

      [HttpPost]
      public JsonResult eliminarReclamo(int idReclamo)
      {
          int idUsuario = gestion_seguridad_ingresoController.IDUsuarioActual();
          Entidad reclamoAVerificar = FabricaEntidad.InstanciarReclamo();
          Command<Entidad> comando = FabricaComando.crearM16ConsultarUsuario(idReclamo);
          Reclamo verificacion = (Reclamo) comando.ejecutar();
          if(idUsuario!=verificacion._usuario)
          {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return (Json("No esta autorizado para eliminar este reclamo"));
          }
          else
          {
              return (Json("Logica de eliminar"));
          }
      }

      public ActionResult M16_ModificarReclamo()
      {
          CModificarReclamo model = new CModificarReclamo();
          return PartialView(model);

      }
    }
	
}