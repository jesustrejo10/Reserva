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

        Entidad IDAO.Consultar(int id)
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
            DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123);
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
                       
                        oferta =  FabricaEntidad.InstanciarOferta(reader["idOferta"].ToString(), reader["nombreOferta"].ToString(), 
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
                conexion.Close();
                return null;
            }
        }
    }
        
}