using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FOReserva.Models.Cruceros
{
    public class CReserva_Cruceros
    {
        private int _count;
        private UserProfile _user;

        /*Constructor Completo*/
        public CReserva_Cruceros (UserProfile user, string owner, DateTime date, string time, int count)
           //: base( owner, date, time )
        {
            this._count = count;
            this._user = user;
            //this._crucero = crucero;
        }

        /*Metodos Get y Set del Usuario de la Reserva*/
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