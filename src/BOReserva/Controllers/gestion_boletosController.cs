using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using BOReserva.Models.gestion_boletos;
using BOReserva.Servicio.Servicio_Boletos;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;



namespace BOReserva.Controllers
{
    public class gestion_boletosController : Controller
    {

        public ActionResult M05_DetalleBoleto(int idorigen, int iddestino, string fechadespegue, string fechaaterrizaje, int monto, string tipo, string primernombre, string segundonombre, string primerapellido, string segundoapellido, string fechanac, string sexo, int pasaporte, string correo, int idvuelo)
        {
           

            Pasajero nuevoPasajero = (Pasajero)FabricaEntidad.InstanciarPasajero(pasaporte, primernombre, segundonombre, primerapellido, segundoapellido, sexo, fechanac, correo);
            CVisualizarBoleto bol = new CVisualizarBoleto();
            bol._idOrigen = idorigen;
            bol._idDestino = iddestino;
            bol._fechaDespegueIda = fechadespegue;
            bol._fechaAterrizajeIda = fechaaterrizaje;
            bol._monto = monto;
            bol._tipoBoleto = tipo;
            bol._pasajero = nuevoPasajero;
            bol._origen = (FabricaComando.buscarM05nombreCiudad(new Entidad(idorigen))).ejecutar();
            bol._destino = (FabricaComando.buscarM05nombreCiudad(new Entidad(iddestino))).ejecutar();
            bol._idVuelo = idvuelo;

            Command<String> comando = FabricaComando.crearM05AgregarPasajero(nuevoPasajero);
            string flag = comando.ejecutar();
            return PartialView(bol);
        }


        public ActionResult M05_VerReserva()
        {

            return PartialView();
        }



        public ActionResult M05_DetalleVuelo(string origen, string destino, string fechasalida, string fechallegada, int idorigen, int iddestino, int monto, string tipo, int idvuelo)
        {
            CVisualizarBoleto vue = new CVisualizarBoleto();

            vue._origen = origen;
            vue._destino = destino;
            vue._fechaDespegueIda = fechasalida;
            vue._fechaAterrizajeIda = fechallegada;
            vue._idOrigen = idorigen;
            vue._idDestino = iddestino;
            vue._monto = monto;
            vue._tipoBoleto = tipo;
            vue._idVuelo = idvuelo;


            return PartialView(vue);
        }

