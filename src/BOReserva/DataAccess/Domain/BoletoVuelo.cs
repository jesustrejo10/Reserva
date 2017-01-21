using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Model;

namespace BOReserva.DataAccess.Domain
{
    public class BoletoVuelo
    {
        public int _id { get; set; }

        public RutaBoleto _ruta { get; set; }

        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }

        public int _monto { get; set; }

        public string _tipo { get; set; }

        public string _fechaVuelta { get; set; }

        public BoletoVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2 )
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new RutaBoleto(ruta_id, ori, dest, nombre1, nombre2);
        }

        public BoletoVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2, int monto)
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new RutaBoleto(ruta_id, ori, dest, nombre1, nombre2);
            _monto = monto;
        }

        public BoletoVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2, int monto, string tipo, string fecha_vuelta)
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new RutaBoleto(ruta_id, ori, dest, nombre1, nombre2);
            _monto = monto;
            _tipo = tipo;
            _fechaVuelta = fecha_vuelta;
        }


        public BoletoVuelo()
        {
        }
    }
}