using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.Autos;
using System.Net;
using FOReserva.Servicio;

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

        //public ActionResult M19_Reserva_Autos_Perfil()
        //{
        //    ManejadorSQLReservaAutomovil manejador = new ManejadorSQLReservaAutomovil();
        //    List<CReserva_Autos_Perfil> lista = manejador.buscarReservas();
        //    return PartialView(lista);
        //}

        //public ActionResult M19_Busqueda_Autos()
        //{
        //    try { 
        //    string res_entrega = Request.Form["SelectedCiudadIdOrigen"].ToString();
        //    string res_destino = Request.Form["SelectedCiudadIdDestino"].ToString();
        //    string fechaIni = Request.Form["fechaini"];
        //    string fechaFin = Request.Form["fechafin"];
        //    string horaIni = Request.Form["res_horaini"];
        //    string horaFin = Request.Form["res_horafin"];


        //        List<CReserva_Autos_Perfil> lista = busqueda(res_entrega, res_destino, fechaIni, fechaFin, horaIni, horaFin);
        //        return View(lista);
        //    }
        //    catch (Exception Error)
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult M19_Accion_Reserva(string matricula, string modelo, string fabricante, string tipo, string color, string transmision, int ciudad, decimal precio, int anio, int pasajero, int disponibilidad, string owner, string date, string time, string fechaini, string fechafin, string horaini, string horafin, string ciudadori, string ciudaddes)
        //{
        //    CReserva_Autos_Perfil reserva = new CReserva_Autos_Perfil(owner, date, time, fechaini, fechafin, horaini, horafin, ciudaddes, ciudadori,1);
        //    reserva.Autos = new CBusquedaModel(matricula, modelo, fabricante, tipo, color, transmision, ciudad, precio, anio, pasajero, disponibilidad);

        //    try
        //    {
        //        ManejadorSQLReservaAutomovil manejador = new ManejadorSQLReservaAutomovil();
        //        manejador.InsertarReservaAuto(reserva);
        //        return View(reserva);
        //    }
        //    catch (ManejadorSQLException AgregarError)
        //    {
        //        return View();
        //    }
        //}

        //public List<CReserva_Autos_Perfil> busqueda(string res_entrega, string res_destino, string fechaini, string fechafin, string horaini, string horafin)
        //{
        //    List<CReserva_Autos_Perfil> lista = null;
        //    ManejadorSQLReservaAutomovil manejador = new ManejadorSQLReservaAutomovil();
        //    lista = manejador.buscarAutosCiudad(res_entrega, res_destino, fechaini, fechafin, horaini, horafin);
        //    return lista;
        //}
    }
}
