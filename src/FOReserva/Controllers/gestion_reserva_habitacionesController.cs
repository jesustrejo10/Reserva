
using FOReserva.Models.ReservaHabitacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Controllers
{
    public class gestion_reserva_habitacionesController : Controller
    {
        //
        // GET: /gestion_reserva_habitaciones/
        [HttpGet]
        public ActionResult mis_reservas()
        {
            var model = CReservaHabitacion.ReservasDeUsuario(usu_id: 1);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult buscar_hoteles(Cvista_BuscarHotel model)
        {
            if (Session["RHACiudades"] == null)
                Session["RHACiudades"] = CReservaHabitacion.ObtenerCiudades();

            if (model.Ciudades == null)
                model.Ciudades = (List<CCiudad>)Session["RHACiudades"];

            if (model.FechaLlegada.Ticks == 0)
                model.FechaLlegada = DateTime.Now.AddDays(1);

            if (model.CantidadDias < 1)
                model.CantidadDias = 1;

            return PartialView(model);
        }

        [HttpGet]
        public ActionResult hoteles_con_habitaciones(Cvista_BuscarHotel datos)
        {
            var model = CReservaHabitacion.BuscarHoteles(datos.LugId, datos.FechaLlegada, datos.CantidadDias);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult detalle_reserva(CReservaHabitacion model)
        {
            model.CargarDesdeDB();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult realizar_reserva(Cvista_ReservarHabitacion reserva)
        {
            reserva.UsuId = 1; // Usuario Actual
            var resultado = CReservaHabitacion.GenerarReserva(reserva);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult cancelar_reserva(CReservaHabitacion reserva)
        {
            var resultado = CReservaHabitacion.CancelarReserva(reserva);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
