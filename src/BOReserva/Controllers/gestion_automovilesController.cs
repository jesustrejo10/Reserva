using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Servicio;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using System.Collections.Generic;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Clase controladora del módulo de Gestión de Automóviles
    /// </summary>
    public class gestion_automovilesController : Controller
    {
        /// <summary>
        /// Atributo ciudad.
        /// </summary>
        public static String _ciudad;
        /// <summary>
        /// Atributo pais.
        /// </summary>
        public static String _pais;


        #region Metodos Carga de Vistas

        #region Metodos para la Insercion de Automoviles

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
            /// Método que se utiliza para guardar un vehículo ingresado
            /// </summary>
            /// <param name="model">Datos que provienen de un formulario de la vista parcial M08_AgregarAutomovil</param>
            /// <returns>Retorna un JsonResult</returns>
            [HttpPost]
            public JsonResult saveVehicle(CAgregarAutomovil model)
            {

                String matricula = model._matricula.ToUpper();
                String anio = model._anio.ToString();
                String cantpasajeros = model._cantpasajeros.ToString();
                String ciudad = gestion_automovilesController._ciudad;
                String color = model._color;
                //String disponibilidad = model._disponibilidad.ToString();
                String fabricante = model._fabricante;
                String fecharegistro = model._fecharegistro.ToString();
                String kilometraje = model._kilometraje.ToString();
                String modelo = model._modelo;
                String pais = gestion_automovilesController._pais;
                String penalidaddiaria = model._penalidaddiaria.ToString();
                String precioalquiler = model._precioalquiler.ToString();
                String preciocompra = model._preciocompra.ToString();
                String tipovehiculo = model._tipovehiculo;
                String transmision = model._transmision;
                String disponibilidad = "1";
                String fk_ciudad = "0";
                Entidad carronuevo = FabricaEntidad.CrearAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                                                         cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                                                         color, disponibilidad, transmision, pais, ciudad, fk_ciudad);  //SE CREA EL VEHICULO
                                                                                                                                        //manejadorSQL buscarid = new manejadorSQL();
                                                                                                                                        //int id_ciudad = buscarid.MBuscaridciudadBD(_ciudad, pais);
                                                                                                                                        //String agrego_si_no = carronuevo.MAgregaraBD(carronuevo, id_ciudad); //SE AGREGA A LA BD RETORNA 1 SI SE AGREGA Y 0 SINO LO LOGRA

                //return (Json(agrego_si_no));
                return (Json("GUARDADO"));
            }

            #endregion

        #region Metodos para la Visualizacion de Automoviles
        
            /// <summary>
            /// Método de la vista parcial M08_VisualizarAutomoviles
            /// </summary>
            /// <returns>Retorna la vista parcial M08_VisualizarAutomoviles</returns>
            public ActionResult M08_VisualizarAutomoviles()
            {
                //var companies = DataRepository.GetCompanies();
                List<CVisualizarAutomovil> listaAutomoviles = new List<CVisualizarAutomovil>();
                //manejadorSQL buscarvehiculos = new manejadorSQL();
                //List<Automovil> listaAutomoviles = buscarvehiculos.MListarvehiculosBD();  //AQUI SE BUSCA TODO LOS VEHICULOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
                Automovil vehiculo = (Automovil)FabricaEntidad.CrearAutomovil("AG234FC", "3", "Mazda", "2006", "Sedan", "1589.5", "5", "7550.0", "250.6", "290.4", "11/11/2016", "Azul", "1", "Automatico", "Venezuela", "Caracas", "1");
                CVisualizarAutomovil automovil = new CVisualizarAutomovil();
                automovil._matricula = vehiculo.matricula.ToUpper();
                automovil._modelo = vehiculo.modelo;
                automovil._fabricante = vehiculo.fabricante;
                automovil._anio = vehiculo.anio;
                automovil._tipovehiculo = vehiculo.tipovehiculo;
                automovil._kilometraje = Convert.ToDouble(vehiculo.kilometraje.ToString());
                automovil._cantpasajeros = vehiculo.cantpasajeros;
                automovil._preciocompra = Convert.ToDouble(vehiculo.preciocompra.ToString());
                automovil._precioalquiler = Convert.ToDouble(vehiculo.precioalquiler.ToString());
                automovil._penalidaddiaria = Convert.ToDouble(vehiculo.penalidaddiaria.ToString());
                automovil._fecharegistro = vehiculo.fecharegistro.ToString();
                automovil._color = vehiculo.color;
                automovil._disponibilidad = vehiculo.disponibilidad;
                automovil._transmision = vehiculo.transmision;
                automovil._pais = vehiculo.pais;
                automovil._ciudad = vehiculo.ciudad;
                listaAutomoviles.Add(automovil);

                return PartialView(listaAutomoviles);
            }


            /// <summary>
            /// Método de la vista parcial M08_VisualizarAutomovil
            /// </summary>
            /// <param name="matricula">Matrícula del vehículo a visualizar</param>
            /// <returns>Retorna la vista parcial M08_VisualizarAutomovil</returns>
            public ActionResult M08_VisualizarAutomovil(String matricula)
            {

                //manejadorSQL buscarvehiculo = new manejadorSQL();
                //Automovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
                //EN TODOS ESTOS METODOS HAY QUE USAR TRY CATCH
                Automovil vehiculo = (Automovil)FabricaEntidad.CrearAutomovil("AG234FC", "3", "Mazda", "2006", "Sedan", "1589.5", "5", "7550.0", "250.6", "290.4", "11/11/2016", "Azul", "1", "Automatico", "Venezuela", "Caracas", "1");
                CVisualizarAutomovil automovil = new CVisualizarAutomovil();
                automovil._matricula = vehiculo.matricula.ToUpper();
                automovil._modelo = vehiculo.modelo;
                automovil._fabricante = vehiculo.fabricante;
                automovil._anio = vehiculo.anio;
                automovil._tipovehiculo = vehiculo.tipovehiculo;
                automovil._kilometraje = Convert.ToDouble(vehiculo.kilometraje.ToString());
                automovil._cantpasajeros = vehiculo.cantpasajeros;
                automovil._preciocompra = Convert.ToDouble(vehiculo.preciocompra.ToString());
                automovil._precioalquiler = Convert.ToDouble(vehiculo.precioalquiler.ToString());
                automovil._penalidaddiaria = Convert.ToDouble(vehiculo.penalidaddiaria.ToString());
                automovil._fecharegistro = vehiculo.fecharegistro.ToString();
                automovil._color = vehiculo.color;
                automovil._disponibilidad = vehiculo.disponibilidad;
                automovil._transmision = vehiculo.transmision;
                automovil._pais = vehiculo.pais;
                automovil._ciudad = vehiculo.ciudad;
                return PartialView(automovil);

                return PartialView(null);
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


            #endregion

        #region Metodos para la Modificacion de Un Automovil

            /// <summary>
            /// Método de la vista parcial M08_ModificarAutomovil
            /// </summary>
            /// <param name="matricula">Matrícula del vehículo a modificar</param>
            /// <returns>Retorna la vista parcial M08_ModificarAutomovil</returns>
            public ActionResult M08_ModificarAutomovil(String matricula)
            {

                //manejadorSQL buscarvehiculo = new manejadorSQL();
                //Automovil vehiculo = buscarvehiculo.MMostrarvehiculoBD(matricula); //BUSCA EL AUTOMOVIL A MOSTRAR
                //EN TODOS ESTOS METODOS HAY QUE USAR TRY CATCH
                Automovil vehiculo = (Automovil)FabricaEntidad.CrearAutomovil("AG234FC", "3", "Mazda", "2006", "Sedan", "1589.5", "5", "7550.0", "250.6", "290.4", "11/11/2016", "Azul", "1", "Automatico", "Venezuela", "Caracas", "1");
                CModificarAutomovil automovil = new CModificarAutomovil();
                automovil._matricula = vehiculo.matricula.ToUpper();
                automovil._modelo = vehiculo.modelo;
                automovil._fabricante = vehiculo.fabricante;
                automovil._anio = vehiculo.anio;
                automovil._tipovehiculo = vehiculo.tipovehiculo;
                automovil._kilometraje = Convert.ToDouble(vehiculo.kilometraje.ToString());
                automovil._cantpasajeros = vehiculo.cantpasajeros;
                automovil._preciocompra = Convert.ToDouble(vehiculo.preciocompra.ToString());
                automovil._precioalquiler = Convert.ToDouble(vehiculo.precioalquiler.ToString());
                automovil._penalidaddiaria = Convert.ToDouble(vehiculo.penalidaddiaria.ToString());
                automovil._fecharegistro = vehiculo.fecharegistro.ToString();
                automovil._color = vehiculo.color;
                automovil._disponibilidad = vehiculo.disponibilidad;
                automovil._transmision = vehiculo.transmision;
                automovil._pais = vehiculo.pais;
                automovil._ciudad = vehiculo.ciudad;
                return PartialView(automovil);

                return PartialView(null);
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
                String anio = model._anio.ToString();
                String cantpasajeros = model._cantpasajeros.ToString();
                String color = model._color;
                //String disponibilidad = model._disponibilidad.ToString();
                String fabricante = model._fabricante;
                String fecharegistro = Convert.ToString(new DateTime());
                String kilometraje = model._kilometraje.ToString();
                String modelo = model._modelo;

                String penalidaddiaria = model._penalidaddiaria.ToString();
                String precioalquiler = model._precioalquiler.ToString();
                String preciocompra = model._preciocompra.ToString();
                String tipovehiculo = model._tipovehiculo;
                String transmision = model._transmision;
                String disponibilidad = "1";
                String fk_ciudad = "0";
                String pais = gestion_automovilesController._pais;
                String ciudad = gestion_automovilesController._ciudad;

                Entidad carronuevo = FabricaEntidad.CrearAutomovil(matricula, modelo, fabricante, anio, tipovehiculo, kilometraje,
                                                                         cantpasajeros, preciocompra, precioalquiler, penalidaddiaria, fecharegistro,
                                                                         color, disponibilidad, transmision, pais, ciudad, fk_ciudad);  //SE CREA EL VEHICULO
                //manejadorSQL buscarid = new manejadorSQL();
                //int id_ciudad = buscarid.MBuscaridciudadBD(_ciudad, pais);
                //String modifico_si_no = carro.MModificarvehiculoBD(carro, id_ciudad); //SE MODIFICA A LA BD RETORNA 1 SI SE  MODIFICO Y 0 SI NO LO LOGRA

                //return (Json(modifico_si_no));

                return (Json("no"));
            }

        #endregion

        #region Metodo para la Eliminacion de un Automovil

        /// <summary>
        /// Método que se utiliza para eliminar un vehículo existente
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a eliminar</param>
        /// <returns>Retorna un JsonResult</returns>
        public JsonResult deleteVehicle(String matricula)
                        {
                            /*
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
                            */
                            return (Json("no"));
                        }

        #endregion

        #region Metodos para el Manejo de Disponibilidad de un Automovil

        /// <summary>
        /// Método para cambiar a "Disponible" el estatus de un vehículo
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo al que se le cambiará el estatus</param>
        /// <returns>Retorna un JsonResult</returns>
        [HttpPost]
            public JsonResult activateVehicle(String matricula)
            {
                /*
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
                */
                return (Json("ACTIVAR/DESACTIVAR"));
            }

            /// <summary>
            /// Método para cambiar a "No disponible" el estatus de un vehículo
            /// </summary>
            /// <param name="matricula">Matrícula del vehículo al que se le cambiará el estatus</param>
            /// <returns>Retorna un JsonResult</returns>
            [HttpPost]
            public JsonResult deactivateVehicle(String matricula)
            {
                /*
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
                */
                return (Json("no"));
            }

            #endregion


        #endregion


        #region Metodos Auxiliares

        /// <summary>
        /// Método para verificar si una matrícula esta registrada
        /// </summary>
        /// <param name="matricula">Matrícula a revisar</param>
        /// <returns>Retorna si esta o no repetida</returns>
        [HttpPost]
        public ActionResult checkplaca(String matricula)
        {    
            Command<bool> Comando = FabricaComando.existeMatriculaAutomovil(FabricaEntidad.CrearAutomovil(matricula));
            if (Comando.ejecutar())
            {
                return (Json("no"));
            }
            return (Json("si"));
            
        }


        /// <summary>
        /// Método que lista los años desde 1930 al 2016
        /// </summary>
        /// <returns>Retorna una lista de items que contine los años</returns>
        public static List<SelectListItem> listadeanios()
        {
            Command<List<SelectListItem>> Comando = FabricaComando.listarAniosAutomovil(new Entidad());
            return Comando.ejecutar();
        }


        /// <summary>
        /// Método que lista una cantidad de números
        /// </summary>
        /// <param name="cant">Tope hasta donde se va a listar</param>
        /// <returns>Retorna una lista de items que contine los números listados</returns>
        public static List<SelectListItem> cantidad(int cant)
        {
            Command<List<SelectListItem>> Comando = FabricaComando.listarCantidadAutomovil(new Entidad(), cant);
            return Comando.ejecutar();
        }


        /// <summary>
        /// Método que lista los colores disponibles para los vehículos
        /// </summary>
        /// <returns>Retorna una lista de items que contine los colores</returns>
        public static List<SelectListItem> colores()
        {
            Command<List<SelectListItem>> Comando = FabricaComando.listarColoresAutomovil(new Entidad());
            return Comando.ejecutar();
        }


        /// <summary>
        /// Método que guarda en una variable la ciudad seleccionada
        /// </summary>
        /// <param name="_ciudad">Nombre de la ciudad a guardar</param>
        [HttpPost]
        public void getCity(String _ciudad)
        {
            gestion_automovilesController._ciudad = _ciudad;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> pais()
        {
            Command<List<SelectListItem>> Comando = FabricaComando.consultarTodosPais(new Entidad());
            return Comando.ejecutar();
        }

        /// <summary>
        /// Método que retorna la lista de ciudades
        /// </summary>
        /// <param name="ciudad">Nombre del país del cual se desea conocer las ciudades disponibles</param>
        /// <returns>Retorna un ActionResult que contiene las ciudades disponibles para el país solicitado</returns>
        [HttpPost]
        public ActionResult listaciudades(String pais)
        {
            List<String> ciudades = new List<String>();
            Command<List<String>> Comando = FabricaComando.consultarTodosCiudad(new Entidad(),pais);
            ciudades = Comando.ejecutar();
            gestion_automovilesController._pais = pais;
            gestion_automovilesController._ciudad = ciudades.First();
            return Json(ciudades);
        }

        #endregion
    }
}
