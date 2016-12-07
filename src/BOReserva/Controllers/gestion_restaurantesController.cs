using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Servicio;
using BOReserva.Models.gestion_restaurantes;

namespace BOReserva.Controllers
{
    public class gestion_restaurantesController : Controller
    {
        // GET: gestion_restaurantes
        public ActionResult M10_GestionRestaurantes_Ver()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            return PartialView(modelo);
        }

        public ActionResult M10_GestionRestaurantes_Agregar()
        {
            var modelo = new CRestauranteModeloVista();
            var bd = new manejadorSQL();
            modelo._listaRestaurantes = bd.consultarRestaurante();
            return PartialView(modelo);
        }

        [HttpPost]
        public JsonResult guardarRestaurante(CRestauranteModelo model)
        {
            return (Json(true, JsonRequestBehavior.AllowGet));
        }
    }
}