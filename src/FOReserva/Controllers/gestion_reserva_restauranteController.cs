using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;
using FOReserva.Servicio;

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

        public ActionResult restaurant_resultados(int search_val, string search_txt)
        {
            ReservaDBDataContext mydb = new ReservaDBDataContext();
            //CRestaurantModel __restmodel = new CRestaurantModel();
            manejadorSQL manejador = new manejadorSQL();
            List<CRestaurantModel> lista = manejador.buscarRest();
            return View(lista);
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
