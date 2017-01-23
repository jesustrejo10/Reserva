using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public enum EnumTipoRevision { Restaurante = 1, Hotel = 2 };

    public class Revision : Entidad
    {
        private decimal _estrellas;
        private string _mensaje;
        private int _tipo;
        private DateTime _fecha;        

        private Entidad _referencia;
        private Entidad _propietario;        

        /// <summary>
        /// Builder Revision
        /// </summary>
        /// <param name="id">ID Base</param>
        public Revision(int id)
            : base(id)
        {
        }

        /// <summary>
        /// Builder Revision
        /// </summary>
        /// <param name="id">ID Base</param>
        /// <param name="name">Name Base</param>
        /// <param name="fecha">Fecha Revision</param>
        /// <param name="mensaje">Mensaje en Revision</param>
        /// <param name="estrellas">Puntuacion de la Revision</param>
        /// <param name="positivo">Valoraciones positivos</param>
        /// <param name="negativo">Valoraciones negativas</param>
        /// <param name="tipo">Tipo Revision</param>
        public Revision(int id, string name, DateTime fecha, string mensaje, decimal estrellas, int tipo)
            : base(id)
        {
            this._fecha = fecha;
            this._mensaje = mensaje;
            this._estrellas = estrellas;
            this._tipo = tipo;
            //this._valoracion = new RevisionValoracion(0, 0);
        }


        /// <summary>
        /// Builder Revision Vacio
        /// </summary>
        public Revision() : base(){ }

        /// <summary>
        /// Permite obtener y indicar el Id de la instancia.
        /// </summary>
        public int Id {
            get { return this._id; }
            set { _id = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Fecha de la instancia.
        /// </summary>
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Mensaje de la instancia.
        /// </summary>
        public string Mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Puntuacion de la instancia.
        /// </summary>
        public decimal Estrellas
        {
            get { return _estrellas; }
            set { _estrellas = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Usuario de la instancia.
        /// </summary>
        public Entidad Propietario
        {
            get { return _propietario; }
            set { _propietario = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Referencia de la instancia.
        /// </summary>
        public Entidad Referencia
        {
            get { return _referencia; }
            set { _referencia = value; }
        }

        /// <summary>
        /// Permite obtener y indicar el Tipo de la instancia.
        /// </summary>
        public EnumTipoRevision Tipo
        {
            get { return (EnumTipoRevision)_tipo; }
            set { _tipo = (int)value; }
        }
    }
}