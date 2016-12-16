using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Servicio;
namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase controladora del módulo de Gestión de Automóviles
    /// </summary>
    public class gestion_automovilesController : Controller
    {
        
        public static String ciudad;
        public static String _pais;



        /// <summary>
        /// Método de la vista parcial M08_AgregarAutomovil
        /// </summary>
        /// <returns>Retorna la vista parcial M08_AgregarAutomovil</returns>
        public ActionResult M08_AgregarAutomovil()
        {
            CAgregarAutomovil model = new CAgregarAutomovil();
            return PartialView(model);
        }


        /// <summary>
        /// Método de la vista parcial M08_VisualizarAutomoviles
        /// </summary>
        /// <returns>Retorna la vista parcial M08_VisualizarAutomoviles</returns>
        public ActionResult M08_VisualizarAutomoviles()
        {
            //var companies = DataRepository.GetCompanies();
            //List<CAutomovil> listavehiculos = new List<CAutomovil>();
            manejadorSQL buscarvehiculos = new manejadorSQL();
            List<Automovil> listavehiculos = buscarvehiculos.MListarvehiculosBD();  //AQUI SE BUSCA TODO LOS VEHICULOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            //CAutomovil test = new CAutomovil("AG234FC", "3", "Mazda", 2006, "Sedan", 1589.5, 5, 7550.0, 250.6, 290.4, DateTime.Parse("11/11/2016"), "Azul", 1, "Automatico", "Venezuela", "Distrito Capital", "Caracas");
            //listavehiculos.Add(test);
            return PartialView(listavehiculos);
        }



        /// <summary>
        /// Método de la vista parcial M08_VisualizarAutomovil
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a visualizar</param>
        /// <returns>Retorna la vista parcial M08_VisualizarAutomovil</returns>
        public ActionResult M08_VisualizarAutomovil(String matricula)
        {
            manejadorSQL buscarvehiculo = new manejadorSQL();
            Automovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
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



        /// <summary>
        /// Método de la vista parcial M08_ModificarAutomovil
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a modificar</param>
        /// <returns>Retorna la vista parcial M08_ModificarAutomovil</returns>
        public ActionResult M08_ModificarAutomovil(String matricula)
        {
            manejadorSQL buscarvehiculo = new manejadorSQL();
            Automovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
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


        /// <summary>
        /// Método que lista los años desde 1930 al 2016
        /// </summary>
        /// <returns>Retorna una lista de items que contine los años</returns>
        public static List<SelectListItem> listadeanios()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "", Value = "" });
            for (int i = 1930; i <= 2016; i++)
            {
                ls.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
            }

            return ls;
        }


        /// <summary>
        /// Método que lista una cantidad de números
        /// </summary>
        /// <param name="cant">Tope hasta donde se va a listar</param>
        /// <returns>Retorna una lista de items que contine los números listados</returns>
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


        /// <summary>
        /// Método que lista los colores disponibles para los vehículos
        /// </summary>
        /// <returns>Retorna una lista de items que contine los colores</returns>
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


        /// <summary>
        /// Método que guarda en una variable la ciudad seleccionada
        /// </summary>
        /// <param name="_ciudad">Nombre de la ciudad a guardar</param>
        [HttpPost]
        public void getCity(String _ciudad)
        {
            ciudad = _ciudad;
        }

        /// <summary>
        /// Método que se utiliza para guardar un vehículo ingresado
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M08_AgregarAutomovil</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult saveVehicle(CAgregarAutomovil model)
        {
            String matricula = model._matricula.ToUpper();
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String _ciudad = ciudad;
            String color = model._color;
            bool disponibilidad = model._disponibilidad;
            String fabricante = model._fabricante;
            DateTime fecharegistro = model._fecharegistro;
            double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = _pais;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;
            Automovil carronuevo = new Automovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje, 
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, _ciudad);  //SE CREA EL VEHICULO
            manejadorSQL buscarid = new manejadorSQL();
            int id_ciudad = buscarid.MBuscaridciudadBD(_ciudad, pais);
            String agrego_si_no = carronuevo.MAgregaraBD(carronuevo, id_ciudad); //SE AGREGA A LA BD RETORNA 1 SI SE AGREGA Y 0 SINO LO LOGRA
            
            return (Json(agrego_si_no));
        }


        /// <summary>
        /// Método que se utiliza para modificar un vehículo existente
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M08_ModificarAutomovil</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult modifyVehicle(CModificarAutomovil model)
        {
            String matricula = model._matricula.ToUpper();
            int anio = model._anio;
            int cantpasajeros = model._cantpasajeros;
            String color = model._color;
            String fabricante = model._fabricante;
            DateTime fecharegistro = new DateTime();

                double kilometraje = model._kilometraje;
            String modelo = model._modelo;
            String pais = _pais;
            String _ciudad = ciudad;
            double penalidaddiaria = model._penalidaddiaria;
            double precioalquiler = model._precioalquiler;
            double preciocompra = model._preciocompra;
            String tipovehiculo = model._tipovehiculo;
            String transmision = model._transmision;

            Automovil carro = new Automovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje, 
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, 
                                             color, 1, transmision, pais, _ciudad);  //SE CREA EL VEHICULO
            manejadorSQL buscarid = new manejadorSQL();
            int id_ciudad = buscarid.MBuscaridciudadBD(_ciudad, pais);
            String modifico_si_no = carro.MModificarvehiculoBD(carro, id_ciudad); //SE MODIFICA A LA BD RETORNA 1 SI SE  MODIFICO Y 0 SI NO LO LOGRA
            
            return (Json(modifico_si_no));
        }

        /// <summary>
        /// Método que se utiliza para visualizar un vehículo ingresado
        /// </summary>
        /// <param name="model">Datos que provienen de un formulario de la vista parcial M08_VisualizarAutomovil</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult viewVehicle(CVisualizarAutomovil model)
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



        /// <summary>
        /// Método que se utiliza para eliminar un vehículo existente
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult deleteVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
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
            Automovil carro = new Automovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            String borro_si_no = carro.MBorrarvehiculoBD(_matricula); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(borro_si_no));
        }


        /// <summary>
        /// Método que retorna la lista de países
        /// </summary>
        /// <returns>Retorna una lista de Items que contiene los países disponibles</returns>
        public static List<SelectListItem> pais()
        {
            manejadorSQL pais = new manejadorSQL();
            List<SelectListItem> __pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();
            int i = 0;
            bool verdad =true;
            _pais = paises[0];
            while (verdad == true)
            {
                try
                {
                    __pais.Add(new SelectListItem
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
            return __pais;
        }

        /// <summary>
        /// Método que retorna la lista de ciudades
        /// </summary>
        /// <param name="pais">Nombre del país del cual se desea conocer las ciudades disponibles</param>
        /// <returns>Retorna un ActionResult que contiene las ciudades disponibles para el país solicitado</returns>
        [HttpPost]
        public ActionResult listaciudades(String pais)
        {
            List<String> objcity = new List<String>();
            _pais = pais;
            manejadorSQL listaciudades = new manejadorSQL();
            int fk = listaciudades.MIdpaisesBD(pais);
            objcity = listaciudades.MListarciudadesBD(fk);
            ciudad = objcity.First();
            return Json(objcity);
        }

        /// <summary>
        /// Método para cambiar a "Disponible" el estatus de un vehículo
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo al que se le cambiará el estatus</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult activateVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
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
            Automovil carro = new Automovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            String estatus_si_no = carro.MDisponibilidadVehiculoBD(_matricula, 1); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(estatus_si_no));
        }

        /// <summary>
        /// Método para cambiar a "No disponible" el estatus de un vehículo
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo al que se le cambiará el estatus</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
        public JsonResult deactivateVehicle(String matricula)
        {
            String _matricula = matricula;
            int anio = 0;
            int cantpasajeros = 0;
            String ciudad = "";
            String color = "";
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
            Automovil carro = new Automovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                             cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                             color, 1, transmision, pais, ciudad);  //SE CREA EL VEHICULO
            String estatus_si_no = carro.MDisponibilidadVehiculoBD(_matricula, 0); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(estatus_si_no));
        }

        /// <summary>
        /// Método para verificar si una matrícula esta registrada
        /// </summary>
        /// <param name="matricula">Matrícula a revisar</param>
        /// <returns>Retorna si esta o no repetida</returns>
        [HttpPost]
        public ActionResult checkplaca(String matricula)
        {
            manejadorSQL placa = new manejadorSQL();
            int existe = placa.MPlacarepetidaBD(matricula); 
            return Json(existe);
        } 

    }
}

