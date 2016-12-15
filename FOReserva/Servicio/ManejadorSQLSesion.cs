using FOReserva.Models.Restaurantes;
using System.Collections.Generic;
using System.Data.SqlClient;
using FOReserva.Models.Sesion;
using System;

namespace FOReserva.Servicio
{
    /*Clase para el manejo de Sesion en DB*/
    public class ManejadorSQLSesion : manejadorSQL
    {
        /*Constructor del ManejadorSQL */
        public ManejadorSQLSesion() : base() { }

        public void ValidacionUsuarioCorreo(string correo)
        {
             int id;
            System.Diagnostics.Debug.WriteLine(correo);
            SqlDataReader read;
               try {
                OpenConextion();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "SELECT usu_id FROM dbo.Usuario WHERE usu_correo='"+correo+"';";
                read = query.ExecuteReader();
              
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (System.Exception mensaje)
            {
                throw new System.Exception(mensaje.Message);
            }
            if (read.HasRows)
            {
                while (read.Read()) {
                    id = read.GetInt32(0);
                    System.Diagnostics.Debug.WriteLine(id);
                }
                
                    throw new ExisteUsuarioCorreoException();
                
            }
            CloseConextion();
        }
        public void ValidacionRegistroCliente(Ccliente cliente)
        {
            try
            {
                ValidacionUsuarioCorreo(cliente.Correo);
                string clave = Seguridad.Cifrar(cliente.Clave0);

                OpenConextion();

                SqlCommand query = this.Conexion.CreateCommand();
                //query.CommandText = @"INSERT INTO dbo.Usuario VALUES ('" + cliente.Nombre + @"','" + cliente.Apellido + @"','" + cliente.Correo + @"','" + cliente.Clave0 + @"',2," + System.DateTime.Now.ToString("dd/MM/yyyy") + @",'Activo');";
                //query.CommandText = @"INSERT INTO dbo.Usuario(usu_nombre, usu_apellido, usu_correo, usu_contraseña, usu_fk_rol, usu_id, usu_fechaCreacion, usu_activo)VALUES('"+cliente.Nombre+@"','"+cliente.Apellido+@"','"+cliente.Correo+@"','"+clave+@"','2',NEXT VALUE FOR usu_id,convert(date,"+@"'"+System.DateTime.Now.ToString("dd/MM/yyyy")+@"'"+"),'Activo');";
                //query.CommandText = @"INSERT INTO dbo.Usuario(usu_nombre, usu_apellido, usu_correo, usu_contraseña, usu_fk_rol, usu_id, usu_fechaCreacion, usu_activo)VALUES('"+cliente.Nombre+@"','"+cliente.Apellido+@"','"+cliente.Correo+@"','"+clave+@"','2',NEXT VALUE FOR usu_id,'"+ DateTime.Now.ToString("yyyy-MM-dd") + @"','Activo');";
                query.CommandText = @"INSERT INTO dbo.Usuario(usu_nombre, usu_apellido, usu_correo, usu_contraseña, usu_fk_rol, usu_fechaCreacion, usu_activo)VALUES('" + cliente.Nombre + @"','" + cliente.Apellido + @"','" + cliente.Correo + @"','" + clave + @"','2','" + DateTime.Now.ToString("yyyy-MM-dd") + @"','Activo');";
                System.Diagnostics.Debug.WriteLine(query.CommandText);
                SqlDataReader read = query.ExecuteReader();
                read.Close();

                SqlCommand query1 = Conexion.CreateCommand();
                query1.CommandText = "SELECT usu_id FROM dbo.Usuario Where usu_correo='" + cliente.Correo + "';";
                SqlDataReader read1 = query1.ExecuteReader();

                int id_usuario = 0;
                if (read1.HasRows)
                {
                    while (read1.Read())
                    {
                        id_usuario = read1.GetInt32(0);
                    }
                }
                read1.Close();


                // insertar en Telefono
                SqlCommand query5 = this.Conexion.CreateCommand();
                query5.CommandText = @"INSERT INTO dbo.Telefono(tel_cod_pais, tel_cod_area, tel_num_telefonico)VALUES(0, 0, 0);";
                System.Diagnostics.Debug.WriteLine(query5.CommandText);
                SqlDataReader read5 = query5.ExecuteReader();
                read5.Close();

                // Buscar id telefono
                SqlCommand query7 = this.Conexion.CreateCommand();
                query7.CommandText = "SELECT MAX(tel_id) FROM dbo.Telefono;";
                System.Diagnostics.Debug.WriteLine(query7.CommandText);
                SqlDataReader read7 = query7.ExecuteReader();
                int id_telefono = 0;
                if (read7.HasRows)
                {
                    while (read7.Read())
                    {
                        id_telefono = read7.GetInt32(0);
                    }
                }
                read7.Close();

                // insertar en Perfil
                SqlCommand query6 = this.Conexion.CreateCommand();
                query6.CommandText = @"INSERT INTO dbo.Perfil(per_fk_usuario, per_genero, per_fecha_nacimiento, per_fk_telefono, per_fk_lugar)VALUES(" + id_usuario + @", 'Hombre', '2016-12-14', " + id_telefono + @", 12);";
                System.Diagnostics.Debug.WriteLine(query6.CommandText);
                SqlDataReader read6 = query6.ExecuteReader();
                read6.Close();

                // seleccionar ID Perfil
                SqlCommand query8 = this.Conexion.CreateCommand();
                query8.CommandText = "SELECT MAX(per_id) FROM dbo.Perfil;";
                System.Diagnostics.Debug.WriteLine(query8.CommandText);
                SqlDataReader read8 = query8.ExecuteReader();
                int id_perfil = 0;
                if (read8.HasRows)
                {
                    while (read8.Read())
                    {
                        id_perfil = read8.GetInt32(0);
                    }
                }
                read8.Close();

                SqlCommand query2 = Conexion.CreateCommand();
                query2.CommandText = @"INSERT INTO dbo.Pregunta_Respuesta (pr_value,pr_respuesta,fk_perfil) VALUES (" + cliente.PreguntaRespuesta0.Pregunta + @",'" + cliente.PreguntaRespuesta0.Respuesta + @"'," + id_perfil + @");";
                SqlDataReader read2 = query2.ExecuteReader();
                read2.Close();

                SqlCommand query3 = Conexion.CreateCommand();
                query3.CommandText = @"INSERT INTO dbo.Pregunta_Respuesta (pr_value,pr_respuesta,fk_perfil) VALUES (" + cliente.PreguntaRespuesta1.Pregunta + @",'" + cliente.PreguntaRespuesta1.Respuesta + @"'," + id_perfil + @");";
                SqlDataReader read3 = query3.ExecuteReader();
                read3.Close();

                SqlCommand query4 = Conexion.CreateCommand();
                query4.CommandText = @"INSERT INTO dbo.Pregunta_Respuesta (pr_value,pr_respuesta,fk_perfil) VALUES (" + cliente.PreguntaRespuesta2.Pregunta + @",'" + cliente.PreguntaRespuesta2.Respuesta + @"'," + id_perfil + @");";
                SqlDataReader read4 = query4.ExecuteReader();
                read4.Close();
            }
            catch (ExisteUsuarioCorreoException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw new ExisteUsuarioCorreoException();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw e;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            CloseConextion();
        }

        

        public Ccliente ValidacionLogin(Ccliente cliente)
        {
            try
            {
                ValidacionUsuarioCorreoExiste(cliente.Correo);
                OpenConextion();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "SELECT usu_id, usu_nombre, usu_apellido, usu_correo, usu_contraseña FROM dbo.Usuario WHERE usu_correo='" + cliente.Correo + "';";
                SqlDataReader read = query.ExecuteReader();
                string clave_descifrada = string.Empty;

                if (read.HasRows)
                {

                    while (read.Read())
                    {
                        cliente.Id = read.GetInt32(0);
                        cliente.Nombre = read.GetString(1);
                        cliente.Apellido = read.GetString(2);
                        cliente.Correo = read.GetString(3);
                        clave_descifrada = Seguridad.Descifrar(read.GetString(4));
                    }

                    if (!clave_descifrada.Equals(cliente.Clave0))
                    {
                        throw new ClavesDiferentesException();
                    }
                }
            }
            catch (ExisteUsuarioCorreoException e)
            {
                throw new ExisteUsuarioCorreoException();
            }
            catch (ClavesDiferentesException e)
            {
                throw new ClavesDiferentesException();
            }
            catch (SqlException S)
            {
                throw S;
            }
            catch (System.Exception mensaje)
            {
                throw new System.Exception(mensaje.Message);
            }
            CloseConextion();
            return cliente;
        }

        public void ValidacionUsuarioCorreoExiste(string correo)
        {
            SqlDataReader read;
            try
            {
                OpenConextion();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "SELECT usu_id FROM dbo.Usuario WHERE usu_correo='"+correo+"';";
                read = query.ExecuteReader();

                
            }
            catch (SqlException S)
            {
                throw S;
            }
            catch (System.Exception mensaje)
            {
                throw new System.Exception(mensaje.Message);
            }

         

            if (!read.HasRows)
            {
                throw new ExisteUsuarioCorreoException();
            }
            CloseConextion();

        }

        public void CambiarClave(int id, string clave)
        {

            try
            {
                OpenConextion();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "UPDATE dbo.Usuario SET usu_contraseña='" + Seguridad.Cifrar(clave) + "' WHERE usu_id=" + id + ";";
                System.Diagnostics.Debug.WriteLine(query.CommandText);
                SqlDataReader read = query.ExecuteReader();
            }
            catch (SqlException S)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + S.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + S.StackTrace);

                throw S;
            }
            catch (System.Exception mensaje)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + mensaje.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + mensaje.StackTrace);

