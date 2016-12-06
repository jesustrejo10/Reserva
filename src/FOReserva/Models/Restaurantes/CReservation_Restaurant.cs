using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Restaurantes
{
    /*Clase Modelo de la Reservacion de un restaurante
      Atributos:
       _count: Cantidad de personas de la reservacion
       _user: Usuario con el que se realiza la reserva
         */
    public class CReservation_Restaurant : ReservationModels
    {

        private int _count;
        private UserProfile _user;

        /*Constructor Completo*/
        public CReservation_Restaurant
           (UserProfile user, string owner, DateTime date, string time, int count)
           : base( owner, date, time )
        {
            this._count = count;
            this._user = user;
            //this._restaurant = restaurant;
        }

        /*Metodos Get y Set del Usuario de la reserva*/
        public UserProfile User
        {
            get { return _user; }
            set { _user = value; }
        }

        /*Metodos Get y Set de la cantidad de personas de la reserva*/
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
