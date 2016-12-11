using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    /// <summary>
    /// Clase donde se realiza el acceso de datos para los vehículos
    /// </summary>
    public class DAOAutomovil
    {
        private String connetionString ="Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;Persist Security Info=True;User ID=DB_A1380A_reserva_admin;Password=ucabds1617a"; //de esta forma el string de conexion se encuentra es en el web.config 
        //private static String connetionString = ConfigurationManager.ConnectionStrings["DB_A1380A_reserva"].ConnectionString; //de esta forma el string de conexion se encuentra es en el web.config 
        
        private SqlConnection con = null;



        /// <summary>
        /// Método que agrega un vehículo a la base de datos
        /// </summary>
        /// <param name="vehiculo">Vehículo a agregar a la base de datos</param>
        /// <param name="id">El id de la ciudad a donde será agregado</param>
        /// <returns>Retorna 1 si se agregó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MAgregarVehiculoBD(Automovil vehiculo, int id)
        {
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "INSERT INTO Automovil VALUES ('"+vehiculo._matricula+"', '"+vehiculo._modelo+"', '"+vehiculo._fabricante+"', "+vehiculo._anio+", "+vehiculo._kilometraje+", "+vehiculo._cantpasajeros+", '"+vehiculo._tipovehiculo+
                    "', " + vehiculo._preciocompra + ", " + vehiculo._precioalquiler + ", " + vehiculo._penalidaddiaria + ", '" + vehiculo._fecharegistro + "', '" + vehiculo._color + "', "+ 1 +", '"+vehiculo._transmision+"', "+ id +")";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("ENTRO EN EL CATCH");
                Debug.WriteLine(ex.ToString());
                con.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método que modifica un vehículo existente de la base de datos
        /// </summary>
        /// <param name="vehiculo">Vehículo a modificar de la base de datos</param>
        /// <param name="id">El id de la ciudad a donde se ubica</param>
        /// <returns>Retorna 1 si se modificó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MModificarVehiculoBD(Automovil vehiculo, int id)
        {
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "UPDATE Automovil SET aut_modelo ='" + vehiculo._modelo + "', aut_fabricante = '" + vehiculo._fabricante + "', aut_anio = " + vehiculo._anio + ", aut_kilometraje = " + vehiculo._kilometraje + ", aut_cantpasajeros = " + vehiculo._cantpasajeros + ", aut_tipovehiculo = '" + vehiculo._tipovehiculo +
                    "', aut_preciocompra = " + vehiculo._preciocompra + ", aut_precioalquiler = " + vehiculo._precioalquiler + ", aut_penalidaddiaria = " + vehiculo._penalidaddiaria + ", aut_fecharegistro = '" + vehiculo._fecharegistro + "', aut_color = '" + vehiculo._color + "', aut_transmision = '" + vehiculo._transmision + "', aut_fk_ciudad = " + id + 
                    " WHERE aut_matricula = '"+vehiculo._matricula+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                con.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método que lista todos los vehículos de la base de datos
        /// </summary>
        /// <returns>Retorna una lista de tipo Automovil</returns>
        public List<Automovil> MListarvehiculosBD()
        {
            List<Automovil> listavehiculos = new List<Automovil>();
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT * FROM Automovil";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                   while (reader.Read()) {
                       //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                       //Y  SE AGREGA a listavehiculos
                       var fecha = reader["aut_fecharegistro"];
                       DateTime fecharegistro = Convert.ToDateTime(fecha).Date;
                       Automovil vehiculo = new Automovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                              Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(),
                                              double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                              double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                              double.Parse(reader["aut_penalidaddiaria"].ToString()), fecharegistro ,
                                              reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()), reader["aut_transmision"].ToString(),
                                              MBuscarnombreciudadBD(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombrePaisBD(Int32.Parse(reader["aut_fk_ciudad"].ToString()))
                                              );
                       listavehiculos.Add(vehiculo);
                   }
                }
                cmd.Dispose();
                con.Close();
                return listavehiculos;
            }
            catch (SqlException ex)
            {
                con.Close();
                return null;
            }
        }


        /// <summary>
        /// Método para buscar un vehículo en particular de la base de datos
        /// </summary>
        /// <param name="matricula">La matrícula del vehículo a buscar</param>
        /// <returns>Retorna un objeto de tipo Automovil</returns>
        public Automovil MMostrarvehiculoBD(String matricula)
        {
            Automovil vehiculo = null;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT * FROM Automovil WHERE aut_matricula = '" + matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["aut_fecharegistro"];
                        DateTime fecharegistro = Convert.ToDateTime(fecha).Date;
                        vehiculo = new Automovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                                 Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(),
                                                 double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                                 double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                                 double.Parse(reader["aut_penalidaddiaria"].ToString()), fecharegistro,
                                                 reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()), reader["aut_transmision"].ToString(),
                                                 MBuscarnombreciudadBD(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombrePaisBD(Int32.Parse(reader["aut_fk_ciudad"].ToString()))
                                                 );
                    }
                    cmd.Dispose();
                    con.Close();
                    return vehiculo;
                }
            }
            catch (SqlException ex)
            {
                con.Close();
                return null;
            }
            }


        /// <summary>
        /// Método que busca en la base de datos el identificador de una ciudad
        /// </summary>
        /// <param name="ciudad">Ciudad cuyo identificador se desea conocer</param>
        /// <param name="pais">País en donde se ubica la ciudad</param>
        /// <returns>Retorna el identificador de la ciudad</returns>
        public int MBuscaridciudadBD (String ciudad, String pais)
        {
            int id_ciudad = 12;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT d.lug_id FROM LUGAR C, LUGAR D WHERE C.lug_id = d.lug_FK_lugar_id AND C.lug_nombre = '"+pais+"' and D.lug_nombre = '"+ciudad+"'"; /*ESTE SQL ES EN CASO DE QUE NO SE MANEJE AL FINAL ESTADOS SINO SOLO PAISES Y CIUDADES*/
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id_ciudad = Int32.Parse(reader[0].ToString()); 
                    }   
                }
                cmd.Dispose();
                con.Close();
                return id_ciudad;
            }
            catch (SqlException ex)
            {
                con.Close();
                return id_ciudad;
            }
        }



        /// <summary>
        /// Método para borrar un vehículo de la base de datos
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo a borrar</param>
        /// <returns>Retorna 1 si se eliminó exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MBorrarvehiculoBD(String matricula)
        {
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "DELETE FROM Automovil WHERE aut_matricula = '"+matricula+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                con.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método para buscar el nombre de una ciudad en la base de datos
        /// </summary>
        /// <param name="id">Identificador de la ciudad a buscar</param>
        /// <returns>Retorna el nombre de la ciudad</returns>
        public String MBuscarnombreciudadBD(int id)
        {
            String _ciudad = "Error al buscar";
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'"; ;
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                con.Close();
                return _ciudad;
            }
        }



        /// <summary>
        /// Método para buscar el nombre de un país
        /// </summary>
        /// <param name="ciudad">Identificador de la ciudad que pertenece a dicho país</param>
        /// <returns>Retorna el nombre de la ciudad</returns>
        public String MBuscarnombrePaisBD(int ciudad) 
        {
            String _lugar = "Error al buscar";
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT E.lug_nombre FROM LUGAR E, LUGAR C WHERE E.lug_id = C.lug_fk_lugar_id " +
                             "AND C.lug_id = " + ciudad ;
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _lugar = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _lugar;
            }
            catch (SqlException ex)
            {
                con.Close();
                return _lugar;
            }
        }



        /// <summary>
        /// Método para listar todos los países de la base de datos
        /// </summary>
        /// <returns>Retorna un String[] con todos los países</returns>
        public String[] MListarpaisesBD()
        {
            String[] listapaises = new String[5000];
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT lug_nombre FROM Lugar WHERE lug_tipo_lugar = 'pais'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int i = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       listapaises[i] = reader[0].ToString();
                        i++;
                    }
                }
                cmd.Dispose();
                con.Close();
                return listapaises;
            }
            catch (SqlException ex)
            {
                con.Close();
                return null;
            }
            catch (InvalidOperationException ex)
            {
                con.Close();
                return null;
            }
        }


        /// <summary>
        /// Método que retorna el identificador de un país
        /// </summary>
        /// <param name="pais">Nombre del país cuyo identificador se desea conocer</param>
        /// <returns>Retorna el identificador del país</returns>
        public int MIdpaisesBD(String pais)
        {
            int fk = -1;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT lug_id FROM Lugar WHERE lug_nombre = '"+pais+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fk = Int32.Parse(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                return fk;
            }
            catch (SqlException ex)
            {
                con.Close();
                return fk;
            }
        }

        /// <summary>
        /// Método para cambiar la disponibilidad de un vehículo de la base de datos
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo cuya disponibilidad se desea cambiar</param>
        /// <param name="activardesactivar">Estatus por el cual se desea cambiar (1 para activar, 0 para desactivar)</param>
        /// <returns>Retorna 1 si se cambio el estatus exitosamente y retorna 0 si no lo pudo hacer</returns>
        public int MDisponibilidadVehiculoBD(string matricula, int activardesactivar)
        {
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "UPDATE Automovil SET aut_disponibilidad = "+activardesactivar+" WHERE aut_matricula = '" + matricula + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                con.Close();
                return 0;
            }
        }


        /// <summary>
        /// Método para listar todas las ciudades de un país
        /// </summary>
        /// <param name="fk">Identificador de país del cual se desea conocer sus ciudades</param>
        /// <returns>Retorna una lista de String que posee las ciudades</returns>
        public List<string> MListarciudadesBD(int fk)
        {
            List<String> _ciudades = new List<string>();
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT lug_nombre FROM Lugar WHERE lug_fk_lugar_id = " + fk ;
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudades.Add(reader[0].ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                return _ciudades;
            }
            catch (SqlException ex)
            {
                con.Close();
                return _ciudades;
            }
        }
    }
}