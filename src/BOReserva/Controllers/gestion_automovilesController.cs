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
            //List<CAutomovil> listavehiculos = new List<CAutomovil>();
            CBasededatos_vehiculo buscarvehiculos = new CBasededatos_vehiculo();
            List<CAutomovil> listavehiculos = buscarvehiculos.MListarvehiculosBD();  //AQUI SE BUSCA TODO LOS VEHICULOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
           /*CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            listavehiculos.Add(test);*/

            return PartialView(listavehiculos);
        }

        public ActionResult M08_VisualizarAutomovil()
        {
            //CBasededatos_vehiculo buscarvehiculo = new CBasededatos_vehiculo();
            //Vehicle vehiculo = buscarvehiculo.MMostrarvehiculoBD(/*AQUI VA LA PLACA A BUSCAR*/); //BUSCA EL AUTOMOVIL A MOSTRAR
            return PartialView(/*SE PASA EL ATRIBUTO vehiculo*/);
        }

        public ActionResult M08_ModificarAutomovil()
        {
            //CBasededatos_vehiculo buscarvehiculo = new CBasededatos_vehiculo();
            //Vehicle vehiculo = buscarvehiculo.MMostrarvehiculoBD(/*AQUI VA LA PLACA A BUSCAR*/); //BUSCA EL AUTOMOVIL A MOSTRAR
            return PartialView(/*SE PASA EL ATRIBUTO vehiculo*/);
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
            String matricula = model._matricula;
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String ciudad = model._ciudad;
            String color = model._color;
            bool disponibilidad = model._disponibilidad;
            String estado = model._estado;
            String fabricante = model._fabricante;
            DateTime fecharegistro = model._fecharegistro;
            double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;
            CAutomovil carronuevo = new CAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje, 
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, 
                                             color, 1, transmision, pais, estado, ciudad);  //SE CREA EL VEHICULO
            int agrego_si_no = carronuevo.MAgregaraBD(carronuevo); //SE AGREGA A LA BD RETORNA 1 SI SE AGREGA Y 0 SINO LO LOGRA
            
            System.IO.File.WriteAllText(@"C:\Users\LAPGrock\Desktop\hola.txt", matricula +" "+modelo); //PRUEBA DE QUE SI SE SACAN BIEN LOS ATRIBUTOS DE LA VISTA
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
            double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
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
            double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
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
