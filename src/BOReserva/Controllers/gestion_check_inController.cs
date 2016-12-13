using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.Models.gestion_check_in;
using BOReserva.Servicio.Servicio_Boletos;
using System.Net;

namespace BOReserva.Controllers
{
    public class gestion_check_inController : Controller
    {

        // GET 
        public ActionResult M05_CheckIn()
        {
            return PartialView();
        }

        // GET 
        public ActionResult M05_RegistroEquipaje()
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

        // POST
        [HttpPost]
        public ActionResult buscarPasesAbordaje(CCheckIn model)
        {
            int pasaporte = model._pasaporte;
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS
            // DE ESE PASAJERO EN PARTICULAR PARA MOSTRARLOS EN LA VISTA
            manejadorSQL_Check buscarboletos = new manejadorSQL_Check();
            List<CBoardingPass> listaboletos = buscarboletos.M05ListarPasesPasajero(pasaporte);
            return PartialView("M05_VerPasesAbordaje", listaboletos);
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
            System.Diagnostics.Debug.WriteLine(id);
            manejadorSQL_Check buscarboleto = new manejadorSQL_Check();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id);

            String hola = boleto._tipoBoleto;
            
            CDetalleBoleto bolView = new CDetalleBoleto(boleto);
            return PartialView(bolView);
            //return PartialView();
        }

        public ActionResult Equipaje(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            CEquipaje equi = new CEquipaje(id);
            return PartialView("M05_Equipaje",equi);
        }

        [HttpPost]
        public ActionResult generarBoardingPass(CDetalleBoleto model)
        {

            String tipo = model._tipoBoardingPass;
            int compara1 = String.Compare(tipo,"Seleccione");
            if (compara1 != 0)
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

                int resultado1 = modificar.MConteoBoarding(pase._boleto, pase._vuelo);

                if (resultado1 == 0)
                {
                    // HACER EL INSERT DE PASE DE ABORDAJE
                    int resultado = modificar.CrearBoardingPass(pase);
                }

                // TENGO QUE BUSCAR EL ID DEL PASE DE ABORDAJE CREADO
                int num_boarding = modificar.IdBoardingPass(pase._boleto, pase._vuelo);
                pase._id = num_boarding;
                // TENGO QUE INSTANCIAR AL MODELO DE VER BOARDING PASS
                return PartialView("M05_VerBoardingPass", pase);
            }
            else {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Debe indicar el vuelo a asociar";
                //Retorno el error
                return Json(error);
            }
        }

        [HttpPost]
        public ActionResult insertarEquipaje(CEquipaje model)
        {
            int pase = model._pase;
            int peso1 = model._peso1;
            int peso2 = model._peso2;

            if (peso1 == 0)
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "No indicó el peso de la maleta";
                //Retorno el error
                return Json(error);
            }
            
            manejadorSQL_Check sql = new manejadorSQL_Check();
            // VEO SI YA TIENE LA MAXIMA CANTIDAD DE MALETAS INSERTADAS
            int num_maletas = sql.MConteoMaletas(pase);
            if (num_maletas !=2 )
            {

                int resultado1 = -1;
                int resultado2 = -1;

                if (peso1 != 0)
                {
                    resultado1 = sql.CrearEquipaje(pase, peso1);
                }

                if (peso2 > 0)
                {
                    resultado2 = sql.CrearEquipaje(pase, peso2);
                }

                if (((peso1 != 0) && (resultado1 == 0)) || ((peso2 > 0) && (resultado2 == 0)))
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    String error = "Error insertando en la BD";
                    return Json(error);

                }
                else
                {
                    return PartialView("M05_RegistroEquipaje");
                }
            }
            else {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                String error = "Ya se registró la máxima cantidad de maletas permitidas";
                return Json(error);
            }
        }

        public JsonResult registrarEquipaje(int pase_id)
        {

            int id_bol = pase_id;
            // TENGO QUE INSTANCIAR AL MODELO DE VER BOARDING PASS
            return (Json(true, JsonRequestBehavior.AllowGet));
        }


        // GET 
        public ActionResult M05_Equipaje()
        {
            return PartialView();
        }

    }
}