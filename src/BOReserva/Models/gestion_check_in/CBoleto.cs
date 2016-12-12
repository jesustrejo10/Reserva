using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_check_in
{
    public class CBoleto
    {
        public int _id { get; set; }

        public int _ida_vuelta { get; set; }

        public int _escala { get; set; }

        public String _tipoBoleto { get; set; }
        public double _costo { get; set; }

        public CLugar _origen { get; set; }

        public CLugar _destino { get; set; }

        public CPasajero _pasajero { get; set; }

        public DateTime _fechaBoleto { get; set; }

        public List<CVuelo> _vuelos { get; set; }

        public CBoleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino,
                      String nombre, String apellido, DateTime fechaBoleto, int idPasajero, string idOrigen, string idDestino,
                      String tipoBol, String correo)
        {
            _id = id;
            _ida_vuelta = ida_vuelta;
            _escala = escala;
            _costo = costo;
            _pasajero = new CPasajero(idPasajero, nombre, apellido, correo);
            _origen = new CLugar(idOrigen, origen);
            _destino = new CLugar(idDestino, destino);
            _fechaBoleto = fechaBoleto;
            _tipoBoleto = tipoBol;
            _vuelos = new List<CVuelo>();

        }

        public CBoleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino,
                       DateTime fechaBoleto, string idOrigen, string idDestino, String tipoBol)
        {
            _id = id;
            _ida_vuelta = ida_vuelta;
            _escala = escala;
            _costo = costo;
            _pasajero = new CPasajero();
            _origen = new CLugar(idOrigen, origen);
            _destino = new CLugar(idDestino, destino);
            _fechaBoleto = fechaBoleto;
            _tipoBoleto = tipoBol;
            _vuelos = new List<CVuelo>();

        }

        public CBoleto(int id)
        {
            _id = id;
        }

    }
}