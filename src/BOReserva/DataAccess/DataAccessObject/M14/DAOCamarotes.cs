using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M14;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M14
{
    public class DAOCamarotes : DAO, IDAOCamarote
    {
        int IDAO.Agregar(Entidad e) {
            Camarote camarote = (Camarote)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCamarote", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@cantidad_camas", camarote._cantidadCama);
                query.Parameters.AddWithValue("@tipo_cama", camarote._tipoCama);
                query.Parameters.AddWithValue("@cabina", camarote._nombreCabina);


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