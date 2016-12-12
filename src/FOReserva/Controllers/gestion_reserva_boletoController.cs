using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.Models.ReservaBoleto;

namespace FOReserva.Controllers
{
    public class gestion_reserva_boletoController : Controller
    {
        //
        private ManejadorSQLReservaBoleto _manejador = new ManejadorSQLReservaBoleto();
        // GET: /gestion_reserva_boleto/

        public ActionResult busqueda_parametros()
        {

            IList<CModeloBoleto> boletos = _manejador.buscarReserva("Caracas", "Valencia", "2013-08-30", "2013-09-02", "Turista");
            foreach (CModeloBoleto boleto in boletos)
            System.Diagnostics.Debug.WriteLine(boleto.codigo);

            IList<CModeloBoleto> disponib = _manejador.buscarDisponibilidad("Turista", "2013-08-30 22:05:00.000");
            foreach (CModeloBoleto boleto in disponib)
            System.Diagnostics.Debug.WriteLine(boleto.codigo);

            return PartialView();
        }
        public ActionResult busqueda_resultados()
        {
            return PartialView();
        }
        public ActionResult boleto_datos()
        {
            return PartialView();
        }
        public ActionResult boleto_reserva()
        {
            return PartialView();
        }
    }
}
