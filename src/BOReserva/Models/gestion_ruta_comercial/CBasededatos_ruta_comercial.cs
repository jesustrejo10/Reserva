using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ruta_comercial
{
    public class CBasededatos_ruta_comercial
    {
        //private String connetionString = @"Data Source=LUISALEJANDROPE\LAPGROCK;Initial Catalog=proyds1617;Integrated Security=True"; //No supe cual es el string de conexion jejejeps
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


        /*public int MModificarVehiculoBD(CAutomovil vehiculo)
        {
            int fk_ciudad = MBuscarfkciudad(vehiculo._ciudad, vehiculo._pais);
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "UPDATE Automovil SET aut_modelo ='" + vehiculo._modelo + "', aut_fabricante = '" + vehiculo._fabricante + "', aut_anio = " + vehiculo._anio + ", aut_kilometraje = " + vehiculo._kilometraje + ", aut_cantpasajeros = " + vehiculo._cantpasajeros + ", aut_tipovehiculo = '" + vehiculo._tipovehiculo +
                    "', aut_preciocompra = " + vehiculo._preciocompra + ", aut_precioalquiler = " + vehiculo._precioalquiler + ", aut_penalidaddiaria = " + vehiculo._penalidaddiaria + ", aut_fecharegistro = '" + vehiculo._fecharegistro + "', aut_color = '" + vehiculo._color + "', aut_transmision = '" + vehiculo._transmision + "', aut_fk_ciudad = " + fk_ciudad + 
                    " WHERE aut_matricula = '"+vehiculo._matricula+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                con.Close();
                return 0;
            }
        }*/


        public List<CRuta> MListarRutasBD()
        {
            List<CRuta> listarutas = new List<CRuta>();
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                String sql = "SELECT a.lug_nombre AS NOrigen,b.lug_nombre AS NDestino,r.rut_tipo_ruta AS TRuta,r.rut_distancia AS DRuta,r.rut_status_ruta AS SRuta FROM Ruta r, Lugar a, Lugar b WHERE r.rut_FK_lugar_origen=a.lug_id AND r.rut_FK_lugar_destino=b.lug_id";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                   while (reader.Read()) {
                       //SE AGREGA CREA UN OBJECTO VEHICLE SE PASAN LOS ATRIBUTO ASI reader["<etiqueta de la columna en la tabla Automovil>"]
                       //Y  SE AGREGA a listavehiculos
                       CRuta ruta = new CRuta(reader["NOrigen"].ToString(), reader["NDestino"].ToString(), reader["SRuta"].ToString(),
                                              reader["TRuta"].ToString(),Int32.Parse(reader["DRuta"].ToString()));
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


        
        
    }
}