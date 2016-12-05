using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    public class gestion_revisionController : Controller
    {
        //
        // GET: /gestion_revision/

        public ActionResult gestion_revision()
        {

            CRevision modelo = new CRevision();
            return PartialView(modelo);


        }

        public ActionResult gestion_ListRevicion()
        {

            CListRevision modelo = new CListRevision();
            return PartialView(modelo);

                        //probando
        }

        public ActionResult Consultar_Revision ()
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


    }
}
