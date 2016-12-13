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

        private ManejadorSQLReservaBoleto _manejador = new ManejadorSQLReservaBoleto();

        public ActionResult busqueda_parametros()
        {

            /*IList<CModeloBoleto> boletos = _manejador.buscarReserva("Caracas", "Valencia", "2013-08-30", "2013-09-02", "Turista");
              foreach (CModeloBoleto boleto in boletos)
              System.Diagnostics.Debug.WriteLine(boleto.codigo); */

            /*IList < CModeloBoleto > disponib = _manejador.buscarDisponibilidad("Turista", "2013-08-30 22:05:00.000");  
              foreach (CModeloBoleto boleto in disponib)
              System.Diagnostics.Debug.WriteLine(boleto.codigo); */

            /*IList<CModeloBoleto> boletos = _manejador.buscarReserva("4455743");
              foreach (CModeloBoleto boleto in boletos)
              System.Diagnostics.Debug.WriteLine(boleto.codigo); */

 //           IList <CModeloBoleto> boletos = _manejador.insertarReserva(DateTime.Today,0,440,"R0002","Ejecutivo", "Valencia","Caracas",4455743);

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

        [HttpPost]
        public JsonResult buscar_vuelos(CBuscarVuelo model)
        {
            string fecha_ida = model._ida;
            string fecha_vuelta = model._vuelta;
            int origen = model.SelectedCiudadIdOrigen;
            int destino = model.SelectedCiudadIdDestino;
            int numeroBoletos = model.numeroBoletos();

            System.Diagnostics.Debug.WriteLine(fecha_ida);
            System.Diagnostics.Debug.WriteLine(fecha_vuelta);
            System.Diagnostics.Debug.WriteLine(origen);
            System.Diagnostics.Debug.WriteLine(destino);
            System.Diagnostics.Debug.WriteLine(numeroBoletos);

            return (Json(true, JsonRequestBehavior.AllowGet));

        }
    }
}
