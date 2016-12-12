using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace FORevision.Controllers
{
    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>
    public class gestion_revisionController : Controller
    {
        /// <summary>
        /// GET: GestionRevision
        /// </summary>
        /// <returns></returns>
        public ActionResult gestion_revision()
        {
            return PartialView();
        }

        public ActionResult lista_revisiones()
        {
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            List<MostrarRevision> lista = manejador.BuscarRevisiones();
            return PartialView(lista);
        }
    }
}



