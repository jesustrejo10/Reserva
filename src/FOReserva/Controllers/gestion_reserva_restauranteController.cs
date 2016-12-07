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

        public ActionResult restaurant_resultados()
        {
            int search_val = Int32.Parse(Request.QueryString["search_val"]);
            string search_txt = Request.QueryString["search_text"];
            try
            {
                List<CRestaurantModel> lista = busqueda(search_val, search_txt);
                return View(lista);
            }
            catch ( NullReferenceException e) {
                //Ventana de error al buscar
                //No se puede usar el mensaje de la excepcion "e.mensaje"
                //Esto se causa al realizar una busqueda con parametros que no son
                //como son caracteres especiales y de mas
                System.Diagnostics.Debug.WriteLine("Error de busqueda");
                System.Diagnostics.Debug.Write(e.Message);
            }
            catch ( ManejadorSQLException e )
            {
                //Ventana de error no conecto a la db
                //Se puede usar el mensaje de la excepcion "e.mensaje"
                System.Diagnostics.Debug.WriteLine("Error de manejador sql");
                System.Diagnostics.Debug.Write( e.Message );
            }
            catch (Exception e) { }

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

            return View();
        }

        public ActionResult confirma_restaurant()
        {
            return View();
        }
    }
}
