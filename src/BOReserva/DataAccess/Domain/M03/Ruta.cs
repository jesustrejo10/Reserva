using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain.M03
{
    public class Ruta : Entidad
    {

        /// <summary>
        /// Declaracion de atributos
        /// </summary>
        #region Atributos
        private int _idRuta { get; set; }
        private int _distancia { get; set; }
        private String _status { get; set; }
        private String _tipo { get; set; }
        private int _idOrigen { get; set; }
        private int _idDestino { get; set; }

        #endregion

         #region Constructores

        /// <summary>
        /// Constructor de la clase Ruta vacio
        /// </summary>
        public Ruta() { }

        /// <summary>
        /// Constructor de la clase Ruta sin el atributo id
        /// </summary>
        /// <param name="idOrigen"></param>
        /// <param name="idDestino"></param>
        /// <param name="tipo"></param>
        /// <param name="status"></param>
        /// <param name="distacia"></param>
        public Ruta(int idOrigen, int idDestino, String tipo, 
                    String status, int distancia)
        {
            _idOrigen = idOrigen;
            _idDestino = idDestino;
            _tipo= tipo;
            _status = status;
            _distancia = distancia;
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
        public Ruta(int idOrigen, int idDestino, String tipo,
                    String status, int distancia, int idRuta)
        {
            _idOrigen = idOrigen;
            _idDestino = idDestino;
            _tipo = tipo;
            _status = status;
            _distancia = distancia;
            _idRuta = idRuta;
        }
        #endregion


    }
}