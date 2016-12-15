using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_itinerario
    {


        public CGestion_itinerario()
        {
        }

        public CGestion_itinerario(DateTime _fechaInicio, DateTime _fechaFin, int _fkCrucero, int _fkRuta)
        {
            this._fechaInicio = _fechaInicio;
            this._fechaFin = _fechaFin;
            this._fkCrucero = _fkCrucero;
            this._fkRuta = _fkRuta;
        }

        public int _fkCrucero { get; set; }

        public DateTime _fechaFin { get; set; }
        public DateTime _fechaInicio { get; set; }
        public int _fkRuta { get; set; }


        public string _ItinerarioCrucero { get; set; }

        public string _estatus { get; set; }

        public string _crucero { get; set; }

        public List<CGestion_itinerario> itinerarios { get; set; }

        public void AgregarItinerario(CGestion_itinerario itinerario)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.insertarItinerario(itinerario);
        }

        public void cambiarEstatusItinerario(DateTime fechaInicio, int fkCrucero, int fkRuta)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.cambiarEstadoItinerario(fechaInicio, fkCrucero, fkRuta);
        }
    }
}