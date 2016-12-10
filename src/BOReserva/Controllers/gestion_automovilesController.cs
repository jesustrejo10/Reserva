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
            //CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            //listavehiculos.Add(test);
            return PartialView(listavehiculos);
        }

        public ActionResult M08_VisualizarAutomovil(String matricula)
        {
            CBasededatos_vehiculo buscarvehiculo = new CBasededatos_vehiculo();
            CAutomovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
            //EN TODOS ESTOS METODOS HAY QUE USAR TRY CATCH
            //CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            CVisualizarAutomovil automovil = new CVisualizarAutomovil();
            automovil._matricula = vehiculo._matricula.ToUpper();
            automovil._modelo = vehiculo._modelo ;
            automovil._fabricante = vehiculo._fabricante ;
            automovil._anio = vehiculo._anio ;
            automovil._tipovehiculo = vehiculo._tipovehiculo ;
            automovil._kilometraje = vehiculo._kilometraje;
            automovil._cantpasajeros = vehiculo._cantpasajeros;
            automovil._preciocompra = vehiculo._preciocompra;
            automovil._precioalquiler = vehiculo._precioalquiler ;
            automovil._penalidaddiaria = vehiculo. _penalidaddiaria;
            automovil._fecharegistro = vehiculo._fecharegistro.Month + "/" + vehiculo._fecharegistro.Day + "/" + vehiculo._fecharegistro.Year;
            automovil._color = vehiculo._color ;
            automovil._disponibilidad = vehiculo._disponibilidad;
            automovil._transmision = vehiculo._transmision;
            automovil._pais = vehiculo._pais;
            automovil._ciudad = vehiculo._ciudad;
            return PartialView(automovil);
        }


     

        public ActionResult M08_ModificarAutomovil(String matricula)
        {
            CBasededatos_vehiculo buscarvehiculo = new CBasededatos_vehiculo();
            CAutomovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
            //EN TODOS ESTOS METODOS HAY QUE USAR TRY CATCH
            //CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            CModificarAutomovil automovil = new CModificarAutomovil();
            automovil._matricula = vehiculo._matricula;
            automovil._modelo = vehiculo._modelo;
            automovil._fabricante = vehiculo._fabricante;
            automovil._anio = vehiculo._anio;
            automovil._tipovehiculo = vehiculo._tipovehiculo;
            automovil._kilometraje = vehiculo._kilometraje;
            automovil._cantpasajeros = vehiculo._cantpasajeros;
            automovil._preciocompra = vehiculo._preciocompra;
            automovil._precioalquiler = vehiculo._precioalquiler;
            automovil._penalidaddiaria = vehiculo._penalidaddiaria;
            automovil._fecharegistro = vehiculo._fecharegistro.Month + "/" + vehiculo._fecharegistro.Day + "/" + vehiculo._fecharegistro.Year;
            automovil._color = vehiculo._color;
            automovil._disponibilidad = vehiculo._disponibilidad;
            automovil._transmision = vehiculo._transmision;
            automovil._pais = vehiculo._pais;
            automovil._ciudad = vehiculo._ciudad;
            return PartialView(automovil);
        }

        public static List<SelectListItem> GetDropDownListForYears()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "", Value = "" });
            for (int i = 1930; i <= 2016; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }

        public static List<SelectListItem> cantidad(int cant)
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "", Value = "" });

            for (int i = 1; i <= cant; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }

        public static List<SelectListItem> colores()
        {
            List<SelectListItem> _color = new List<SelectListItem>();
            _color.Add(new SelectListItem
            {
                Text = "Azul",
                Value = "Azul"
            });
            _color.Add(new SelectListItem
            {
                Text = "Negro",
                Value = "Negro"
            });
            _color.Add(new SelectListItem
            {
                Text = "Blanco",
                Value = "Blanco"
            });
            _color.Add(new SelectListItem
            {
                Text = "Rojo",
                Value = "Rojo"
            });
            _color.Add(new SelectListItem
            {
                Text = "Gris",
                Value = "Gris"
            });
            _color.Add(new SelectListItem
            {
                Text = "Verde",
                Value = "Verde"
            });
            return _color;
        }

       

        [HttpPost]
        public JsonResult saveVehicle(CAgregarAutomovil model)
        {
            String matricula = model._matricula.ToUpper();
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String ciudad = model._ciudad;
            String color = model._color;
            bool disponibilidad = model._disponibilidad;
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
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            int agrego_si_no = carronuevo.MAgregaraBD(carronuevo); //SE AGREGA A LA BD RETORNA 1 SI SE AGREGA Y 0 SINO LO LOGRA
            
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult modifyVehicle(CModificarAutomovil model)
        {
            String matricula = model._matricula.ToUpper();
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String color = model._color;
            bool disponibilidad = true;
            String fabricante = model._fabricante;
            DateTime fecharegistro = Convert.ToDateTime(model._fecharegistro);
            double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = model._pais;
            String ciudad = model._ciudad;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;

            CAutomovil carro = new CAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje, 
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, 
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            int modifico_si_no = carro.MModificarvehiculoBD(carro); //SE MODIFICA A LA BD RETORNA 1 SI SE  MODIFICO Y 0 SI NO LO LOGRA
            
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
            int disponibilidad = model._disponibilidad;
            String fabricante = model._fabricante;
            String fecharegistro = model._fecharegistro;
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


        
        public JsonResult deleteVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
            int disponibilidad = 0;
            String fabricante = "";
            DateTime fecharegistro = DateTime.Now;
            double kilometraje = 0;
            String modelo = "";
            String pais = "";
            double penalidaddiaria = 0;
            double precioalquiler = 0;
            double preciocompra = 0;
            String tipovehiculo = "";
            String transmision = "";
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE" + matricula);
            CAutomovil carro = new CAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            int modifico_si_no = carro.MBorrarvehiculoBD(_matricula); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(true, JsonRequestBehavior.AllowGet));
        }



        public static List<SelectListItem> ciudades()
        {
            List<SelectListItem> _ciudad = new List<SelectListItem>();
            _ciudad.Add(new SelectListItem
            {
                Text = "Caracas",
                Value = "Caracas"
            });
            _ciudad.Add(new SelectListItem
            {
                Text = "Los Teques",
                Value = "Teques"
            });
            _ciudad.Add(new SelectListItem
            {
                Text = "Dallas",
                Value = "Dallas"
            });
            return _ciudad;
        }

        public static List<SelectListItem> pais()
        {
            CBasededatos_vehiculo pais = new CBasededatos_vehiculo();
            List<SelectListItem> _pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();
            int i = 0;
            bool verdad =true;
            while (verdad == true)
            {
                try
                {
                    _pais.Add(new SelectListItem
                    {
                        Text = paises[i].ToString(),
                        Value = i.ToString()
                    });
                    i++;
                }
                catch (Exception e) { 
                    verdad = false;
                }
            }
            return _pais;
        }


        public JsonResult activateVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
            int disponibilidad = 0;
            String fabricante = "";
            DateTime fecharegistro = DateTime.Now;
            double kilometraje = 0;
            String modelo = "";
            String pais = "";
            double penalidaddiaria = 0;
            double precioalquiler = 0;
            double preciocompra = 0;
            String tipovehiculo = "";
            String transmision = "";
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE" + matricula);
            CAutomovil carro = new CAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            int estatus_si_no = carro.MDisponibilidadVehiculoBD(_matricula, 1); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        
        public JsonResult deactivateVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
            int disponibilidad = 0;
            String fabricante = "";
            DateTime fecharegistro = DateTime.Now;
            double kilometraje = 0;
            String modelo = "";
            String pais = "";
            double penalidaddiaria = 0;
            double precioalquiler = 0;
            double preciocompra = 0;
            String tipovehiculo = "";
            String transmision = "";
            Debug.WriteLine("IMPRIMIENDO UN MENSAJE" + matricula);
            CAutomovil carro = new CAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            int estatus_si_no = carro.MDisponibilidadVehiculoBD(_matricula, 0); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        

    }
}
