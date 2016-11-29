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
            //var companies = DataRepository.GetCompanies();
            List<Vehicle> mVehicles = new List<Vehicle>();
            Vehicle test = new Vehicle(1, "foca", "foculia", "focasa");
            mVehicles.Add(test);

            return PartialView(mVehicles);
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

        [HttpPost]
        public JsonResult modifyVehicle(CModificarAutomovil model)
        {
            String matricula = model._matricula;
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String ciudad = model._ciudad;
            String color = model._color;
            bool disponibilidad = model._disponibilidad;
            String estado = model._estado;
            String fabricante = model._fabricante;
            DateTime fecharegistro = model._fecharegistro;
            float kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            float penalidaddiaria = model._penalidaddiaria;
            float precioalquiler = model._precioalquiler;
            float preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE" + matricula);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult viewVehicle(CModificarAutomovil model)
        {
            String matricula = model._matricula;
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String ciudad = model._ciudad;
            String color = model._color;
            bool disponibilidad = model._disponibilidad;
            String estado = model._estado;
            String fabricante = model._fabricante;
            DateTime fecharegistro = model._fecharegistro;
            float kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            float penalidaddiaria = model._penalidaddiaria;
            float precioalquiler = model._precioalquiler;
            float preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE" + matricula);
            return (Json(true, JsonRequestBehavior.AllowGet));
        }


        public string DeleteData(int id){
            //TODO hacer el metodo
            return null;
        }
        public string UpdateData(int id, string value, int? rowId,
               int? columnPosition, int? columnId, string columnName){
                   return null;
            }
        public int AddData(string name, string address, string town, int? country){
            return 1;

        }
    }
}
