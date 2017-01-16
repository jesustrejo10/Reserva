using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOCruceros : DAO, IDAOCruceros
    {
        public DAOCruceros()
        { }

        int IDAO.Agregar(Entidad e)
        {
            Crucero crucero = (Crucero)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCrucero", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nombrecrucero", crucero._nombreCrucero);
                query.Parameters.AddWithValue("@compania", crucero._companiaCrucero);
                query.Parameters.AddWithValue("@capacidad", crucero._capacidadCrucero);
                query.Parameters.AddWithValue("@imagen", "");
                
                /*
                query.Parameters.Add("@ciudadOrigenRuta", SqlDbType.VarChar).Value = strOri[0];
                query.Parameters.Add("@paisOrigenRuta", SqlDbType.VarChar).Value = strOri[1];
                query.Parameters.Add("@ciudadDestinoRuta", SqlDbType.VarChar).Value = strDes[0];
                query.Parameters.Add("@paisDestinoRuta", SqlDbType.VarChar).Value = strDes[1];
                query.Parameters.Add("@tipoRuta", SqlDbType.VarChar).Value = model._tipoRuta;
                query.Parameters.Add("@estadoRuta", SqlDbType.VarChar).Value = model._estadoRuta;
                query.Parameters.Add("@distanciaRuta", SqlDbType.Int).Value = model._distanciaRuta;
                 */

                query.ExecuteNonQuery();
                
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader lector = query.ExecuteReader();
                lector.Close();                
                con.Close();
                return 1;
            }
            catch (SqlException ex)
            {                
                Debug.WriteLine(ex.ToString());
                con.Close();
                return 0;
            }
        }

    }
}