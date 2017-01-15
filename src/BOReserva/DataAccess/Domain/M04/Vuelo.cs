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
        private String _ciudadOrigen { get; set; }
        private String _ciudadDestino { get; set; }
        private String _fechaDespegue { get; set; }
        private String _statusVuelo { get; set; }
        private String _fechaAterrizaje { get; set; }
        private String _matriculaAvion { get; set; }

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
        /// Constructor de la clase Vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="codigoVuelo"></param>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="fechaDespegue"></param>
        /// <param name="status"></param>
        /// <param name="fechaAterrizaje"></param>
        /// <param name="matriculaAvion"></param>
        public Vuelo(int id, String codigoVuelo, String ciudadOrigen, String ciudadDestino, String fechaDespegue, 
            String status, String fechaAterrizaje, String matriculaAvion)
        {
            _id = id;
            _codigoVuelo = codigoVuelo;
            _ciudadOrigen = ciudadOrigen;
            _ciudadDestino = ciudadDestino;
            _fechaDespegue = fechaDespegue;
            _statusVuelo = status;
            _fechaAterrizaje = fechaAterrizaje;
            _matriculaAvion = matriculaAvion;
        }
        #endregion

    }
}