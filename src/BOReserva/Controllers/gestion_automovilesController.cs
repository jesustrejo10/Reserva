using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
namespace BOReserva.Controllers
{
    public class gestion_automovilesController : Controller
    {
        //
        // GET: /gestion_automoviles/

        public ActionResult M08_AgregarAutomovil()
        {
            CAgregarAutomovil model = new CAgregarAutomovil();
            return PartialView(model);
        }

        public ActionResult M08_VisualizarAutomoviles()
        {
            return PartialView();
        }

        public ActionResult M08_VisualizarAutomovil()
        {
            return PartialView();
        }

        public ActionResult M08_ModificarAutomovil()
        {
            return PartialView();
        }

        public static List<SelectListItem> GetDropDownListForYears()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "", Value = "" });
            for (int i = 1999; i <= 2016; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }

        public static List<SelectListItem> cantidadpasajeros()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "", Value = "" });

            for (int i = 1; i <= 10; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }

        [HttpPost]
        public JsonResult saveVehicle(CAgregarAutomovil model)
        {
            String prueba = model._matricula;
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE"+prueba);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

    }
}
