using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Servicio;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Models;
using BOReserva.Views.gestion_restaurantes.Fabrica;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace BOReserva.Controllers
{
    public class gestion_restaurantesController : Controller
    {

    

        #region Consultar Restaurantes por ciudad
        /// <summary>
        /// Método para el acceso a la interfaz de visualización de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Ver(int id = 0)
        {
            ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Nombre");
        
            if (id != 0)
            {
               
                Entidad _lugar = FabricaEntidad.inicializarLugar(id, "");//Aqui se envia la clave foranea de lugar para realizar la busqueda
                Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _lugar);
                List<Entidad> restaurantes = comando.ejecutar();
                CRestauranteModelo Restaurant = FabricaEntidad.inicializarRestaurant();
                List<CRestauranteModelo> lista = FabricaEntidad.inicializarListaRestarant();

                foreach (Entidad item in restaurantes)
                {
                    lista.Add((CRestauranteModelo)item);
                   
                }

                Restaurant.listaRestaurantes = lista;
                return PartialView(Restaurant);
            }

            return PartialView();
        }

        #endregion

        /// <summary>
        /// Método para el acceso a la interfaz de agregación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Agregar()
        {
            ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Nombre");
            ViewBag.Horarios = FabricaVista.asignarItemsComboBox(cargarComboBoxHorario(), "", "");
            return PartialView();
        }

         
        /// <summary>
        /// Método para el acceso a la interfaz de modificación de restaurantes.
        /// </summary>
        /// <returns>Retorna un objeto para renderizar la vista parcial.</returns>
        public ActionResult M10_GestionRestaurantes_Modificar(int id)
        {

            ViewBag.Ciudad = FabricaVista.asignarItemsComboBox(cargarComboBoxLugar(), "Id", "Nombre");
            ViewBag.Horarios = FabricaVista.asignarItemsComboBox(cargarComboBoxHorario(), "", "");
            
            Entidad _restaurant = FabricaEntidad.inicializarRestaurant();
            ((CRestauranteModelo)_restaurant)._id = id;
            Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.CONSULTAR_ID, _restaurant);
            Entidad rest = comando.ejecutar();

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

 

        /// <summary>
        /// Método para el almacenado de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpPost]
        public JsonResult guardarRestaurante(String Nombre,String Direccion,String Telefono, String Descripcion, int idLugar,String HoraIni,String HoraFin)
        {
          

            //Chequeo de campos obligatorios para el formulario
            //if ((model.nombre == null) || (model.direccion == null) 
            //    || (model.horarioApertura == null) || (model.horarioCierre == null) || (model.idLugar == -1))
            //{
            //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    string error = "Error, campo obligatorio vacío";
            //    return Json(error);
            //}
            Entidad _restaurant = FabricaEntidad.inicializarRestaurant(Nombre, Direccion,Telefono, Descripcion, HoraIni, HoraFin, idLugar);
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CREAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, _restaurant);
                    
         
            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando el restaurante.";
                return Json(error);
            }
            
        }

        /// <summary>
        /// Método para la modificación de restaurantes, tomando como parámetro un modelo de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>

        [HttpPost]
        public JsonResult modificarRestaurante(int Id,String Nombre, String Direccion, String Telefono, String Descripcion, int idLugar, String HoraIni, String HoraFin)
        {
            //Chequeo de campos obligatorios para el formulario
            //if ((model.id == -1) || (model.nombre == null) || (model.direccion == null)
            //    || (model.horarioApertura == null) || (model.horarioCierre == null) || (model.idLugar == -1))
            //{
            //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    string error = "Error, campo obligatorio vacío";
            //    return Json(error);
            //}
            Entidad _restaurant = FabricaEntidad.inicializarRestaurant(Id,Nombre, Direccion, Telefono, Descripcion, HoraIni, HoraFin, idLugar);
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

        /// <summary>
        /// Método para la eliminación de restaurantes, tomando como parámetro un id de restaurante.
        /// </summary>
        /// <returns>Retorna un objecto tipo JsonResult que indica el éxito o fracaso de la operación.</returns>
        [HttpGet]
        public JsonResult eliminarRestaurante(int id)
        {
            System.Diagnostics.Debug.WriteLine("Id de resturant a eliminar "+id);

            Entidad _restaurant = FabricaEntidad.inicializarRestaurant();
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

        #region Cargar Combobox ciudades
        /// <summary>
        /// Cargar combo de ciudades 
        /// </summary>
        /// <returns></returns>
        public List<Lugar> cargarComboBoxLugar()
        {
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_LUGAR);
            List<Entidad> lugares = comando.ejecutar();
            List<Lugar> lista = FabricaEntidad.inicializarListaLugar() ;
            Lugar lug;
            foreach (Entidad lugar in lugares)
            {
                lug = (Lugar)lugar;
                lista.Add(lug);

            }
            return lista;
        }
        #endregion

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
    }
}