using BOReserva.Models.gestion_seguridad_ingreso;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Servicio
{
    public class M01SQL
    {
        private SqlConnection conexion = null;
        string stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";

        public Cgestion_seguridad_ingreso UsuarioEnBD(String usuario)
        {
            String usuarioBD = "", nombreBD = "", claveBD = "";
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_contraseña from Usuario where usu_correo like @usu_correo", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    usuarioBD = lector.GetString(0);
                    nombreBD = lector.GetString(1);
                    claveBD = lector.GetString(2);
                }
                lector.Close();
                conexion.Close();
                return new Cgestion_seguridad_ingreso(usuarioBD, claveBD, nombreBD);
            }
            catch (SqlException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public String UsuarioEstatus(String usuario)
        {
            String estatus = "";
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select usu_activo from Usuario where usu_correo like @usu_correo", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                estatus = Convert.ToString(cmd.ExecuteScalar());
                conexion.Close();
                return estatus;
            }
            catch (SqlException e)
            {
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Boolean BloquearUsuario(String usuario)
        {            
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Usuario set usu_activo='inactivo' where usu_correo like @usu_correo", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}