        public ActionResult M05_CrearBoleto()
        {

            CBuscarVuelo model = new CBuscarVuelo();


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

      
        public ActionResult M05_VerVuelos(int idorigen, int iddestino, string idavuelta, string tipo, string fechaida, string fechavuelta)
        {
             manejadorSQL_Boletos sqlboletos = new manejadorSQL_Boletos();
            
            //List<CVuelo> listavuelos = new List<CVuelo>();
            //listavuelos = sqlboletos.M05ListarVuelosIdaBD(fechaida, fechavuelta, idorigen, iddestino, tipo);
            Command<List<Entidad>> comando = FabricaComando.consultarM05listaVuelosBD(fechaida, fechavuelta, idorigen, iddestino, tipo);
            List<Entidad> listavuelos = comando.ejecutar();

            
            return PartialView(listavuelos);
        }

   
        public ActionResult M05_DetalleVueloReserva(int id_reserva)
        {

            //BUSCA LA RESERVA A MOSTRA
            //Uso Boleto ya que tiene los mismos atributos de reserva_bolet
            Command<Entidad> comando = FabricaComando.consultarM05BoletopasajeroBD(id_reserva);
            Boleto reserva = (Boleto)comando.ejecutar();
            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS
            List<BoletoVuelo> vuelos = reserva._vuelos;
            CVisualizarBoleto bol = new CVisualizarBoleto();


            if (reserva._ida_vuelta == 1)
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
            else
            {
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

            bol._origen = reserva._origen.Name;
            bol._destino = reserva._destino.Name;
            bol._monto = reserva._costo;
            bol._tipoBoleto = reserva._tipoBoleto;
            bol._nombre = reserva._pasajero._primer_nombre;
            bol._apellido = reserva._pasajero._primer_apellido;
            bol._pasaporte = reserva._pasajero._id;
            bol._correo = reserva._pasajero._correo;
            bol._idReserva = id_reserva;
            return PartialView(bol);
        }


       
        public ActionResult M05_DetalleBoletoReserva(int id_reserva)
        {
            //BUSCA LA RESERVA A MOSTRA
            //Uso Boleto ya que tiene los mismos atributos de reserva_bolet
            Command<Entidad> comando = FabricaComando.consultarM05BoletopasajeroBD(id_reserva);
            Boleto reserva = (Boleto)comando.ejecutar();
            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS
            List<BoletoVuelo> vuelos = reserva._vuelos;
            CVisualizarBoleto bol = new CVisualizarBoleto();


            if (reserva._ida_vuelta == 1)
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
            else
            {
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

            bol._origen = reserva._origen.Name;
            bol._destino = reserva._destino.Name;
            bol._monto = reserva._costo;
            bol._tipoBoleto = reserva._tipoBoleto;
            bol._nombre = reserva._pasajero._primer_nombre;
            bol._apellido = reserva._pasajero._primer_apellido;
            bol._pasaporte = reserva._pasajero._id;
            bol._correo = reserva._pasajero._correo;
            bol._idReserva = id_reserva;

            System.Diagnostics.Debug.WriteLine("Origen: " + bol._origen + ", Destino: " + bol._destino + ", Monto: " + bol._monto + ", fecha despeje ida: " + bol._fechaDespegueIda + ", fecha aterrizaje ida: " + bol._fechaAterrizajeIda + ", fecha despeje vuelta: " + bol._fechaDespegueVuelta + ", fecha aterrizaje vuelta: " + bol._fechaAterrizajeVuelta);

            System.Diagnostics.Debug.WriteLine("Finaliza el controller");

            return PartialView(bol);
        }

       
        public ActionResult M05_BoletoCreadoReserva(int id_reserva)
        {

         
            //BUSCA LA RESERVA A MOSTRA
            //Uso Boleto ya que tiene los mismos atributos de reserva_bolet
            Command<Entidad> comando = FabricaComando.consultarM05BoletopasajeroBD(id_reserva);
            Boleto reserva = (Boleto)comando.ejecutar();
            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS
            List<BoletoVuelo> vuelos = reserva._vuelos;
            CVisualizarBoleto bol = new CVisualizarBoleto();


            if (reserva._ida_vuelta == 1)
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
            else
            {
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

            bol._origen = reserva._origen.Name;
            bol._destino = reserva._destino.Name;
            bol._monto = reserva._costo;
            bol._tipoBoleto = reserva._tipoBoleto;
            bol._nombre = reserva._pasajero._primer_nombre;
            bol._apellido = reserva._pasajero._primer_apellido;
            bol._pasaporte = reserva._pasajero._id;
            bol._correo = reserva._pasajero._correo;
            bol._idReserva = id_reserva;
            int id_origen = reserva._origen.Id;
            int id_destino = reserva._destino.Id;
            double dcosto = reserva._costo;
            int costo = (int)dcosto;

            //Tomo todos los datos de bol para crear el boleto
            //Creo método para crear el boleto en el servicio y le paso por parámetro los atributos
            //(bol_id,bol_escala,bol_ida_vuelta,bol_costo,fk_origen,fk_destino,fk_pasajero,bol_fecha,tipo_boleto)
           

            int id_vuelo = reserva._vuelos[0]._id;
            System.Diagnostics.Debug.WriteLine("EL ID DEL VUELO DE LA RESERVA ES: " + id_vuelo);
            String fecha_bol = DateTime.Today.ToString("yyyy/MM/dd");
           
         
            Boleto nuevoBoleto = (Boleto)FabricaEntidad.InstanciarBoleto(id_origen, id_destino, reserva._pasajero._id, costo, reserva._tipoBoleto, id_vuelo, fecha_bol);
            Command<String> comando2 = FabricaComando.crearM05CrearBoleto(nuevoBoleto);
            string flag = comando2.ejecutar();

            System.Diagnostics.Debug.WriteLine("Finaliza el controller");

            return PartialView(bol);
        }

        public ActionResult M05_BoletoCreado(int idorigen, int iddestino, int pasaporte, int monto, string tipo, int idvuelo)
        {
            String fecha_bol = DateTime.Today.ToString("yyyy/MM/dd");
            Boleto nuevoBoleto = (Boleto)FabricaEntidad.InstanciarBoleto(idorigen, iddestino, pasaporte, monto, tipo, idvuelo, fecha_bol);
            Command<String> comando = FabricaComando.crearM05CrearBoleto(nuevoBoleto);
            string flag = comando.ejecutar();

            return PartialView();
        }



        public ActionResult M05_DatosUsuario(int idorigen, int iddestino, string fechadespegue, string fechaaterrizaje, int monto, string tipo, int idvuelo)
        {

            CVisualizarBoleto vue = new CVisualizarBoleto();

            vue._idOrigen = idorigen;
            vue._idDestino = iddestino;
            vue._fechaDespegueIda = fechadespegue;
            vue._fechaAterrizajeIda = fechaaterrizaje;
            vue._monto = monto;
            vue._tipoBoleto = tipo;
            vue._idVuelo = idvuelo;


            return PartialView(vue);
        }

        public ActionResult M05_DetallePrueba(int id_reserva)
        {

            return PartialView();

        }

        public ActionResult M05_VisualizarBoletos()
        {
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            //manejadorSQL_Boletos buscarboletos = new manejadorSQL_Boletos();
            //List<CBoleto> listaboletos = buscarboletos.M05ListarBoletosBD();
            Command<List<Entidad>> comando = FabricaComando.ConsultarBoletos();
            List<Entidad> listaBoletos = comando.ejecutar();
            return PartialView(listaBoletos);
        }

       
        public ActionResult M05_VisualizarReservasPasajero(int pasaporte)
        {

            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            Command<List<Entidad>> comando = FabricaComando.ConsultarBoletosPasajero(pasaporte);
            List<Entidad> listaBoletos = comando.ejecutar();
            return PartialView(listaBoletos);
        }

        // GET
        public ActionResult M05_VisualizarBoleto(int id)
        {


            //BUSCA EL BOLETO A MOSTRAR
            Command<Entidad> comando = FabricaComando.mostrarM05boleto(id);
            Boleto boleto = (Boleto)comando.ejecutar();
            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS
            List<BoletoVuelo> vuelos = boleto._vuelos;
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
            else
            {
                var time0 = vuelos[0]._fechaPartida.TimeOfDay.ToString();
                var time1 = vuelos[0]._fechaLlegada.TimeOfDay.ToString();
                var time2 = vuelos[1]._fechaPartida.TimeOfDay.ToString();
                var time3 = vuelos[1]._fechaLlegada.TimeOfDay.ToString();
                bol._fechaDespegueIda = vuelos[0]._fechaPartida.Day + "/" + vuelos[0]._fechaPartida.Month + "/" + vuelos[0]._fechaPartida.Year;
                bol._fechaDespegueVuelta = vuelos[1]._fechaPartida.Day + "/" + vuelos[1]._fechaPartida.Month + "/" + vuelos[1]._fechaPartida.Year;
                bol._fechaAterrizajeIda = vuelos[0]._fechaLlegada.Day + "/" + vuelos[0]._fechaLlegada.Month + "/" + vuelos[0]._fechaLlegada.Year;
                bol._fechaAterrizajeVuelta = vuelos[1]._fechaLlegada.Day + "/" + vuelos[1]._fechaLlegada.Month + "/" + vuelos[1]._fechaLlegada.Year;
                bol._horaDespegueIda = time0;
                bol._horaAterrizajeIda = time1;
                bol._horaDespegueVuelta = time2;
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
            Command<Entidad> comando = FabricaComando.mostrarM05boleto(id);
            Boleto boleto = (Boleto)comando.ejecutar();
            CModificarBoleto boletoView = new CModificarBoleto(boleto);
            return PartialView(boletoView);
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
            int idOrigen = model._idOrigen;
            int idDestino = model._idDestino;
            String primer_nombre = model._pasajero._primer_nombre;
            String segundo_nombre = model._pasajero._segundo_nombre;
            String primer_apellido = model._pasajero._primer_apellido;
            String segundo_apellido = model._pasajero._segundo_apellido;
            String fecha_nac = model._pasajero._fecha_nacimiento;
            String sexo = model._pasajero._sexo;
            int idVuelo = model._idVuelo;


            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        // POST
        [HttpPost]
        public JsonResult verReserva(CVisualizarBoleto model)
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

        // POST
        [HttpPost]
        public JsonResult eliminarBoleto(int id)
        {

            Command<String> comando = FabricaComando.crearM05EliminarBoleto(id);
            String elimino_si_no = comando.ejecutar();
            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult modificarDatosPasajero(CModificarBoleto model)
        {
            Pasajero pasajero = (Pasajero)FabricaEntidad.InstanciarPasajero(model._id, model._primer_nombre, model._segundo_nombre, model._primer_apellido, model._segundo_apellido, model._sexo, model._fecha_nac.ToString("yyyy/MM/dd"), model._correo);
            Command<String> comando = FabricaComando.modificarM05modificarPasajero(pasajero);
            String agrego_si_no = comando.ejecutar();

            return (Json(true, JsonRequestBehavior.AllowGet));
        }


        [HttpPost]
        public JsonResult modificarTipoBoleto(CModificarBoleto model)
        {
            bool disponibilidad = false;
            String tipo = model._tipoBoleto;

            Command<Entidad> comando = FabricaComando.mostrarM05boleto(model._bol_id);
            Boleto boleto = (Boleto)comando.ejecutar();
            List<BoletoVuelo> lista = boleto._vuelos;
            String tipoOri = boleto._tipoBoleto;
          
            int compara = String.Compare(tipoOri, tipo);
            if (compara != 0)
            {

                // PRIMERO VEO SI ES IDA O IDA Y VUELTA
                Command<int> comando2 = FabricaComando.mostrarM05idaVuelta(model._bol_id);
                int ida_vuelta = comando2.ejecutar();
                // EL BOLETO ES IDA 1
                // EL BOLETO ES IDA Y VUELTA 2
                if (ida_vuelta == 1)
                {
                    int codigo_vuelo1 = lista[0]._id;
                    Command<bool> comando3 = FabricaComando.verificarM05Boleto(codigo_vuelo1, tipo);
                    disponibilidad =comando3.ejecutar();

                }
                else
                {
                    int codigo_vuelo_ida = lista[0]._id;
                    int codigo_vuelo_vuelta = lista[1]._id;
                    Command<bool> comando4 = FabricaComando.verificarM05Boleto(codigo_vuelo_ida, tipo);
                    Command<bool> comando5 = FabricaComando.verificarM05Boleto(codigo_vuelo_vuelta, tipo);
                    bool disp_ida = comando4.ejecutar();
                    bool disp_vuelta = comando5.ejecutar();
                    disponibilidad = ((disp_ida) && (disp_vuelta));
                    System.Diagnostics.Debug.WriteLine(disponibilidad);

                }

                if (disponibilidad)
                {

                    // HACER EL UPDATE
                    boleto._tipoBoleto = tipo;
                    Command<int> comando6 = FabricaComando.modificarM05modificarBoleto(boleto);
                    int num = comando6.ejecutar();
                    return (Json(true, JsonRequestBehavior.AllowGet));
                }
                else
                {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "No hay disponibilidad para cambiar de categoría";
                    //Retorno el error
                    return Json(error);
                }

            }
            else
            {
                //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //Agrego mi error
                String error = "Posee la misma categoría de boleto";
                //Retorno el error
                return Json(error);
            }


        }

    }
}
