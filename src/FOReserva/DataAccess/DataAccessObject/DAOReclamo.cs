using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;

using FOReserva.DataAccess.DataAccessObject.Common;

using FOReserva.DataAccess.DataAccessObject;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FOReserva.DataAccess.DataAccessObject
{
    public class DAOReclamo : DAO, IDAOReclamo
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOReclamo(){}

        /// <summary>
        /// Metodo para guardar un reclamo en la BD
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
                              "1," + reclamo._usuarioReclamo + ");";


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

        public List<Reclamo> ConsultarReclamosPorUsuario(int _idUsuario)
        {
            List<Reclamo> reclamos = FabricaEntidad.instanciarListaReclamo();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "SELECT * FROM reclamo where rec_fk_usuario = "+ _idUsuario;
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
                        reclamos.Add(reclamo);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return reclamos;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            return reclamos;
        }

        /// <summary>
        /// Metodo para eliminar un reclamo en la BD
        /// </summary>
        /// <param name="_idReclamo">id del reclamo que será eliminado</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        public int EliminarReclamo(int _idReclamo)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "DELETE FROM RECLAMO WHERE rec_id = "+ _idReclamo;
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

        public int ModificarReclamo(Reclamo reclamo)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "UPDATE RECLAMO SET rec_titulo='"+reclamo._tituloReclamo+"', rec_descripcion='"+reclamo._detalleReclamo+"', rec_fecha='"+reclamo._fechaReclamo+"' WHERE rec_id="+reclamo._idReclamo;
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


        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        public Entidad Consultar(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Entidad reclamoE = FabricaEntidad.InstanciarReclamo();
            Reclamo reclamo = (Reclamo)reclamoE;
            try
            {
                conexion.Open();
                String sql = "SELECT * FROM Reclamo WHERE rec_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reclamo._id = Int32.Parse(reader["rec_id"].ToString());
                        reclamo._tituloReclamo = reader["rec_titulo"].ToString();
                        reclamo._detalleReclamo = reader["rec_descripcion"].ToString();
                        String[] divisor = reader["rec_fecha"].ToString().Split(' '); //recortamos la fecha
                        reclamo._fechaReclamo = divisor[0];
                        reclamo._estadoReclamo = Int32.Parse(reader["rec_estatus"].ToString());
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return reclamo;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }


    }
}