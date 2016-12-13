using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Autos
{
    public class CReserva_Autos_Perfil : ReservationModels
    {
        private int _idReserva;
        private string _fechaIni;
        private string _fechaFin;
        private string _ciudadOri;
        private string _ciudadDes;
        private int _status;
        private int _idUsuario;
        private int _cuenta;
        private int _idAutos;
        private CBusquedaModel _autos;

        /*Constructor Completo*/
        public CReserva_Autos_Perfil(string owner, string date, string time, int idReserva, string fechaIni, string fechaFin, string ciudadOri, string ciudadDes, int status, int cuenta, int idUsuario, int idAutos)
            : base( owner, date, time )
        {
            this._idReserva = idReserva;
            this._fechaIni = fechaIni;
            this._fechaFin = fechaFin;
            this._ciudadOri = ciudadOri;
            this._ciudadDes = ciudadDes;
            this._status = status;
            this._cuenta = cuenta;
            this._idUsuario = idUsuario;
            this._idAutos = idAutos;
        }

        /*Constructor Vacio*/
        public CReserva_Autos_Perfil() : base() { }

        public int IdReserva
        {
            get { return _idReserva; }
            set { _idReserva = value; }
        }

        public string FechaIni
        {
            get { return _fechaIni; }
            set { _fechaIni = value; }
        }

        public string FechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }

        public string CiudadOri
        {
            get { return _ciudadOri; }
            set { _ciudadOri = value; }
        }

        public string CiudadDes
        {
            get { return _ciudadDes; }
            set { _ciudadDes = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /*Metodos Get y Set de persona de la reserva*/
        public int cuenta
        {
            get { return _cuenta; }
            set { _cuenta = value; }
        }

        /*Id del usuario que se encuentra logeado*/
        public int IdUsuario
        {
            get { return IdUsuario; }
            set { IdUsuario = value; }
        }

        public int IdAutos
        {
            get { return IdAutos; }
            set { IdAutos = value; }
        }

        /*
         * Autos de la reserva
         */
        public CBusquedaModel Autos
        {
            get { return _autos; }
            set { _autos = value; }
        }

    }
}