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
        public String _estadoReclamo { get; set; }

        public Reclamo() 
        {
        }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="tituloReclamo"></param>
        /// <param name="detalleReclamo"></param>
        /// <param name="fechaReclamo"></param>
        /// <param name="estadoReclamo"></param>
        public Reclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, String estadoReclamo)
        {           
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
        }
       
    }

}