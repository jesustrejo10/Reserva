using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Servicio;
using System.Net;
using FOReserva.DataAccess.Domain;
using FOReserva.Models.gestion_reserva_automovil;
using FOReserva.Controllers.PatronComando;

namespace FOReserva.Controllers
{
    public class gestion_reserva_autoController : Controller
    {

        /// <summary>
        /// Metodo para modificar una reserva
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult M19_Modificar_reserva(CReservaAutomovil reserva)
        {
            var id = reserva._id;
            var hora = reserva._hora_fin;

            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.ACTUALIZAR, FabricaComando.comandoReservaAuto.NULO, reserva);
            //Chequeo de campos obligatorios para el formulario
            if ((reserva._id == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, no se tiene la identificación de la reserva";
                return Json(error);
            }

            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error al tratar de modificar la reserva.";
                return Json(error);
            }
        }
        //
        // GET: /gestion_reserva_autos/
        /// <summary>
        /// Metodo que muestra la pantalla principal para buscar automoviles
        /// </summary>
        /// <returns></returns>
        public ActionResult M19_Reserva_Autos()
        {
            CVistaReservaAuto model = new CVistaReservaAuto();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM19ObtenerPaises();
            model._paises = comando.ejecutar();

            //Aca puedo devolver
            return PartialView(model);
        }

        /// <summary>
        /// Metodo para las imagenes de los autos
        /// </summary>
        /// <returns></returns>
        public ActionResult M19_Reserva_AutosImagenes()
        {
            return PartialView();
        }

        /// <summary>
        /// Método para visualizar todas las reservas del usuario logueado
        /// </summary>
        /// <returns></returns>
        public ActionResult M19_Reserva_Autos_Perfil()
        {
            var user_id = 1;

            if (Session["id_usuario"] != null && Session["id_usuario"] is int)
                user_id = (int)Session["id_usuario"];

            // Cableado por el módulo de login
            user_id = 163;

            Entidad _usuario = FabricaEntidad.inicializarUsuario(user_id);
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoReservaAuto.NULO, _usuario);
            List<Entidad> reservas = comando.ejecutar();

            List<CReservaAutomovil> lista = FabricaEntidad.inicializarListaReserva();

