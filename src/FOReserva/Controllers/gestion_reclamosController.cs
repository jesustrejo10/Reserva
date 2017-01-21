using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando;

namespace FOReserva.Controllers
{
    public class gestion_reclamosController : Controller
    {
        /// <summary>
        /// Metodo para guardar el avion, haciendo el insert en la base de datos 
        /// </summary>
        /// <returns>Retorna un ActionResult que contiene los elementos de la vista </returns>
        public ActionResult M16_AgregarReclamo()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            return PartialView(model);
        }
        public ActionResult M16_VisualizarReclamo()
        {
            //Reclamo reclamo1 = new Reclamo(1, "Maleta perdida", "no consigo mi maleta", "19/20/2016", "iniciado");
            //Reclamo reclamo2 = new Reclamo(2, "Perdí mi boleto", "necesito retornar", "20/20/2016", "procesado");
            List<Reclamo> listaReclamos = new List<Reclamo>();
            //listaReclamos.Add(reclamo1);
            //listaReclamos.Add(reclamo2);

            return PartialView(listaReclamos);
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

    }
}