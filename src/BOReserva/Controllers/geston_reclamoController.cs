using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_reclamo;
using System.Net;
using System.Data.SqlClient;

namespace BOReserva.Controllers
{
    public class geston_reclamoController : Controller
    {

        public ActionResult M16_AgregarReclamo()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            return PartialView(model);
        }
    }
}
