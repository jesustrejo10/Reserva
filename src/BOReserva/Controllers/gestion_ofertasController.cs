﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_ofertas;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_automoviles;
using BOReserva.Models.gestion_restaurantes;
using System.Collections.Specialized;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using System.Diagnostics;
using BOReserva.DataAccess.DataAccessObject.M11;
using BOReserva.Excepciones.M09;



namespace BOReserva.Controllers
{
    public class gestion_ofertasController : Controller
    {
        //
        // GET: /gestion_ofertas/
        private static int idpaquete;
        private static int idOferta;
        /// <summary>
        /// Carga la vista de Agregar Paquete
        /// </summary>
        /// <returns></returns>
        public ActionResult M11_AgregarPaquete()
        {
            CAgregarPaquete model = new CAgregarPaquete();
            return PartialView();
        }

        /// <summary>
        /// Carga la Vista de Agegar Oferta.
        /// </summary>
        /// <returns>Vista parcial con formulario Agregar Oferta.</returns>
        public ActionResult M11_AgregarOferta()
        {
            return PartialView();
        }
         /// <summary>
        /// Método de la vista parcial M11_VisualizarPaquete
         /// </summary>
        /// <returns>Retorna la vista parcial M11_VisualizarPaquetes en conjunto del Modelo de dicha vista</returns>
        public ActionResult M11_VisualizarPaquete()
        {
            Command<List<Entidad>> comando = FabricaComando.crearM11VisualizarPaquetes();
            List<Entidad> listaPaquetes = comando.ejecutar();
            return PartialView(listaPaquetes);
            /*manejadorSQL sql = new manejadorSQL();
            List<CPaquete> paquetes = new List<CPaquete>();
            paquetes = sql.listarPaquetes();
            return PartialView(paquetes);*/
        }

