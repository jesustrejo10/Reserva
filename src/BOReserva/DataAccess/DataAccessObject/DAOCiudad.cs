using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOCiudad : DAO , IDAOCiudad
    {
        int IDAO.Agregar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        Domain.Entidad IDAO.Modificar(Domain.Entidad e)
        {
            throw new NotImplementedException();
        }

        Domain.Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

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

        public int obtenerIDciudad(String ciudad)
        {
            int id = 0;
            SqlConnection conexion = Conectar();
            conexion.Open();
            String sql = "select lug_id FROM Lugar  where lug_nombre = '"+ciudad+"';";
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
    }
}