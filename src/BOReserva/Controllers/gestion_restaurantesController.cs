using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Views.gestion_restaurantes.Fabrica;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace BOReserva.Controllers
{
    /// <summary>
    /// Controlador vista restaurant
    /// </summary>
    public class gestion_restaurantesController : Controller
    {
    
        #region Cargar Vista Consultar Restaurantes por ciudad 
        /// <summary>
        /// Método para el acceso a la interfaz de visualización de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Ver(int id = -1)
        {

            try
            {
                ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Name");


                Entidad _lugar = FabricaEntidad.crearLugar(id, "");//Aqui se envia la clave foranea de lugar para realizar la busqueda
                Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _lugar);
                List<Entidad> restaurantes = comando.ejecutar();
                CRestauranteModelo Restaurant = FabricaEntidad.crearRestaurant();
                List<CRestauranteModelo> lista = FabricaEntidad.crearListaRestarant();

                foreach (Entidad item in restaurantes)
                {
                    lista.Add((CRestauranteModelo)item);
                }

                Restaurant.listaRestaurantes = lista;
                return PartialView(Restaurant);
            }
            catch (Exception)
            {
                return PartialView();
            }
        }

        #endregion

        #region Cargar Vista Agregar Restaurant
        /// <summary>
        /// Método para el acceso a la interfaz de agregación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Agregar()
        {
            ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Name");
            ViewBag.Horarios = FabricaVista.asignarItemsComboBox(cargarComboBoxHorario(), "", "");
            return PartialView();
        }
        #endregion

        #region Cargar Vista Modificar 
        /// <summary>
        /// Método para el acceso a la interfaz de modificación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Modificar(int id)
        {    
            try
            {
                //Atributos del metodo
                Entidad _restaurant = FabricaEntidad.crearRestaurant();
                ((CRestauranteModelo)_restaurant)._id = id;
                Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.CONSULTAR_ID, _restaurant);
                Entidad rest = comando.ejecutar();

                //Cargar la ciudad donde se encuentra el restaurant registrado en la base de datos
                ViewBag.Ciudad = FabricaVista.asignarItemsComboBoxConPosicion(cargarComboBoxLugar(), "Id", "Name", ((CRestauranteModelo)rest).idLugar);
                ViewBag.HorariosIni = FabricaVista.asignarItemsComboBoxConPosicion(cargarComboBoxHorario(), "", "", ((CRestauranteModelo)rest).horarioApertura);
                ViewBag.HorariosFin = FabricaVista.asignarItemsComboBoxConPosicion(cargarComboBoxHorario(), "", "", ((CRestauranteModelo)rest).horarioCierre);

                //Elementos a cargar en la Ventana
                ViewBag.Id = ((CRestauranteModelo)rest)._id;
                ViewBag.NombreRestaurant = ((CRestauranteModelo)rest).nombre;
                ViewBag.DescripcionRestaurant = ((CRestauranteModelo)rest).descripcion;
                ViewBag.DireccionRestaurant = ((CRestauranteModelo)rest).direccion;
                ViewBag.TelefonoRestaurant = ((CRestauranteModelo)rest).Telefono;
                ViewBag.IdLugarRestaurant = ((CRestauranteModelo)rest).idLugar;
                ViewBag.HoraIniRestaurant = ((CRestauranteModelo)rest).horarioApertura;
                ViewBag.HoraFinRestaurant = ((CRestauranteModelo)rest).horarioCierre;

                return PartialView();
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        #endregion

        #region Agregar Restaurante
        /// <summary>
        /// Método para el almacenado de restaurantes, tomando como parámetros los campos de la vista.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpPost]
        public JsonResult guardarRestaurante(String Nombre,String Direccion,String Telefono, String Descripcion, int idLugar,String HoraIni,String HoraFin)
        {


            //Chequeo de campos obligatorios para el formulario
            if ((Nombre == "") || (Direccion == "")|| (HoraIni == "Horario Inicio") || (Telefono == "") || (HoraFin == "Horario Fin") || (idLugar == 0))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, existen campos vacios";
                return Json(error);
            }

            try
            {
                Entidad _restaurant = FabricaEntidad.crearRestaurant(Nombre, Direccion, Telefono, Descripcion, HoraIni, HoraFin, idLugar);
                Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CREAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _restaurant);


                if (comando.ejecutar())
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string error = "Error agregando el restaurante.";
                    TempData["ErrorServidor"] = "Error en Base de Datos";
                    return Json(error);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando el restaurante.";
                return Json(error);
            }
            
        }
        #endregion

        #region modificar Restaurante
        /// <summary>
        /// Método para la modificación de restaurantes, tomando como parámetros los campos de la vista.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>

        [HttpPost]
        public JsonResult modificarRestaurante(int Id,String Nombre, String Direccion, String Telefono, String Descripcion, int idLugar, String HoraIni, String HoraFin)
        {
            //Chequeo de campos obligatorios para el formulario
            if ((Nombre == "") || (Direccion == "") || (HoraIni == "Horario Inicio") || (Telefono == "") || (HoraFin == "Horario Fin") || (idLugar == 0))
            {
                
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, campo obligatorio vacío";
                return Json(error);
            }

            try
            {
                Entidad _restaurant = FabricaEntidad.crearRestaurant(Id, Nombre, Direccion, Telefono, Descripcion, HoraIni, HoraFin, idLugar);
                Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ACTUALIZAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _restaurant);

                if (comando.ejecutar())
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string error = "Error modificando el restaurante.";
                    return Json(error);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error modificando el restaurante.";
                return Json(error);

            }
        }
        #endregion

        #region Eliminar Restaurante
        /// <summary>
        /// Método para la eliminación de restaurantes, tomando como parámetro un id de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpGet]
        public JsonResult eliminarRestaurante(int id)
        {
            try
            {

                Entidad _restaurant = FabricaEntidad.crearRestaurant();
                ((CRestauranteModelo)_restaurant)._id = id;
                Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ELIMINAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _restaurant);
                //Chequeo de campos obligatorios para el formulario
                if ((id == -1))
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string error = "Error, campo obligatorio vacío";
                    return Json(error);
                }

                if (comando.ejecutar())
                {
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string error = "Error eliminando el restaurante.";
                    return Json(error);
                }
            }
            catch (Exception)
            {

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error eliminando el restaurante.";
                return Json(error);
            }

        }
        #endregion

        #region Cargar Combobox ciudades
        /// <summary>
        /// Cargar combo de ciudades 
        /// </summary>
        /// <returns></returns>
        public List<Lugar> cargarComboBoxLugar()
        {
            List<Lugar> lista2 = FabricaEntidad.crearListaLugar();
            lista2.Add(FabricaEntidad.crearLugar(0,"Error en Carga"));
            try
            {
                Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_LUGAR);
                List<Entidad> lugares = comando.ejecutar();
                List<Lugar> lista = FabricaEntidad.crearListaLugar();
                Lugar lug;
                foreach (Entidad lugar in lugares)
                {
                    lug = (Lugar)lugar;
                    lista.Add(lug);

                }
                return lista;
            }
            catch (Exception)
            {

                return lista2;
            }
        }
        #endregion

        #region cargar combobox Horarios
        /// <summary>
        /// Cargar combo de horarios
        /// </summary>
        /// <returns></returns>
        public List<String> cargarComboBoxHorario()
        {
            Command<List<String>> comando = (Command<List<String>>)FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_HORA);
            List<String> horarios = comando.ejecutar();
            return horarios;
        }
        #endregion
    }
}