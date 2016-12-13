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
        private string _descripcion;
        private string _tipo;
        private DateTime _fecha;
        private CRevisionValoracion _valoracion;

        /// <summary>
        /// Builder Revision
        /// </summary>
        /// <param name="id">ID Base</param>
        /// <param name="name">Name Base</param>
        /// <param name="fecha">Fecha Revision</param>
        /// <param name="descripcion">Mensaje en Revision</param>
        /// <param name="puntuacion">Puntuacion de la Revision</param>
        /// <param name="positivo">Valoraciones positivos</param>
        /// <param name="negativo">Valoraciones negativas</param>
        /// <param name="tipo">Tipo Revision</param>
        public CRevision(int id, string name, DateTime fecha, string descripcion, int puntuacion, int positivo, int negativo, string tipo)
            : base(id, name)
        {
             this._fecha = fecha;
             this._descripcion = descripcion;
             this._puntuacion = puntuacion;
             this._tipo = tipo;
             this._valoracion = new CRevisionValoracion(positivo, negativo);
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
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int Puntuacion
        {
            get { return _puntuacion; }
            set { _puntuacion = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}