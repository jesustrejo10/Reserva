using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_reclamos;
using System.Net;


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
    }
	
}