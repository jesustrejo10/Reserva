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

        public ActionResult restaurant_resultados( )
        {
            int search_val = Int32.Parse(Request.QueryString["search_val"]);
            string search_txt = Request.QueryString["search_text"];
            
            List<CRestaurantModel> lista = null;
            if (search_val == 1)
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                lista = manejador.buscarRestCity(search_txt);
            }
            else if (search_val == 2)
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                lista = manejador.buscarRestName(search_txt);
            }
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
