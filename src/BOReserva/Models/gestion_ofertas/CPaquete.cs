using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class CPaquete
    {

        public int _idPaquete { get; set; }

        public String _nombrePaquete { get; set; }

        public String _idAuto { get; set; }

        public float _precioPaquete { get; set; }

        public int _idOferta { get; set; }

        public COferta _oferta;

        public int? _seleccionAuto { get; set; }

        public int? _idRestaurante { get; set; }

        public int? _idHabitacion { get; set; }

        public int? _idCrucero { get; set; }

        public int? _idVuelo { get; set; }

        public DateTime? _fechaIniAuto { get; set; }

        public DateTime? _fechaIniRest { get; set; }

        public DateTime? _fechaIniHabi { get; set; }

        public DateTime? _fechaIniCruc { get; set; }

        public DateTime? _fechaIniVuelo { get; set; }

        public DateTime? _fechaFinAuto { get; set; }

        public DateTime? _fechaFinRest { get; set; }

        public DateTime? _fechaFinHabi { get; set; }

        public DateTime? _fechaFinCruc { get; set; }

        public DateTime? _fechaFinVuelo { get; set; }

        public bool _estadoPaquete { get; set; }

        public int _fkOferta { get; set; }

       public CPaquete() { }
        public CPaquete (int id, string nombre, float precio, COferta oferta)
        {
            _idPaquete = id;
            _nombrePaquete = nombre;
            _precioPaquete = precio;
            _oferta = oferta;
        }

        public CPaquete(int id, string nombre, float precio, bool estado)
        {
            _idPaquete = id;
            _nombrePaquete = nombre;
            _precioPaquete = precio;
            _estadoPaquete = estado;
        }

        public CPaquete(int id, string nombre, float precio)
        {
            _idPaquete = id;
            _nombrePaquete = nombre;
            _precioPaquete = precio;
        }

        public CPaquete(int idPaquete, String nombrePaquete, float precioPaquete, int fkOferta)
        {
            _idPaquete = idPaquete;
            _nombrePaquete = nombrePaquete;
            _precioPaquete = precioPaquete;
            _fkOferta = fkOferta;
        }



        public String formatDate(DateTime? date)
        {
            return (String.Format("{0:MM/dd/yyyy}", date));
        }
    }
}