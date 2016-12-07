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
            return PartialView();
        }

        [HttpPost]
        public JsonResult buscarDiarios(Cvista_Diarios model)
        {
            String prueba = model._prueba;
            Console.WriteLine(prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

    }
}
