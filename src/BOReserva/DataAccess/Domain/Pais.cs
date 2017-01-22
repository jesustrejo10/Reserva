using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase para el manejo de los paises
    /// </summary>
    public class Pais : Entidad
    {
        public String _nombre { get; set; }
        public Dictionary<int, Entidad> _ciudades { get; set; }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="id">Id del pais</param>
        /// <param name="nombre">Nombre del pais</param>
        public Pais(int id, String nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }

        /// <summary>
        /// Contructor del pais
        /// </summary>
        /// <param name="id">Id del pais</param>
        /// <param name="nombre">Nombre del pais</param>
        /// <param name="ciudades">Lista de ciudades asociadas a el</param>
        public Pais(int id, String nombre, Dictionary<int,Entidad> ciudades)
        {
            this._id = id;
            this._nombre = nombre;
            this._ciudades = ciudades;
        }

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="reader">Recibe un SqlDataReader</param>
        public Pais(SqlDataReader reader)
        {
            try
            {
                int idPais = Int32.Parse(reader["id_pais"].ToString());
                String nombrePais = reader["nombre_pais"].ToString();
                this._id = idPais;
                this._nombre = nombrePais;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Pais() { }
    }
}