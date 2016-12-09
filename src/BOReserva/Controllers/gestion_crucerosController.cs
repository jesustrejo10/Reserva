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

        public ActionResult M24_ListarCruceros()
        {
            ConexionBD cbd = new ConexionBD();
            VistaListaCrucero vlc = new VistaListaCrucero();
            vlc.cruceros = cbd.listarCruceros();
            return PartialView("M24_ListarCruceros",vlc);
        }
    }
}