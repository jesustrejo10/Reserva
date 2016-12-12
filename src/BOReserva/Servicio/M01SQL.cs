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
            String usuarioBD = "", nombreBD = "", apellidoBD = "", claveBD = "", statusBD="";
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_apellido ,usu_contraseña, usu_activo from Usuario where usu_correo like @usu_correo AND usu_fk_rol IS NOT NULL", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                 SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_apellido ,usu_contraseña, usu_activo from Usuario where usu_correo like @usu_correo AND usu_fk_rol NOT BETWEEN 2 AND 3", conexion);
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    usuarioBD = lector.GetString(0);
                    nombreBD = lector.GetString(1);
                    apellidoBD = lector.GetString(2);
                    claveBD = lector.GetString(3);

                    System.Diagnostics.Debug.WriteLine("Correo " + usuarioBD + " contrasena " + claveBD);

                    statusBD = lector.GetString(4);

                }
                lector.Close();
                conexion.Close();
                return new Cgestion_seguridad_ingreso(usuarioBD, claveBD, nombreBD,apellidoBD,statusBD);
            }
            catch (SqlException e)
            {
                throw  e;
              //  return null;
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
                SqlCommand cmd = new SqlCommand("Update Usuario set usu_activo='Inactivo' where usu_correo like @usu_correo", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean InsertarLogin(String usuario) {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Insert into Login(log_idusuario,log_sesion,log_intentos) values((Select usu_id from Usuario where usu_correo like @usu_correo),0,0);", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
                throw e;
                
            }
            catch (Exception e)
            {
                return false;
            }
        
        }

        public Boolean EliminarLogin(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("DELETE from Login WHERE log_idusuario=1", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public Boolean IncrementarIntentos(String usuario) {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Login set log_intentos=log_intentos+1 where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                if (cmd.ExecuteNonQuery() < 1)
                {
                    InsertarLogin(usuario);
                    cmd.ExecuteNonQuery();
                }                
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("El error esta en incrementar intentos");
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }        
        }

        public Boolean ResetearIntentos(String usuario)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Update Login set log_intentos=0 where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;              
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                throw e;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int NumeroIntentos(String usuario)
        {
            int intentos = 0;
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select log_intentos from Login where log_idusuario=(Select usu_id from Usuario where usu_correo like @usu_correo)", conexion);
                cmd.Parameters.AddWithValue("@usu_correo", usuario);
                if (cmd.ExecuteScalar()==null)
                {
                    InsertarLogin(usuario);
                }
                else
                    intentos = Convert.ToInt32(cmd.ExecuteScalar());
                System.Diagnostics.Debug.WriteLine(intentos);
                conexion.Close();
                return intentos;
            }
            catch (SqlException e)
            {
                throw e;
               // return -1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }


    }
}
