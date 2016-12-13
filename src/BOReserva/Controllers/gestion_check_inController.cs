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

            int id_bol = model._bol_id;

            manejadorSQL_Check modificar = new manejadorSQL_Check();

            // OBTENGO EL /LOS VUELOS DEL BOLETO

            List<CVuelo> lista = modificar.M05ListarVuelosBoleto(model._bol_id);

            // PRIMERO VEO SI ES IDA O IDA Y VUELTA 
            int ida_vuelta = modificar.MBuscarIdaVuelta(model._bol_id);
            // EL BOLETO ES IDA 1
            // EL BOLETO ES IDA Y VUELTA 2
            
            // DATOS PARA INSERTAR EN PASE DE ABORDAJE
            CBoardingPass pase = new CBoardingPass();

            if (ida_vuelta == 1)
            {
                pase._vuelo = lista[0]._id;
                pase._fechaPartida = lista[0]._fechaPartida;
                pase._fechaLlegada = lista[0]._fechaLlegada;
                pase._horaPartida = lista[0]._fechaPartida.TimeOfDay.ToString(); 
                pase._origen = lista[0]._ruta._origen;
                pase._destino = lista[0]._ruta._destino;
                pase._nombreOri = lista[0]._ruta._nomOrigen;
                pase._nombreDest = lista[0]._ruta._nomDestino;

            }
            else
            {
                String tipo = model._tipoBoardingPass;
                int compara = String.Compare(tipo, "Ida");
                if (compara == 0)
                {
                    pase._vuelo = lista[0]._id;
                    pase._fechaPartida = lista[0]._fechaPartida;
                    pase._fechaLlegada = lista[0]._fechaLlegada;
                    pase._horaPartida = lista[0]._fechaPartida.TimeOfDay.ToString(); 
                    pase._origen = lista[0]._ruta._origen;
                    pase._destino = lista[0]._ruta._destino;
                    pase._nombreOri = lista[0]._ruta._nomOrigen;
                    pase._nombreDest = lista[0]._ruta._nomDestino;

                }
                else
                {
                    pase._vuelo = lista[1]._id;
                    pase._fechaPartida = lista[1]._fechaPartida;
                    pase._fechaLlegada = lista[1]._fechaLlegada;
                    pase._horaPartida = lista[1]._fechaPartida.TimeOfDay.ToString(); 
                    pase._origen = lista[1]._ruta._origen;
                    pase._destino = lista[1]._ruta._destino;
                    pase._nombreOri = lista[1]._ruta._nomOrigen;
                    pase._nombreDest = lista[1]._ruta._nomDestino;
                }
            }

            pase._boleto = model._bol_id;
            pase._asiento = "A12";
            pase._nombre = model._primer_nombre;
            pase._apellido = model._primer_apellido;



            // HACER EL INSERT DE PASE DE ABORDAJE
            int resultado = modificar.CrearBoardingPass(pase);
            // TENGO QUE INSTANCIAR AL MODELO DE VER BOARDING PASS
            return PartialView("M05_VerBoardingPass",pase);
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