            foreach (Entidad item in reservas)
            {
                lista.Add((CReservaAutomovil)item);

            }
            return PartialView(lista);
        }

        /// <summary>
        /// Método para ver el detalle de la reserva
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult M19_Detalle_reserva(CReservaAutomovil model)
        {

            Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoReservaAuto.CONSULTAR_ID,model);
            Entidad reserva = comando.ejecutar();

            // Se hace el casteo puesto que la vista utiliza el modelo CReservaAutomovil
            CReservaAutomovil modelo_reserva = (CReservaAutomovil)reserva;
            return PartialView(modelo_reserva);
        }

        /// <summary>
        /// Método para eliminar reserva, lo que se hace es actualizar el estado a cancelada
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult M19_Eliminar_reserva(CReservaAutomovil reserva)
        {
            var id = reserva._id;
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.ELIMINAR, FabricaComando.comandoReservaAuto.NULO,reserva);
            //Chequeo de campos obligatorios para el formulario
            if ((reserva._id == -1))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error, no se tiene la identificación de la reserva";
                return Json(error);
            }

            if (comando.ejecutar())
            {
                return (Json(true, JsonRequestBehavior.AllowGet));
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error al tratar de eliminar la reserva.";
                return Json(error);
            }
        }

        /// <summary>
        /// Busqueda de autos disponibles
        /// </summary>
        /// <returns></returns>
        public ActionResult M19_Busqueda_Autos()
        {

            System.Diagnostics.Debug.WriteLine("LLEGA AL CONTROLLER BBUSQUEDA DE AUTOS");

            try
            {
                //obtengo los datos ingresados en el formulario
                string res_entrega = Request.Form["SelectedCiudadIdOrigen"].ToString();
                string res_destino = Request.Form["SelectedCiudadIdDestino"].ToString();
                string fechaIni = Request.Form["_fechaini"];
                string fechaFin = Request.Form["_fechafin"];
                string horaIni = Request.Form["res_horaini"];
                string horaFin = Request.Form["res_horafin"];

                System.Diagnostics.Debug.WriteLine("DATOS DEL FORMULARIO DE BUSQUEDA INGRESADOS:  lugarEntrega: " + res_entrega + ", lugarDestino: " + res_destino + ", fechaIni: " + fechaIni + ", fechaFin: " + fechaFin + ", horaIni: " + horaIni + ", horaFin " + horaFin);

                int idEntrega = Int32.Parse(res_entrega);
                int idDestino = Int32.Parse(res_destino);


                //Creo _datos de tipo Entidad y lo inicializo como CVistaReservaAuto
                Entidad _datos = FabricaEntidad.inicializarCVistaReservaAuto(fechaIni, fechaFin, horaIni, horaFin, idEntrega, idDestino);

                Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoReservaAuto.CONSULTAR_AUTOS, _datos);
                List<Entidad> autos = comando.ejecutar();//devuelve una lista de CAutomovil con autos de la ciudad

                System.Diagnostics.Debug.WriteLine("PASA DEL COMANDO");

                List<CAutomovil> lista = FabricaEntidad.inicializarListaAutomovil_();

                foreach (Entidad item in autos)
                {
                    lista.Add((CAutomovil)item);

                }


                System.Diagnostics.Debug.WriteLine("DATOS DE LA LISTA LUEGO DEL COMANDO:  fechaini: " + lista[0]._fechaini + ", fechafin: " + lista[0]._fechafin + ", horaini: " + lista[0]._horaini + ", horafin: " + lista[0]._horafin + ", ciudadorigen: " + lista[0]._ciudadorigen + ", ciudaddestino: " + lista[0]._ciudaddestino);

                return PartialView(lista);

            }
            catch (Exception error)
            {


            }
            return View(); ;

        }

        /// <summary>
        /// En este metodo se ejecuta el guardar la reserva en el sistema
        /// </summary>
        /// <param name="fechaini"></param>
        /// <param name="fechafin"></param>
        /// <param name="horaini"></param>
        /// <param name="horafin"></param>
        /// <param name="matricula"></param>
        /// <param name="ciudadori"></param>
        /// <param name="ciudaddes"></param>
        /// <returns></returns>
        public ActionResult M19_Accion_Reserva(string fechaini, string fechafin, string horaini, string horafin, string matricula, int ciudadori, int ciudaddes)
        {

            System.Diagnostics.Debug.WriteLine("LLEGA AL CONTROLLER DE ACCION RESERVA");

            System.Diagnostics.Debug.WriteLine("fechaini: " + fechaini + ", fechafin: " + fechafin + ", horaini: " + horaini + ", horafin: " + horafin + ", idusuario: 1, matricula: " + matricula + ", ciudadori: " + ciudadori + ", ciudaddes: " + ciudaddes);

            try
            {
                Entidad _reserva = FabricaEntidad.inicializarAutomovil(matricula, " ", " ", " ", " ", " ", 1, 8.0, 1, 1, 1, fechaini, fechafin, horaini, horafin, ciudadori, ciudaddes);
                Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CREAR, FabricaComando.comandoReservaAuto.NULO, _reserva);


                if (comando.ejecutar())
                {
                    CAutomovil auto = (CAutomovil)_reserva;
                    auto._matricula = "11111111";
                    return View(auto);
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string error = "Error agregando la reserva del automovil.";
                    return Json(error);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string error = "Error agregando la reserva del automovil.";
                return Json(error);
            }

        }

        /// <summary>
        /// Método que retorna la lista de países
        /// </summary>
        /// <returns>Retorna una lista de Items que contiene los países disponibles</returns>
        public static List<SelectListItem> pais()
        {
            Command<Dictionary<int, Entidad>> commandpais = FabricaComando.crearM19ObtenerPaises();
            Dictionary<int, Entidad> _paises = commandpais.ejecutar();
            List<SelectListItem> __pais = new List<SelectListItem>();
            int i = 0;
            bool verdad = true;
            foreach (var item in _paises)
            {
                Pais country = (Pais)item.Value;
                __pais.Add(new SelectListItem
                {
                    Text = country._nombre,
                    Value = Convert.ToString(country._id)
                });
            }

            return __pais;
        }

    }
}
