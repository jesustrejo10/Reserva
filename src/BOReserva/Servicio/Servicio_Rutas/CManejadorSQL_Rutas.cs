﻿using BOReserva.Models.gestion_ruta_comercial;
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
        private String connectionString = "";
        private manejadorSQL bd = new manejadorSQL(); 


        public CManejadorSQL_Rutas() {
            this.connectionString = bd.stringDeConexions;
        }

        private SqlConnection con = null;

        public void probarconexion()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }

        public List<CRuta> MListarRutasBD()
        {
            List<CRuta> listarutas = new List<CRuta>();
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                String sql = "SELECT r.rut_id as IRuta, lO.lug_nombre as PaisO, lD.lug_nombre as PaisD,  a.lug_nombre AS NOrigen,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b, Lugar lO, Lugar lD WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id AND a.lug_FK_lugar_id=lO.lug_id AND b.lug_FK_lugar_id=lD.lug_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //SE AGREGA CREA UN OBJECTO RUTA SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Rutas>"]
                        //Y  SE AGREGA a listarutas
                        CRuta ruta = new CRuta(Int32.Parse(reader["IRuta"].ToString()), reader["NOrigen"].ToString() + " - " + reader["PaisO"].ToString(), reader["NDestino"].ToString() + " - " + reader["PaisD"].ToString(), reader["SRuta"].ToString(),
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
                throw ex;
            }
        }



        public Boolean ValidarRuta(CAgregarRuta model)
        {
            try
            {
            String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
            String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);

            con = new SqlConnection(connectionString);

            con.Open();

            SqlCommand query = new SqlCommand("M03_ValidarRuta", con);

            query.CommandType = CommandType.StoredProcedure;

            query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
            query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
            query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
            query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
            query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;            

            query.ExecuteNonQuery();

            //creo un lector sql para la respuesta de la ejecucion del comando anterior               
            SqlDataReader lector = query.ExecuteReader();

            if (!lector.HasRows)
                return true;
            else
                return false;

            lector.Close();
                

            }
            catch (SqlException e)
            {
                con.Close();
                throw e;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Boolean InsertarRuta(CAgregarRuta model)
        {
            try
            {

                String[] strDes = model._destinoRuta.Split(new[] { " - " }, StringSplitOptions.None);
                String[] strOri = model._origenRuta.Split(new[] { " - " }, StringSplitOptions.None);

                con = new SqlConnection(connectionString);

                con.Open();
                
                SqlCommand query = new SqlCommand("M03_AgregarRuta", con);

                               
                if (ValidarRuta(model)){

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
                return false;

            }
            catch (SqlException e)
            {
                throw e; ;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public Boolean MModificarRuta(CAgregarRuta model)        {
            try
            {
                String status = model._estadoRuta;
                int distancia = model._distanciaRuta;
                int id = model._idRuta;

                con = new SqlConnection(connectionString);
                con.Open();
                String query = "UPDATE Ruta Set rut_status_ruta = '"+status+"', rut_distancia = "+distancia+" where rut_id = "+id;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();                

                lector.Close();

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

        public List<String> listarLugares()
        {
            List<String> lugares = new List<String>();
            String lugar;
            try
            {
                //Inicializo la conexion con el string de conexion
                con = new SqlConnection(connectionString);
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
                con = new SqlConnection(connectionString);
                //INTENTO abrir la conexion
                con.Open();
                String query = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id  and l.lug_nombre != '" + strOri[0] + "'";
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

        public CAgregarRuta MMostrarRutaBD(int idRuta)
        {
            CAgregarRuta ruta = new CAgregarRuta();
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                String sql = "SELECT a.lug_nombre AS NOrigen, lO.lug_nombre as PaisO, lD.lug_nombre as PaisD,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b, Lugar lO, Lugar lD WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id AND a.lug_FK_lugar_id=lO.lug_id AND b.lug_FK_lugar_id=lD.lug_id AND r.rut_id = '" + idRuta + "'";
                SqlCommand cmd = new SqlCommand(sql, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ruta._idRuta = idRuta;
                        ruta._origenRuta = reader["NOrigen"].ToString() + " - " + reader["PaisO"].ToString();
                        ruta._destinoRuta = reader["NDestino"].ToString() + " - " + reader["PaisD"].ToString();
                        ruta._estadoRuta = reader["SRuta"].ToString();
                        ruta._tipoRuta = reader["TRuta"].ToString();
                        ruta._distanciaRuta = Int32.Parse(reader["DRuta"].ToString());
                    }
                    cmd.Dispose();
                    con.Close();
                    return ruta;
                }
            }
            catch (SqlException ex)
            {
                con.Close();
                throw ex;
            }
        }

        public Boolean deshabilitarRuta(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                con = new SqlConnection(connectionString);
                //INTENTO abrir la conexion
                con.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Inactiva' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();
                con.Close();
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

        public Boolean habilitarRuta(int id)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                con = new SqlConnection(connectionString);
                //INTENTO abrir la conexion
                con.Open();
                String query = "UPDATE Ruta SET rut_status_ruta='Activa' where rut_id='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader lector = cmd.ExecuteReader();
                con.Close();
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


    }
}