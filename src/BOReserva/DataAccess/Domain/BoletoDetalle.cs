using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.DataAccess.Domain
{
    public class BoletoDetalle : Entidad
    {
        public String _primer_nombre { get; set; }

        public String _primer_apellido { get; set; }

        public String _segundo_nombre { get; set; }

        public String _segundo_apellido { get; set; }

        public DateTime _fecha_nac { get; set; }

        public String _fecha { get; set; }

        public String _sexo { get; set; }

        public String _correo { get; set; }

        public String _origen { get; set; }
        public String _destino { get; set; }
        public String _fechaDespegueIda { get; set; }
        public String _fechaDespegueVuelta { get; set; }
        public String _fechaAterrizajeIda { get; set; }
        public String _fechaAterrizajeVuelta { get; set; }
        public String _horaDespegueIda { get; set; }
        public String _horaDespegueVuelta { get; set; }
        public String _horaAterrizajeIda { get; set; }
        public String _horaAterrizajeVuelta { get; set; }
        public double _monto { get; set; }
        public String _tipoBoleto { get; set; }
        public int _bol_id { get; set; }

        public String _tipoBoardingPass { get; set; }

        public List<SelectListItem> _tipos { get; set; }

        //Constructor por default por si acaso
        public BoletoDetalle() { }

        //Constructor para pasarle los valores a la vista
        public BoletoDetalle(Boleto boleto)
        {
            _tipos = new List<SelectListItem>();
            _id = boleto._pasajero._id;
            _primer_nombre = boleto._pasajero._primer_nombre;
            _segundo_nombre = boleto._pasajero._segundo_nombre;
            _primer_apellido = boleto._pasajero._primer_apellido;
            _segundo_apellido = boleto._pasajero._segundo_apellido;
            _correo = boleto._pasajero._correo;
            _sexo = boleto._pasajero._sexo;
            _fecha_nac = boleto._pasajero._fecha_nac;

            _bol_id = boleto._id;
            List<BoletoVuelo> vuelos = boleto._vuelos;
            int num = boleto._vuelos.Count;
            if (boleto._ida_vuelta == 1)
            {
                var time = vuelos[0]._fechaPartida.TimeOfDay.ToString();
                var time1 = vuelos[0]._fechaLlegada.TimeOfDay.ToString();
                _fechaDespegueIda = vuelos[0]._fechaPartida.Day + "/" + vuelos[0]._fechaPartida.Month + "/" + vuelos[0]._fechaPartida.Year;
                _fechaDespegueVuelta = "";
                _fechaAterrizajeIda = vuelos[0]._fechaLlegada.Day + "/" + vuelos[0]._fechaLlegada.Month + "/" + vuelos[0]._fechaLlegada.Year;
                _fechaAterrizajeVuelta = "";
                _horaDespegueIda = time;
                _horaDespegueVuelta = "";
                _horaAterrizajeIda = time1;
                _horaAterrizajeVuelta = "";
                _tipos.Add(new SelectListItem
                {
                    Text = "Ida",
                    Value = "Ida"
                });
                _tipoBoardingPass = "Ida";
            }
            else
            {
                var time0 = vuelos[0]._fechaPartida.TimeOfDay.ToString();
                var time1 = vuelos[0]._fechaLlegada.TimeOfDay.ToString();
                if (vuelos.Count == 2)
                {
                    var time2 = vuelos[1]._fechaPartida.TimeOfDay.ToString();
                    var time3 = vuelos[1]._fechaLlegada.TimeOfDay.ToString();
                    _fechaDespegueVuelta = vuelos[1]._fechaPartida.Day + "/" + vuelos[1]._fechaPartida.Month + "/" + vuelos[1]._fechaPartida.Year;
                    _fechaAterrizajeVuelta = vuelos[1]._fechaLlegada.Day + "/" + vuelos[1]._fechaLlegada.Month + "/" + vuelos[1]._fechaLlegada.Year;
                    _horaAterrizajeIda = time2;
                    _horaAterrizajeVuelta = time3;
                }
                _fechaDespegueIda = vuelos[0]._fechaPartida.Day + "/" + vuelos[0]._fechaPartida.Month + "/" + vuelos[0]._fechaPartida.Year;
                _fechaAterrizajeIda = vuelos[0]._fechaLlegada.Day + "/" + vuelos[0]._fechaLlegada.Month + "/" + vuelos[0]._fechaLlegada.Year;
                _horaDespegueIda = time0;
                _horaDespegueVuelta = time1;
                _tipos.Add(new SelectListItem
                {
                    Text = "Seleccione",
                    Value = "Seleccione"
                });
                _tipos.Add(new SelectListItem
                {
                    Text = "Ida",
                    Value = "Ida"
                });
                _tipos.Add(new SelectListItem
                {
                    Text = "Vuelta",
                    Value = "Vuelta"
                });
                _tipoBoardingPass = "";
            }


            _origen = boleto._origen.Name;
            _destino = boleto._destino.Name;
            _monto = boleto._costo;
            _tipoBoleto = boleto._tipoBoleto;
        }
    }
}
