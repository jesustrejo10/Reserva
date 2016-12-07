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

        public Cgestion_seguridad_ingreso UsuarioEnBD(String usuario, String clave) {
            String usuarioBD = "", nombreBD = "", claveBD = "";
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Select usu_correo, usu_nombre, usu_contraseña from Usuario where usu_correo like '" + usuario + "'", conexion);
                //cmd.CommandType = CommandType.StoredProcedure;
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
    }
}