using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using FOReserva.Models.Itinerario;
using System.Globalization;

namespace FOReserva.Servicio
{
    public class ManejadorSQLItinerario
    {
        public string stringDeConexion;

        public ManejadorSQLItinerario()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }

        //Procedimiento para traer la lista de lugares destino de usuario
        public List<String> listarLugares()
        {
            List<String> lugares = new List<String>();
            String lugar;
           
            try
            {
                SqlConnection connection = new SqlConnection(stringDeConexion);
                //SE INTENTA ABRIR LA CONEXION
                connection.Open();
                //String queryString = "SELECT LU.lug_nombre AS ciudad, V.VUE_FECHA_DESPEGUE as ida, V.VUE_FECHA_ATERRIZAJE as vuelta, BOL.BOL_ID as boleto FROM BOLETO BOL, Lugar LU, PASAJERO PAS, Usuario US, VUELO V, BOLETO_VUELO BV WHERE BOL.BOL_FK_LUGAR_DESTINO=LU.lug_id and BOL.BOL_FK_PASAJERO=PAS.PAS_ID and PAS.PAS_CORREO = US.usu_correo and BV.BOL_FK_BOLETO = BOL.BOL_ID AND	Bv.BOL_FK_VUELO = V.VUE_ID AND PAS.pas_id=19720982";
                String queryString = "SELECT  L.LUG_NOMBRE AS ciudad, I.ICRU_FECHA_INICIO AS ida, I.ICRU_FECHA_FIN AS vuelta,RU.RUT_TIPO_RUTA AS ruta, R.RC_ID AS boleto FROM RESERVA_CRUCERO R, ITINERARIO_CRUCERO I, RUTA RU, LUGAR L WHERE R.FK_USUARIO=1 AND R.FK_FECHA=I.ICRU_FECHA_INICIO AND I.ICRU_FK_RUTA=RU.RUT_ID AND RU.RUT_FK_LUGAR_DESTINO=L.LUG_ID AND RU.RUT_ID=R.FK_RUTA UNION SELECT L.LUG_NOMBRE AS ciudad, V.VUE_FECHA_DESPEGUE AS ida, V.VUE_FECHA_ATERRIZAJE AS vuelta, RU.RUT_TIPO_RUTA AS ruta, B.BOL_ID AS boleto FROM BOLETO B, BOLETO_VUELO BV, VUELO V, PASAJERO P, USUARIO U, LUGAR L, RUTA RU WHERE B.BOL_FK_LUGAR_DESTINO=L.LUG_ID AND BV.BOL_FK_BOLETO=B.BOL_ID AND BV.BOL_FK_VUELO=V.VUE_ID AND B.BOL_FK_PASAJERO=P.PAS_ID AND P.PAS_CORREO = U.USU_CORREO	AND	V.VUE_FK_RUTA=RU.RUT_ID AND U.USU_ID= 1";
                    SqlCommand cmd = new SqlCommand(queryString, connection);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    lugar = lector["ciudad"].ToString() + "-" + lector["ida"].ToString() + "-" + lector["vuelta"].ToString() + "-" + lector["ruta"].ToString() + "-" + lector["boleto"].ToString(); 
                    lugares.Add(lugar);
                }
                //CERRAR LECTOR
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                connection.Close();
                return (lugares);

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
      //LISTA DE FECHAS LLENADA A PARTIR DEL DESTINO SELECCIONADO
        public List<String> consultarFechas(String origen)
        {
            String[] origen1 = origen.Split('-');
            String origen2 = origen1[0];
            var lugares = new List<String>();
            String lugar;
            String lugar2;
            String[] lugar3;
            String[] lugar4;
            try
            {
                //INICIALIZACION DE CONEXION
                SqlConnection connection = new SqlConnection(stringDeConexion);
                //ABRIR CONEXION
                connection.Open();
                //String queryString = "SELECT V.VUE_FECHA_DESPEGUE as ciudad, V.VUE_FECHA_ATERRIZAJE as ciudad2 FROM BOLETO BOL, Lugar LU, PASAJERO PAS, Usuario US, VUELO V, BOLETO_VUELO BV WHERE BOL.BOL_FK_LUGAR_DESTINO=LU.lug_id and BOL.BOL_FK_PASAJERO=PAS.PAS_ID and PAS.PAS_CORREO = US.usu_correo and BV.BOL_FK_BOLETO = BOL.BOL_ID AND Bv.BOL_FK_VUELO = V.VUE_ID AND PAS.pas_id=19720982 and lu.lug_nombre like ('%"+origen2+"%')";
                String queryString = "SELECT  I.ICRU_FECHA_INICIO AS ciudad, I.ICRU_FECHA_FIN AS ciudad2 FROM RESERVA_CRUCERO R, ITINERARIO_CRUCERO I, RUTA RU, LUGAR L WHERE R.FK_USUARIO=1 AND R.FK_FECHA=I.ICRU_FECHA_INICIO AND I.ICRU_FK_RUTA=RU.RUT_ID AND RU.RUT_FK_LUGAR_DESTINO=L.LUG_ID AND RU.RUT_ID=R.FK_RUTA AND L.LUG_NOMBRE LIKE ('%" + origen2 + "%') UNION SELECT V.VUE_FECHA_DESPEGUE AS ciudad, V.VUE_FECHA_ATERRIZAJE AS ciudad2 FROM BOLETO B, BOLETO_VUELO BV, VUELO V, PASAJERO P, USUARIO U, LUGAR L, RUTA RU WHERE B.BOL_FK_LUGAR_DESTINO=L.LUG_ID AND BV.BOL_FK_BOLETO=B.BOL_ID AND BV.BOL_FK_VUELO=V.VUE_ID AND B.BOL_FK_PASAJERO=P.PAS_ID AND P.PAS_CORREO = U.USU_CORREO AND V.VUE_FK_RUTA=RU.RUT_ID AND U.USU_ID= 1 AND L.LUG_NOMBRE LIKE ('%" + origen2 + "%')";


                SqlCommand cmd = new SqlCommand(queryString, connection);
                SqlDataReader lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    //SE TRAE TODO LO DE LA CONSULTA
                    lugar = lector["ciudad"].ToString();
                    lugar2 = lector["ciudad2"].ToString();
                    //SEPARAMOS CADA ATRIBUTO
                    lugar3 = lugar.Split(' ');
                    lugar4 = lugar2.Split(' ');
                    //SE CONCATENAN PARA QUE SALGA EN EL DROPDOWNLIST
                    String lugar5 = lugar3[0] + "-" + lugar4[0];
                   // AGARRAS CADA UNO
                    string strDate = lugar3[0];
                    string strDate2 = lugar4[0];
                    //LA PASAMOS A DATE PARA RESTARLAS
                    DateTime FECHA1 = DateTime.ParseExact(strDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime FECHA2 = DateTime.ParseExact(strDate2, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    TimeSpan ts = FECHA2 - FECHA1;
                    //SE RESTAN LOS DIAS 
                    int differenceInDays = ts.Days;
                    String dias = differenceInDays.ToString();
                    int diasfinal = Int32.Parse(dias);
                    if (diasfinal < 1){
                        String numero = "1";
                        lugares.Add(numero);
                    }
                    else
                    for (int i = 1; i <= diasfinal; i++)
                    {
                        //SE PASA A STRING PARA DEVOLVERLO A LA LISTA
                        String i2 = i.ToString();
                        lugares.Add(i2);
                    } }
                //cierro el lector
                lector.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                connection.Close();
                return lugares;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                throw e;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                throw e;
            }
        }
//SE INSERTA LA ACTIVIDAD PARTIENDO DE LO SELECCIONADO EN LOS DROPDOWNLIST
        public Boolean insertarItinerario(Cvista_Itinerario model)
        {
            try
            {
                if (model._actividad == null) 
                {
                    return false;
                }
                    SqlConnection connection = new SqlConnection(stringDeConexion);
                    //Inicializo la conexion con el string de conexion
                    connection = new SqlConnection(stringDeConexion);
                    //INTENTO abrir la conexion
                    connection.Open();
                    //uso el SqlCommand para realizar los querys
                    SqlCommand query = connection.CreateCommand();
                    String[] prueba = model._ciudad.Split('-');
                    String pasar = prueba[4];
                    int pasar2 = Int32.Parse(pasar);
                    String tipo = prueba[3];
                    if ((tipo == "maritimo") || (tipo == "Maritimo") || (tipo == "maritima") || (tipo == "Maritima")) 
                    { 
                    //INSERTA EN LA BD
                    query.CommandText = "INSERT INTO Itinerario_Vac VALUES ('" + model._fecha + "','" + model._actividad + "',null,'" + pasar2 + "');";
                    }
                    else
                    {
                    query.CommandText = "INSERT INTO Itinerario_Vac VALUES ('" + model._fecha + "','" + model._actividad + "','" + pasar2 + "',null);";
                    }
                    //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                    SqlDataReader lector = query.ExecuteReader();
                    //cierro el lector
                    lector.Close();
                    // CERRAR LA CONEXION
                    connection.Close();
                    return true;
                }
            
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }

        }
//ELIMINA UN ITINERARIO
                public Boolean eliminarItinerario(Cvista_Itinerario model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(stringDeConexion);
                //Inicializo la conexion con el string de conexion
                connection = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                connection.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = connection.CreateCommand();
                String[] prueba = model._ciudad.Split('-');
                String pasar = prueba[4];
                int pasar2 = Int32.Parse(pasar);
                String tipo = prueba[3];
                if ((model._actividad == null))
                {
                    return false;
                }
                else
                {

                    if ((tipo == "maritimo") || (tipo == "Maritimo") || (tipo == "maritima") || (tipo == "Maritima")) 
                    {
                        //INSERTA EN LA BD
                        query.CommandText = "DELETE FROM Itinerario_Vac WHERE itiv_dia='" + model._fecha + "' and itiv_fk_crucero = '" + pasar2 + "'";
                    }
                    else
                    {
                        query.CommandText = "DELETE FROM Itinerario_Vac WHERE itiv_dia='" + model._fecha + "' and itiv_fk_boleto = '" + pasar2 + "'";
                        
                    }
                    
                    
                    //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                    SqlDataReader lector = query.ExecuteReader();
                    lector.Close();
                    connection.Close();
                    return true;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }

        }
        // SE MODIFICA EL ITINERARIO
         public Boolean modificarItinerario(Cvista_Itinerario model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(stringDeConexion);
                //Inicializo la conexion con el string de conexion
                connection = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                connection.Open();
                //uso el SqlCommand para realizar los querys
                SqlCommand query = connection.CreateCommand();
                String[] prueba = model._ciudad.Split('-');
                String pasar = prueba[4];
                int pasar2 = Int32.Parse(pasar);
                String tipo = prueba[3];
                if ((model._actividad == null) || (model._actividad.Contains("select")) || (model._actividad.Contains("Select")) ||
                (model._actividad.Contains("SELECT")) || (model._actividad.Contains("update")) || (model._actividad.Contains("UPDATE")) ||
                (model._actividad.Contains("Update")) || (model._actividad.Contains("INSERT")) || (model._actividad.Contains("insert")) ||
                (model._actividad.Contains("Insert")) || (model._actividad.Contains("Delete")) || (model._actividad.Contains("delete")) ||
                 (model._actividad.Contains("DELETE")))
                {
                    return false;
                }
                else
                {

                    if ((tipo == "maritimo") || (tipo == "Maritimo") || (tipo == "maritima") || (tipo == "Maritima")) 
                    {
                        //INSERTA EN LA BD
                        query.CommandText = "UPDATE Itinerario_Vac SET itiv_actividad='" + model._actividad + "' WHERE (itiv_dia='" + model._fecha + "' and itiv_fk_crucero='" + pasar2 + "')";
                    }
                    else
                    {
                        query.CommandText = "UPDATE Itinerario_Vac SET itiv_actividad='" + model._actividad + "' WHERE (itiv_dia='" + model._fecha + "' and itiv_fk_boleto='" + pasar2 + "')";

                    }
                    SqlDataReader lector = query.ExecuteReader();
                    lector.Close();

                    connection.Close();
                    return true;
                }
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                return false;
            }
        }

