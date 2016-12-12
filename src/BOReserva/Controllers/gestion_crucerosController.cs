using BOReserva.Models.gestion_cruceros;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_crucerosController : Controller
    {
        // GET: gestion_cruceros
        public ActionResult M24_GestionCruceros()
        {
            return PartialView();
        }

        public ActionResult M24_AgregarCabinas()
        {
            ConexionBD cbd = new ConexionBD();
            VistaListaCrucero vlc = new VistaListaCrucero();
            CGestion_cabina cabina = new CGestion_cabina() { cabinas = new List<CGestion_cabina>()};
            //CGestion_crucero crucero = new CGestion_crucero();
            vlc.cruceros = cbd.listarCruceros();
            ViewBag.ShowDropDown = new SelectList(vlc.cruceros, "_idCrucero", "_nombreCrucero");
            //cabina.cabinas = cbd.listarCabinas(crucero._idCrucero);
            return PartialView("M24_AgregarCabinas", cabina);
            //return PartialView();
        }

        public JsonResult M24_ListarCabinas(int id)
        {
            ConexionBD cbd = new ConexionBD();
            //VistaListaCrucero vlc = new VistaListaCrucero();
            //CGestion_cabina cabina = new CGestion_cabina();
            ////CGestion_crucero crucero = new CGestion_crucero();
            //vlc.cruceros = cbd.listarCruceros();
            //ViewBag.ShowDropDown = new SelectList(vlc.cruceros, "_idCrucero", "_nombreCrucero");
            var listaCabinas = cbd.listarCabinas(id);
            //return Json (new { cabinas = listaCabinas });
            return (Json(listaCabinas, JsonRequestBehavior.AllowGet));
            //return PartialView();
        }


        public ActionResult M24_ListarCruceros()
        {
            ConexionBD cbd = new ConexionBD();
            VistaListaCrucero vlc = new VistaListaCrucero();
            vlc.cruceros = cbd.listarCruceros();
            return PartialView("M24_ListarCruceros", vlc);
        }

        [HttpPost]
        public JsonResult guardarCrucero(CGestion_crucero model)
        {
            String _nombreCrucero = model._nombreCrucero;
            String _companiaCrucero = model._companiaCrucero;
            int _capacidadCrucero = model._capacidadCrucero;
            //HttpPostedFile = model._imagen;

            CGestion_crucero crucero = new CGestion_crucero(_nombreCrucero, _companiaCrucero, _capacidadCrucero);
            crucero.AgregarCrucero(crucero); 

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult eliminarCrucero(int id_crucero)
        {
            CGestion_crucero crucero = new CGestion_crucero();
            crucero.EliminarCrucero(id_crucero);
            Console.WriteLine(id_crucero);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult guardarCabina(CGestion_cabina model)
        {
            String _nombreCabina = model._nombreCabina;
            float _precioCabina = model._precioCabina;
            int _fkCrucero = model._fkCrucero;

            CGestion_cabina cabina = new CGestion_cabina(_nombreCabina, _precioCabina, _fkCrucero);
            cabina.AgregarCabinas(cabina);

            return (Json(true, JsonRequestBehavior.AllowGet));
        }
    }
}