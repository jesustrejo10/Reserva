using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Restaurantes
{
    public class CReservation_Restaurant : ReservationModels
    {
        private int _count { get; set; }
        //private CRestaurante { get; set; }
        private UserProfile _user;

        public CReservation_Restaurant
           (UserProfile user, string owner, DateTime date, string time, int count)
           : base( owner, date, time )
        {
            this._count = count;
            this._user = user;
            //this._restaurant = restaurant;
        }

    }
}
