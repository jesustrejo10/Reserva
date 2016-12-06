using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class CBasededatos_vehiculo
    {
        //private String connetionString = @"Data Source=LUISALEJANDROPE\LAPGROCK;Initial Catalog=proyds1617;Integrated Security=True"; //No supe cual es el string de conexion jejejeps
        private String connetionString = @"Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User ID=DB_A1380A_reserva_admin;Password = ucabds1617a"; //No supe cual es el string de conexion jejejeps
        
        private SqlConnection con = null;

        public void probarconexion()
        {
            con = new SqlConnection(connetionString);
            con.Open();
        }

        public int MAgregarVehiculoBD(CAutomovil vehiculo)
        {
            int fk_ciudad = MBuscarfkciudad(vehiculo._ciudad, vehiculo._pais, vehiculo._estado);
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "INSERT INTO Automovil VALUES ('"+vehiculo._matricula+"', '"+vehiculo._modelo+"', '"+vehiculo._fabricante+"', "+vehiculo._anio+", "+vehiculo._kilometraje+", "+vehiculo._cantpasajeros+", '"+vehiculo._tipovehiculo+
                    "', " + vehiculo._preciocompra + ", " + vehiculo._precioalquiler + ", " + vehiculo._penalidaddiaria + ", '" + vehiculo._fecharegistro + "', '" + vehiculo._color + "', "+ 1 +", '"+vehiculo._transmision+"', "+ fk_ciudad+")";
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

        public List<CAutomovil> MListarvehiculosBD()
        {
            List<CAutomovil> listavehiculos = new List<CAutomovil>();
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
                       CAutomovil vehiculo = new CAutomovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                              Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(),
                                              double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                              double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                              double.Parse(reader["aut_penalidaddiaria"].ToString()), fecharegistro ,
                                              reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()), reader["aut_transmision"].ToString(),
                                              MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombreLugar(MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), "Estado", "Ciudad"),
                                              MBuscarnombreLugar(MBuscarnombreLugar(MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), "Estado", "Ciudad"), "Pais", "Estado"));
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


        public CAutomovil MMostrarvehiculoBD(String matricula)
        {
            CAutomovil vehiculo = null;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT * FROM Automovil WHERE aut_matricula = '"+matricula+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                        //SE CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a vehiculo
                    vehiculo = new CAutomovil(reader["aut_matricula"].ToString(), reader["aut_modelo"].ToString(), reader["aut_fabricante"].ToString(),
                                              Int32.Parse(reader["aut_anio"].ToString()), reader["aut_tipovehiculo"].ToString(), 
                                              double.Parse(reader["aut_kilometraje"].ToString()), Int32.Parse(reader["aut_cantpasajeros"].ToString()),
                                              double.Parse(reader["aut_preciocompra"].ToString()), double.Parse(reader["aut_precioalquiler"].ToString()),
                                              double.Parse(reader["aut_penalidaddiaria"].ToString()), DateTime.Parse(reader["aut_fecharegistro"].ToString()),
                                              reader["aut_color"].ToString(), Int32.Parse(reader["aut_disponibilidad"].ToString()),reader["aut_transmision"].ToString(),
                                              MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), MBuscarnombreLugar(MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), "Estado", "Ciudad"),
                                              MBuscarnombreLugar(MBuscarnombreLugar(MBuscarnombreciudad(Int32.Parse(reader["aut_fk_ciudad"].ToString())), "Estado", "Ciudad"), "Pais", "Estado"));
                }
                cmd.Dispose();
                con.Close();
                return vehiculo;
            }
            catch (SqlException ex)
            {
                con.Close();
                return null;
            }
        }

        public int MBuscarfkciudad (String ciudad, String pais, String estado)
        {
            int fk_ciudad = 12;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT C.id_lugar FROM LUGAR P, LUGAR E, LUGAR C WHERE P.id_lugar = E.FK_lugar_id AND E.id_lugar = C.FK_lugar_id AND " +
                             "P.nombre_lugar = '"+pais+"' AND E.nombre_lugar = '"+estado+"' AND C.nombre_lugar = '"+ciudad+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                    fk_ciudad = Int32.Parse(reader[0].ToString()); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
                }
                cmd.Dispose();
                con.Close();
                return fk_ciudad;
            }
            catch (SqlException ex)
            {
                con.Close();
                return fk_ciudad;
            }
        }

        public int MBorrarvehiculo(String matricula)
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

        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT C.nombre_lugar FROM LUGAR C WHERE C.id_lugar = '" + id + "'"; ;
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //SE OBTIENE LA CIUDAD Y SE PASA
                    //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                    _ciudad = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
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

        public String MBuscarnombreLugar(String ciudad, String tipo1, String tipo2) //TIPO1 Y TIPO2 ES POR EJEMPLO SI SE BUSCA UN PAIS Y SE CONOCE EL ESTADO TIPO1 ES PAIS Y TIPO2 ES ESTADO
        {
            String _lugar = "No aplica";
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT E.nombre_lugar FROM LUGAR E, LUGAR C WHERE E.id_lugar = C.FK_lugar_id AND " +
                             "AND C.nombre_lugar = '" + ciudad + "' AND E.tipo_lugar = 'Estado' AND E.tipo_lugar = '"+tipo1+"' AND "+
                             "C.tipo_lugar = '"+tipo2+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //SE OBTIENE LA CIUDAD Y SE PASA
                    //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
                    _lugar = reader[0].ToString(); //EL 0 REPRESENTA LA PRIMERA Y UNICA COLUMNA QUE DEVULVE EL SqlDataReader
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
    }
}