using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace FOReserva.Models
{
    /*Clase Modelo para manejo de las reservas
      Atributos: 
       _date: Fecha de la reserva
       _time: Hora de la reserva*/
    public class ReservationModels : BaseEntity
    {
        /*dia de la reservacion*/
        private String _date;
        /*Hora de la reserva*/
        private string _time;

        /*Constructor Completo de Reservas*/
        public ReservationModels( string owner, string date, string time )
            : base( )
        {
            this.Name = owner;
            this._date = date;
            this._time = time;
        }

        public ReservationModels() : base() { }

        /*Fecha de la reserva*/
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /*Hora de la reserva*/
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

    }
}

