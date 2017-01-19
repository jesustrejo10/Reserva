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
          Reclamo reclamo1 = new Reclamo("Maleta perdida","no consigo mi maleta","19/20/2016",1,1);
          Reclamo reclamo2 = new Reclamo("Perdí mi boleto", "necesito retornar", "20/20/2016",1,2);
          List<Reclamo> listaReclamos = new List<Reclamo>();
          listaReclamos.Add(reclamo1);
          listaReclamos.Add(reclamo2);

          return PartialView(listaReclamos);
      }

      [HttpPost]
      public JsonResult guardarReclamo(CAgregarReclamo model)
      {
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