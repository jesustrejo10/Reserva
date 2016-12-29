using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}