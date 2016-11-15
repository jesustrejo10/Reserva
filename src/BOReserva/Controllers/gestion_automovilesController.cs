using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
namespace BOReserva.Controllers
{
    public class gestion_automovilesController : Controller
    {
        //
        // GET: /gestion_automoviles/

        public ActionResult M08_AgregarAutomovil()
        {
            CAgregarAutomovil model = new CAgregarAutomovil();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult saveVehicle(CAgregarAutomovil model)
        {
            String prueba = model._matricula;
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE"+prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

    }
}
