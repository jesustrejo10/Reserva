using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_check_in;
using BOReserva.Servicio.Servicio_Boletos;

namespace BOReserva.Controllers
{
    public class gestion_check_inController : Controller
    {

        // GET 
        public ActionResult M05_CheckIn()
        {
            return PartialView();
        }

        // POST
        [HttpPost]
        public ActionResult buscarBoletos(CCheckIn model)
        {
            int pasaporte = model._pasaporte;
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS
            // DE ESE PASAJERO EN PARTICULAR PARA MOSTRARLOS EN LA VISTA
            manejadorSQL_Check buscarboletos = new manejadorSQL_Check();
            List<CBoleto> listaboletos = buscarboletos.M05ListarBoletosPasajero(pasaporte);
            return PartialView("M05_VerBoletosCheckIn",listaboletos);
        }

        // GET 
        public ActionResult M05_VerBoletosCheckIn()
        {
            return PartialView();
        }


        // POST
        [HttpPost]
        public JsonResult verBoleto(CVisualizarBoleto model)
        {
            String origen = model._origen;
            String destino = model._destino;
            String fechaSalIda = model._fechaDespegueIda;
            String fechaSalVuelta = model._fechaDespegueVuelta;
            String fechaLlegIda = model._fechaAterrizajeIda;
            String fechaLlegVuelta = model._fechaAterrizajeVuelta;
            String horaSalIda = model._horaDespegueIda;
            String horaSalVuelta = model._horaDespegueVuelta;
            String horaLlegIda = model._horaAterrizajeIda;
            String horaLlegVuelta = model._horaAterrizajeVuelta;
            double monto = model._monto;
            String tipoBoleto = model._tipoBoleto;
            String nombre = model._nombre;
            String apellido = model._apellido;
            int pasaporte = model._pasaporte;
            String correo = model._correo;
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        public ActionResult M05_VerDetalleBoleto(int id)
        {
            //System.Diagnostics.Debug.WriteLine(id);
            manejadorSQL_Check buscarboleto = new manejadorSQL_Check();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id);

            String hola = boleto._tipoBoleto;
            
            CDetalleBoleto bolView = new CDetalleBoleto(boleto);
            return PartialView(bolView);
            //return PartialView();
        }

        [HttpPost]
        public ActionResult generarBoardingPass(CDetalleBoleto model)
        {

            String tipo = model._tipoBoardingPass;
            int id_bol = model._bol_id;

            manejadorSQL_Check modificar = new manejadorSQL_Check();

            // OBTENGO EL /LOS VUELOS DEL BOLETO

            List<CVuelo> lista = modificar.M05ListarVuelosBoleto(model._bol_id);

            // PRIMERO VEO SI ES IDA O IDA Y VUELTA 
            int ida_vuelta = modificar.MBuscarIdaVuelta(model._bol_id);
            // EL BOLETO ES IDA 1
            // EL BOLETO ES IDA Y VUELTA 2
            if (ida_vuelta == 1)
            {
                int codigo_vuelo1 = lista[0]._id;

            }
            else
            {
                int codigo_vuelo_ida = lista[0]._id;
                int codigo_vuelo_vuelta = lista[1]._id;

            }

            // HACER EL INSERT DE PASE DE ABORDAJE
            
            // TENGO QUE INSTANCIAR AL MODELO DE VER BOARDING PASS
            return PartialView("M05_VerBoardingPass");
        }


        // GET 
        public ActionResult M05_Equipaje()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_VerBoardingPass()
        {
            return PartialView();
        }
    }
}