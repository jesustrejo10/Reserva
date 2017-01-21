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
        public int _idRuta { get; set; }
        public int _distancia { get; set; }
        public String _status { get; set; }
        public String _tipo { get; set; }
        public String _origenRuta { get; set; }
        public String _destinoRuta { get; set; }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase Ruta vacio
        /// </summary>
        public Ruta() { }

        /// <summary>
        /// Constructor de la clase Ruta sin el atributo id
        /// </summary>
        /// <param name="origenRuta"></param>
        /// <param name="destinoRuta"></param>
        /// <param name="tipo"></param>
        /// <param name="status"></param>
        /// <param name="distacia"></param>
        public Ruta(int idRuta, int distancia,String status,String tipo,String origenRuta, String destinoRuta)
        {
            _idRuta = idRuta;
            _origenRuta = origenRuta;
            _destinoRuta = destinoRuta;
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
        public Ruta(String origenRuta, String destinoRuta, String tipo,
                    String status, int distancia, int idRuta)
        {
            _origenRuta = origenRuta;
            _destinoRuta = destinoRuta;
            _tipo = tipo;
            _status = status;
            _distancia = distancia;
            _idRuta = idRuta;
        }
        #endregion


    }
}