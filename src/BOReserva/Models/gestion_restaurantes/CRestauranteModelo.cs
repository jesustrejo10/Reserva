using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_restaurantes
{
    /// <summary>
    /// Clase del modelo de restaurantes.
    /// </summary>
    public class CRestauranteModelo: Entidad
    {
        #region Atributos
        private int _id;
        private int _idLugar;
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private string _descripcion;
        private string _horarioApertura;
        private string _horarioCierre;
        private List<CRestauranteModelo> _listaRestaurantes;
        #endregion

        #region Constructores
        public CRestauranteModelo() { }

        public CRestauranteModelo(string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            this._nombre = nombre;
            this._direccion = direccion;
            this._telefono = telefono;
            this._descripcion = descripcion;
            this._horarioApertura = horarioApertura;
            this._horarioCierre = horarioCierre;
            this._idLugar = idLugar;
        }

        public CRestauranteModelo(int id, string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            this.Id = id;
            this._nombre = nombre;
            this._direccion = direccion;
            this._telefono = telefono;
            this._descripcion = descripcion;
            this._horarioApertura = horarioApertura;
            this._horarioCierre = horarioCierre;
            this._idLugar = idLugar;
        }
        #endregion

        #region Get y Set
        public int id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public int idLugar
        {
            get { return this._idLugar; }
            set { this._idLugar = value; }
        }

        public String nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }


        public String direccion
        {
            get { return this._direccion; }
            set { this._direccion = value; }
        }

        public String descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }

        public String horarioApertura
        {
            get { return this._horarioApertura; }
            set { this._horarioApertura = value; }
        }

        public String horarioCierre
        {
            get { return this._horarioCierre; }
            set { this._horarioCierre = value; }
        }

        public string Telefono
        {
            get { return this._telefono; }
            set { this._telefono = value; }
        }
        
        public List<CRestauranteModelo> listaRestaurantes
        {
            get
            {
                return _listaRestaurantes;
            }

            set
            {
                _listaRestaurantes = value;
            }
        }
        #endregion

    }
}