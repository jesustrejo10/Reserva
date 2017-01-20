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
    public class DAOCabina : DAO, IDAOCabina
    {
        int IDAO.Agregar(Entidad e)
        {
            Cabina cabina = (Cabina)e;
            SqlConnection con = Connection.getInstance(_connexionString);
            try
            {
                con.Open();

                SqlCommand query = new SqlCommand("M24_AgregarCabina", con);

                query.CommandType = CommandType.StoredProcedure;

                query.Parameters.AddWithValue("@nombrecabina", cabina._nombreCabina);
                query.Parameters.AddWithValue("@precio", cabina._precioCabina);
                query.Parameters.AddWithValue("@fk_id_crucero", cabina._fkCrucero);
                

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