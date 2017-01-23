using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.DataAccess.Domain
{

    /**
     *Clase para el manejo de la reserva de cruceros
     */
    public class ReservaCrucero : Entidad
    {
        public DateTime _fechaReserva { get; set; }
        public int _cantidadPasajeros { get; set; }
        public int _usuario { get; set; }
        public int _crucero { get; set; }
        public int _ruta { get; set; }
        public DateTime _fechaInicio { get; set; }
        public String _status { get; set; }

        public ReservaCrucero()
        {

        }

        public ReservaCrucero(int id, DateTime fechaReserva, int cantidadPasajeros, int usuario, int crucero, int ruta, DateTime fechaInicio, String status)
        {
            this._id = id;
            this._fechaReserva = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._usuario = usuario;
            this._crucero = crucero;
            this._ruta = ruta;
            this._fechaInicio = fechaInicio;
            this._status = status;
        }

        public ReservaCrucero(DateTime fechaReserva, int cantidadPasajeros, int usuario, int crucero, int ruta, DateTime fechaInicio, String status)
        {
            this._fechaReserva = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._usuario = usuario;
            this._crucero = crucero;
            this._ruta = ruta;
            this._fechaInicio = fechaInicio;
            this._status = status;
        }

        public ReservaCrucero(int cantidadPasajeros, int usuario, int crucero, int ruta, DateTime fechaInicio, String status)
        {
            this._cantidadPasajeros = cantidadPasajeros;
            this._usuario = usuario;
            this._crucero = crucero;
            this._ruta = ruta;
            this._fechaInicio = fechaInicio;
            this._status = status;
        }
    }
}
