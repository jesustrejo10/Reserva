using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Boleto : Entidad
    {
        public int _ida_vuelta { get; set; }

        public int _escala { get; set; }

        public String _tipoBoleto { get; set; }
        public double _costo { get; set; }

        public Lugar _origen { get; set; }
        public int _idOrigen { get; set; }
        
        public Lugar _destino { get; set; }
        public int _idDestino { get; set; }

        public Pasajero _pasajero { get; set; }
        public int _idPasajero { get; set; }

        public DateTime _fechaBoleto { get; set; }

        public List<BoletoVuelo> _vuelos { get; set; }
        public int _idVuelo { get; set; }

        public String _codigo { get; set; }

        public Boleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino,
                      String nombre, String apellido, DateTime fechaBoleto, int idPasajero, int idOrigen, int idDestino,
                      String tipoBol, String correo)
        {
            _id = id;
            _ida_vuelta = ida_vuelta;
            _escala = escala;
            _costo = costo;
            _pasajero = new Pasajero(idPasajero, nombre, apellido, correo);
            _origen = new Lugar(idOrigen, origen);
            _destino = new Lugar(idDestino, destino);
            _fechaBoleto = fechaBoleto;
            _tipoBoleto = tipoBol;
            _vuelos = new List<BoletoVuelo>();
        }

        //Constructor usado para las reservas, ya que el único atributo extra en la tabla reserva es el código
        public Boleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino,
                      String nombre, String apellido, DateTime fechaBoleto, int idPasajero, int idOrigen, int idDestino,
                      String tipoBol, String correo, string codigo)
        {
            _id = id;
            _ida_vuelta = ida_vuelta;
            _escala = escala;
            _costo = costo;
            _pasajero = new Pasajero(idPasajero, nombre, apellido, correo);
            _origen = new Lugar(idOrigen, origen);
            _destino = new Lugar(idDestino, destino);
            _fechaBoleto = fechaBoleto;
            _tipoBoleto = tipoBol;
            _vuelos = new List<BoletoVuelo>();
            _codigo = codigo;

        }

        public Boleto(int id, int ida_vuelta, int escala, double costo, String origen, String destino,
                       DateTime fechaBoleto, int idOrigen, int idDestino, String tipoBol)
        {
            _id = id;
            _ida_vuelta = ida_vuelta;
            _escala = escala;
            _costo = costo;
            _pasajero = new Pasajero();
            _origen = new Lugar(idOrigen, origen);
            _destino = new Lugar(idDestino, destino);
            _fechaBoleto = fechaBoleto;
            _tipoBoleto = tipoBol;
            _vuelos = new List<BoletoVuelo>();

        }

        public Boleto(int origen , int destino, int pasaporte, double monto, string tipo, int idVuelo, string fec)
        {
            this._idOrigen = origen;
            this._idDestino = destino;
            this._idPasajero = pasaporte;
            this._costo = monto;
            this._tipoBoleto = tipo;
            this._idVuelo = idVuelo;
            this._fechaBoleto = Convert.ToDateTime(fec);

        }

        public Boleto(int id)
        {
            _id = id;
        }

        public Boleto() { }
    }
}