using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.DataAccess.Domain;
using System.Data;

namespace BOReserva.DataAccess.DataAccessObject.M03
{
    public class DAORuta : DAO, IDAORuta
    {

        public DAORuta() { }

        public Boolean ValidarRuta(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {

                String[] strDes = ruta._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = ruta._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);


                conexion.Open();

                SqlCommand query = new SqlCommand("M03_ValidarRuta", conexion);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = ruta._tipo;

                query.ExecuteNonQuery();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();

                if (!lector.HasRows)
                    return true;
                else
                    return false;

                lector.Close();


            }
            catch (SqlException ex)
            {
                conexion.Close();
                throw ex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Boolean habilitarRuta(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Activa' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

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
        public Boolean deshabilitarRuta(int id)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Inactiva' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                conexion.Close();
                return true;

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
        public Dictionary<int, Entidad> listarLugares()
        {

            List<String> lugares = new List<String>();
            Dictionary<int, Entidad> listaLugares = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais,r.rut_id as idruta from Lugar l, Lugar ll,ruta r where l.lug_FK_lugar_id = ll.lug_id and r.rut_FK_lugar_origen = l.lug_id";

                SqlCommand cmd = new SqlCommand(query, conexion);


                SqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();
                    int id = Int32.Parse(lector["idruta"].ToString());
                    Ruta lugarO = new Ruta();
                    lugarO._origenRuta = lugar;
                    lugarO._idRuta = id;

                    listaLugares.Add(lugarO._idRuta,lugarO);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listaLugares;

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
        public Dictionary<int, Entidad> consultarDestinos(string origen)
        {
            String[] strOri = origen.Split(new[] { " - " }, StringSplitOptions.None);
            var lugares = new List<String>();
            Dictionary<int, Entidad> listaLugares = new Dictionary<int, Entidad>();
            //puedo usar Singleton
            SqlConnection conexion = Connection.getInstance(_connexionString);
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                //INTENTO abrir la conexion
                conexion.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id  and l.lug_nombre != '" + strOri[0] + "'";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + " - " + lector["pais"].ToString();
                    lugares.Add(lugar);
                }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return listaLugares;

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
        public Entidad MMostrarRutaBD(int idRuta)
        {
            Ruta ruta = new Ruta();
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                String sql = "SELECT a.lug_nombre AS NOrigen, lO.lug_nombre as PaisO, lD.lug_nombre as PaisD,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b, Lugar lO, Lugar lD WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id AND a.lug_FK_lugar_id=lO.lug_id AND b.lug_FK_lugar_id=lD.lug_id AND r.rut_id = '" + idRuta + "'";
                SqlCommand cmd = new SqlCommand(sql, conexion);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ruta._idRuta = idRuta;
                        ruta._origenRuta = reader["NOrigen"].ToString() + " - " + reader["PaisO"].ToString();
                        ruta._destinoRuta = reader["NDestino"].ToString() + " - " + reader["PaisD"].ToString();
                        ruta._status = reader["SRuta"].ToString();
                        ruta._tipo = reader["TRuta"].ToString();
                        ruta._distancia = Int32.Parse(reader["DRuta"].ToString());
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return ruta;
                }
            }
            catch (SqlException ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        int IDAO.Agregar(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            IDAORuta rutas = new DAORuta();
            try
            {

                String[] strDes = ruta._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = ruta._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);

                conexion.Open();

                SqlCommand query = new SqlCommand("M03_AgregarRuta", conexion);


                if (rutas.ValidarRuta(ruta))
                {

                    query.CommandType = CommandType.StoredProcedure;

                    query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                    query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                    query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                    query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                    query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = ruta._tipo;
                    query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = ruta._status;
                    query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = ruta._distancia;

                    query.ExecuteNonQuery();

                    //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                    SqlDataReader lector = query.ExecuteReader();

                    lector.Close();

                    return 1;
                }
                return 2;

            }
            catch (SqlException ex)
            {
                return 3;
                throw ex;
            }
            catch (Exception ex)
            {
                return 4;
                throw ex;
            }
        }
        public Boolean MModificarRuta(Entidad e)
        {
            Ruta ruta = (Ruta)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                String status = ruta._status;
                int distancia = ruta._distancia;
                int id = ruta._idRuta;

                conexion.Open();
                String query = "UPDATE Ruta Set rut_status_ruta = '" + status + "', rut_distancia = " + distancia + " where rut_id = " + id;
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader lector = cmd.ExecuteReader();

                lector.Close();

                return true;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}