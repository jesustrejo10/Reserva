using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_boletos
{
    public class CVuelo
    {
        public int _id { get; set; }

        public CRuta _ruta { get; set; }

        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }

        public int _monto { get; set; }

        public string _tipo { get; set; }

        public CVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2 )
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new CRuta(ruta_id, ori, dest, nombre1, nombre2);
        }

        public CVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2, int monto)
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new CRuta(ruta_id, ori, dest, nombre1, nombre2);
            _monto = monto;
        }

        public CVuelo(int num_id, DateTime fechasal, DateTime fechalleg, int ruta_id, int ori, int dest, String nombre1, String nombre2, int monto, string tipo)
        {
            _id = num_id;
            _fechaPartida = fechasal;
            _fechaLlegada = fechalleg;
            _ruta = new CRuta(ruta_id, ori, dest, nombre1, nombre2);
            _monto = monto;
            _tipo = tipo;
        }


        public CVuelo() { 
        }
    }
}