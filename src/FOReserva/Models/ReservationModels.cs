using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace FOReserva.Models
{
    public class ReservationModels : BaseEntity
    {
        private DateTime _date { get; set; }
        private string _time { get; set; }

        public ReservationModels( string owner, DateTime date, string time )
            : base( owner )
        {
            this._date = date;
            this._time = time;
        }
    }
}
