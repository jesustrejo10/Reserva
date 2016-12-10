using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class COferta
    {
        public int _idOferta { get; set; }

        public String _nombreOferta { get; set; }

        public float _porcentajeOferta { get; set; }

        public DateTime _fechaIniOferta { get; set; }

        public DateTime _fechaFinOferta { get; set; }

        public bool _estadoOferta { get; set; }

        public COferta(){ 

        }

        public COferta(int id, String nombre, float porcentaje, DateTime fInicio, DateTime fFin, bool estado){
            _idOferta = id;
            _nombreOferta = nombre;
            _porcentajeOferta = porcentaje;
            _fechaIniOferta = fInicio;
            _fechaFinOferta = fFin;
            _estadoOferta = estado;
        }

    }
}