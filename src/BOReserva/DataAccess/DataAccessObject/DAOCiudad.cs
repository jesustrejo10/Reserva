using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase para el manejo de las ciudades en la BD
    /// </summary>
    public class DAOCiudad : DAO , IDAOCiudad
    {
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        int IDAO.Agregar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        Domain.Entidad IDAO.Modificar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        Domain.Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar todas las ciudad
        /// </summary>
        /// <returns>Retorna un listado de ciudades</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaCiudades = new Dictionary<int, Entidad>();
            int id;
            String nombre;
            int fk;
            SqlConnection conexion = Conectar();
            conexion.Open();
            String sql = "select c.lug_id as id, c.lug_nombre as name , c.lug_FK_lugar_id as pais FROM Lugar c where c.lug_tipo_lugar = 'ciudad';";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = int.Parse(reader[0].ToString());
                    nombre = reader[1].ToString();
                    fk = int.Parse(reader[2].ToString());
                    Entidad ciudad = FabricaEntidad.InstanciarCiudad(id, nombre,fk);
                    listaCiudades.Add(id, ciudad);
                }
            }
            cmd.Dispose();
            conexion.Close();
            return listaCiudades;
        }

        /// <summary>
        /// Metodo usado para obtener el ID de una ciudad
        /// </summary>
        /// <param name="ciudad">Ciudad a buscar</param>
        /// <returns>Retorna un _idHotel entero</returns>

        public int obtenerIDciudad(String ciudad)
        {
            try
            {
                int id = 0;
                SqlConnection conexion = Conectar();
                conexion.Open();
                String sql = "select lug_id FROM Lugar  where lug_nombre = '" + ciudad + "';";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = int.Parse(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return id;
            }
            catch (SqlException ex)
            {
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }
    }


}