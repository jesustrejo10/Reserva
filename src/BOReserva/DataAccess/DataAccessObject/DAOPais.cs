using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase para el manejo de lo relacionado de los paises en la BD
    /// </summary>
    public class DAOPais : DAO , IDAOPais
    {
        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        int IDAO.Agregar(Domain.Entidad e)
        {
            //no aplica
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
            //no aplica

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
        /// Metodo para consultar todos los paises
        /// </summary>
        /// <returns>Retorna un listado de paises</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaPaises = new Dictionary<int, Entidad>();
            int id;
            String nombre;
            SqlConnection conexion = Conectar();
            conexion.Open();
            String sql = "select p.lug_id as id, p.lug_nombre as name FROM Lugar p where p.lug_tipo_lugar = 'pais';";
            SqlCommand cmd = new SqlCommand(sql, conexion);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = int.Parse(reader[0].ToString());
                    nombre = reader[1].ToString();
                    Entidad pais = FabricaEntidad.InstanciarPais(id, nombre);
                    listaPaises.Add(id,pais);
                }
            }
            cmd.Dispose();
            conexion.Close();
            return listaPaises;
        }

    }
}