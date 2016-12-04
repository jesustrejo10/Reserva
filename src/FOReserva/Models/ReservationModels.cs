using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace FOReserva.Models
{
    public class ReservationModels : DbContext
    {
        private string _owner { get; set; }
        private DateTime _date { get; set; }
        private String _time { get; set; }

    }
}
