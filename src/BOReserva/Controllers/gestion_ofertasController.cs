using System;
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

        public ActionResult M11_DetallePaquete(String paqueteIdStr)
        {
            int paqueteId = Int32.Parse(paqueteIdStr);
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);
        }

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


        public List<COferta> M11_PaquetesPorOferta()
        {
            manejadorSQL sql = new manejadorSQL();
            List<COferta> ofertas = new List<COferta>();
            ofertas = sql.listarOfertasEnBD();
            return (ofertas);
        }
        
        [HttpPost]
        public JsonResult M11_ListarAutomoviles()
        {
            //Automovil automovil = new Automovil();
            //return Json(automovil.MListarvehiculos());
            return null;
        }

        [HttpPost]
        public JsonResult M11_ListarRestaurantes()
        {
            //manejadorSQL sql = new manejadorSQL();
            //var restauranteList = new List<CRestauranteModelo>();
           // restauranteList = sql.consultarRestaurante();
            //Metodos para M11 Probados 
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoRestaurant.LISTAR_RESTAURANT, null);
            List <Entidad> restaurantes = comando.ejecutar();
            //return Json(restauranteList);
            /*List<CRestauranteModelo> lista = FabricaEntidad.crearListaRestarant();
            CRestauranteModelo rest;
            foreach (Entidad re in restaurantes)
            {
                rest = (CRestauranteModelo)re;
                lista.Add(rest);

            }*/
            CRestauranteModelo Restaurant = FabricaEntidad.crearRestaurant();
            List<CRestauranteModelo> lista = FabricaEntidad.crearListaRestarant();

            foreach (Entidad item in restaurantes)
            {
                lista.Add((CRestauranteModelo)item);
            }

            return Json(lista);
        }

        public ActionResult M11_ModificarPaquete(String paqueteIdStr)
        {
            
            
            int paqueteId = Int32.Parse(paqueteIdStr);
            /*Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(paqueteId);
            Entidad paquete = comando.ejecutar();
            Paquete paquetebuscado = (Paquete)paquete;
            idpaquete = paquetebuscado._id;
            CPaquete modelopaquete = new CPaquete();
            modelopaquete._idAuto = paquetebuscado._idAuto;
            modelopaquete._idCrucero = paquetebuscado._idCrucero;
            modelopaquete._idHabitacion = paquetebuscado._idHotel;
            modelopaquete._idRestaurante = paquetebuscado._idRestaurante;*/
            //todavía falta

            //Comentar estas 4 líneas siguientes que funcionaban antes de esta entrega
            //Descimentándolas mientras se adapta a patrones
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete;
            paquete = sql.detallePaquete(paqueteId);
            return PartialView(paquete);
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

         /*   //llena la lista de los paquetes asociados a la oferta
            try
            {
                modificarOferta._listaPaquetes = coferta.MBuscarPaquetesAsociadosBD(idOferta.ToString());
            }
            catch (NullReferenceException e)
            {
                return PartialView(modificarOferta);
            }*/

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
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listHoteles = new List<CConsultar>();
            listHoteles = sql.listarHotelesM11();
            return Json(listHoteles);
        }

        [HttpPost]
        public JsonResult M11_ListarCruceros()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listCruceros = new List<CConsultar>();
            listCruceros = sql.listarCrucerosM11();
            return Json(listCruceros);
        }

        [HttpPost]
        public JsonResult M11_ListarVuelos()
        {
            manejadorSQL sql = new manejadorSQL();
            List<CConsultar> listVuelos = new List<CConsultar>();
            listVuelos = sql.listarVuelosM11();
            return Json(listVuelos);
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

        [HttpPost]
        public JsonResult obtenerOferta(int idOferta)
        {
            manejadorSQL sql = new manejadorSQL();
            COferta oferta = new COferta();
            oferta = sql.obtenerOferta(idOferta);
            return Json(oferta);
        }

        

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

      /*  [HttpPost]
        public JsonResult desactivarOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.desactivarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }*/

      /*  [HttpPost]
        public JsonResult activarOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }*/

     /*   [HttpPost]
        public JsonResult desactivarPaquete(String ofertaIdStr)
        {
            int paqueteId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.desactivarPaquete(paqueteId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }*/

        /*[HttpPost]
        public JsonResult activarPaquete(String ofertaIdStr)
        {
            int paqueteId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarPaquete(paqueteId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
        }*/


        [HttpPost]
        public JsonResult ConsultarDetalleOferta(String ofertaIdStr)
        {
            int ofertaId = Int32.Parse(ofertaIdStr);
            //AGREGAR EL USING DEL MANEJADOR SQL ANTES (using BOReserva.Servicio; o using FOReserva.Servicio;)
            //instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            //realizo el insert
            bool resultado = sql.activarOferta(ofertaId);
            //envio una respuesta dependiendo del resultado del insert
            if (resultado)
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Error procesando la petición";
                return Json(error);
            }
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
            manejadorSQL sql = new manejadorSQL();
            CPaquete paquete = new CPaquete();
            paquete._idPaquete = idPaquete;
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

            paquete._idAuto = idAuto;
            paquete._precioPaquete = float.Parse(precio);
            sql.modificarPaquete(paquete);

            return Json(true);
        }

        [HttpPost]
        public JsonResult desactivarOferta(int id)
        {
            Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
            Entidad oferta = comando.ejecutar();
            Oferta ofertabuscada = (Oferta)oferta;
            ofertabuscada._id = id;
            Command<String> comando1 = FabricaComando.crearM11DisponibilidadOferta(ofertabuscada, 0);
            String borro_si_no = comando1.ejecutar();
            return (Json(borro_si_no));
        }

        public JsonResult activarOferta(int id)
        {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarOferta(id);
                Entidad oferta = comando.ejecutar();
                Oferta ofertabuscada = (Oferta)oferta;
                ofertabuscada._id = id;
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadOferta(ofertabuscada, 1);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
        }

        public JsonResult activarPaquete(int id)
        {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(id);
                Entidad paquete = comando.ejecutar();
                Paquete paquetebuscado = (Paquete)paquete;
                paquetebuscado._id = id;
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadPaquete(paquetebuscado, 1);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));
        }

        public JsonResult desactivarPaquete(int id)
        {
                Command<Entidad> comando = FabricaComando.crearM11ConsultarPaquete(id);
                Entidad paquete = comando.ejecutar();
                Paquete paquetebuscado = (Paquete)paquete;
                paquetebuscado._id = id;
                Command<String> comando1 = FabricaComando.crearM11DisponibilidadPaquete(paquetebuscado, 0);
                String borro_si_no = comando1.ejecutar();
                return (Json(borro_si_no));     
        }
	}
}