using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class MostrarRevision 
    {
        private DateTime _fecha;
        private string _mensaje;
        private int _tipo;
        private int _puntuacion;


        /// <summary>
        /// Builder Revision
        /// </summary>
        /// <param name="id">ID Base</param>
        /// <param name="name">Name Base</param>
        /// <param name="fecha">Fecha Revision</param>
        /// <param name="mensaje">Mensaje en Revision</param>
        /// <param name="tipo">Tipo Revision</param>
        /// <param name="puntuacion">Puntuacion de la Revision</param>
        /// <param name="positivo">Valoraciones positivos</param>
        /// <param name="negativo">Valoraciones negativas</param>        
        public MostrarRevision(DateTime fecha, string mensaje, int tipo, int puntuacion)
            
        {
            this._fecha = fecha;
            this._mensaje = mensaje;
            this._tipo = tipo;
            this._puntuacion = puntuacion;

        }

        /// <summary>
        /// Builder Revision Vacio
        /// </summary>
        public MostrarRevision() : base() { }

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