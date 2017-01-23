using System;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.M20;
using System.Data;

namespace FOReserva.Controllers
{
    using System.Collections.Generic;

    /// <summary>
    /// Gestion Revision Controlador
    /// </summary>

    using Hotel = DataAccess.Domain.Hotel;
    using Restaurante = DataAccess.Domain.Restaurante;
    public class gestion_revisionController : Controller
    {
        [HttpGet]
        public ActionResult revisiones(int id, EnumTipoRevision tipo)
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult valoracion(int id, EnumTipoRevision tipo)
        {
            return PartialView();
        }

        /// <summary>
        /// POST: obtener_revisiones, obtiene el conjunto de revisiones de una referencia segun su tipo.
        /// </summary>
        /// <returns>Retorna la vista que compone el conjunto de revisiones de dicha referencia.</returns>
        [HttpPost]
        public ActionResult obtener_revisiones(int id, EnumTipoRevision tipo)
        {
            var revisiones = new List<Revision>();
            Entidad referencia = null;
            if (tipo == EnumTipoRevision.Hotel)
            {
                referencia = new Hotel() { _id = id };
            }
            else if (tipo == EnumTipoRevision.Restaurante)
            {
                referencia = new Restaurante() { _id = id };
            }
            revisiones = DAORevision.Singleton().ObtenerRevisionesPorReferencia(referencia);
            return PartialView(revisiones);

        }

        /// <summary>
        /// POST: obtener_valoracion, obtiene la valoracion resultante de una referencia segun su tipo.
        /// </summary>
        /// <returns>Retorna la vista que compone la valoracion resultante de una referencia.</returns>
        [HttpPost]
        public ActionResult obtener_valoracion(int id, EnumTipoRevision tipo)
        {
            var revisiones = new ReferenciaValorada();
            Entidad referencia = null;
            if (tipo == EnumTipoRevision.Hotel)
            {
                referencia = new Hotel() { _id = id };
            }
            else if (tipo == EnumTipoRevision.Restaurante)
            {
                referencia = new Restaurante() { _id = id };
            }
            revisiones = DAORevision.Singleton().ObtenerValoracionPorReferencia(referencia);
            return PartialView(revisiones);

        }

        /// <summary>
        /// POST: form_revision, obtiene el formulario para crear una revision.
        /// </summary>
        /// <returns>Retorna la vista que compone el formulario para crear una revision.</returns>
        [HttpPost]
        public ActionResult form_revision(int id, EnumTipoRevision tipo)
        {
            return PartialView();
        }

        /// <summary>
        /// POST: guardar_revision, procesa la solicitud para crear una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult guardar_revision(Revision revision)
        {
            return Json(new { completa = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST: borrar_revision, procesa la solicitud para borrar una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult borrar_revision(Revision revision)
        {
            return Json(new { completa = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST: guardar_revision, procesa la solicitud para crear una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult guardar_revision(RevisionValoracion revision)
        {
            return Json(new { completa = true }, JsonRequestBehavior.AllowGet);
        }
    }

}




