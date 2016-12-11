using System;
using System.Collections.Generic;
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



        public ActionResult restaurant_resultados()
        {
            int search_val = Int32.Parse(Request.QueryString["search_val"]);
            string name_rest = Request.QueryString["name_rest"];
            try
            {
                List<CRestaurantModel> lista = busqueda(search_val, name_rest);
                return View(lista);
            }
            catch (NullReferenceException e)
            {
                //Ventana de error al buscar
                //No se puede usar el mensaje de la excepcion "e.mensaje"
                //Esto se causa al realizar una busqueda con parametros que no son
                //como son caracteres especiales y de mas
                return View("No se encontraron resultados");
            }
            catch (ManejadorSQLException f)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
                return View("error_conexion");
            }
            catch (Exception g)
            {

            }

            // Error desconocido (seria bueno mostrar 
            // el mensaje para ver que lo causo
            // de la excepcion.
            return View();
        }

        /* Metodo para la busqueda de los restaurantes en DB
           search_val: Metodo de busqueda 
             1 para ciudad
             2 para nombre
           search_txt:
             nombre de la ciudad o del restaurante a buscar*/
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

        /* Metodo para la seleccion del restaurante 
           donde hacer la reserva
             */
        public ActionResult reservar_restaurant(int id_rest)
        {
            try
            {
                CRestaurantModel restaurante = new CRestaurantModel();
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                restaurante = manejador.buscarRest(id_rest);
                return View(restaurante);
            }
            catch (ManejadorSQLException f)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "f.mensaje"
                return View("error_conexion");
            }
            catch (Exception g)
            {

            }
            return View();
        }

        /*
         * Metodo que confirma la reserva
         *  Crea la reserva en DB
         *  En caso contrario devuelve vista al momento de crear la reserva
             */
        public ActionResult confirma_restaurant(int restaurantID,string name_rest,string addres_rest, string name_client, string reserv_date, string reserv_hour, int number_person, string name_city)
        {
            CReservation_Restaurant reserva = new CReservation_Restaurant(name_client,reserv_date,reserv_hour,number_person, 5, restaurantID);
            reserva.Restaurant = new CRestaurantModel(restaurantID, name_rest, addres_rest);
            reserva.Restaurant.CityName = name_city;
            try
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                manejador.CrearReserva(reserva);
                return View(reserva);
            }
            catch (ManejadorSQLException e)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
                reserva = null;
                return View("error_conexion" + e.Message);
            }
            catch (InvalidManejadorSQLException f)
            {
                //Ventana de error al crear la reserva
                //Esto se causa por una sitaxis erronea del sql
                //como son caracteres especiales o demas
                reserva = null;
                return View("Error al crear Reserva");
            }
            catch (Exception e)
            {
                reserva = null;
                ViewBag.Message = "Lo sentimos, la reserva no pudo ser realizada debido al siguiente error del sistema:" + e.Message;
                return View(reserva);
            }
        }

        /* Metodo que devuelve todas las reservas del usuario logeado 
         * userID = id del usuario logeado
             */
        public ActionResult lista_reserva_restaurantes()
        {
            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            List<CReservation_Restaurant> lista = manejador.buscarReservas();
            return View(lista);
        }

        /* 
         * Metodo para la eliminacion de la reserva
         */
        [System.Web.Services.WebMethod] 
        public void eliminar_reserva(int id)
        {
            try
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                manejador.eliminarReserva(id);
            }
            catch (ManejadorSQLException e)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
             
            }
            catch (InvalidManejadorSQLException e)
            {
                //Ventana de error al eliminar la reserva
                //Esto se causa por una sitaxis erronea del sql
                //como son caracteres especiales o demas
            }
            catch (Exception e)
            {
                // Error desconocido del sistema
            }
        }
        [System.Web.Services.WebMethod]
        public void editar_reserva(int id)
        {

        }
    }
}
