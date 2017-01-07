using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DAO
{
    public class DAOReclamo : DAO, IDAOReclamo
    {
        public DAOReclamo() {}




        int IDAO.Agregar(Entidad e)
        {

            Reclamo reclamo = (Reclamo)e;
            // SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                //    conexion.Open();
                //String sql = "INSERT INTO Reclamo" +
                //                   "(rec_id, rec_titulo, rec_detalle, rec_fecha, rec_estado, rec_fk_usuario) " +
                //                 "VALUES (NEXT VALUE FOR reclamo_sequence,'" + rec._nombre + "','" +  + ",0,1,15);";


                // Debug.WriteLine(sql);
                //SqlCommand cmd = new SqlCommand(sql, conexion);
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();
                //conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                // Debug.WriteLine("ENTRO EN EL CATCH");
                //Debug.WriteLine(ex.ToString());
                //  conexion.Close();
                return 0;
            }
        }

        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }
    }
}