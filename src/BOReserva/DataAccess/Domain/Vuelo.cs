using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Vuelo
    /// </summary>
    public class Vuelo : Entidad
    {
        #region Atributos

        private String _codigoVuelo;
        private int _ruta;
        private DateTime _fechaDespegue;
        private String _statusVuelo;
        private DateTime _fechaAterrizaje;
        private int _avion;

        #endregion

        #region Getters y Setters
        
        /// <summary>
        /// Get y Set del atributo _id
        /// </summary>
        public int IdVuelo
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// get y set del atributo _codigoVuelo
        /// </summary>
        public String CodigoVuelo
        {
            get { return _codigoVuelo; }
            set { _codigoVuelo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdRuta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        /// <summary>
        /// Get y Set del atributo _fechaDespegue
        /// </summary>
        public DateTime FechaDespegue
        {
            get { return _fechaDespegue; }
            set { _fechaDespegue = value; }
        }

        /// <summary>
        /// Get y Set del atributo _statusVuelo
        /// </summary>
        public String StatusVuelo
        {
            get { return _statusVuelo; }
            set { _statusVuelo = value; }
        }

        /// <summary>
        /// Get y Set del atributo _Avion
        /// </summary>
        public int IdAvion
        {
            get { return _avion; }
            set { _avion = value; }
        }

        /// <summary>
        /// Get y Set del atributo _fechaAterrizaje
        /// </summary>
        public DateTime FechaAterrizaje
        {
            get { return _fechaAterrizaje; }
            set { _fechaAterrizaje = value; }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase Vuelo vacia
        /// </summary>
        public Vuelo() { }

        /// <summary>
        /// Constructor de la clase Vuelo sin el atributo id
        /// </summary>
        /// <param name="codigoVuelo"></param>
        /// <param name="ruta"></param>
        /// <param name="fechaDespegue"></param>
        /// <param name="status"></param>
        /// <param name="fechaAterrizaje"></param>
        /// <param name="avion"></param>
        public Vuelo(String codigoVuelo, int ruta, DateTime fechaDespegue, 
                      String status, DateTime fechaAterrizaje, int avion)
        {
            _codigoVuelo = codigoVuelo;
            _ruta = ruta;
            _fechaDespegue = fechaDespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaAterrizaje;
            _avion = avion;
        }

        /// <summary>
        /// Constructor de la clase Vuelo con todos sus atributos inicializados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoVuelo"></param>
        /// <param name="ruta"></param>
        /// <param name="fechaDespegue"></param>
        /// <param name="status"></param>
        /// <param name="fechaAterrizaje"></param>
        /// <param name="avion"></param>
        public Vuelo(int id, String codigoVuelo, int ruta, DateTime fechaDespegue, 
            String status, DateTime fechaAterrizaje, int avion)
        {
            _id = id;
            _codigoVuelo = codigoVuelo;
            _ruta = ruta;
            _fechaDespegue = fechaDespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaAterrizaje;
            _avion = avion;
        }
        #endregion

    }
}