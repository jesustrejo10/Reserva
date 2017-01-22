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


namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOBoleto : DAO, IDAOBoleto
    {

        public DAOBoleto() { }

        int IDAO.Agregar(Entidad e)
        {
            Boleto boleto = (Boleto)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Boleto (bol_escala,bol_ida_vuelta,bol_costo,bol_fk_lugar_origen,bol_fk_lugar_destino,bol_fk_pasajero,bol_fecha,bol_tipo_boleto) VALUES(" + boleto._escala + "," + boleto._ida_vuelta + "," + boleto._costo + "," + boleto._idOrigen + "," + boleto._idDestino + "," + boleto._idPasajero + ",'" + boleto._fechaBoleto.ToString("yyyy/MM/dd") + "','" + boleto._tipoBoleto + "')";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 5;
            }
        }

        int IDAOBoleto.EliminarBoleto(int id) {
            try
            {
                SqlConnection conexion = Connection.getInstance(_connexionString);
                conexion.Open();
                String sql = "DELETE FROM Boleto WHERE bol_id = " + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
           
            try
            {
                SqlConnection conexion = Connection.getInstance(_connexionString);
                Boleto boleto = new Boleto();
                conexion.Open();
                String sql = "SELECT * FROM Boleto WHERE bol_id = " + id + "";

                // FALTA OBTENER EL/LOS VUELOS DE ESE BOLETO
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var fecha = reader["bol_fecha"];
                        List<BoletoVuelo> lista = M05ListarVuelosBoleto(id);
                        Pasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("bol_fk_pasajero")));
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                        boleto = new Boleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())), fechaboleto,
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")),
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")),
                                               reader["bol_tipo_boleto"].ToString());
                        boleto._vuelos = lista;
                        boleto._pasajero = pasajero;
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return boleto;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        Entidad IDAO.Modificar(Entidad e) {
            Boleto boleto = (Boleto)e;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "UPDATE Boleto SET bol_tipo_boleto = '" + boleto._tipoBoleto + "' WHERE bol_id = " + boleto._id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return boleto;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        int IDAOBoleto.MBuscarIdaVuelta(int id) {
            int _conteo = 0;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT bol_ida_vuelta FROM Boleto WHERE bol_id =" + id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _conteo = reader.GetInt32(reader.GetOrdinal("bol_ida_vuelta")); ;
                    }
                }
                cmd.Dispose();
                con.Close();
                return _conteo;
            }
            catch (SqlException ex)
            {
                return _conteo;
            }
        }

        int IDAOBoleto.MConteoCategoria(int codigo_vuelo, String tipo)
        {
            int _conteo = 0;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT COUNT(*) AS num " +
                             "FROM Boleto_Vuelo B, Boleto C " +
                             "WHERE B.bol_fk_vuelo = " + codigo_vuelo +
                             " AND C.bol_id = B.bol_fk_boleto " +
                             "AND UPPER(C.bol_tipo_boleto) = UPPER('" + tipo + "')";
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
            catch (SqlException ex)
            {
                return _conteo;
            }
        }

        int IDAOBoleto.MConteoCapacidad(int codigo_vuelo, String tipo)
        {
            
            int _conteo = 0;
            try
            {
                String sql;
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                if(tipo=="Turista"){
                    sql = "SELECT A.avi_pasajeros_turista num " +
                           "FROM Vuelo V, Avion A " +
                           "WHERE V.vue_id =" + codigo_vuelo +
                           " AND V.vue_fk_avion = A.avi_id";
                }
                else if (tipo == "Ejecutivo")
                {
                     sql = "SELECT A.avi_pasajeros_ejecutiva num " +
                          "FROM Vuelo V, Avion A " +
                          "WHERE V.vue_id =" + codigo_vuelo +
                          " AND V.vue_fk_avion = A.avi_id";

                }
                else {
                    sql = "SELECT A.avi_pasajeros_vip num " +
                           "FROM Vuelo V, Avion A " +
                           "WHERE V.vue_id =" + codigo_vuelo +
                           " AND V.vue_fk_avion = A.avi_id";
                }
           
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
            catch (SqlException ex)
            {
                return _conteo;
            }
        }

        List<Entidad> IDAOBoleto.ConsultarBoletos()
        {
            List<Entidad> listaboletos = new List<Entidad>();
            SqlConnection conexion = null;
            try
            {
                conexion = Connection.getInstance(_connexionString);
                conexion.Open();
                String sql = "SELECT * FROM Boleto";
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["bol_fecha"];
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                        Boleto boleto = new Boleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                               MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                               MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                               Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")),
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")),
                                               reader["bol_tipo_boleto"].ToString(),
                                               MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        List<Entidad> IDAOBoleto.ConsultarBoletosPasajero(int id)
        {
            List<Entidad> listaboletos = new List<Entidad>();
            SqlConnection conexion = null;
            try
            {
                conexion = Connection.getInstance(_connexionString);
                conexion.Open();
                String sql = "SELECT reb_id,reb_fecha_reservado,reb_ida_vuelta,reb_escala,reb_costo,fk_origen,fk_destino,fk_pas_id,reb_tipo,reb_codigo FROM Reserva_Boleto WHERE fk_pas_id=" + id;
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       

                        var fecha = reader["reb_fecha_reservado"];
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                        Boleto boleto = new Boleto(Int32.Parse(reader["reb_id"].ToString()), Int32.Parse(reader["reb_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["reb_escala"].ToString()), double.Parse(reader["reb_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_destino"].ToString())),
                                               MBuscarnombrepasajero(Int32.Parse(reader["fk_pas_id"].ToString())),
                                               MBuscarapellidopasajero(Int32.Parse(reader["fk_pas_id"].ToString())), fechaboleto,
                                               Int32.Parse(reader["fk_pas_id"].ToString()), reader.GetInt32(reader.GetOrdinal("fk_origen")),
                                               reader.GetInt32(reader.GetOrdinal("fk_destino")),
                                               reader["reb_tipo"].ToString(),
                                               MBuscarcorreopasajero(Int32.Parse(reader["fk_pas_id"].ToString())),
                                               reader["reb_codigo"].ToString());
                        List<BoletoVuelo> listavuelos = M05ListarVuelosReserva((int)reader["reb_id"]);


                        boleto._vuelos = listavuelos;


                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                conexion.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                conexion.Close();
                return null;
            }
        }

        Entidad IDAOBoleto.M05MostrarReservaBD(int id_reserva)
        {
            //Es CBoleto ya que tiene los mismos atributos que la reserva
            Boleto boleto = null;

            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT reb_id,reb_fecha_reservado,reb_ida_vuelta,reb_escala,reb_costo,fk_origen,fk_destino,fk_pas_id,reb_tipo,reb_codigo FROM Reserva_Boleto WHERE reb_id = " + id_reserva;
                System.Diagnostics.Debug.WriteLine(sql);
                // FALTA OBTENER EL/LOS VUELOS DE ESA RESERVA
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var fecha = reader["reb_fecha_reservado"];
                        List<BoletoVuelo> lista = M05ListarVuelosReserva(id_reserva);
                        Pasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("fk_pas_id")));
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                        boleto = new Boleto(Int32.Parse(reader["reb_id"].ToString()), Int32.Parse(reader["reb_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["reb_escala"].ToString()), double.Parse(reader["reb_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_destino"].ToString())), fechaboleto,
                                               reader.GetInt32(reader.GetOrdinal("fk_origen")),
                                               reader.GetInt32(reader.GetOrdinal("fk_destino")),
                                               reader["reb_tipo"].ToString());
                        boleto._vuelos = lista;
                        boleto._pasajero = pasajero;



                    }
                    cmd.Dispose();
                    con.Close();
                    return boleto;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }









        public List<BoletoVuelo> M05ListarVuelosReserva(int id_reserva)
        {
            List<BoletoVuelo> listavuelos = new List<BoletoVuelo>();
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT fk_vue_id FROM Reserva_Vuelo WHERE fk_reb_id =" + id_reserva;
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BoletoVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["fk_vue_id"].ToString()));
                        listavuelos.Add(datosVuelo);
                    }
                }
                cmd.Dispose();
                con.Close();
                int inte = listavuelos.Count;
                return listavuelos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public List<BoletoVuelo> M05ListarVuelosBoleto(int id_boleto)
        {
            List<BoletoVuelo> listavuelos = new List<BoletoVuelo>();
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
            catch (SqlException ex)
            {
                return null;
            }
        }

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
            catch (SqlException ex)
            {
                return ruta;
            }
        }
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
            catch (SqlException ex)
            {
                return vuelo;
            }
        }

        public Pasajero MBuscarDatosPasajero(int id)
        {
            Pasajero pas = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT * FROM Pasajero WHERE pas_id = '" + id + "'";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["pas_fecha_nacimiento"];
                        DateTime fechanac = Convert.ToDateTime(fecha).Date;
                        pas = new Pasajero(Int32.Parse(reader["pas_id"].ToString()), reader["pas_primer_nombre"].ToString(),
                                             reader["pas_segundo_nombre"].ToString(), reader["pas_primer_apellido"].ToString(),
                                             reader["pas_segundo_apellido"].ToString(), reader["pas_sexo"].ToString(),
                                             fechanac, reader["pas_correo"].ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                return pas;
            }
            catch (SqlException ex)
            {
                return pas;
            }
        }

        public String MBuscarnombrepasajero(int id)
        {
            String _nombre = "";
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT pas_primer_nombre FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _nombre = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _nombre;
            }
            catch (SqlException)
            {
                return _nombre;
            }
        }

        public String MBuscarapellidopasajero(int id)
        {
            String _apellido = "";
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT pas_primer_apellido FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _apellido = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _apellido;
            }
            catch (SqlException)
            {
                return _apellido;
            }
        }

        public String MBuscarcorreopasajero(int id)
        {
            String _correo = "";
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT pas_correo FROM Pasajero WHERE pas_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _correo = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _correo;
            }
            catch (SqlException ex)
            {
                return _correo;
            }
        }

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