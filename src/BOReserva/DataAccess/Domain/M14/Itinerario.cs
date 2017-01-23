using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain.M14
{
    public class Itinerario : Entidad
    {
        public Itinerario() { }        

        public DateTime _FechaInicio { get; set; }
        public DateTime _FechaFin { get; set; }
        public String _estatus { get; set; }        
        public String _Crucero { get; set; }
        public String _RutaOrigen { get; set; }
        public String _RutaDestino { get; set; }
        public String _Ruta { get; set; }

        public Itinerario(int id,DateTime fechainicio, DateTime fechafin, String estatus, String ruta, String crucero)
        {
            _FechaInicio = fechainicio;
            _FechaFin = fechafin;
            _estatus = estatus;
            _Crucero = crucero;
            _Ruta = ruta;
            _id = id;
        }

        public Itinerario(int id, DateTime fechainicio, DateTime fechafin, String estatus, String rutaorigen, String rutadestino, String crucero)
        {
            _FechaInicio = fechainicio;
            _FechaFin = fechafin;
            _estatus = estatus;
            _Crucero = crucero;
            _RutaOrigen = rutaorigen;
            _RutaDestino = rutadestino;
            _id = id;
        }
    }
}