using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOReserva.Models.gestion_boletos;

namespace BOReserva.Servicio.Servicio_Boletos
{
    public class manejadorSQL_Boletos
    {
         public string stringDeConexion;

        public manejadorSQL_Boletos()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }







      
        //Parametro el id del vuelo
        public int BuscarCantBolVue(int id_vuelo)
        {
            int _conteo = 0;
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT count(bol_fk_vuelo) as num FROM Boleto_Vuelo WHERE bol_fk_vuelo = "+id_vuelo;
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




          public List<CVuelo> M05ListarVuelosVueltaBD(string fecha_ida, string fecha_vuelta, int id_origen, int id_destino, string tipo)
        {
            List<CVuelo> listavuelos = new List<CVuelo>();
            try
            {

                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();

                //Busco la capacidad del avion del vuelo, segun el tipo de boleto


                String sql = "SELECT v.vue_id as id,v.vue_fecha_despegue as despegue,v.vue_fecha_aterrizaje as aterrizaje,r.rut_id as id_ruta,r.rut_FK_lugar_origen as id_origen,r.rut_FK_lugar_destino as id_destino,lo.lug_nombre as nombre_origen,ld.lug_nombre as nombre_destino FROM Vuelo v, Ruta r, Lugar lo, Lugar ld WHERE v.vue_fk_ruta=r.rut_id AND r.rut_fk_lugar_origen = lo.lug_id AND r.rut_fk_lugar_destino = ld.lug_id AND r.rut_FK_lugar_origen=" + id_destino + "AND r.rut_FK_lugar_destino=" + id_origen + " AND v.vue_fecha_despegue >= '" + fecha_vuelta + "' AND v.vue_fecha_despegue <=  DATEADD(day, 1, '" + fecha_vuelta + "')";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Random rnd = new Random();

                        //Tengo que ver en cada vuelo que la cantidad de fk_vuelo en Boleto_Vuelo sea menor que la capacidad del tipo de boleto en el avion
                        int cant_bol_vue = 0;//Cantidad de fk_vuelo en Boleto_Vuelo
                        int cap = 0;//capacidad del tipo de boleto en el avión
                        //Si tipo de boleto = Turista entonces busco cap turista, si es ejecutivo cap ejecutivo y si es vip cap vip
                        //Obtengo el id del vuelo
                        System.Diagnostics.Debug.WriteLine("METODO DE LISTAR VUELOS IDA");

                        int id_vuelo = Int32.Parse(reader["id"].ToString());
                        System.Diagnostics.Debug.WriteLine("id vuelo: " + id_vuelo);

                        //Obtengo cantidad de fk_vuelo en Boleto_vuelo
                        cant_bol_vue = BuscarCantBolVue(id_vuelo);
                        System.Diagnostics.Debug.WriteLine("cantidad de fk_vuelo en Boleto_Vuelo: " + cant_bol_vue);

                        if (tipo.Equals("Turista"))
                        {


                            //Obtengo la capacidad del avion en clase Turista 
                            cap = MBuscarCapTurista(id_vuelo);


                        }
                        else if (tipo.Equals("Ejecutivo"))
                        {

                            //Obtengo la capacidad del avion en clase Ejecutivo 
                            cap = MBuscarCapEjecutivo(id_vuelo);

                        }
                        else if (tipo.Equals("Vip"))
                        {

                            //Obtengo la capacidad del avion en clase Vip 
                            cap = MBuscarCapVip(id_vuelo);

                        }

                        System.Diagnostics.Debug.WriteLine("Capacidad en tipo " + tipo + " : " + cap);

                        if (cant_bol_vue < cap)
                        {

                            CVuelo vuelo = new CVuelo(Int32.Parse(reader["id"].ToString()),
                                              reader.GetDateTime(reader.GetOrdinal("despegue")),
                                              reader.GetDateTime(reader.GetOrdinal("aterrizaje")),
                                              Int32.Parse(reader["id_ruta"].ToString()),
                                              Int32.Parse(reader["id_origen"].ToString()),
                                              Int32.Parse(reader["id_destino"].ToString()),
                                              reader.GetString(reader.GetOrdinal("nombre_origen")),
                                              reader.GetString(reader.GetOrdinal("nombre_destino")),
                                              rnd.Next(300, 1001), tipo, fecha_vuelta);

                            listavuelos.Add(vuelo);

                        }
                        else
                        {


                            System.Diagnostics.Debug.WriteLine("CAPACIDAD MAXIMA ALCANZADA EN EL AVION PARA BOLETOS DEL TIPO: " + tipo);


                        }
                    }
                }
                cmd.Dispose();
                con.Close();
                return listavuelos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }







