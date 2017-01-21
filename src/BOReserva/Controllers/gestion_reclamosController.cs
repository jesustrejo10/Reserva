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
          //ESTO ES TEMPORAL MIENTRAS SIMON PASA LA FUNCION
          model._usuario = 1;
          //RECUERDA QUE LO ANTERIOR DEBES CAMBIARLO KARLIANA SUAREZ
          Entidad nuevoReclamo = FabricaEntidad.InstanciarReclamo(model);
          Command<String> comando = FabricaComando.crearM16AgregarReclamo(nuevoReclamo);
          String verificacion = comando.ejecutar();
          return (Json(verificacion));
      }

      public ActionResult M16_ModificarReclamo()
      {
          CModificarReclamo model = new CModificarReclamo();
          return PartialView(model);

      }
    }
	
}