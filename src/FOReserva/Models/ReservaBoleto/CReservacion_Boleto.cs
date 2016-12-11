using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.ReservaBoleto
{
    public class CReservacion_Boleto : ReservationModels
    {
        private int _count;
        private UserProfile _user;
        private int _idUser;
        private string _codigo;
        private DateTime _fecha;
        private string _tipo;

        /*Constructor Completo*/
        public CReservacion_Boleto
           (UserProfile user, string owner, DateTime date, string time, int count, int idUser, string codigo, DateTime fecha, string tipo)
           : base( owner, date, time )
        {
            this._count = count;
            this._user = user;
            this._idUser = idUser;
            this.codigo = _codigo;
            this.fecha = _fecha;
            this.tipo = _tipo;
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

        public int IdUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }
        public string codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

    }
}