        public List<CVuelo> M05ListarVuelosIdaBD(string fecha_ida, string fecha_vuelta, int id_origen, int id_destino, string tipo)
        {
            List<CVuelo> listavuelos = new List<CVuelo>();
            try
            {

                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();

                //Busco la capacidad del avion del vuelo, segun el tipo de boleto


                String sql = "SELECT v.vue_id as id,v.vue_fecha_despegue as despegue,v.vue_fecha_aterrizaje as aterrizaje,r.rut_id as id_ruta,r.rut_FK_lugar_origen as id_origen,r.rut_FK_lugar_destino as id_destino,lo.lug_nombre as nombre_origen,ld.lug_nombre as nombre_destino FROM Vuelo v, Ruta r, Lugar lo, Lugar ld WHERE v.vue_fk_ruta=r.rut_id AND r.rut_fk_lugar_origen = lo.lug_id AND r.rut_fk_lugar_destino = ld.lug_id AND r.rut_FK_lugar_origen=" + id_origen + "AND r.rut_FK_lugar_destino=" + id_destino + " AND v.vue_fecha_despegue >= '" + fecha_ida + "' AND v.vue_fecha_despegue <=  DATEADD(day, 1, '" + fecha_ida + "')";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Random rnd = new Random();

                        //Tengo que ver en cada vuelo que la cantidad de fk_vuelo en Boleto_Vuelo sea menor que la capacidad del tipo de boleto en el avion
                        int cant_bol_vue = 0;//Cantidad de fk_vuelo en Boleto_Vuelo
                        int cap = 0;//capacidad del tipo de boleto en el avión
                        //Si tipo de boleto = Turista entonces busco cap turista, si es ejecutivo cap ejecutivo y si es vip cap vip
                        //Obtengo el id del vuelo
                        System.Diagnostics.Debug.WriteLine("METODO DE LISTAR VUELOS IDA");

                        int id_vuelo = Int32.Parse(reader["id"].ToString());
                        System.Diagnostics.Debug.WriteLine("id vuelo: " + id_vuelo);

                        //Obtengo cantidad de fk_vuelo en Boleto_vuelo
                        cant_bol_vue = BuscarCantBolVue(id_vuelo);
                        System.Diagnostics.Debug.WriteLine("cantidad de fk_vuelo en Boleto_Vuelo: " + cant_bol_vue);

                        if (tipo.Equals("Turista"))
                        {


                            //Obtengo la capacidad del avion en clase Turista 
                            cap = MBuscarCapTurista(id_vuelo);


                        }
                        else if (tipo.Equals("Ejecutivo"))
                        {

                            //Obtengo la capacidad del avion en clase Ejecutivo 
                            cap = MBuscarCapEjecutivo(id_vuelo);

                        }
                        else if (tipo.Equals("Vip"))
                        {

                            //Obtengo la capacidad del avion en clase Vip 
                            cap = MBuscarCapVip(id_vuelo);

                        }

                        System.Diagnostics.Debug.WriteLine("Capacidad en tipo " + tipo + " : " + cap);

                        if (cant_bol_vue < cap)
                        {

                            CVuelo vuelo = new CVuelo(Int32.Parse(reader["id"].ToString()),
                                              reader.GetDateTime(reader.GetOrdinal("despegue")),
                                              reader.GetDateTime(reader.GetOrdinal("aterrizaje")),
                                              Int32.Parse(reader["id_ruta"].ToString()),
                                              Int32.Parse(reader["id_origen"].ToString()),
                                              Int32.Parse(reader["id_destino"].ToString()),
                                              reader.GetString(reader.GetOrdinal("nombre_origen")),
                                              reader.GetString(reader.GetOrdinal("nombre_destino")),
                                              rnd.Next(300, 1001), tipo, fecha_vuelta);

                            listavuelos.Add(vuelo);

                        }
                        else
                        {


                            System.Diagnostics.Debug.WriteLine("CAPACIDAD MAXIMA ALCANZADA EN EL AVION PARA BOLETOS DEL TIPO: " + tipo);


                        }
                    }
                }
                cmd.Dispose();
                con.Close();
                return listavuelos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        //Procedimiento del Modulo 5 para buscar las ciudades
        public List<CLugar> buscarCiudades()
        {
            List<CLugar> ciudades = new List<CLugar>();

            string queryString = "SELECT [lug_id] ,[lug_nombre] FROM [dbo].[Lugar] WHERE [lug_tipo_lugar] = 'ciudad'";

            using (SqlConnection connection = new SqlConnection(stringDeConexion))
            using (SqlCommand cmd = new SqlCommand(queryString, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            var text = reader.GetString(reader.GetOrdinal("lug_nombre"));
                            var id = reader.GetInt32(reader.GetOrdinal("lug_id"));
                            ciudades.Add(new CLugar(id.ToString(), text));
                        }

                    }
                }
            }
            return ciudades;
            }

        public List<CBoleto> M05ListarBoletosBD()
        {
            List<CBoleto> listaboletos = new List<CBoleto>();
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT * FROM Boleto";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["bol_fecha"];
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                        CBoleto boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()),Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                               MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                               MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                               Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                               reader["bol_tipo_boleto"].ToString(),
                                               MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                con.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }


        public List<CBoleto> M05ListarReservasPasajeroBD(int pasaporte)
        {
            List<CBoleto> listaboletos = new List<CBoleto>();
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "SELECT reb_id,reb_fecha_reservado,reb_ida_vuelta,reb_escala,reb_costo,fk_origen,fk_destino,fk_pas_id,reb_tipo,reb_codigo FROM Reserva_Boleto WHERE fk_pas_id=" + pasaporte;
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        var fecha = reader["reb_fecha_reservado"];
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                        CBoleto boleto = new CBoleto(Int32.Parse(reader["reb_id"].ToString()), Int32.Parse(reader["reb_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["reb_escala"].ToString()), double.Parse(reader["reb_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["fk_destino"].ToString())),
                                               MBuscarnombrepasajero(Int32.Parse(reader["fk_pas_id"].ToString())),
                                               MBuscarapellidopasajero(Int32.Parse(reader["fk_pas_id"].ToString())), fechaboleto,
                                               Int32.Parse(reader["fk_pas_id"].ToString()), reader.GetInt32(reader.GetOrdinal("fk_origen")).ToString(),
                                               reader.GetInt32(reader.GetOrdinal("fk_destino")).ToString(),
                                               reader["reb_tipo"].ToString(),
                                               MBuscarcorreopasajero(Int32.Parse(reader["fk_pas_id"].ToString())),
                                               reader["reb_codigo"].ToString());


                        System.Diagnostics.Debug.WriteLine("procedimiento LISTAR VUELOS DE LA RESERVA");
                        System.Diagnostics.Debug.WriteLine("el id de la reserva es: " + (int)reader["reb_id"]);
                        List<CVuelo> listavuelos = M05ListarVuelosReserva((int)reader["reb_id"]);


                        boleto._vuelos = listavuelos;


                        listaboletos.Add(boleto);
                    }
                }
                cmd.Dispose();
                con.Close();
                return listaboletos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
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
            catch (SqlException ex)
            {
                return _ciudad;
            }
        }

        public String MBuscarnombrepasajero(int id)
        {
            String _nombre = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
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
            catch (SqlException ex)
            {
                return _nombre;
            }
        }

        public String MBuscarapellidopasajero(int id)
        {
            String _apellido = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
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
            catch (SqlException ex)
            {
                return _apellido;
            }
        }

        public String MBuscarcorreopasajero(int id)
        {
            String _correo = "";
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
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

        public CPasajero MBuscarDatosPasajero(int id)
        {
            CPasajero pas = null;
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
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
                        pas = new CPasajero (Int32.Parse(reader["pas_id"].ToString()), reader["pas_primer_nombre"].ToString(),
                                             reader["pas_segundo_nombre"].ToString(), reader["pas_primer_apellido"].ToString(),
                                             reader["pas_segundo_apellido"].ToString(), reader["pas_sexo"].ToString(),
                                             fechanac,reader["pas_correo"].ToString());
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


       public int M05ModificarDatosPasajero(CPasajero pasajero)
       {
           int idaaaa = pasajero._id;
           String va = pasajero._primer_nombre;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "UPDATE Pasajero SET pas_primer_nombre = '"+ pasajero._primer_nombre+"' , pas_segundo_nombre = '" + pasajero._segundo_nombre + "' , pas_primer_apellido = '" + pasajero._primer_apellido +"' , pas_segundo_apellido = '" + pasajero._segundo_apellido + "' , pas_correo = '" + pasajero._correo + "' WHERE pas_id = " + pasajero._id + "";

               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();
               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public CBoleto M05MostrarBoletoBD(int id)
       {
           CBoleto boleto = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT * FROM Boleto WHERE bol_id = " + id + "";

               // FALTA OBTENER EL/LOS VUELOS DE ESE BOLETO
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {

                   while (reader.Read())
                   {
                       var fecha = reader["bol_fecha"];
                       List<CVuelo> lista= M05ListarVuelosBoleto(id);
                       CPasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("bol_fk_pasajero")));
                       DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                       boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                              Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())), fechaboleto,
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                              reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                              reader["bol_tipo_boleto"].ToString());
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

        //Recibe el id de la reserva seleccionada e la tabla
       public CBoleto M05MostrarReservaBD(int id_reserva)
       {
           //Es CBoleto ya que tiene los mismos atributos que la reserva
           CBoleto boleto = null;

           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
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
                       List<CVuelo> lista = M05ListarVuelosReserva(id_reserva);
                       CPasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("fk_pas_id")));
                       DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                       boleto = new CBoleto(Int32.Parse(reader["reb_id"].ToString()), Int32.Parse(reader["reb_ida_vuelta"].ToString()),
                                              Int32.Parse(reader["reb_escala"].ToString()), double.Parse(reader["reb_costo"].ToString()),
                                              MBuscarnombreciudad(Int32.Parse(reader["fk_origen"].ToString())),
                                              MBuscarnombreciudad(Int32.Parse(reader["fk_destino"].ToString())), fechaboleto,
                                              reader.GetInt32(reader.GetOrdinal("fk_origen")).ToString(),
                                              reader.GetInt32(reader.GetOrdinal("fk_destino")).ToString(),
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

       public CVuelo MBuscarDatosVuelo(int id)
       {
           CVuelo vuelo = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT vue_fecha_despegue, vue_fecha_aterrizaje, vue_fk_ruta FROM Vuelo WHERE vue_id ="+id+"";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CRuta rut = MBuscarDatosRuta(Int32.Parse(reader["vue_fk_ruta"].ToString()));

                       vuelo = new CVuelo(id, reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue")),
                                          reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje")),
                                          Int32.Parse(reader["vue_fk_ruta"].ToString()),
                                          rut._origen, rut._destino, rut._nomOrigen,rut._nomDestino);
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

       public CRuta MBuscarDatosRuta(int id)
       {
           CRuta ruta = null;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT rut_FK_lugar_origen, rut_FK_lugar_destino FROM Ruta WHERE rut_id =" + id + "";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       ruta = new CRuta(id, Int32.Parse(reader["rut_FK_lugar_origen"].ToString()), Int32.Parse(reader["rut_FK_lugar_destino"].ToString()),
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

       public String MBuscarTipoBoletoOriginal(int id)
       {
           String tipo = "";
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT bol_tipo_boleto FROM Boleto WHERE bol_id =" + id + "";
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       tipo = reader["bol_tipo_boleto"].ToString();
                   }
               }
               cmd.Dispose();
               con.Close();
               return tipo;
           }
           catch (SqlException ex)
           {
               return tipo;
           }
       }


       public List<CVuelo> M05ListarVuelosBoleto(int id_boleto)
       {
           List<CVuelo> listavuelos = new List<CVuelo>();
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT bol_fk_vuelo FROM Boleto_Vuelo WHERE bol_fk_boleto ="+id_boleto+"";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["bol_fk_vuelo"].ToString()));
                       listavuelos.Add(datosVuelo);
                   }
               }
               cmd.Dispose();
               con.Close();
               int  inte = listavuelos.Count;
               return listavuelos;
           }
           catch (SqlException ex)
           {
               return null;
           }
       }

        //OBTENGO LOS VUELOS DE LA RESERVA, EN LA TABLA RESERVA_VUELO CON EL ID DE LA RESERVA
       public List<CVuelo> M05ListarVuelosReserva(int id_reserva)
       {
           List<CVuelo> listavuelos = new List<CVuelo>();
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT fk_vue_id FROM Reserva_Vuelo WHERE fk_reb_id =" + id_reserva;
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       CVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["fk_vue_id"].ToString()));
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




       public int M05EliminarBoletoBD(int id)
       {
            try
            {
                SqlConnection con = new SqlConnection(stringDeConexion);
                con.Open();
                String sql = "DELETE FROM Boleto WHERE bol_id = "+id+"";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        }

        public int MConteoTurista(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num "+
                            "FROM Boleto_Vuelo B, Boleto C "+
                            "WHERE B.bol_fk_vuelo = "+id+
                            " AND C.bol_id = B.bol_fk_boleto "+
                            "AND UPPER(C.bol_tipo_boleto) = UPPER('Turista')";
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

       public int MConteoEjecutivo(int id)
       {
           int _conteo = 0;
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();
               String sql = "SELECT COUNT(*) AS num " +
                            "FROM Boleto_Vuelo B, Boleto C " +
                            "WHERE B.bol_fk_vuelo = " + id +
                            " AND C.bol_id = B.bol_fk_boleto " +
                            "AND UPPER(C.bol_tipo_boleto) = UPPER('Ejecutivo')";
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

       public int MConteoVip(int id)
      {
          int _conteo = 0;
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "SELECT COUNT(*) AS num " +
                           "FROM Boleto_Vuelo B, Boleto C " +
                           "WHERE B.bol_fk_vuelo = " + id +
                           " AND C.bol_id = B.bol_fk_boleto " +
                           "AND UPPER(C.bol_tipo_boleto) = UPPER('Vip')";
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



       public int M05CrearBoletoReservaBD(int escala,int idaVuelta,int costo,int fkOrigen,int fkDestino,int fkPasajero,string fecha,string tipo,int id_vuelo)
       {
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();



               String sql = "INSERT INTO Boleto (bol_escala,bol_ida_vuelta,bol_costo,bol_fk_lugar_origen,bol_fk_lugar_destino,bol_fk_pasajero,bol_fecha,bol_tipo_boleto) VALUES("+escala+","+idaVuelta+","+costo+","+fkOrigen+","+fkDestino+","+fkPasajero+",'"+fecha+"','"+tipo+"')";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               //Inserto en tabla n a n Reserva_Vuelo
               InsertarEnBoleto_Vuelo(id_vuelo);
               cmd.Dispose();
               con.Close();




               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public void InsertarEnBoleto_Vuelo(int id_vuelo)
       {
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();

               int id_boleto = BuscarUltimoIdBoleto();
               String sql = "INSERT INTO Boleto_Vuelo (bol_fk_boleto,bol_fk_vuelo) VALUES(" + id_boleto + "," + id_vuelo + ")";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();

           }
           catch (SqlException ex)
           {

           }
       }

       public int BuscarUltimoIdBoleto()
       {
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();

               //Busco el id del último boleto que ingresé en la bd


               String sql = "SELECT top 1 bol_id AS idboleto FROM Boleto order by bol_id desc";

               var id_boleto = 0;
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {

                       id_boleto = (Int32.Parse(reader["idboleto"].ToString()));
                   }
               }
               cmd.Dispose();
               con.Close();

               System.Diagnostics.Debug.WriteLine("El ultimo id de la tabla Boleto es: "+ id_boleto);
               return id_boleto;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public int CrearPasajero(int pasaporte,string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string fecha_nac, string sexo, string correo)
       {
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();

               System.Diagnostics.Debug.WriteLine("INSERTANDO EN PASAJERO");

               String sql = "INSERT INTO Pasajero (pas_id,pas_primer_nombre,pas_segundo_nombre,pas_primer_apellido,pas_segundo_apellido,pas_fecha_nacimiento,pas_sexo,pas_correo) VALUES("+pasaporte+",'" + primer_nombre + "','" + segundo_nombre + "','" + primer_apellido + "','" + segundo_apellido + "','" + fecha_nac + "','" + sexo + "','" + correo+ "')";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               cmd.Dispose();
               con.Close();




               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }



       public int M05CrearBoletoBD(int monto, int idorigen, int iddestino, int pasaporte, string fecha, string tipo, int idvuelo)
       {
           try
           {
               SqlConnection con = new SqlConnection(stringDeConexion);
               con.Open();



               String sql = "INSERT INTO Boleto (bol_escala,bol_ida_vuelta,bol_costo,bol_fk_lugar_origen,bol_fk_lugar_destino,bol_fk_pasajero,bol_fecha,bol_tipo_boleto) VALUES(0,1," + monto + "," + idorigen + "," + iddestino + "," + pasaporte + ",'" + fecha + "','" + tipo + "')";
               System.Diagnostics.Debug.WriteLine(sql);
               SqlCommand cmd = new SqlCommand(sql, con);
               cmd.ExecuteNonQuery();
               //Inserto en tabla n a n Reserva_Vuelo
               InsertarEnBoleto_Vuelo(idvuelo);
               cmd.Dispose();
               con.Close();




               return 1;
           }
           catch (SqlException ex)
           {
               return 0;
           }
       }

       public int MBuscarIdaVuelta(int id)
      {
          int _conteo = 0;
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
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

      public int MBuscarCapTurista(int id)
      {
          int _conteo = 0;
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "SELECT A.avi_pasajeros_turista num " +
                           "FROM Vuelo V, Avion A " +
                           "WHERE V.vue_id =" +id+
                           " AND V.vue_fk_avion = A.avi_id";
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

      public int MBuscarCapEjecutivo(int id)
      {
          int _conteo = 0;
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "SELECT A.avi_pasajeros_ejecutiva num " +
                           "FROM Vuelo V, Avion A " +
                           "WHERE V.vue_id =" + id +
                           " AND V.vue_fk_avion = A.avi_id";
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

      public int MBuscarCapVip(int id)
      {
          int _conteo = 0;
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "SELECT A.avi_pasajeros_vip num " +
                           "FROM Vuelo V, Avion A " +
                           "WHERE V.vue_id =" + id +
                           " AND V.vue_fk_avion = A.avi_id";
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

      public int M05ModificarTipoBoleto(int id_bol, String tipo)
      {

          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "UPDATE Boleto SET bol_tipo_boleto = '" + tipo + "' WHERE bol_id = " + id_bol +"";

              SqlCommand cmd = new SqlCommand(sql, con);
              cmd.ExecuteNonQuery();
              cmd.Dispose();
              con.Close();
              return 1;
          }
          catch (SqlException ex)
          {
              return 0;
          }
      }

      public List<CBoleto> M05ListarBoletosPasajero(int id)
      {
          List<CBoleto> listaboletos = new List<CBoleto>();
          try
          {
              SqlConnection con = new SqlConnection(stringDeConexion);
              con.Open();
              String sql = "SELECT * FROM Boleto WHERE bol_fk_pasajero = " + id + "";
              SqlCommand cmd = new SqlCommand(sql, con);
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                  while (reader.Read())
                  {
                      var fecha = reader["bol_fecha"];
                      DateTime fechaboleto = Convert.ToDateTime(fecha).Date;
                      CBoleto boleto = new CBoleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                             Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                             MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                             MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())),
                                             MBuscarnombrepasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())),
                                             MBuscarapellidopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())), fechaboleto,
                                             Int32.Parse(reader["bol_fk_pasajero"].ToString()), reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")).ToString(),
                                             reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")).ToString(),
                                             reader["bol_tipo_boleto"].ToString(),
                                             MBuscarcorreopasajero(Int32.Parse(reader["bol_fk_pasajero"].ToString())));
                      listaboletos.Add(boleto);
                  }
              }
              cmd.Dispose();
              con.Close();
              return listaboletos;
          }
          catch (SqlException ex)
          {
              return null;
          }
      }




    }
}
