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

    using Usuario = DataAccess.Domain.Usuario;
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
            var valoracion = new ReferenciaValorada();
            Entidad referencia = null;
            if (tipo == EnumTipoRevision.Hotel)
            {
                referencia = new Hotel() { _id = id };
            }
            else if (tipo == EnumTipoRevision.Restaurante)
            {
                referencia = new Restaurante() { _id = id };
            }
            valoracion = DAORevision.Singleton().ObtenerValoracionPorReferencia(referencia);
            return PartialView(valoracion);

        }

        /// <summary>
        /// POST: form_revision, obtiene el formulario para crear una revision.
        /// </summary>
        /// <returns>Retorna la vista que compone el formulario para crear una revision.</returns>
        [HttpPost]
        public ActionResult form_revision(Revision revision)
        {
            Usuario propietario = new Usuario(revision.Propietario._id);
            propietario.Id = Session["id_usuario"] == null ? 1 : (int)Session["id_usuario"];
            revision.Propietario = propietario;
            return PartialView(revision);
        }

        /// <summary>
        /// POST: guardar_revision, procesa la solicitud para crear una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult guardar_revision(Revision revision)
        {
            Usuario propietario = new Usuario(revision.Propietario._id);
            propietario.Id = Session["id_usuario"] == null ? 1 : (int)Session["id_usuario"];
            revision.Propietario = propietario;
            var completa = DAORevision.Singleton().GuardarRevision(revision);
            return Json(new { operacion = completa }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST: borrar_revision, procesa la solicitud para borrar una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult borrar_revision(Revision revision)
        {
            Usuario propietario = new Usuario(revision.Propietario._id);
            propietario.Id = Session["id_usuario"] == null ? 1 : (int)Session["id_usuario"];
            revision.Propietario = propietario;
            var completa = DAORevision.Singleton().BorrarRevision(revision);
            return Json(new { operacion = completa }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// POST: guardar_revision, procesa la solicitud para crear una revision.
        /// </summary>
        /// <returns>Retorna la respuesta de la solucitud.</returns>
        [HttpPost]
        public ActionResult guardar_valoracion(RevisionValoracion valoracion)
        {
            Usuario propietario = new Usuario(valoracion.Propietario._id);
            propietario.Id = Session["id_usuario"] == null ? 1 : (int)Session["id_usuario"];
            valoracion.Propietario = propietario;
            var completa = DAORevision.Singleton().GuardarValoracion(valoracion);
            return Json(new { completa = true }, JsonRequestBehavior.AllowGet);
        }
    }

}




