using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_boletos;
using BOReserva.Servicio.Servicio_Boletos;

namespace BOReserva.Controllers
{
    public class gestion_boletosController : Controller
    {

        public ActionResult M05_VerReserva()
        {
            return PartialView();
        }

        public ActionResult M05_CrearBoleto()
        {
            /*//instancio el manejador de sql
            manejadorSQL sql = new manejadorSQL();
            List<string> resultado = sql.buscarCiudades();*/
            CBuscarVuelo model = new CBuscarVuelo();
            //model._ciudadDestinoList = resultado;
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult buscarVuelos(CBuscarVuelo model)
        {
            String fecha_ida = model._ida;
            String fecha_vuelta = model._vuelta;
            int sel = model.SelectedCiudadIdOrigen;
            int sel2 = model.SelectedCiudadIdDestino;

            return (Json(true, JsonRequestBehavior.AllowGet));

        }

        public ActionResult M05_VerVuelos()
        {
            return PartialView();
        }

        public ActionResult M05_DetalleVuelo()
        {
            return PartialView();
        }

        public ActionResult M05_DatosUsuario()
        {
            return PartialView();
        }
        public ActionResult M05_DetalleBoleto()
        {
            return PartialView();
        }

        public ActionResult M05_VisualizarBoletos()
        {
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
             manejadorSQL_Boletos buscarboletos = new manejadorSQL_Boletos();
             List<CBoleto> listaboletos = buscarboletos.M05ListarBoletosBD();  
            return PartialView(listaboletos);
        }

        // GET
        public ActionResult M05_VisualizarBoleto(int id)
        {
            //BUSCA EL BOLETO A MOSTRAR
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id); 

            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS

            List<CVuelo> vuelos = boleto._vuelos;

            CVisualizarBoleto bol = new CVisualizarBoleto();


            if (boleto._ida_vuelta == 1)
            {
                var time = vuelos[0]._fechaPartida.TimeOfDay.ToString();
                var time1 = vuelos[0]._fechaLlegada.TimeOfDay.ToString();
                bol._fechaDespegueIda = vuelos[0]._fechaPartida.Day + "/" + vuelos[0]._fechaPartida.Month + "/" + vuelos[0]._fechaPartida.Year;
                bol._fechaDespegueVuelta = "";
                bol._fechaAterrizajeIda = vuelos[0]._fechaLlegada.Day + "/" + vuelos[0]._fechaLlegada.Month + "/" + vuelos[0]._fechaLlegada.Year;
                bol._fechaAterrizajeVuelta = "";
                bol._horaDespegueIda = time;
                bol._horaDespegueVuelta = "";
                bol._horaAterrizajeIda = time1;
                bol._horaAterrizajeVuelta = "";
            }
            else {
                var time0 = vuelos[0]._fechaPartida.TimeOfDay.ToString();
                var time1 = vuelos[0]._fechaLlegada.TimeOfDay.ToString();
                var time2 = vuelos[1]._fechaPartida.TimeOfDay.ToString();
                var time3 = vuelos[1]._fechaLlegada.TimeOfDay.ToString();
                bol._fechaDespegueIda = vuelos[0]._fechaPartida.Day + "/" + vuelos[0]._fechaPartida.Month + "/" + vuelos[0]._fechaPartida.Year;
                bol._fechaDespegueVuelta = vuelos[1]._fechaPartida.Day + "/" + vuelos[1]._fechaPartida.Month + "/" + vuelos[1]._fechaPartida.Year;
                bol._fechaAterrizajeIda = vuelos[0]._fechaLlegada.Day + "/" + vuelos[0]._fechaLlegada.Month + "/" + vuelos[0]._fechaLlegada.Year;
                bol._fechaAterrizajeVuelta = vuelos[1]._fechaLlegada.Day + "/" + vuelos[1]._fechaLlegada.Month + "/" + vuelos[1]._fechaLlegada.Year;
                bol._horaDespegueIda = time0;
                bol._horaDespegueVuelta = time1;
                bol._horaAterrizajeIda = time2;
                bol._horaAterrizajeVuelta = time3;
            }

            bol._origen = boleto._origen.Name;
            bol._destino = boleto._destino.Name;
            bol._monto = boleto._costo;
            bol._tipoBoleto = boleto._tipoBoleto;
            bol._nombre = boleto._pasajero._primer_nombre;
            bol._apellido = boleto._pasajero._primer_apellido;
            bol._pasaporte = boleto._pasajero._id;
            bol._correo = boleto._pasajero._correo;

            return PartialView(bol);
        }

        public ActionResult M05_ModificarBoleto(int id)
        {
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id);

            CModificarBoleto bolView = new CModificarBoleto();

            bolView.bol = boleto;
            return PartialView(bolView);
        }

        // POST
        [HttpPost]
        public JsonResult verBoleto(CVisualizarBoleto model)
        {
            String origen = model._origen;
            String destino = model._destino;
            String fechaSalIda = model._fechaDespegueIda;
            String fechaSalVuelta = model._fechaDespegueVuelta;
            String fechaLlegIda= model._fechaAterrizajeIda;
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

        // POST
        [HttpPost]
        public JsonResult eliminarBoleto(int id)
        {
            manejadorSQL_Boletos eliminar = new manejadorSQL_Boletos();
            int modifico_si_no = eliminar.M05EliminarBoletoBD(id);

            return (Json(true, JsonRequestBehavior.AllowGet));
        }



    }
}
