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

        public ActionResult M05_VisualizarBoleto(int id)
        {
            //BUSCA EL BOLETO A MOSTRAR
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id); 

          /*  CVisualizarAutomovil automovil = new CVisualizarAutomovil();
            automovil._matricula = vehiculo._matricula;
            automovil._modelo = vehiculo._modelo;
            automovil._fabricante = vehiculo._fabricante;
            automovil._anio = vehiculo._anio;
            automovil._tipovehiculo = vehiculo._tipovehiculo;
            automovil._kilometraje = vehiculo._kilometraje;
            automovil._cantpasajeros = vehiculo._cantpasajeros;
            automovil._preciocompra = vehiculo._preciocompra;
            automovil._precioalquiler = vehiculo._precioalquiler;
            automovil._penalidaddiaria = vehiculo._penalidaddiaria;
            automovil._fecharegistro = vehiculo._fecharegistro.Month + "/" + vehiculo._fecharegistro.Day + "/" + vehiculo._fecharegistro.Year;
            automovil._color = vehiculo._color;
            automovil._disponibilidad = vehiculo._disponibilidad;
            automovil._transmision = vehiculo._transmision;
            automovil._pais = vehiculo._pais;
            automovil._ciudad = vehiculo._ciudad;*/
            return PartialView(boleto);
        }


    }
}
