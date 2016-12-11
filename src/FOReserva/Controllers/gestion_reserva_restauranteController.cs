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

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult error_conexion()
        {
            return View();
        }

     

        public ActionResult restaurant_resultados()
        {
            int search_val = Int32.Parse(Request.QueryString["search_val"]);
            string name_rest = Request.QueryString["name_rest"];
            try
            {
                List<CRestaurantModel> lista = busqueda(search_val, name_rest);
                return View(lista);
            }
            catch ( NullReferenceException e) {
                //Ventana de error al buscar
                //No se puede usar el mensaje de la excepcion "e.mensaje"
                //Esto se causa al realizar una busqueda con parametros que no son
                //como son caracteres especiales y de mas
                return View("error_conexion");
            }
            catch ( ManejadorSQLException f)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
                return View("error_conexion");
            }
            catch (Exception g) { 
            
            }

            // Error desconocido (seria bueno mostrar 
            // el mensaje para ver que lo causo
            // de la excepcion.
            return View();
        }

        private List<CRestaurantModel> busqueda(int search_val, string search_txt)
        {
            List<CRestaurantModel> lista = null;
            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            if (search_val == 1)
                lista = manejador.buscarRestCity(search_txt);
            else if (search_val == 2)
                lista = manejador.buscarRestName(search_txt);
            return lista;
        }

        public ActionResult reservar_restaurant(int id_rest)
        {
            CRestaurantModel restaurante = new CRestaurantModel();
            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            restaurante = manejador.buscarRest(id_rest);
            return View(restaurante);
        }

        public ActionResult confirma_restaurant(int restaurantID,string name_rest,string addres_rest, string name_client, string reserv_date, string reserv_hour, int number_person, string name_city)
        {
            CReservation_Restaurant reserva = new CReservation_Restaurant(name_client,reserv_date,reserv_hour,number_person, 5, restaurantID);
            reserva.Restaurant = new CRestaurantModel(restaurantID, name_rest, addres_rest);
            reserva.Restaurant.CityName = name_city;
            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            manejador.CrearReserva(reserva);
            return View(reserva);
        }

        public ActionResult lista_reserva_restaurantes()
        {
            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            List<CReservation_Restaurant> lista = manejador.buscarReservas();
            return View(lista);
        }

    }
}
