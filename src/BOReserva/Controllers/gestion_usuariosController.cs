using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Controllers
{
    public class gestion_usuariosController : Controller
    {
        //
        // GET: /gestion_usuario/
        public ActionResult Index()
        {
            return PartialView();
        }
	}
}