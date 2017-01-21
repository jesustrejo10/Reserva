using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{

    public class Reclamo : Entidad
    {
        public String _tituloReclamo { get; set; }
        public String _detalleReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public int _estadoReclamo { get; set; }
        public int _usuario { get; set; }
        public int _editable { get; set; }

        /// <summary>
        /// constructor de la clase sin parámetros
        /// </summary>
        public Reclamo() {}
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="tituloReclamo"></param>
        /// <param name="detalleReclamo"></param>
        /// <param name="fechaReclamo"></param>
        /// <param name="estadoReclamo"></param>
        public Reclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
        {           
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._usuario = usuario;
        }
        /// <summary>
        /// Constructor de la clase sin el atributo usuario que uso luego para modificar
        /// </summary>
        /// <param name="tituloReclamo"></param>
        /// <param name="detalleReclamo"></param>
        /// <param name="fechaReclamo"></param>
        /// <param name="estadoReclamo"></param>
        public Reclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo)
        {
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
        }
        /// <summary>
        /// Constructor de la clase sin el parámetro _editable
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tituloReclamo"></param>
        /// <param name="detalleReclamo"></param>
        /// <param name="fechaReclamo"></param>
        /// <param name="estadoReclamo"></param>
        /// <param name="usuario"></param>
        public Reclamo(int id, String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int usuario)
        {
            this._id = id;
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._usuario = usuario;
        }
       
       
    }

}