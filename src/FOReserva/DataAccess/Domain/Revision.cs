using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Revision : Entidad
    {
        private int _puntuacion;
        private string _mensaje;
        private int _tipo;
        private DateTime _fecha;
        //private RevisionValoracion _valoracion;

        private Entidad _referencia;
        private Entidad _usuario;

        public enum TipoRevision { Restaurante = 1, Hotel = 2 };

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
        public Revision(int id, string name, DateTime fecha, string mensaje, int puntuacion, int tipo)
            : base(id)
        {
            this._fecha = fecha;
            this._mensaje = mensaje;
            this._puntuacion = puntuacion;
            this._tipo = tipo;
            //this._valoracion = new RevisionValoracion(0, 0);
        }

        /// <summary>
        /// Builder Revision Vacio
        /// </summary>
        public Revision() : base(){ }

        public int Id {
            get { return this._id; }
            set { _id = value; }
        }

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

        public Entidad Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public Entidad Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }

        public TipoRevision Tipo
        {
            get { return (TipoRevision)_tipo; }
            set { _tipo = (int)value; }
        }
    }
}