using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;

namespace FOReserva.Controllers
{
    public class gestion_reserva_restauranteController : Controller
    {
        //
        // GET: /GestionReservaRestaurant/
        public ActionResult gestion_reserva_restaurante()
        {
            return PartialView();
        }

        //[HttpPost]
        //public JsonResult buscar_restaurante(CRestaurantModel model)
        //{
        //    return (Json(true, JsonRequestBehavior.AllowGet));
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult restaurant_resultados()
        {
            ReservaDBDataContext mydb = new ReservaDBDataContext();

            var __restmodel = mydb.Restaurantes.ToList();
            return View(__restmodel);
       
        }

        public ActionResult reservar_restaurant()
        {
            return View();
        }

        public ActionResult confirma_restaurant()
        {
            return View();
        }
    }
}