         public String buscarActividad(string boleto, string dia)
         {
             string actividad = null;
             try
             {
                 //Inicializo la conexion con el string de conexion
                 //  con = new SqlConnection(connectionString);
                 SqlConnection connection = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 //con.Open();
                 connection.Open();
                 SqlCommand query = connection.CreateCommand();
                 //String queryString = "SELECT l.lug_nombre as ciudad, ll.lug_nombre as pais from Lugar l, Lugar ll where l.lug_FK_lugar_id = ll.lug_id  and l.lug_nombre != '" + strOri[0] + "'";
                 String[] prueba = boleto.Split('-');
                 String pasar = prueba[4];
                 int pasar2 = Int32.Parse(pasar);
                 String tipo = prueba[3];
                 if ((tipo == "maritimo") || (tipo == "Maritimo") || (tipo == "maritima") || (tipo == "Maritima")) 
                 {
                     //INSERTA EN LA BD
                     query.CommandText = "SELECT ITIV_ACTIVIDAD FROM ITINERARIO_VAC WHERE ITIV_DIA ='" + dia + "' AND ITIV_FK_CRUCERO='" + pasar2 + "'";
                 }
                 else
                 {
                     query.CommandText = "SELECT ITIV_ACTIVIDAD FROM ITINERARIO_VAC WHERE ITIV_DIA ='" + dia + "' AND ITIV_FK_BOLETO='" + pasar2 + "'";

                 }

                // String queryString = "SELECT ITIV_ACTIVIDAD FROM ITINERARIO_VAC WHERE ITIV_DIA ='" + dia + "' AND ITIV_FK_BOLETO='" + pasar2 + "'";
                 //SqlCommand cmd = new SqlCommand(query, connection);
                 //SqlCommand cmd = new SqlCommand(queryString, connection);
                 SqlDataReader lector = query.ExecuteReader();
                 List<CItinerario> lista = new List<CItinerario>();
                 while (lector.Read())
                 {
                     actividad = lector.GetString(0);
                     //CItinerario activo = new CItinerario();
                     //activo._actividad = actividad;
                     //lista.Add(activo);
                     return actividad;
                 }
                 //cierro el lector
                 lector.Close();
                 //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                 connection.Close();
                 return actividad;
             }
             catch (SqlException e)
             {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                throw e;
             }
             catch (Exception e)
             {
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.Message);
                System.Diagnostics.Debug.WriteLine("ERROR -------->" + e.StackTrace);
                throw e;
             }
         }
    }
}
