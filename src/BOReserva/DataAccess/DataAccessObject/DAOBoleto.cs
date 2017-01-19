using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


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

        int IDAO.Eliminar(int id) {
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
    }
}