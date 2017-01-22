using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Models.gestion_ofertas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M11
{
    public class DAOOferta : DAO, IDAOOferta
    {
        public DAOOferta() { }

        /// <summary>
        /// Agregar Oferta a la BAse de Datos
        /// </summary>
        /// <param name="e">Entidad del tipo oferta</param>
        /// <returns></returns>
        int IDAO.Agregar(Entidad e)
        {
            Oferta oferta = (Oferta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            Debug.WriteLine("FECHAA" + oferta._fechaIniOferta);
            string fecha = oferta._fechaIniOferta.ToString("dd-MM-yyyy");
            Debug.WriteLine("FECHAA " + fecha);
            try
            {
                conexion.Open();
                String querySql = "INSERT INTO Oferta VALUES ('"
                                  + oferta._nombreOferta + "','" + oferta._fechaIniOferta.ToString("MM-dd-yyyy")
                                  + "', '" + oferta._fechaFinOferta.ToString("MM-dd-yyyy") + "',"
                                  + oferta._porcentajeOferta + ",'" + oferta._estadoOferta + "');";
                Debug.WriteLine(querySql);
                SqlCommand cmd = new SqlCommand(querySql, conexion);
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

        /// <summary>
        /// Metodo implementado de IDAO para consultar los ofertas de la BD
        /// </summary>
        /// <returns>Retorna el listado de hoteles</returns>
        List<Entidad> IDAOOferta.ConsultarTodos()
        {
            Debug.WriteLine("LLEGÓ A DAO OFERTA");

            List<Entidad> listaOfertas = FabricaEntidad.asignarListaDeEntidades();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Entidad oferta;

            try
            {
                conexion.Open();                                
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ConsultarOfertas]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                Debug.WriteLine("HIZO CONEXIÓN");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Debug.WriteLine("CMD.READER");

                    while (reader.Read())
                    {

                        var fechaInivar = reader["fechaIn"];
                        var fechaFinvar = reader["fechaFin"];
                        var estadovar = reader["estado"];

                        DateTime fechaInicio = Convert.ToDateTime(fechaInivar).Date;
                        DateTime fechaFin = Convert.ToDateTime(fechaFinvar).Date;
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);

                        List<String> listaPaquetes = new List<String>();

                       // listaPaquetes = MBuscarNombrePaquetesDeOferta(Int32.Parse(reader["ofe_id"].ToString()));
                       
                        oferta =  FabricaEntidad.InstanciarOferta(Int32.Parse(reader["idOferta"].ToString()), reader["nombreOferta"].ToString(), 
                                                                  listaPaquetes, float.Parse(reader["porcentaje"].ToString()),
                                                                  fechaInicio, fechaFin, disponibilidad);
                        listaOfertas.Add(oferta);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaOfertas;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return null;
            }
        }

        /// <summary>
        /// Procedimiento que consulta el detalle de una oferta en la base de datos
        /// </summary>
        /// <param name="id">Id de la oferta</param>
        /// <returns>Una entidad del tipo oferta</returns>
        Entidad IDAO.Consultar(int id)
        {
            Debug.WriteLine("LLEGÓ A DAO CONSULTAROFERTA");
            SqlConnection conexion = Connection.getInstance(_connexionString);
            Entidad oferta = null;
            Int32 _id;
            _id = id;
                       
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("[dbo].[M11_ConsultarOferta]", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                Debug.WriteLine("HIZO CONEXIÓN EN VISUAL");

                Debug.WriteLine(id);
                Debug.WriteLine(_id);

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@ofer_id";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = id;
                
                //SqlCmd.Parameters.Add(ParNombre);
                cmd.Parameters.Add(ParId);

                Debug.WriteLine("HIZO LA PARTED E PARÁMETRO");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Debug.WriteLine("CMD.READER EN CONSULTAR");
                    while (reader.Read())
                    {
                        var fechaInivar = reader["fechaIn"];
                        var fechaFinvar = reader["fechaFin"];
                        var estadovar = reader["estado"];

                        DateTime fechaInicio = Convert.ToDateTime(fechaInivar).Date;
                        DateTime fechaFin = Convert.ToDateTime(fechaFinvar).Date;
                        Boolean disponibilidad = Convert.ToBoolean(estadovar);

                        Debug.WriteLine("FECHAINI" + fechaInicio);

                        List<String> listaPaquetes = new List<String>();

                      //  listaPaquetes = MBuscarNombrePaquetesDeOferta(Int32.Parse(reader["ofe_ID"].ToString()));

                        oferta = FabricaEntidad.InstanciarOferta(Int32.Parse(reader["idOferta"].ToString()), reader["nombreOferta"].ToString(),
                                                                  listaPaquetes, float.Parse(reader["porcentaje"].ToString()),
                                                                  fechaInicio, fechaFin, disponibilidad);
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return oferta;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        public String eliminarOferta(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "DELETE FROM Oferta WHERE hot_id = " + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return ex.Message;
            }
        }

        string IDAOOferta.disponibilidadOferta(Entidad e, int disponibilidad) 
        {
            Oferta oferta = (Oferta)e;
            int  ofertaId = oferta._idOferta;
            SqlConnection conexion = new SqlConnection(_connexionString);
            try
            {           
                conexion.Open();
                SqlCommand query = conexion.CreateCommand();
                query.CommandText = "UPDATE Oferta SET ofe_estado = disponibilidad WHERE ofe_id=" + ofertaId;
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();
                SqlCommand query1 = conexion.CreateCommand();
                query1.CommandText = "UPDATE Paquete SET paq_fk_oferta = null WHERE paq_fk_oferta=" + ofertaId;
                SqlDataReader lector1 = query1.ExecuteReader();
                lector1.Close();
                conexion.Close();
                return "1";
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Entre en excepcion sql de IDAOOferta");
                conexion.Close();
                return ex.Message;
                
            }
            
        }
        
    }
        
}