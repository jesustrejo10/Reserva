using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_restaurantes;

namespace BOReserva.Controllers
{
    public class gestion_restaurantesController : Controller
    {
        // GET: gestion_restaurantes
        public ActionResult M10_GestionRestaurantes()
        {
            var model = new CRestauranteModelo();
            return PartialView(model);
        }

        public ActionResult M10_VerRestaurantes()
        {
            var model = new CRestauranteModelo();
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult saveRestaurant(CRestauranteModelo model)
        {
            return (Json(true, JsonRequestBehavior.AllowGet));
        }
    }
}