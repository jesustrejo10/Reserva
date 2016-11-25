using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_boletosController : Controller
    {

        public ActionResult M05_CrearBoleto()
        {
            return PartialView();
        }

    }
}
