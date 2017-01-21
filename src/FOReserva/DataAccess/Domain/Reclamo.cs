using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Reclamo: Entidad
    {
        public int _idReclamo { get; set; }
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public int _estadoReclamo { get; set; }
        public int _usuarioReclamo{get; set;}
        public Reclamo(int id, String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int _usuarioReclamo)
        {
            this._idReclamo = id;
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
        }

        public Reclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int _usuarioReclamo)
        {
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._usuarioReclamo = _usuarioReclamo;
        }
    }
}