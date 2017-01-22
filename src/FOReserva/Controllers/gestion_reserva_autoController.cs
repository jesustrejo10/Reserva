using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Autos;
using FOReserva.Servicio;
using System.Net;
using FOReserva.DataAccess.Domain;
using FOReserva.Models.gestion_reserva_automovil;
using FOReserva.Controllers.PatronComando;

namespace FOReserva.Controllers
{
    public class gestion_reserva_autoController : Controller
    {
        //
        // GET: /gestion_reserva_autos/

        public ActionResult M19_Reserva_Autos()
        {
            Cvista_ReservaAutos model = new Cvista_ReservaAutos();
            return PartialView(model);
        }

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

        public ActionResult M19_Busqueda_Autos()
        {
            try { 
            string res_entrega = Request.Form["SelectedCiudadIdOrigen"].ToString();
            string res_destino = Request.Form["SelectedCiudadIdDestino"].ToString();
            string fechaIni = Request.Form["fechaini"];
            string fechaFin = Request.Form["fechafin"];
            string horaIni = Request.Form["res_horaini"];
            string horaFin = Request.Form["res_horafin"];


                List<CReserva_Autos_Perfil> lista = busqueda(res_entrega, res_destino, fechaIni, fechaFin, horaIni, horaFin);
                return View(lista);
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult M19_Accion_Reserva(string matricula, string modelo, string fabricante, string tipo, string color, string transmision, int ciudad, decimal precio, int anio, int pasajero, int disponibilidad, string owner, string date, string time, string fechaini, string fechafin, string horaini, string horafin, string ciudadori, string ciudaddes)
        {
            CReserva_Autos_Perfil reserva = new CReserva_Autos_Perfil(owner, date, time, fechaini, fechafin, horaini, horafin, ciudaddes, ciudadori,1);
            reserva.Autos = new CBusquedaModel(matricula, modelo, fabricante, tipo, color, transmision, ciudad, precio, anio, pasajero, disponibilidad);

            try
            {
                ManejadorSQLReservaAutomovil manejador = new ManejadorSQLReservaAutomovil();
                manejador.InsertarReservaAuto(reserva);
                return View(reserva);
            }
            catch (ManejadorSQLException)
            {
                return View();
            }
        }

        public List<CReserva_Autos_Perfil> busqueda(string res_entrega, string res_destino, string fechaini, string fechafin, string horaini, string horafin)
        {
            List<CReserva_Autos_Perfil> lista = null;
            ManejadorSQLReservaAutomovil manejador = new ManejadorSQLReservaAutomovil();
            lista = manejador.buscarAutosCiudad(res_entrega, res_destino, fechaini, fechafin, horaini, horafin);
            return lista;
        }
       
    }
}
