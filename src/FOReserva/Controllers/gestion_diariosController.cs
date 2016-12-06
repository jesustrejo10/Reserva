using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Diarios;

namespace FOReserva.Controllers
{
    public class gestion_diariosController : Controller
    {
        //
        // GET: /gestion_diarios/

        public ActionResult gestion_diarios()
        {
            Cvista_Diarios model = new Cvista_Diarios();
            return PartialView(model);
        }

        public ActionResult gestion_diariosImagenes()
        {
            Cvista_Diarios model = new Cvista_Diarios();
            return PartialView(model);
        }

    }
}
