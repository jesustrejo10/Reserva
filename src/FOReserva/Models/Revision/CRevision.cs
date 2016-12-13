using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    /// <summary>
    /// Clase Revision
    /// </summary>
    public class CRevision : BaseEntity
    {        
        private int _puntuacion;
        private string _mensaje;
        private int _tipo;
        private DateTime _fecha;
        private CRevisionValoracion _valoracion;

        /// <summary>
        /// Builder Revision
        /// </summary>
        /// <param name="id">ID Base</param>
        /// <param name="name">Name Base</param>
        /// <param name="fecha">Fecha Revision</param>
        /// <param name="mensaje">Mensaje en Revision</param>
        /// <param name="puntuacion">Puntuacion de la Revision</param>
        /// <param name="positivo">Valoraciones positivos</param>
        /// <param name="negativo">Valoraciones negativas</param>
        /// <param name="tipo">Tipo Revision</param>
        public CRevision(int id, string name, DateTime fecha, string mensaje, int puntuacion, int tipo)
            : base(id, name)
        {
             this._fecha = fecha;
             this._mensaje = mensaje;
             this._puntuacion = puntuacion;
             this._tipo = tipo;
             this._valoracion = new CRevisionValoracion(0,0);
        }

        /// <summary>
        /// Builder Revision Vacio
        /// </summary>
        public CRevision() : base(){}

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }
        public int Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; }
        }
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}