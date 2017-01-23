using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class BoardingPass : Entidad
    {
        public DateTime _fechaPartida { get; set; }

        public DateTime _fechaLlegada { get; set; }

        public int _boleto { get; set; }

        public int _origen { get; set; }

        public int _destino { get; set; }

        public String _asiento { get; set; }

        public int _vuelo { get; set; }

        public String _nombre { get; set; }
        public String _apellido { get; set; }

        public String _nombreOri { get; set; }
        public String _nombreDest { get; set; }

        public String _horaPartida { get; set; }

        public BoardingPass() { }

        public BoardingPass(int id, String nombre1, String nombre2, int vuelo)
        {
            _id = id;
            _nombreOri = nombre1;
            _nombreDest = nombre2;
            _vuelo = vuelo;
        }
        public BoardingPass(int vuelo, DateTime fechaPartida, DateTime fechaLlegada, String horaPartida, int origen, int destino, 
            String nombreOri, String nombreDest, int boleto, String asiento, String nombre, String apellido)
        {
            _vuelo = vuelo;
            _fechaPartida = fechaPartida;
            _fechaLlegada = _fechaLlegada;
            _horaPartida = _horaPartida;
            _origen = origen;
            _destino = destino;
            _nombreOri = nombreOri;
            _nombreDest = nombreDest;
            _boleto = boleto;
            _asiento = asiento;
            _nombre = nombre;
            _apellido = apellido;

        }
    }
}