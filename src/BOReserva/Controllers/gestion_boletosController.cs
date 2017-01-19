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

        public ActionResult M05_DetalleBoleto(int idorigen, int iddestino, string fechadespegue, string fechaaterrizaje, int monto, string tipo, string primernombre, string segundonombre, string primerapellido, string segundoapellido, string fechanac, string sexo, int pasaporte, string correo, int idvuelo)
        {
            System.Diagnostics.Debug.WriteLine("Llega a controller de detalle boleto");
            System.Diagnostics.Debug.WriteLine("origen: "+idorigen+", destino: "+iddestino+", despegue: "+fechadespegue+", aterrizaje: "+fechaaterrizaje+", monto: "+monto+", tipo: "+tipo+", primernombre: "+primernombre+", segundonombre: "+segundonombre+", primerapellido: "+primerapellido+", segundoapellido: "+segundoapellido+", fechanac: "+fechanac+", sexo: "+sexo+", pasaporte: "+pasaporte+", correo: "+correo);
            CPasajero pasa = new CPasajero();
            pasa._primer_nombre = primernombre;
            pasa._segundo_nombre = segundonombre;
            pasa._primer_apellido = primerapellido;
            pasa._segundo_apellido = segundoapellido;
            pasa._fecha_nacimiento = fechanac;
            pasa._sexo = sexo;
            pasa._id = pasaporte;
            pasa._correo = correo;

            CVisualizarBoleto bol = new CVisualizarBoleto();
            manejadorSQL_Boletos sqlboletos = new manejadorSQL_Boletos();
            bol._idOrigen = idorigen;
            bol._idDestino = iddestino;
            bol._fechaDespegueIda = fechadespegue;
            bol._fechaAterrizajeIda = fechaaterrizaje;
            bol._monto = monto;
            bol._tipoBoleto = tipo;
            bol._pasajero = pasa;
            bol._origen = sqlboletos.MBuscarnombreciudad(idorigen);
            bol._destino = sqlboletos.MBuscarnombreciudad(iddestino);
            bol._idVuelo = idvuelo;

            sqlboletos.CrearPasajero(pasaporte,primernombre,segundonombre,primerapellido,segundoapellido,fechanac,sexo,correo);



            return PartialView(bol);
        }


        public ActionResult M05_VerReserva()
        {

            return PartialView();
        }



        public ActionResult M05_DetalleVuelo(string origen,string destino,string fechasalida,string fechallegada,int idorigen,int iddestino,int monto, string tipo, int idvuelo)
        {

            System.Diagnostics.Debug.WriteLine("Llega al controller de detalleVuelo");
            System.Diagnostics.Debug.WriteLine("origen: " + origen + ", destino: " + destino + ", fecha salida: " + fechasalida + ", fecha llegada: " + fechallegada + ", id origen: " + idorigen + ", id destino: " + iddestino+", monto: "+monto+", tipo: "+tipo+", id vuelo: "+idvuelo);

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

            System.Diagnostics.Debug.WriteLine("Llega al controller de VerVuelos");
            System.Diagnostics.Debug.WriteLine("DATOS CONTROLLER VERVUELOS: id_origen: "+idorigen+", id_destino: "+iddestino+", ida_vuelta: "+idavuelta+", tipo: "+tipo+", fecha ida: "+ fechaida+", fecha vuelta: "+fechavuelta);

            manejadorSQL_Boletos sqlboletos = new manejadorSQL_Boletos();
            List<CVuelo> listavuelos = new List<CVuelo>();
            listavuelos = sqlboletos.M05ListarVuelosIdaBD(fechaida, fechavuelta, idorigen, iddestino, tipo);
           // System.Diagnostics.Debug.WriteLine("DATOS CONTROLLER VERVUELOS: listavuelos: vuelos[0]: partida:  "+ listavuelos[0]._fechaPartida+", llegada: "+listavuelos[0]._fechaLlegada);


            return PartialView(listavuelos);
        }

        public ActionResult M05_DetalleVueloReserva(int id_reserva)
        {

          
            System.Diagnostics.Debug.WriteLine("Llega al controller de detalleveuloreserva");

            //BUSCA LA RESERVA A MOSTRAR
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            //Uso CBoleto ya que tiene los mismos atributos de reserva_boleto
            CBoleto reserva = buscarboleto.M05MostrarReservaBD(id_reserva);


            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS

            List<CVuelo> vuelos = reserva._vuelos;

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



        public ActionResult M05_DetalleBoletoReserva(int id_reserva)
        {


            System.Diagnostics.Debug.WriteLine("Llega al controller detalleBoletoReserva");

            //BUSCA LA RESERVA A MOSTRAR
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            //Uso CBoleto ya que tiene los mismos atributos de reserva_boleto
            CBoleto reserva = buscarboleto.M05MostrarReservaBD(id_reserva);

            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS

            List<CVuelo> vuelos = reserva._vuelos;

            System.Diagnostics.Debug.WriteLine("vuelos[0]: " + vuelos[0]._fechaPartida + ", " + vuelos[0]._fechaLlegada);

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

            System.Diagnostics.Debug.WriteLine("Llega al controller de boletocreadoreserva");

            //BUSCA LA RESERVA A MOSTRAR
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            //Uso CBoleto ya que tiene los mismos atributos de reserva_boleto
            CBoleto reserva = buscarboleto.M05MostrarReservaBD(id_reserva);

            // EL/LOS VUELOS DEL BOLETO ESTAN EN UNA LISTA
            // NO SOPORTA ESCALAS

            List<CVuelo> vuelos = reserva._vuelos;

            System.Diagnostics.Debug.WriteLine("vuelos[0]: " + vuelos[0]._fechaPartida + ", " + vuelos[0]._fechaLlegada);

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


            //Tomo todos los datos de bol para crear el boleto
            //Creo método para crear el boleto en el servicio y le paso por parámetro los atributos
            //(bol_id,bol_escala,bol_ida_vuelta,bol_costo,fk_origen,fk_destino,fk_pasajero,bol_fecha,tipo_boleto)
            manejadorSQL_Boletos sqlboleto = new manejadorSQL_Boletos();

           
            int id_origen = int.Parse(reserva._origen.Id);
            int id_destino = int.Parse(reserva._destino.Id);
            double dcosto = reserva._costo;
            int costo = (int) dcosto;

           
            
            int id_vuelo = reserva._vuelos[0]._id;
            System.Diagnostics.Debug.WriteLine("EL ID DEL VUELO DE LA RESERVA ES: " + id_vuelo);

            String fecha_bol = DateTime.Today.ToString("yyyy/MM/dd");
            Console.WriteLine("FECHA: "+ fecha_bol);

            System.Diagnostics.Debug.WriteLine("CREAR BOLETO --- escala: 0, ida_vuelta: " + reserva._ida_vuelta + ", costo: " + costo + ", id_origen: " + id_origen + ", id_destino: " + id_destino + ", id_pasajero: " + reserva._pasajero._id + ", fecha boleto: " + fecha_bol + ", tipo: " + reserva._tipoBoleto);

            sqlboleto.M05CrearBoletoReservaBD(0, reserva._ida_vuelta, costo, id_origen, id_destino, reserva._pasajero._id, fecha_bol, reserva._tipoBoleto, id_vuelo);

            
            
            System.Diagnostics.Debug.WriteLine("Finaliza el controller");

            return PartialView(bol);
        }

        public ActionResult M05_BoletoCreado(int idorigen, int iddestino, int pasaporte, int monto, string tipo, int idvuelo )
        {




            manejadorSQL_Boletos sqlboleto = new manejadorSQL_Boletos();
            String fecha_bol = DateTime.Today.ToString("yyyy/MM/dd");
            Console.WriteLine("FECHA: " + fecha_bol);

            sqlboleto.M05CrearBoletoBD(monto, idorigen, iddestino, pasaporte, fecha_bol, tipo, idvuelo);



            System.Diagnostics.Debug.WriteLine("Finaliza el controller");

            return PartialView();
        }



        public ActionResult M05_DatosUsuario(int idorigen, int iddestino, string fechadespegue, string fechaaterrizaje,int monto,string tipo, int idvuelo)
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
             manejadorSQL_Boletos buscarboletos = new manejadorSQL_Boletos();
             List<CBoleto> listaboletos = buscarboletos.M05ListarBoletosBD();
            return PartialView(listaboletos);
        }


        public ActionResult M05_VisualizarReservasPasajero(int pasaporte)
        {

            System.Diagnostics.Debug.WriteLine("Llega al controller visualizarreservaspasajero");
            //SE BUSCAN TODOS LOS BOLETOS QUE ESTAN EN LA BASE DE DATOS PARA MOSTRARLOS EN LA VISTA
            manejadorSQL_Boletos buscarboletos = new manejadorSQL_Boletos();
            List<CBoleto> listaboletos = buscarboletos.M05ListarReservasPasajeroBD(pasaporte);



            return PartialView(listaboletos);
        }

        // GET
        public ActionResult M05_VisualizarBoleto(int id)
        {

            System.Diagnostics.Debug.WriteLine("llega al controller");

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
            manejadorSQL_Boletos buscarboleto = new manejadorSQL_Boletos();
            CBoleto boleto = buscarboleto.M05MostrarBoletoBD(id);

            String hola = boleto._tipoBoleto;

            CModificarBoleto bolView = new CModificarBoleto(boleto);
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
            manejadorSQL_Boletos eliminar = new manejadorSQL_Boletos();
            int modifico_si_no = eliminar.M05EliminarBoletoBD(id);

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        [HttpPost]
        public JsonResult modificarDatosPasajero(CModificarBoleto model)
        {

            CPasajero pas = new CPasajero(model._id, model._primer_nombre,model._segundo_nombre,model._primer_apellido,
                                          model._segundo_apellido,model._sexo,model._fecha_nac,model._correo);
            manejadorSQL_Boletos modificar = new manejadorSQL_Boletos();
            int modifico_si_no = modificar.M05ModificarDatosPasajero(pas);

            return (Json(true, JsonRequestBehavior.AllowGet));
        }

        public bool verificarDisponibilidad(int codigo_vuelo, String tipo)
        {
            bool disponibilidad = false;
            manejadorSQL_Boletos modificar = new manejadorSQL_Boletos();

            int compara1 = String.Compare(tipo, "Turista");
            int compara2 = String.Compare(tipo, "Ejecutivo");
            int compara3 = String.Compare(tipo, "Vip");

            if (compara1 == 0)
            {

                int conteo = modificar.MConteoTurista(codigo_vuelo);
                int cap = modificar.MBuscarCapTurista(codigo_vuelo);
                System.Diagnostics.Debug.WriteLine(conteo);
                System.Diagnostics.Debug.WriteLine(cap);
                if (conteo < cap)
                {
                    disponibilidad = true;
                }
                else
                {
                    disponibilidad = false;
                }

            }

            if (compara2 == 0)
            {
                int conteo = modificar.MConteoEjecutivo(codigo_vuelo);
                int cap = modificar.MBuscarCapEjecutivo(codigo_vuelo);
                System.Diagnostics.Debug.WriteLine(conteo);
                System.Diagnostics.Debug.WriteLine(cap);
                if (conteo < cap)
                {
                    disponibilidad = true;
                }
                else
                {
                    disponibilidad = false;
                }
            }

            if (compara3 == 0)
            {

                int conteo = modificar.MConteoVip(codigo_vuelo);
                int cap = modificar.MBuscarCapVip(codigo_vuelo);
                if (conteo < cap)
                {
                    disponibilidad = true;
                }
                else
                {
                    disponibilidad = false;
                }
            }

            return disponibilidad;
        }


        [HttpPost]
        public JsonResult modificarTipoBoleto(CModificarBoleto model)
        {
            bool disponibilidad = false;
            String tipo = model._tipoBoleto;

            manejadorSQL_Boletos modificar = new manejadorSQL_Boletos();
            String tipoOri = modificar.MBuscarTipoBoletoOriginal(model._bol_id);
            List<CVuelo> lista = modificar.M05ListarVuelosBoleto(model._bol_id);

            int compara = String.Compare(tipoOri, tipo);
            if (compara != 0) {

                // PRIMERO VEO SI ES IDA O IDA Y VUELTA
                int ida_vuelta = modificar. MBuscarIdaVuelta(model._bol_id);
                // EL BOLETO ES IDA 1
                // EL BOLETO ES IDA Y VUELTA 2
                if (ida_vuelta == 1) {
                    int codigo_vuelo1 = lista[0]._id;

                    disponibilidad = verificarDisponibilidad(codigo_vuelo1, tipo);

                } else {
                    int codigo_vuelo_ida = lista[0]._id;
                    int codigo_vuelo_vuelta = lista[1]._id;

                    bool disp_ida = verificarDisponibilidad(codigo_vuelo_ida, tipo);
                    bool disp_vuelta = verificarDisponibilidad(codigo_vuelo_vuelta, tipo);

                    disponibilidad = ((disp_ida) && (disp_vuelta));
                    System.Diagnostics.Debug.WriteLine(disponibilidad);

                }

                if (disponibilidad) {

                    // HACER EL UPDATE
                    int num = modificar.M05ModificarTipoBoleto(model._bol_id, tipo);
                    return (Json(true, JsonRequestBehavior.AllowGet));
                } else {
                    //Creo el codigo de error de respuesta (OJO: AGREGAR EL USING DE SYSTEM.NET)
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //Agrego mi error
                    String error = "No hay disponibilidad para cambiar de categoría";
                    //Retorno el error
                    return Json(error);
                }

            } else {
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
