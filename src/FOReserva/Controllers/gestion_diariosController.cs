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
            CDiarioModel model = new CDiarioModel();
            return PartialView(model);
        }

        public ActionResult gestion_diariosImagenes()
        {            
            return PartialView();
        }

        [HttpPost]
        public JsonResult buscarDiarios(CDiarioModel model)
        {
            String prueba = model._prueba;
            String f_inicio = model._fecha_ini;
            String f_fin = model._fecha_fin;
            Console.WriteLine(prueba);
            return (Json("asdf", JsonRequestBehavior.AllowGet));
        }

    }
}
