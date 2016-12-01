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
        private String connetionString = "Data Source=ServerName; Initial Catalog=DatabaseName;User ID=DB_A1380A_reserva_admin; Password=ucabds1617a"; //No supe cual es el string de conexion jejejeps
        private SqlConnection con = null;

        public void probarconexion()
        {
            con = new SqlConnection(connetionString);
            con.Open();
        }

        public int MAgregarVehiculoBD(CAutomovil vehiculo)
        {
            int fk_ciudad = MBuscarfkciudad(vehiculo._ciudad);
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "INSERT INTO Automovil VALUES ('"+vehiculo._matricula+"', '"+vehiculo._modelo+"', '"+vehiculo._fabricante+"', "+vehiculo._anio+", "+vehiculo._kilometraje+", "+vehiculo._cantpasajeros+", '"+vehiculo._tipovehiculo+
                    "', " + vehiculo._preciocompra + ", " + vehiculo._precioalquiler + ", " + vehiculo._penalidaddiaria + ", '" + vehiculo._fecharegistro + "', '" + vehiculo._color + "', "+ 1 +", '"+vehiculo._transmision+", "+ fk_ciudad+")";
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

        public int MBuscarfkciudad (String ciudad)
        {
            int fk_ciudad = -99;
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT id_lugar FROM Automovil WHERE tipo_lugar = 'ciudad' AND nombre_lugar = '" + ciudad + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                        //SE OBTIENE LA CIUDAD Y SE PASA
                        //Y  COLOCA QUE FK_CIUDAD ES IGUAL A LO QUE DEVUELVE EL SQL
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
    }
}