                throw new System.Exception(mensaje.Message);
            }
            CloseConextion();
        }

        public void ValidarPreguntaRespuesta(int id, string pregunta, string respuesta )
        {
            SqlDataReader read;
            try
            {
               OpenConextion();

                // seleccionamos el id del perfil
                SqlCommand query3 = Conexion.CreateCommand();
                query3.CommandText = "SELECT per_id FROM dbo.Perfil Where per_fk_usuario='" + id + "';";
                SqlDataReader read3 = query3.ExecuteReader();
                int id_perfil = 0;
                if (read3.HasRows)
                {
                    while (read3.Read())
                    {
                        id_perfil = read3.GetInt32(0);
                    }
                }
                read3.Close();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "SELECT pr_id FROM dbo.Pregunta_Respuesta Where fk_perfil=" + id_perfil + " AND pr_value=" + pregunta + " AND pr_respuesta='" + respuesta + "'";
                read = query.ExecuteReader();
                if (!read.HasRows)
                {
                    System.Diagnostics.Debug.WriteLine("RESPUESTA ERRONEAAAAAAAAAAAAA");
                    throw new RespuestaErroneaException();
                }

                CloseConextion();
            }
            catch (SqlException S)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN="+S.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + S.StackTrace);
                throw S;
            }
            catch (Exception mensaje)
            {
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + mensaje.Message);
                System.Diagnostics.Debug.WriteLine("SQL EXCEPTIONNNNNNNNNNNNNNNNNN=" + mensaje.StackTrace);
                throw new Exception(mensaje.Message);
            }

            
        }

        public Dictionary<string, string> BuscarIdPregunta(string correo) {
            Dictionary<string, string> mapa = new Dictionary<string, string>();
            Random random = new Random();
            int valor = random.Next(1, 4);

            try {
                ValidacionUsuarioCorreoExiste(correo);

                                OpenConextion();
                // seleccionamos el id del usuario
                SqlCommand query1 = Conexion.CreateCommand();
                query1.CommandText = "SELECT usu_id FROM dbo.Usuario Where usu_correo='" + correo + "';";
                SqlDataReader read1 = query1.ExecuteReader();

                int id_usuario = 0;
                if (read1.HasRows)
                {
                    while (read1.Read())
                    {
                        id_usuario = read1.GetInt32(0);
                    }
                }
                read1.Close();


                // seleccionamos el id del perfil
                SqlCommand query3 = Conexion.CreateCommand();
                query3.CommandText = "SELECT per_id FROM dbo.Perfil Where per_fk_usuario='" + id_usuario + "';";
                SqlDataReader read3 = query3.ExecuteReader();
                int id_perfil = 0;
                if (read3.HasRows)
                {
                    while (read3.Read())
                    {
                        id_perfil = read3.GetInt32(0);
                    }
                }
                read3.Close();

                // seleccionamos la lista de respuestas
                int[] lista = new int[3];
                SqlCommand query2 = this.Conexion.CreateCommand();
                query2.CommandText = "SELECT pr_value FROM dbo.Pregunta_Respuesta WHERE pr_id='" + id_perfil + "';";
                SqlDataReader read2 = query2.ExecuteReader();
                string clave_descifrada = string.Empty;
                int contador = 0;
                if (read2.HasRows)
                {

                    while (read2.Read())
                    {
                        lista[contador] = read2.GetInt32(0);
                        contador++;
                    }
                }
                System.Diagnostics.Debug.WriteLine("tam: " + contador);
                string resultado = lista[random.Next(0, contador)].ToString();
                System.Diagnostics.Debug.WriteLine("resultado: " + resultado);

                mapa["value_pregunta"] = resultado;
                mapa["id_usuario"] = id_usuario.ToString();
                System.Diagnostics.Debug.WriteLine(mapa["value_pregunta"]);
                System.Diagnostics.Debug.WriteLine(mapa["id_usuario"]);
                System.Diagnostics.Debug.WriteLine(mapa["id_usuario"]);
            }
            catch (ExisteUsuarioCorreoException e) {
                throw new ExisteUsuarioCorreoException();
            }
            catch (SqlException e) {
                throw e;
            }
            catch (Exception e) {
                throw new Exception();
            }

            CloseConextion();
            return mapa;
        }



        //HECHOS POR MARIO **********************************************************
       
        public void EditarCliente(Ccliente cliente)
        {
            int telefono;
            int codigo_area;
            SqlDataReader read;
            SqlDataReader read2;
            SqlDataReader read3;
            try
            {
                codigo_area = int.Parse(cliente.Codigo_Area);
                telefono = int.Parse(cliente.Telefono);
                ValidacionUsuarioCorreoExiste(cliente.Correo); // validamos que el usuario exista
                OpenConextion();

                //UPDATE USUARIO
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "UPDATE U SET U.usu_nombre = '" + cliente.Nombre+"', U.usu_apellido = '"+cliente.Apellido+"' FROM dbo.Usuario AS U WHERE U.usu_correo='" + cliente.Correo+"';";
                System.Diagnostics.Debug.WriteLine("QUERY1:"+query.CommandText);
                read = query.ExecuteReader();
                read.Close();

                //UPDATE PERFIL
                SqlCommand query2 = this.Conexion.CreateCommand();
                query2.CommandText = "UPDATE P SET P.per_genero = '" + cliente.Genero + "' FROM dbo.Perfil AS P INNER JOIN dbo.Usuario AS U ON U.usu_id = P.per_fk_usuario WHERE U.usu_correo='" + cliente.Correo + "';";
                System.Diagnostics.Debug.WriteLine("QUERY2:" + query2.CommandText);
                read2 = query2.ExecuteReader();
                read2.Close();

                //UPDATE PERFIL
                SqlCommand query3 = this.Conexion.CreateCommand();
                query3.CommandText = "UPDATE T SET T.tel_cod_area = " + codigo_area + ", T.tel_num_telefonico = " + telefono + " FROM dbo.Telefono AS T INNER JOIN dbo.Perfil AS P ON P.per_fk_telefono = T.tel_id INNER JOIN dbo.Usuario AS U ON U.usu_id = P.per_fk_usuario WHERE U.usu_correo = '" + cliente.Correo + "';";
                System.Diagnostics.Debug.WriteLine("QUERY3:" + query3.CommandText);
                read3 = query3.ExecuteReader();
                read3.Close();
            }
            catch (ExisteUsuarioCorreoException e)
            {
                System.Diagnostics.Debug.WriteLine("Holisss--->  CATCH NO EXISTE USUARIO");
                throw e;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Holisss--->  CATCH SQL EXCEPTION");
                System.Diagnostics.Debug.WriteLine("Error----> "+e.Message);
                System.Diagnostics.Debug.WriteLine("Traza----> " + e.StackTrace);
                throw e;
            }
            catch (System.Exception mensaje)
            {
                throw new System.Exception(mensaje.Message);
            }
            
            CloseConextion();
        }


        public Ccliente ObtenerCliente(Ccliente cliente)
        {
            SqlDataReader read;
            try
            {
                ValidacionUsuarioCorreoExiste(cliente.Correo); // validamos que el usuario exista
                OpenConextion();
                SqlCommand query = this.Conexion.CreateCommand();
                query.CommandText = "SELECT U.usu_nombre, U.usu_apellido, P.per_genero, T.tel_cod_area, T.tel_num_telefonico FROM dbo.Usuario U, dbo.Perfil P, dbo.Telefono T WHERE U.usu_correo='" + cliente.Correo + "' and U.usu_id = P.per_fk_usuario and P.per_fk_telefono = T.tel_id;";
                read = query.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new ExisteUsuarioCorreoException();
                }
                else
                {
                    while (read.Read())
                    {
                        cliente.Nombre = read.GetString(0);
                        cliente.Apellido = read.GetString(1);
                        cliente.Genero = read.GetString(2);
                        cliente.Codigo_Area = read.GetInt32(3).ToString();
                        cliente.Telefono = read.GetInt32(4).ToString();
                    }
                }

            }
            catch (ExisteUsuarioCorreoException e)
            {
                throw e;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (System.Exception mensaje)
            {
                throw new System.Exception(mensaje.Message);
            }

            CloseConextion();
            return cliente;
        }







    }
}