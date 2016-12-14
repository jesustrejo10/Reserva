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
            // arreglar porq boleto es un Cboleto
            CVisualizarBoleto bol = new CVisualizarBoleto();

            bol._origen = boleto._origen.Name;
            bol._destino = boleto._destino.Name;

            /* OBTENER POR MEDIO DE LA LISTA Y LA CLASE CVUELO
            bol._fechaDespegueIda = boleto._fechaDespegueIda.Day + "/" + boleto._fechaDespegueIda.Month + "/" + boleto._fechaDespegueIda.Year;
            bol._fechaDespegueVuelta = boleto._fechaDespegueVuelta.Day + "/" + boleto._fechaDespegueVuelta.Month + "/" + boleto._fechaDespegueVuelta.Year;
            bol._fechaAterrizajeIda = boleto._fechaAterrizajeIda.Day + "/" + boleto._fechaAterrizajeIda.Month + "/" + boleto._fechaAterrizajeIda.Year;
            bol._fechaAterrizajeVuelta = boleto._fechaAterrizajeVuelta.Day + "/" + boleto._fechaAterrizajeVuelta.Month + "/" + boleto._fechaAterrizajeVuelta.Year;
            bol._horaSalIda = boleto._fechaDespegueIda.Hour;
            bol._horaSalVuelta = boleto._fechaDespegueVuelta.Hour;
            bol._horaLlegIda = boleto._fechaAterrizajeIda.Hour;
            bol._horaLlegVuelta = boleto._fechaAterrizajeVuelta.Hour;*/

            bol._fechaDespegueIda = "";
            bol._fechaDespegueVuelta = "";
            bol._fechaAterrizajeIda = "";
            bol._fechaAterrizajeVuelta = "";
            bol._horaDespegueIda = "";
            bol._horaDespegueVuelta = "";
            bol._horaAterrizajeIda = "";
            bol._horaAterrizajeVuelta = "";

            bol._monto = boleto._costo;
            bol._tipoBoleto = boleto._tipoBoleto;
            bol._nombre = boleto._pasajero._primer_nombre;
            bol._apellido = boleto._pasajero._primer_apellido;
            bol._pasaporte = boleto._pasajero._id;
            bol._correo = boleto._pasajero._correo;

            return PartialView(bol);
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

