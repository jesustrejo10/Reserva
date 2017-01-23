using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Pais : Entidad
    {
        public String _nombre { get; set; }
        public Dictionary<int, Entidad> _ciudades { get; set; }

        public Pais(int id, String nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }

        public Pais(int id, String nombre, Dictionary<int,Entidad> ciudades)
        {
            this._id = id;
            this._nombre = nombre;
            this._ciudades = ciudades;
        }


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
        
        public Pais() { }
    }
}