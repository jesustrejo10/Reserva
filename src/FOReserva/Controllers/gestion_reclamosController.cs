using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;

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

    }
}