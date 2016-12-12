using BOReserva.Models.gestion_ruta_comercial;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.Servicio.Servicio_Rutas
{
    public class CManejadorSQL_Rutas
    {
        private String connetionString = @"Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User ID=DB_A1380A_reserva_admin;Password = ucabds1617a"; //No supe cual es el string de conexion jejejeps

        private SqlConnection con = null;

        public void probarconexion()
        {
            con = new SqlConnection(connetionString);
            con.Open();
        }

        public Boolean MAgregarRuta(CAgregarRuta model)
        {
            try
            {

                String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);

                con = new SqlConnection(connetionString);
                con.Open();

                SqlCommand query = new SqlCommand("M03_AgregarRuta", con);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;
                query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = model._estadoRuta;
                query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = model._distanciaRuta;

                query.ExecuteNonQuery();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();

                lector.Close();

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


        public List<CRuta> MListarRutasBD()
        {
            List<CRuta> listarutas = new List<CRuta>();
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT a.lug_nombre AS NOrigen,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                        //Y  SE AGREGA a listavehiculos
                        CRuta ruta = new CRuta(reader["NOrigen"].ToString(), reader["NDestino"].ToString(), reader["SRuta"].ToString(),
                                               reader["TRuta"].ToString(), Int32.Parse(reader["DRuta"].ToString()));
                        listarutas.Add(ruta);
                    }
                }
                con.Close();
                return listarutas;
            }
            catch (SqlException ex)
            {
                con.Close();
                return null;
            }
        }

        public Boolean InsertarRuta(CAgregarRuta model)
        {
            try
            {

                String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);

                con = new SqlConnection(connetionString);

                con.Open();

                SqlCommand query = new SqlCommand("M03_AgregarRuta", con);
                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;
                query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = model._estadoRuta;
                query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = model._distanciaRuta;

                query.ExecuteNonQuery();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();

                lector.Close();

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

        public List<String> listarLugares()
        {
            List<String> lugares = new List<String>();
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                con = new SqlConnection(connetionString);
                //INTENTO abrir la conexion
                con.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();
                    lugares.Add(lugar);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                con.Close();
                return lugares;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<String> consultarDestinos(String origen)
        {
            String[] strOri = origen.Split(new[] { " - " }, StringSplitOptions.None);
            var lugares = new List<String>();
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                con = new SqlConnection(connetionString);
                //INTENTO abrir la conexion
                con.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id and l.lug_nombre != '" + strOri[0] + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();
                    lugares.Add(lugar);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                con.Close();
                return lugares;

            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
