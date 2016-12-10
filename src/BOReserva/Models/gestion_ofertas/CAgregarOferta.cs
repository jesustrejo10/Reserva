using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ofertas
{
    public class CAgregarOferta
    {

        public String _idOferta { get; set; }

        public String _nombreOferta { get; set; }

        public List<CPaquete> _nombrePaquete { get; set; }

        public float _porcentajeOferta { get; set; }

        public DateTime _fechaIniOferta { get; set; }

        public DateTime _fechaFinOferta { get; set; }

        public bool _estadoOferta { get; set; }

        public String formatDate(DateTime date){
            return(String.Format("{0:MM/dd/yyyy}", date));
        }
    }
}