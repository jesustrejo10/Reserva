using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
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

            //manejadorSQL_Check buscarboletos = new manejadorSQL_Check();
            //List<CBoleto> listaboletos = buscarboletos.M05ListarBoletosPasajero(pasaporte);

            List<Entidad> listaboletos = (FabricaComando.ConsultarBoletos(pasaporte)).ejecutar();

            return PartialView("M05_VerBoletosCheckIn",listaboletos);
        }

        // POST
        [HttpPost]
        public ActionResult buscarPasesAbordaje(CCheckIn model)
        {
            int pasaporte = model._pasaporte;
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS
            // DE ESE PASAJERO EN PARTICULAR PARA MOSTRARLOS EN LA VISTA

            //manejadorSQL_Check buscarboletos = new manejadorSQL_Check();
            //List<CBoardingPass> listaboletos = buscarboletos.M05ListarPasesPasajero(pasaporte);

            List<Entidad> listaBoletos = (FabricaComando.ConsultarPasajeros(pasaporte)).ejecutar();

            return PartialView("M05_VerPasesAbordaje", listaBoletos);
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

            //manejadorSQL_Check buscarboleto = new manejadorSQL_Check();
            //CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id);
            Command<Entidad> co = FabricaComando.mostrarM05boleto(id);
            Boleto boleto = (Boleto) co.ejecutar();
            BoletoDetalle bolView = (BoletoDetalle) FabricaEntidad.InstanciarDetalleBoleto(boleto);

            return PartialView(boleto);

        }

        public ActionResult Equipaje(int id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            CEquipaje equi = new CEquipaje(id);
            return PartialView("M05_Equipaje",equi);
        }
        //faltapatrones
        [HttpPost]
        public ActionResult generarBoardingPass(CDetalleBoleto model)
        {
            BoletoVuelo lista1 = null;
            BoletoVuelo lista2 = null;
            String tipo = model._tipoBoardingPass;
            int compara1 = String.Compare(tipo,"Seleccione");
            if (compara1 != 0)
            {
                int id_bol = model._bol_id;

                manejadorSQL_Check modificar = new manejadorSQL_Check();

                // OBTENGO EL /LOS VUELOS DEL BOLETO
                Command<List<Entidad>> comando = FabricaComando.consultarM05listaVuelos(model._bol_id);
                List<Entidad> lista = comando.ejecutar();
                //List<BoletoVuelo> lista = modificar.M05ListarVuelosBoleto(model._bol_id);
                lista1 = (BoletoVuelo)lista[0];
                if (lista.Count == 2) {
                    lista2 = (BoletoVuelo)lista[1]; 
                }

                // PRIMERO VEO SI ES IDA O IDA Y VUELTA
                //int ida_vuelta = modificar.MBuscarIdaVuelta(model._bol_id);
                Command<int> comando2 = FabricaComando.mostrarM05idaVuelta(model._bol_id);
                int ida_vuelta = comando2.ejecutar();
                // EL BOLETO ES IDA 1
                // EL BOLETO ES IDA Y VUELTA 2

                // DATOS PARA INSERTAR EN PASE DE ABORDAJE
                CBoardingPass pase2 = new CBoardingPass();
                BoardingPass pase;

                if (ida_vuelta == 1)
                {
                    pase = (BoardingPass)FabricaEntidad.InstanciarBoardingPass(lista1._id, lista1._fechaPartida, lista1._fechaLlegada, lista1._fechaPartida.TimeOfDay.ToString(), lista1._ruta._origen, lista1._ruta._destino, lista1._ruta._nomOrigen, lista1._ruta._nomDestino, model._bol_id, "A12", model._primer_nombre, model._primer_apellido);
                    /*pase._vuelo = lista1._id;
                    pase._fechaPartida = lista1._fechaPartida;
                    pase._fechaLlegada = lista1._fechaLlegada;
                    pase._horaPartida = lista1._fechaPartida.TimeOfDay.ToString();
                    pase._origen = lista1._ruta._origen;
                    pase._destino = lista1._ruta._destino;
                    pase._nombreOri = lista1._ruta._nomOrigen;
                    pase._nombreDest = lista1._ruta._nomDestino;*/

                }
                else
                {
                    int compara = String.Compare(tipo, "Ida");
                    if (compara == 0)
                    {
                        pase = (BoardingPass)FabricaEntidad.InstanciarBoardingPass(lista1._id, lista1._fechaPartida, lista1._fechaLlegada, lista1._fechaPartida.TimeOfDay.ToString(), lista1._ruta._origen, lista1._ruta._destino, lista1._ruta._nomOrigen, lista1._ruta._nomDestino, model._bol_id, "A12", model._primer_nombre, model._primer_apellido);

                    }
                    else
                    {
                        pase = (BoardingPass)FabricaEntidad.InstanciarBoardingPass(lista2._id, lista2._fechaPartida, lista2._fechaLlegada, lista2._fechaPartida.TimeOfDay.ToString(), lista2._ruta._origen, lista2._ruta._destino, lista2._ruta._nomOrigen, lista2._ruta._nomDestino, model._bol_id, "A12", model._primer_nombre, model._primer_apellido);
                    }
                }

               

                //int resultado1 = modificar.MConteoBoarding(pase._boleto, pase._vuelo);
                Command<int> comando3 = FabricaComando.conteoM05Boarding(pase._boleto, pase._vuelo);
                int resultado1 = comando3.ejecutar();

                if (resultado1 == 0)
                {
                    // HACER EL INSERT DE PASE DE ABORDAJE
                    Command<int> comando4 = FabricaComando.crearM05CrearBoarding(pase);
                    int resultado = comando4.ejecutar();
                    //int resultado = modificar.CrearBoardingPass(pase2);
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

            Command<int> comando = FabricaComando.conteoM05maletas(pase);

           
            // VEO SI YA TIENE LA MAXIMA CANTIDAD DE MALETAS INSERTADAS
           
            int num_maletas = comando.ejecutar();
            if (num_maletas !=2 )
            {

                int resultado1 = -1;
                int resultado2 = -1;

                if (peso1 != 0)
                {
                    
                     Command<int> comando2 = FabricaComando.crearM05maletas(pase, peso1);
                     resultado1 = comando2.ejecutar();
                }

                if (peso2 > 0)
                {
                   
                    Command<int> comando3 = FabricaComando.crearM05maletas(pase, peso2);
                    resultado2 = comando3.ejecutar();
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
