using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Vuelo : Entidad
    {
        #region Atributos

        
        private String _codigoVuelo { get; set; }
        private int _idRuta { get; set; }
        private DateTime _fechaDespegue { get; set; }
        private String _statusVuelo { get; set; }
        private DateTime _fechaAterrizaje { get; set; }
        private int _idAvion { get; set; }

        #endregion

        #region Getters y Setters
        /// <summary>
        /// Get y Set del atributo _id
        /// </summary>
        /// <returns>id del vuelo/returns>
        public int idVuelo
        {
            get { return _id; }
            set { _id = value; }
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
        /// <param name="idAvion"></param>
        public Vuelo(String codigoVuelo, int ruta, DateTime fechaDespegue, 
                      String status, DateTime fechaAterrizaje, int idAvion)
        {
            _codigoVuelo = codigoVuelo;
            _idRuta = ruta;
            _fechaDespegue = fechaDespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaAterrizaje;
            _idAvion = idAvion;
        }

        /// <summary>
        /// Constructor de la clase Vuelo con todos sus atributos inicializados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoVuelo"></param>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="fechaDespegue"></param>
        /// <param name="status"></param>
        /// <param name="fechaAterrizaje"></param>
        /// <param name="idAvion"></param>
        public Vuelo(int id, String codigoVuelo, int ruta, DateTime fechaDespegue, 
            String status, DateTime fechaAterrizaje, int idAvion)
        {
            _id = id;
            _codigoVuelo = codigoVuelo;
            _idRuta = ruta;
            _fechaDespegue = fechaDespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaAterrizaje;
            _idAvion = idAvion;
        }
        #endregion

    }
}