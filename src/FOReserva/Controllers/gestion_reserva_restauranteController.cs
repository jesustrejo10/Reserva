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
            Cvista_restaurante model = new Cvista_restaurante();
            return PartialView(model);
        }


        [HttpPost]
        public JsonResult buscar_restaurante(Cvista_restaurante model)
        {
            String prueba = model._nombre;
            Console.WriteLine(prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
