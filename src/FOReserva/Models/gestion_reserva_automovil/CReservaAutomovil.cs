using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.gestion_reserva_automovil
{
    /// <summary>
    /// Clase del modelo de reserva de automoviles
    /// </summary>
    public class CReservaAutomovil: Entidad
    {
        #region Atributos        
        public string _fecha_ini  { get; set; }
        public string _fecha_fin { get; set; }
        public string _hora_ini { get; set; }
        public string _hora_fin { get; set; }
        public int _idUsuario { get; set; }
        public string _idAutomovil { get; set; }
        public int _idLugarOri { get; set; }
        public int _idLugarDest { get; set; }
        public int _estatus { get; set; }
        public List<CReservaAutomovil> _listaReservas { get; set; }
        public CAutomovil _auto { get; set; }
        public CLugar _LugarOri { get; set; }
        public CLugar _LugarDest { get; set; }


        #endregion

        #region Constructores
        public CReservaAutomovil() { }

        public CReservaAutomovil(int id, string fecha_ini, string fecha_fin, string horario_ini,
                                       string horario_fin, int idUsuario, string idAuto, int idOri, int idDest,
                                       int estatus)
        {
            this._id = id;
            this._fecha_ini = fecha_ini;
            this._fecha_fin = fecha_fin;
            this._hora_ini = horario_ini;
            this._hora_fin = horario_fin;
            this._idUsuario = idUsuario;
            this._idAutomovil = idAuto;
            this._idLugarOri = idOri;
            this._idLugarDest = idDest;
            this._estatus = estatus;
        }

        public CReservaAutomovil(string fecha_ini, string fecha_fin, string horario_ini,
                               string horario_fin, int idUsuario, string idAuto, int idOri, int idDest,
                               int estatus)
        {
            this._fecha_ini = fecha_ini;
            this._fecha_fin = fecha_fin;
            this._hora_ini = horario_ini;
            this._hora_fin = horario_fin;
            this._idUsuario = idUsuario;
            this._idAutomovil = idAuto;
            this._idLugarOri = idOri;
            this._idLugarDest = idDest;
            this._estatus = estatus;
        }

        public CReservaAutomovil(int id, string fecha_ini, string fecha_fin, string horario_ini,
                         string horario_fin, int idUsuario, int estatus, CAutomovil auto,
                         CLugar origen, CLugar destino)
        {
            this._id = id;
            this._fecha_ini = fecha_ini;
            this._fecha_fin = fecha_fin;
            this._hora_ini = horario_ini;
            this._hora_fin = horario_fin;
            this._idUsuario = idUsuario;
            this._LugarOri = origen;
            this._LugarDest = destino;
            this._estatus = estatus;
            this._auto = auto;
        }

        public CReservaAutomovil(string fecha_ini, string fecha_fin, string horario_ini,
                                 string horario_fin, int idUsuario, int estatus, CAutomovil auto,
                                 CLugar origen, CLugar destino)
        {
            this._fecha_ini = fecha_ini;
            this._fecha_fin = fecha_fin;
            this._hora_ini = horario_ini;
            this._hora_fin = horario_fin;
            this._idUsuario = idUsuario;
            this._LugarOri = origen;
            this._LugarDest = destino;
            this._estatus = estatus;
            this._auto = auto;
        }

        #endregion

    }
}