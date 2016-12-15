using System;
using System.Web.Mvc;
using FOReserva.Models.Restaurantes;
using FOReserva.Servicio;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;

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
                return View();
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
                ViewBag.Message = "Lo sentimos, la reserva no pudo ser realizada debido al siguiente error del sistema:" + g.Message;

            }
            return View();
        }

        /*
         * Metodo que confirma la reserva
         *  Crea la reserva en DB
         *  En caso contrario devuelve vista al momento de crear la reserva
             */
        public ActionResult confirma_restaurant(int restaurantID, string name_rest, string addres_rest, string name_client, string reserv_date, string reserv_hour, int number_person, string name_city)
        {
            CReservation_Restaurant reserva = new CReservation_Restaurant(name_client, reserv_date, reserv_hour, number_person, 5, restaurantID);
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
                return View("error_conexion");
            }
            catch (InvalidManejadorSQLException f)
            {
                reserva = null;
                ViewBag.Message = "Lo sentimos, la reserva no pudo ser realizada debido a un error del sistema";
                return View(reserva);
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
            try
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                List<CReservation_Restaurant> lista = manejador.buscarReservas();
                return View(lista);
            }
            catch (ManejadorSQLException f)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "f.mensaje"
                return View("error_conexion");
            }
            catch (Exception g)
            {
                ViewBag.Message = "Lo sentimos, la reserva no pudo ser realizada debido al siguiente error del sistema:" + g.Message;

            }
            return View();

        }


        /* 
         * Metodo para la eliminacion de la reserva
         */
        [System.Web.Services.WebMethod]
        public JsonResult eliminar_reserva(int id)
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
                return null;
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
                ViewBag.Message = "Lo sentimos, la reserva no pudo ser realizada debido al siguiente error del sistema:" + e.Message;
            }

            return Json("exito");
        }

        /*
         *  Metodo para Modificar una reserva
         *   c_id_reserva: ID de la reserva a modificar
         *   c_name_client: A nombre de quien se hizo la reserva
         *   c_reserv_date: Fecha de la reserva
         *   c_reserv_hour: hora de la reserva
         *   c_number_person: numero de personas
         */

        [HttpPost]
        public ActionResult _EditarReserva(int id)
        {

            ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
            List<CReservation_Restaurant> lista = manejador.buscarReservas();
            CReservation_Restaurant model = new CReservation_Restaurant();

            CReservation_Restaurant DBModel = lista.Where(i => i.Id.Equals(id)).FirstOrDefault();
            if (DBModel != null) model = DBModel;

            return View(model);

        }

        public string cadena (CReservation_Restaurant tmp) {
            string botones = "<a href='#' id='icon_edit' data-action='/gestion_reserva_restaurante/_EditarReserva/" + tmp.Id + "'" + "class='update list-icon' value='" + tmp.Id + "'>" + "<i class='fa fa fa-pencil-square'></i></a>" + "<a href='#' class='delete list-icon' value='" + tmp.Id + "'style='margin-left: 12px;'>" + "<i class='fa fa-times-circle'></i></a>";
            string fila = "<td>" + tmp.Id + "</td>" + "<td>" + tmp.Restaurant.Name + "</td>" + "<td class='reserv_name' value='"
                + tmp.Name + "'>" + tmp.Name + "</td>" + "<td class='reserv_date' value='" + tmp.Date + "'>" + tmp.Date + "</td>"
                + "<td class='reserv_time' value='" + tmp.Time + "'>" + tmp.Time + "</td>" + "<td class='reserv_count' value='" + tmp.Count + "'>"
                + tmp.Count + "</td>" + "<td style='text-align: center;'>" + botones + "</td>";
            return fila;
        }

        public JsonResult UpdateReserva(CReservation_Restaurant tmp)
        {
            try
            {
                ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
                manejador.actualizarReserva(tmp);
            }
            catch (ManejadorSQLException e)
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
                return null;
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
                return null;
            }

            string fila = cadena(tmp);
            return Json(fila);

        }


    }
}