        /// <summary>
        /// Detalle Paquete con ID Striing
        /// </summary>
        /// <param name="paqueteIdStr"></param>
        /// <returns></returns>
        public ActionResult M11_DetallePaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);
        }

        /// <summary>
        /// Detalle Paquetes.
        /// </summary>
        /// <param name="paqueteIdStr"></param>
        /// <returns></returns>
        public JsonResult infoPaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return Json(paquete);
        }

        /// <summary>
        /// Método para Visalizar la lista de Ofertas.
        /// </summary>
        /// <returns>Vista Parcial con la Lista de Ofertas disponibles</returns>
        public ActionResult M11_VisualizarOferta()
        {
            Debug.WriteLine("BOTON VISUALIZAR OFERTA");
            Command<List<Entidad>> comando = FabricaComando.crearM11VisualizarOfertas();
            List<Entidad> listaOfertas = comando.ejecutar();
            return PartialView(listaOfertas);
        }

        /// <summary>
        /// Lista de Paquetes por Oferta.
        /// </summary>
        /// <returns></returns>
        public List<COferta> M11_PaquetesPorOferta()
        {
            manejadorSQL sql = new manejadorSQL();
            List<COferta> ofertas = new List<COferta>();
            ofertas = sql.listarOfertasEnBD();
            return (ofertas);
        }
        
        /// <summary>
        /// Lista de Automóviles disponibles
        /// </summary>
        /// <returns>Lista de Automóviles</returns>
        [HttpPost]
        public JsonResult M11_ListarAutomoviles()
        {
            DAOPaquete daopaq = new DAOPaquete();
            List<CVisualizarAutomovil> listAutos = new List<CVisualizarAutomovil>();
            listAutos = daopaq.consultarAutos();
            return Json(listAutos);
            /*Automovil automovil = new Automovil();
            return Json(automovil.MListarvehiculos());
            return null;*/
        }

        /// <summary>
        /// Lista de Restaurantes
        /// </summary>
        /// <returns>La Lista de Restaurantes</returns>
        [HttpPost]
        public JsonResult M11_ListarRestaurantes()
        {
            //manejadorSQL sql = new manejadorSQL();
            DAOPaquete daopaq = new DAOPaquete();
            List<CConsultar> listRestaurante = new List<CConsultar>();
            listRestaurante = daopaq.consultarRestaurante();
            return Json(listRestaurante);
            //Metodos para M11 Probados 
           /* Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoRestaurant.LISTAR_RESTAURANT, null);
            List <Entidad> restaurantes = comando.ejecutar();
            //esto ya no se usa
            //return Json(restauranteList);
            /*List<CRestauranteModelo> lista = FabricaEntidad.crearListaRestarant();
            CRestauranteModelo rest;
            foreach (Entidad re in restaurantes)
            {
                rest = (CRestauranteModelo)re;
                lista.Add(rest);


            }



            CRestauranteModelo Restaurant = FabricaEntidad.crearRestaurant();
            List<CRestauranteModelo> lista = FabricaEntidad.crearListaRestarant();

            foreach (Entidad item in restaurantes)
            {
                lista.Add((CRestauranteModelo)item);
            }
            */

        }

        /// <summary>
        /// Modificar la vista Modificar Paquete
        /// </summary>
        /// <param name="paqueteIdStr"></param>
        /// <returns></returns>
        public ActionResult M11_ModificarPaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(paqueteId);
            Entidad ePaquete = comando.ejecutar();
            Paquete paquete = (Paquete)ePaquete;
            String disponibilidad = "Inactivo";
            if (paquete._estadoPaquete == true) { disponibilidad = "Activo"; } else { disponibilidad = "Inactivo"; }

            idpaquete = paqueteId;

            CPaquete visualPaquete = new CPaquete();

            visualPaquete._idPaquete = paquete._idPaquete;
            visualPaquete._nombrePaquete = paquete._nombrePaquete;
            visualPaquete._precioPaquete = paquete._precioPaquete;
            visualPaquete._idAuto = paquete._idAuto;
            visualPaquete._idRestaurante = paquete._idRestaurante;
            visualPaquete._idHabitacion = paquete._idHotel;
            visualPaquete._idCrucero = paquete._idCrucero;
            visualPaquete._idVuelo = paquete._idVuelo;

            visualPaquete._fechaIniAuto = paquete._fechaIniAuto;
            visualPaquete._fechaIniRest = paquete._fechaIniRest;
            visualPaquete._fechaIniHabi = paquete._fechaIniHotel;
            visualPaquete._fechaIniCruc = paquete._fechaIniCruc;
            visualPaquete._idVuelo = paquete._idVuelo;


            Debug.WriteLine("RELLENA");

            CPaquete cpaquete = new CPaquete();
            //todavía falta

            //Comentar estas 4 líneas siguientes que funcionaban antes de esta entrega
            //Descimentándolas mientras se adapta a patrones
            /*manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);*/
            return PartialView(visualPaquete); 
            //
        }

        /// <summary>
        /// Método para Visualizar Oferta en Detalle.
        /// </summary>
        /// <param name="id">Id de la Oferta a Consultar.</param>
        /// <returns>Oferta a Modificar.</returns>
        public ActionResult M11_ConsultarOferta(int id)
        {
            Debug.WriteLine("BOTON VISUALIZAR OFERTA");

            Debug.WriteLine("ID EN LISTA" + id.ToString());

            Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
            Entidad eOferta = comando.ejecutar();

           //  METER EN UN TRY CATCH
            Oferta oferta = (Oferta)eOferta;

            String disponibilidad = "Inactivo";
            if (oferta._estadoOferta == true) { disponibilidad = "Activo"; } else { disponibilidad = "Inactivo"; }

            CVisualizarOferta visualOferta = new CVisualizarOferta();           

            visualOferta._idOferta = oferta._idOfertaa;
            visualOferta._nombreOferta = oferta._nombreOferta;
            visualOferta._nombrePaquete = oferta._nombrePaquete;
            visualOferta._porcentajeOferta = oferta._porcentajeOferta;
            visualOferta._fechaIniOferta = oferta._fechaIniOferta.Day + "/" + oferta._fechaIniOferta.Month + "/" + oferta._fechaIniOferta.Year;
            visualOferta._fechaFinOferta = oferta._fechaFinOferta.Day + "/" + oferta._fechaFinOferta.Month + "/" + oferta._fechaFinOferta.Year;
            visualOferta._estadoOferta = disponibilidad;
            return PartialView(visualOferta);
        }

        /// <summary>
        /// Método para Modificar Oferta. Lee desde la Vista.
        /// </summary>
        /// <param name="id">id de la oferta seleccionada</param>
        /// <returns></returns>
        public ActionResult M11_ModificarOferta(int id)
        {
            Debug.WriteLine("BOTON MODIFICAR OFERTA");
            Debug.WriteLine("ID EN LISTA" + id.ToString());

            Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
            Entidad eOferta = comando.ejecutar();
            Oferta oferta = (Oferta)eOferta;

            String disponibilidad = "Inactivo";
            if (oferta._estadoOferta == true) { disponibilidad = "Activo"; } else { disponibilidad = "Inactivo"; }

            idOferta = id;

            CModificarOferta visualOferta = new CModificarOferta();

            visualOferta._idOferta = oferta._idOferta;
            visualOferta._nombreOferta = oferta._nombreOferta;
            visualOferta._nombrePaquete = oferta._nombrePaquete;
            visualOferta._porcentajeOferta = oferta._porcentajeOferta;
            visualOferta._fechaIniOferta = oferta._fechaIniOferta;
            visualOferta._fechaFinOferta = oferta._fechaFinOferta;
            visualOferta._estadoOferta = disponibilidad;
            

            Debug.WriteLine("RELLENA");

            COferta coferta = new COferta();

       /*     try
            {
                visualOferta._listaPaquetes = coferta.MBuscarPaquetesAsociadosBD(idOferta.ToString());
            }
            catch (NullReferenceException e)
            {
                return PartialView(visualOferta);
            }
            */
            return PartialView(visualOferta); //Es del tipo modificarOerta
        }

        /// <summary>
        /// Método post que realiza el cambio en la base de datos.
        /// </summary>
        /// <param name="model">Model Oferta a Modificar.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult modifyOferta(CModificarOferta model)
        {
            Debug.WriteLine("ENTRÓ A MODIFY OFERTA");
            Debug.WriteLine("NOMBRE OFERTA RECOGIDO" + model._nombreOferta);
            Debug.WriteLine("ENTRÓ A MODIFY OFERTA " + idOferta);

            int _id = idOferta;

            Boolean disponibilidad = false;

            Entidad modificarOferta = FabricaEntidad.InstanciarOferta(model, disponibilidad, _id);
            //con la fabrica instancie a la oferta.
            Command<String> comando = FabricaComando.crearM11ModificarOferta(modificarOferta, _id);
            String agrego_si_no = comando.ejecutar();
            return (Json(agrego_si_no));
        }

        //Carga paquetes en el multiselect de agregar oferta
        public JsonResult M11_CargarPaquetesSelect()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CPaquete> paquetesList = new List<CPaquete>();
            paquetesList = sql.listarPaquetesEnBD();
            return Json(paquetesList);
        }

        //Carga paquetes en el multiselect de agregar oferta
        public JsonResult M11_CargarPaquetesAsociados(int idOferta)
        {
            manejadorSQL sql = new manejadorSQL();
            List<CPaquete> paquetesList = new List<CPaquete>();
            paquetesList = sql.listarPaquetesAsociados(idOferta);
            return Json(paquetesList);
        }

        [HttpPost]
        public JsonResult M11_ListarHoteles()
        {
            //manejadorSQL sql = new manejadorSQL();
            DAOPaquete daopaq = new DAOPaquete();
            List<CConsultar> listHoteles = new List<CConsultar>();
            listHoteles = daopaq.listarHotelesM11();
            return Json(listHoteles);
        }

        [HttpPost]
        public JsonResult M11_ListarCruceros()
        {
            //manejadorSQL sql = new manejadorSQL();
            DAOPaquete daopaq = new DAOPaquete();
            List<CConsultar> listCruceros = new List<CConsultar>();
            listCruceros = daopaq.listarCrucerosM11();
            return Json(listCruceros);

            //Código nuevo para la segunda entrega
            /*List<String> lista = new List<string>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM14VisualizarCruceros();
            Dictionary<int, Entidad> listaCruceros = comando.ejecutar();
            foreach (var crucero in listaCruceros)
            {
                    BOReserva.DataAccess.Domain.Crucero c = (BOReserva.DataAccess.Domain.Crucero)crucero.Value;
                    lista.Add(c._nombreCrucero);
                    Debug.WriteLine("Crucero: " + c._nombreCrucero);
            }
            return Json(lista);*/
        }

        [HttpPost]
        public JsonResult M11_ListarVuelos()
        {
            //manejadorSQL sql = new manejadorSQL();
            DAOPaquete daopaq = new DAOPaquete();
            List<CConsultar> listVuelos = new List<CConsultar>();
            listVuelos = daopaq.listarVuelosM11();
            return Json(listVuelos);

            //Código nuevo para la segunda entrega
            /*List<String> lista = new List<String>();
            List<CConsultar> listVuelos2 = new List<CConsultar>();
            CConsultar consulta = new CConsultar();
            List<Entidad> listaVuelos;
            Command<List<Entidad>> comando = FabricaComando.ConsultarM04_ConsultarTodos();
            listaVuelos = comando.ejecutar();
            foreach (Entidad vuelo in listaVuelos)
            {
                Vuelo v = (Vuelo)vuelo;
                Ruta ruta = v.getRuta;
                String origen = ruta.origenRuta;
                String destino = ruta.destinoRuta;
                String origen_destino = origen + "-" + destino;
                Debug.WriteLine("La ruta es: "+origen_destino);
                consulta._id = v.IdVuelo;
                consulta._codigoVuelo = v.CodigoVuelo;
                consulta._nombreSalida = origen;
                consulta._nombreLlegada = destino;
                listVuelos2.Add(consulta);
               // lista.Add(origen_destino);
        }
            return Json(listVuelos2);*/
        }


        [HttpPost]
        public JsonResult asociarPaquetesOferta(int[] idsPaquetes)
        {
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.asociarOfertaPaquete(idsPaquetes);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error insertando en la BD";
                return Json(error);
            }
        }

        [HttpPost]
        public JsonResult asociarPaquetesModificar(int[] idsPaquetes, int idOferta)
        {
            if (idsPaquetes != null)
            {
                //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
                //instancio el manejador de sql
                manejadorSQL sql = new manejadorSQL();
                //realizo el insert
                bool resultado = sql.asociarPaquetesModificar(idsPaquetes, idOferta);
                //envio una respuesta dependiendo del resultado del insert
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error insertando en la BD";
                    return Json(error);
                }
            }
            return Json("");
        }

     /*   [HttpPost]
        public JsonResult obtenerOferta(int idOferta)
        {
            manejadorSQL sql = new manejadorSQL();
            COferta oferta = new COferta();
            oferta = sql.obtenerOferta(idOferta);
            return Json(oferta);
        }*/

        

        [HttpPost]
        public JsonResult desasociarPaquetesModificar(int[] idsPaquetes,int idOferta)
        {
            if (idsPaquetes != null)
            {
                //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
                //instancio el manejador de sql
                manejadorSQL sql = new manejadorSQL();
                //realizo el insert
                bool resultado = sql.desasociarPaquetesModificar(idsPaquetes, idOferta);
                //envio una respuesta dependiendo del resultado del insert
                if (resultado)
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error insertando en la BD";
                    return Json(error);
                }
            }
            return Json("");
        }


        public JsonResult deletePaquete(String idPaquete)
        {
            int _idPaquete = Int32.Parse(idPaquete.ToString());

            String _idOfertaa = "";
            String _nombreOferta = "";
            float _porcentajeOferta = float.Parse(idPaquete.ToString());
            DateTime _fechaIniOferta = System.DateTime.Now;
            DateTime _fechaFinOferta = System.DateTime.Now;

            COferta oferta = new COferta(_idOfertaa, _nombreOferta, _porcentajeOferta, _fechaIniOferta, _fechaFinOferta, false);

            int modifico_si_no = oferta.MDesvincularPaqueteDeOfertaBD(_idPaquete); //SE BORRA LA BD RETORNA 1 SI SE  BORRA Y 0 SI NO LO LOGRA
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        /// <summary>
        /// Método para Guardar Oferta.
        /// </summary>
        /// <param name="model">La Oferta</param>
        /// <param name="estadoOferta">Dsponible 1, No disponible 0</param>
        /// <returns>Resultado del Guardado n BD</returns>
        [HttpPost]
        public JsonResult guardarOferta(CAgregarOferta model, string estadoOferta)
        {
            
            if (estadoOferta == "1")
                model._estadoOferta = true;
            else
                model._estadoOferta = false;
            //Chequeo si los campos obligatorios estan vacios como medida de seguridad
            if ((model._nombreOferta == null) || (model._porcentajeOferta == 0) || (model._fechaIniOferta == null) || (model._fechaFinOferta == null))
            {
                

                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Error: Campo obligatorio vacio";
                //Retorno el error
                return Json(error);
            }


            if (model._fechaFinOferta.Date < model._fechaIniOferta.Date)
            {
               Response.StatusCode = (int)HttpStatusCode.BadRequest;
               String Error = "Error: La fecha de Inicio no puede ser igual a la fecha Fin";
               return Json(Error);
            }

            Entidad nuevaOferta = FabricaEntidad.InstanciarOferta(model);
            //con la fabrica instancie la oferta.
            Command<String> comando = FabricaComando.crearM11AgregarOferta(nuevaOferta);
            String agrego_si_no = comando.ejecutar();

            return (Json(agrego_si_no));
        }

        [HttpPost]
        public JsonResult guardarPaquete(String nombrePaq, String idAuto, int idHotel, int idCrucero, int idRestaurante, 
                                          int idVuelo, String fiAuto, String ffAuto, String fiHotel, String ffHotel,
                                          String fiCrucero, String ffCrucero,String fiRestaurante, String ffRestaurante,
                                          String fiVuelo, String ffVuelo, String precio, String estado)
        {
           // manejadorSQL sql = new manejadorSQL();
            CPaquete paquete = new CPaquete();
            if (estado == "1")
                paquete._estadoPaquete = true;
            else
                paquete._estadoPaquete = false;
            paquete._nombrePaquete = nombrePaq;
            if (idAuto == "00")
                idAuto = null;

            if (idHotel != 0)
                paquete._idHabitacion = idHotel;

            if (idCrucero != 0)
                paquete._idCrucero = idCrucero;

            if (idRestaurante !=0)
                paquete._idRestaurante = idRestaurante;

            if(idVuelo !=0)
                paquete._idVuelo = idVuelo;

            if (fiAuto == "")
                fiAuto = null;
            else
                paquete._fechaIniAuto = DateTime.Parse(fiAuto);
            if (ffAuto == "")
                ffAuto = null;
            else
                paquete._fechaFinAuto = DateTime.Parse(ffAuto);
            if (fiHotel == "")
                fiHotel = null;
            else
                paquete._fechaIniHabi = DateTime.Parse(fiHotel);

            if (ffHotel == "")
                ffHotel = null;
            else
                paquete._fechaFinHabi = DateTime.Parse(ffHotel);

            if (fiCrucero == "")
                fiCrucero = null;
            else
                paquete._fechaIniCruc = DateTime.Parse(fiCrucero);
            
            if (ffCrucero == "")
                ffCrucero = null;
            else
                paquete._fechaFinCruc = DateTime.Parse(ffCrucero);

            if (fiRestaurante== "")
                fiRestaurante = null;
            else
                paquete._fechaIniRest = DateTime.Parse(fiRestaurante);
            if (ffRestaurante == "")
                ffRestaurante = null;
            else
                paquete._fechaFinRest = DateTime.Parse(ffRestaurante);

            if (fiVuelo == "")
                fiVuelo = null;
            else
                paquete._fechaIniVuelo = DateTime.Parse(fiVuelo);

            if (ffVuelo == "")
                ffVuelo = null;
            else
                paquete._fechaFinVuelo = DateTime.Parse(ffVuelo);

                paquete._idAuto = idAuto;
                paquete._precioPaquete = float.Parse(precio);
                //sql.agregarPaquete(paquete);

            //return Json(true);
                Entidad nuevoPaquete = FabricaEntidad.InstanciarPaquete(paquete);
                //Con la fábrica se instancia el paquete.
                Command<String> comando = FabricaComando.crearM11AgregarPaquete(nuevoPaquete);
                String agrego_si_no = comando.ejecutar();
               return (Json(agrego_si_no));
        }

        [HttpPost]
        public JsonResult modificarPaquete(String nombrePaq, String idAuto, int idHotel, int idCrucero, int idRestaurante,
                                          int idVuelo, String fiAuto, String ffAuto, String fiHotel, String ffHotel,
                                          String fiCrucero, String ffCrucero, String fiRestaurante, String ffRestaurante,
                                          String fiVuelo, String ffVuelo, String precio, int idPaquete)
        {
            //manejadorSQL sql = new manejadorSQL();
            CPaquete paquete = new CPaquete();
            paquete._idPaquete = idpaquete;
            paquete._nombrePaquete = nombrePaq;
            if (idAuto == "00")
                idAuto = null;

            if (idHotel != 0)
                paquete._idHabitacion = idHotel;

            if (idCrucero != 0)
                paquete._idCrucero = idCrucero;

            if (idRestaurante != 0)
                paquete._idRestaurante = idRestaurante;

            if (idVuelo != 0)
                paquete._idVuelo = idVuelo;

            if (fiAuto == "")
                fiAuto = null;
            else
                paquete._fechaIniAuto = DateTime.Parse(fiAuto);
            if (ffAuto == "")
                ffAuto = null;
            else
                paquete._fechaFinAuto = DateTime.Parse(ffAuto);
            if (fiHotel == "")
                fiHotel = null;
            else
                paquete._fechaIniHabi = DateTime.Parse(fiHotel);

            if (ffHotel == "")
                ffHotel = null;
            else
                paquete._fechaFinHabi = DateTime.Parse(ffHotel);

            if (fiCrucero == "")
                fiCrucero = null;
            else
                paquete._fechaIniCruc = DateTime.Parse(fiCrucero);

            if (ffCrucero == "")
                ffCrucero = null;
            else
                paquete._fechaFinCruc = DateTime.Parse(ffCrucero);

            if (fiRestaurante == "")
                fiRestaurante = null;
            else
                paquete._fechaIniRest = DateTime.Parse(fiRestaurante);
            if (ffRestaurante == "")
                ffRestaurante = null;
            else
                paquete._fechaFinRest = DateTime.Parse(ffRestaurante);

            if (fiVuelo == "")
                fiVuelo = null;
            else
                paquete._fechaIniVuelo = DateTime.Parse(fiVuelo);

            if (ffVuelo == "")
                ffVuelo = null;
            else
                paquete._fechaFinVuelo = DateTime.Parse(ffVuelo);

            //Así estaba antes de esta entrega
            /*paquete._idAuto = idAuto;
            paquete._precioPaquete = float.Parse(precio);
            sql.modificarPaquete(paquete);

            return Json(true);*/

            //Nuevo
            Boolean disponibilidad = false;

            Entidad modificarPaquete = FabricaEntidad.InstanciarPaquete(paquete, disponibilidad, idpaquete);
            //con la fabrica instancie a la oferta.
            Command<String> comando = FabricaComando.crearM11ModificarPaquetes(modificarPaquete, idpaquete);
            String agrego_si_no = comando.ejecutar();
            return (Json(agrego_si_no));
        }

        /// <summary>
        /// Cambia el estado de una oferta a inactiva.
        /// </summary>
        /// <param name="id">Id de la oferta a desactivar.</param>
        /// <returns>Resultado de la actualización.</returns>
        public JsonResult desactivarOferta(int id)
        {
            Debug.WriteLine("DESACTIVAR OFERTA " + id);
            try
            {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
                Entidad oferta = comando.ejecutar();
                Oferta ofertaBuscada = (Oferta)oferta;
                ofertaBuscada._id = id;
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadOferta(ofertaBuscada, 0);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));

            }            
        }

        /// <summary>
        /// Cambia el estado de una oferta a activa.
        /// </summary>
        /// <param name="id">Id de la oferta a activar.</param>
        /// <returns>Resultado de la actualización.</returns>
        public JsonResult activarOferta(int id)
        {
            Debug.WriteLine("ACTIVAR OFERTA " + id);
            try
            {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
                Entidad oferta = comando.ejecutar();
                Oferta ofertaBuscada = (Oferta)oferta;
                ofertaBuscada._id = id;
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadOferta(ofertaBuscada, 1);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));

            }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }

        /// <summary>
        /// Cambia el estado de una PAQUETE a activO.
        /// </summary>
        /// <param name="id">Id del paquete a activar.</param>
        /// <returns>Resultado de la actualización.</returns>
        public JsonResult activarPaquete(int id)
        {
            Debug.WriteLine("ACTIVAR PAQUETE " + id);
            idpaquete = id;
            try
            {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(id);
                Entidad paquete = comando.ejecutar();
                Paquete paqueteBuscado = (Paquete)paquete;
                paqueteBuscado._id = id;
                Debug.WriteLine("DESACTIVAR PAQUETE " + paqueteBuscado._nombrePaquete);
                Debug.WriteLine("DESACTIVAR PAQUETE " + paqueteBuscado._id);
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadPaquete(paqueteBuscado, 1);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
        }
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }

        /// <summary>
        /// Cambia el estado de una oferta a inactiva.
        /// </summary>
        /// <param name="id">Id de la oferta a desactivar.</param>
        /// <returns>Resultado de la actualización.</returns>
        public JsonResult desactivarPaquete(int id)
        {
            Debug.WriteLine("DESACTIVAR PAQUETE " + id);
            try
            {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(id);
                Entidad paquete = comando.ejecutar();
                Paquete paqueteBuscado = (Paquete)paquete;
                paqueteBuscado._id = id;
                Debug.WriteLine("DESACTIVAR PAQUETE " + paqueteBuscado._nombrePaquete);
                Debug.WriteLine("DESACTIVAR PAQUETE " + paqueteBuscado._id);
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadPaquete(paqueteBuscado, 0);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));     

        }            
            catch (ReservaExceptionM09 ex)
            {
                return (Json(ex.Mensaje));
            }
        }
	}
}