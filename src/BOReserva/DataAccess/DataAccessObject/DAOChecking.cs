using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase de Acceso a datos para el chickin de un boleto
    /// </summary>
    public class DAOChecking : DAO, IDAOCheckIn
    {
        int IDAO.Agregar(Entidad e) {
            BoardingPass pase = (BoardingPass)e;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "INSERT INTO Pase_Abordaje (pas_fk_boleto,pas_fk_asiento, pas_fk_lugar_origen, pas_fk_lugar_destino,pas_fk_vuelo) " +
                    " VALUES (" + pase._boleto + ",'" + pase._asiento + "'," + pase._origen + "," + pase._destino + "," + pase._vuelo + ")";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                String hola = ex.ToString();
                return 0;
            }
        }

        /// <summary>
        /// Lista de pases de un pasajero
        /// </summary>
        /// <param name="pasaporte"></param>
        /// <returns></returns>
        public List<Entidad> ListarPasesPasajero(int pasaporte)
        {
            List<Entidad> listaboletos = new List<Entidad>();
            IDAOLugar c = (DAOLugar) FabricaDAO.instanciarDaoLugar();

            try
            {
                SqlConnection con = Connection.getInstance(_connexionString);
                con.Open();
                String sql = "SELECT P.pas_id AS numpas, P.pas_fk_lugar_origen AS origen, P.pas_fk_lugar_destino AS destino, P.pas_fk_vuelo AS vuelo" +
                             " FROM Pase_Abordaje P, Boleto B " +
                             " WHERE B.bol_fk_pasajero = " + pasaporte +
                             " AND P.pas_fk_boleto = B.bol_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BoardingPass boleto = new BoardingPass(Int32.Parse(reader["numpas"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["destino"].ToString())),
                                               Int32.Parse(reader["vuelo"].ToString()));
                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                con.Close();
                return listaboletos;
            }
            catch (SqlException )
            {
                return null;
            }
        }

        List<Entidad> IDAOCheckIn.M05ListarVuelosBoleto(int id_boleto)
        {
            List<Entidad> listavuelos = new List<Entidad>();
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT bol_fk_vuelo FROM Boleto_Vuelo WHERE bol_fk_boleto =" + id_boleto + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BoletoVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["bol_fk_vuelo"].ToString()));
                        listavuelos.Add(datosVuelo);
                    }
                }
                cmd.Dispose();
                con.Close();
                int inte = listavuelos.Count;
                return listavuelos;
            }
            catch (SqlException )
            {
                return null;
            }
        }

        int IDAOCheckIn.MConteoMaletas(int pase) { 
           int _conteo = -1;
           try
           {
               SqlConnection con = new SqlConnection(_connexionString);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            " FROM Equipaje  " +
                            " WHERE equ_fk_pase_abordaje = " + pase + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                   }
               }
               cmd.Dispose();
               con.Close();
               return _conteo;
           }
           catch (SqlException )
           {
               return _conteo;
           }
       }

        int IDAOCheckIn.CrearEquipaje(int id, int peso) {
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "INSERT INTO Equipaje (equ_peso,equ_fk_pase_abordaje) " +
                    " VALUES (" + peso + "," + id + ")";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                String hola = ex.ToString();
                return 0;
            }

        }

        int IDAOCheckIn.MConteoBoarding(int num_bol, int num_vue)
        {
            int _conteo = 0;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT COUNT(*) AS num " +
                             "FROM Pase_Abordaje B " +
                             "WHERE B.pas_fk_vuelo = " + num_vue +
                             " AND B.pas_fk_boleto =" + num_bol + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _conteo = reader.GetInt32(reader.GetOrdinal("num")); ;
                    }
                }
                cmd.Dispose();
                con.Close();
                return _conteo;
            }
            catch (SqlException )
            {
                return _conteo;
            }
        }

        int IDAOCheckIn.IdBoardingPass(int num_bol, int num_vue)
        {
            int _conteo = 0;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT P.pas_id AS id_pase " +
                             "FROM Pase_Abordaje P " +
                             "WHERE P.pas_fk_vuelo = " + num_vue +
                             " AND  P.pas_fk_boleto =" + num_bol + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _conteo = reader.GetInt32(reader.GetOrdinal("id_pase")); ;
                    }
                }
                cmd.Dispose();
                con.Close();
                return _conteo;
            }
            catch (SqlException )
            {
                return _conteo;
            }
        }

        /// <summary>
        /// Buscar datos del vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BoletoVuelo MBuscarDatosVuelo(int id)
        {
            BoletoVuelo vuelo = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT vue_fecha_despegue, vue_fecha_aterrizaje, vue_fk_ruta FROM Vuelo WHERE vue_id =" + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        RutaBoleto rut = MBuscarDatosRuta(Int32.Parse(reader["vue_fk_ruta"].ToString()));

                        vuelo = new BoletoVuelo(id, reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue")),
                                           reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje")),
                                           Int32.Parse(reader["vue_fk_ruta"].ToString()),
                                           rut._origen, rut._destino, rut._nomOrigen, rut._nomDestino);
                    }
                }
                cmd.Dispose();
                con.Close();
                return vuelo;
            }
            catch (SqlException )
            {
                return vuelo;
            }
        }

        /// <summary>
        /// Buscar datos de la ruta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RutaBoleto MBuscarDatosRuta(int id)
        {
            RutaBoleto ruta = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT rut_FK_lugar_origen, rut_FK_lugar_destino FROM Ruta WHERE rut_id =" + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ruta = new RutaBoleto(id, Int32.Parse(reader["rut_FK_lugar_origen"].ToString()), Int32.Parse(reader["rut_FK_lugar_destino"].ToString()),
                             MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_origen"].ToString())),
                             MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_destino"].ToString())));


                    }
                }
                cmd.Dispose();
                con.Close();
                return ruta;
            }
            catch (SqlException )
            {
                return ruta;
            }
        }

        /// <summary>
        /// Busca el nombre de la ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _ciudad;
            }
            catch (SqlException)
            {
                return _ciudad;
            }
        }
    }
}