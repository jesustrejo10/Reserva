using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOReclamo : DAO, IDAOReclamo
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOReclamo() {}

        /// <summary>
        /// Metodo para hacer el insert de un reclamo en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        int IDAO.Agregar(Entidad e)
        {
            Reclamo reclamo = (Reclamo)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Reclamo " +
                             "(rec_titulo, rec_descripcion, rec_fecha, rec_estatus , rec_fk_usuario) " +
                              "VALUES ('" + reclamo._tituloReclamo + "','" + reclamo._detalleReclamo + "','" + reclamo._fechaReclamo + "'," +
                              "1," + reclamo._usuario + ");";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 5;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }
        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

      

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<Reclamo> listareclamos = new List<Reclamo>();
            Dictionary<int, Entidad> listaReclamos = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "SELECT * FROM reclamo";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int idReclamo;
                    String tituloReclamo;
                    String detalleReclamo;
                    String fechaReclamo;
                    int estadoReclamo;
                    int editable;
                    int usuario;
                  
                    while (reader.Read())
                    {
                        idReclamo = Int32.Parse(reader["rec_id"].ToString());
                        tituloReclamo = reader["rec_titulo"].ToString();
                        detalleReclamo = reader["rec_descripcion"].ToString();
                        fechaReclamo = reader["rec_fecha"].ToString();
                        estadoReclamo = Int32.Parse(reader["rec_estatus"].ToString());
                        usuario = Int32.Parse(reader["rec_fk_usuario"].ToString());
                        String[] divisor = fechaReclamo.Split(' '); //recortamos la fecha

                        Entidad reclamoE = FabricaEntidad.InstanciarReclamo(idReclamo, tituloReclamo, detalleReclamo, divisor[0], estadoReclamo, usuario);
                        Reclamo reclamo = (Reclamo)reclamoE;
                        listaReclamos.Add(idReclamo, reclamo);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaReclamos;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }
      
    }

}