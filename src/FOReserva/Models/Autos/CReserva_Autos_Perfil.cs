using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Autos
{
    public class CReserva_Autos_Perfil : ReservationModels
    {
       //private int _idReserva;
        private string _fechaIni;
        private string _fechaFin;
        private string _horaini;
        private string _horafin;
        private string _ciudadOri;
        private string _ciudadDes;
        private int _status;
      //  private int _idUsuario;
        private CBusquedaModel _autos;

        /*Constructor Completo*/
        public CReserva_Autos_Perfil(string owner, string date, string time, string fechaIni, string fechaFin,
            string horaIni, string horaFin, string ciudadOri, string ciudadDes, int status)
            : base( owner, date, time )
        {
            //this._idReserva = idReserva;
            this._fechaIni = fechaIni;
            this._fechaFin = fechaFin;
            this._horaini = horaIni;
            this._horafin = horaFin;
            this._ciudadOri = ciudadOri;
            this._ciudadDes = ciudadDes;
            this._status = status;
           // this._idUsuario = idUsuario;
        }

        /*Constructor Vacio*/
        public CReserva_Autos_Perfil() : base() { }

        //public int IdReserva
        //{
        //    get { return _idReserva; }
        //    set { _idReserva = value; }
        //}

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

        public string HoraIni
        {
            get { return _horaini; }
            set { _horaini = value; }
        }

        public string HoraFin
        {
            get { return _horafin; }
            set { _horafin = value; }
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

        /*Id del usuario que se encuentra logeado*/
        //public int IdUsuario
        //{
        //    get { return IdUsuario; }
        //    set { IdUsuario = value; }
        //}

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