using FOReserva.Models.Diarios;
using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace FOReserva.Servicio
{
    /*Clase para manejo de Diarios de Viaje en BD*/
    public class ManejadorSQLDiarios : manejadorSQL
    {
        StringBuilder sb;
        //SqlCommand cmd;
        /*Constructor de manejadorSQL*/
        public ManejadorSQLDiarios() : base() { }


    /*BUSQUEDAS*/


        /*Buscar TODOS los Diarios de Viaje*/
        public List<CDiarioModel> obtenerDiarios()
        {
            string query = @"SELECT
            d.id_diar,
            d.nombre_diario,
            CASE 
            WHEN len(descripcion_diar)>100
            THEN LEFT(descripcion_diar, 97) + '...' 
            ELSE descripcion_diar END descr,
            d.fk_destino, d.calif_creador, d.fecha_carga_diar 
            FROM Diario_Viaje d;";
            SqlDataReader read = Executer(query);
            List<CDiarioModel> listaDV = new List<CDiarioModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string desc = read.GetString(2);
                    int lug = read.GetInt32(3);
                    int cal = read.GetInt32(4);
                    DateTime carga = read.GetDateTime(5);
                    CDiarioModel diario = new CDiarioModel();
                    diario.Id = id;
                    diario.Nombre = nombre;
                    diario.Descripcion = desc;
                    diario.Destino = lug;
                    diario.Calif_creador = cal;
                    diario.Fecha_carga = carga;
                    listaDV.Add(diario);
                }
            }
            CloseConnection();
            return listaDV;
        }


        /*Buscar Diarios de Viaje dado un modelo*/
       
        public List<CDiarioModel> buscarDiarios(CDiarioModel diar)
        {
            sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(" d.id_diar, d.nombre_diario, CASE ");
            sb.Append("  WHEN len(d.descripcion_diar)>100 ");
            sb.Append("  THEN LEFT(d.descripcion_diar, 97) + '...' ");
            sb.Append("  ELSE d.descripcion_diar END descr, ");
            sb.Append("  d.fk_destino, d.calif_creador, d.fecha_carga_diar ");
            sb.Append("FROM Diario_Viaje d ");
            if (diar.Destino != -1) //Si se busca por destino se anexa la tabla al query
            {
                sb.Append(", Lugar l ");
            }
            sb.Append("WHERE d.fecha_carga_diar BETWEEN CONVERT(varchar,@finicio,111) AND CONVERT(varchar,@ffin,111)");
            if (diar.Destino != -1) //Si se busca por destino se anexa la condición al query
            {
                sb.Append(" AND (l.lug_id = @destino OR l.lug_FK_lugar_id = @destino ) AND d.fk_destino = l.lug_id ");
            }
            if (diar.Rating != 0) //Si se filtra por rating se anexa la condición al query
            {
                sb.Append(" AND d.calif_creador >= @rating ");
            }
            if (diar.Filtro == 0) //Fechas descendientes (más recientes primero)
            {
                sb.Append("ORDER BY d.fecha_carga_diar DESC");
            }
            else if (diar.Filtro == 1) //Fechas ascendientes (más antiguos primero)
            {
                sb.Append("ORDER BY d.fecha_carga_diar ASC");
            }
            string query = sb.ToString();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@finicio", diar.Fecha_ini));
            par.Add(new SqlParameter("@ffin", diar.Fecha_fin));
            par.Add(new SqlParameter("@destino", diar.Destino));
            par.Add(new SqlParameter("@rating", diar.Rating));

            SqlDataReader read = Executer(query,par);
            List<CDiarioModel> listaDV = new List<CDiarioModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string desc = read.GetString(2);
                    int lug = read.GetInt32(3);
                    int cal = read.GetInt32(4);
                    DateTime carga = read.GetDateTime(5);
                    CDiarioModel diario = new CDiarioModel();
                    diario.Id = id;
                    diario.Nombre = nombre;
                    diario.Descripcion = desc;
                    diario.Destino = lug;
                    diario.Calif_creador = cal;
                    diario.Fecha_carga = carga;
                    listaDV.Add(diario);
                }
            }
            CloseConnection();
            return listaDV;
        }

        /*Buscar un Diario de Viaje dado su ID*/
       
        public CDiarioModel buscarDiarios(int id_dia)
        {
            CDiarioModel diario = null;
            sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append("  d.id_diar, d.nombre_diario, d.fecha_ini_diar, ");
            sb.Append("  d.descripcion_diar, d.fecha_carga_diar, ");
            sb.Append("  d.calif_creador, d.rating, d.num_visita, ");
            sb.Append("  d.fk_usuario_id, d.fecha_fin_diar, d.fk_destino ");
            sb.Append("FROM dbo.Diario_Viaje AS d ");
            sb.Append("WHERE d.id_diar = @diarid");
            string query = sb.ToString();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@diarid", id_dia));

            SqlDataReader read = Executer(query,par);
            if (read.HasRows)
            {
                read.Read();
                int id = read.GetInt32(0);
                string nombre = read.GetString(1);
                DateTime f_ini = read.GetDateTime(2);
                string desc = read.GetString(3);
                DateTime f_carga = read.GetDateTime(4);
                int cal = read.GetInt32(5);
                int rating = read.GetInt32(6);
                int visitas = read.GetInt32(7);
                int user = read.GetInt32(8);
                DateTime f_fin = read.GetDateTime(9);
                int destino = read.GetInt32(10);
                diario = new CDiarioModel(id, null, nombre, f_ini, f_fin, desc, f_carga, cal, rating, visitas, destino, user);
            }

            CloseConnection();
            return diario;
        }

        /*Buscar TODOS los Lugares para dropdown*/
       
        public List<CLugar> obtenerLugares()
        {
            string query = @"SELECT
            lug_id,
            lug_nombre,
            lug_tipo_lugar
            FROM Lugar;";
            SqlDataReader read = Executer(query);
            List<CLugar> listaLugares = new List<CLugar>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string tipo = read.GetString(2);
                    CLugar lug = new CLugar();
                    lug.ID = id;
                    lug.Nombre = nombre;
                    lug.Tipo = tipo;
                    listaLugares.Add(lug);
                }
            }
            CloseConnection();
            return listaLugares;
        }

        /* Buscar el nombre del publicador del diario de viaje según el ID de este */

        public String obtenerUsuario(int id)
        {
            string query = @"SELECT
                u.usu_nombre,
                u.usu_apellido
                FROM
                    dbo.Usuario AS u
                    INNER JOIN dbo.Diario_Viaje AS dv 
                    ON dv.fk_usuario_id = u.usu_id
                WHERE
                    dv.id_diar = @userid";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@userid", id));

            SqlDataReader read = Executer(query,par);
            string nombre = "";

            if (read.HasRows)
            {
                read.Read();
                nombre = read.GetString(0) + " " + read.GetString(1);
            }
            CloseConnection();
            return nombre;
        }

        
        //Busqueda de Nombres de Lugares (obtiene el Lugar a traves de la id
        
        public String obtenerNombreLugar(int id)
        {
            string query = @"SELECT
                l.lug_nombre
            FROM dbo.Lugar AS l
            WHERE l.lug_id = @lugarid";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@lugarid", id));

            SqlDataReader read = Executer(query,par);
            string nombre = "";

            if (read.HasRows)
            {
                read.Read();
                nombre = read.GetString(0);
            }
            CloseConnection();
            return nombre;
        }

        //Busqueda de numero de visitas de un Diario
        
        public int obtenerNumeroVisitas(int id)
        {
            string query = @"SELECT
                Diario_Viaje.num_visita
            FROM dbo.Diario_Viaje 
            WHERE id_diar = @diarid";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@diarid", id));

            SqlDataReader read = Executer(query,par);
            int numero=0 ;

            if (read.HasRows)
            {
                read.Read();
                numero = read.GetInt32(0) ;
            }
            CloseConnection();
            return numero;
        }


     /*INSERCIONES*/



        /*Nuevo Diario*/


        public int CrearDiario(CDiarioModel nDiar)
        {
            string query = @"INSERT INTO Diario_Viaje
            (nombre_diario,fecha_ini_diar,descripcion_diar,
            fecha_carga_diar,calif_creador,rating,num_visita
            ,fk_usuario_id,fecha_fin_diar,fk_destino) 
            OUTPUT Inserted.id_diar
            VALUES(@nombre,CONVERT(varchar,@finicio,111),@descr,
            CONVERT(varchar,@fcarga,111),@calif,0,0,11,@ffin,@dest)";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@nombre", nDiar.Nombre));
            par.Add(new SqlParameter("@finicio", nDiar.Fecha_ini));
            par.Add(new SqlParameter("@descr", nDiar.Descripcion));
            par.Add(new SqlParameter("@fcarga", nDiar.Fecha_carga));
            par.Add(new SqlParameter("@calif", nDiar.Calif_creador));
            par.Add(new SqlParameter("@ffin", nDiar.Fecha_fin));
            par.Add(new SqlParameter("@dest", nDiar.Destino));
            
            SqlDataReader read = Executer(query,par);
            int id = -1;
            if (read.HasRows)
            {
                read.Read();
                id = read.GetInt32(0);
            }
            CloseConnection();
            return id;
        }
        
        
        
        
        /*MODIFICACIONES*/

        /*Actualizar numero de visitas*/
        /*Este metodo obtendra el diario a partir de la respuesta
          de buscar diario de viaje dado un modelo */

        public int actualizarVisitas(CDiarioModel diar)
        {
            int visitas = diar.Num_visita;
            visitas++;
            string query = "UPDATE Diario_Viaje SET num_visita = @visitas WHERE id_diar = @did";
            
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@visitas", visitas));
            par.Add(new SqlParameter("@did", diar.Id));
                        
            this.Executer(query,par);
            CloseConnection();
            return visitas;
        }

        public int actualizarRating(CDiarioModel diario, bool esLike)
        {
            int nuevoRating = diario.Rating;
            if (esLike)
            {
                nuevoRating++;
            }
            else
            {
                nuevoRating--;
            }
            string query = "UPDATE Diario_Viaje SET rating = @rat WHERE id_diar = @did";

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(new SqlParameter("@rat", nuevoRating));
            par.Add(new SqlParameter("@did", diario.Id));

            this.Executer(query,par);
            CloseConnection();
            return nuevoRating;
        }

        /* Utilidad para imágenes */
        public static Image ByteAImagen(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ImagenAByte(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }    
}