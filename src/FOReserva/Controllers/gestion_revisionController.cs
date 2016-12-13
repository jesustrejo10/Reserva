using FOReserva.Models.Revision;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using FOReserva.Models.Restaurantes;
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

        public ActionResult lista_revisiones(int id)
        {
            Console.WriteLine("Lista Rev " + id);
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            List<CRevision> lista = manejador.BuscarRevisiones(id);
            return PartialView(lista);
        }

        public ActionResult crear_revision_form()
        {
            ManejadorSQLRevision manejador = new ManejadorSQLRevision();
            bool resp = manejador.Crear_Revision();
            return PartialView();
        }

        public ActionResult crear_revision()
        {
            return PartialView();
        }
    }
}



