using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.DataAccess.DataAccessObject;
using System.Data.SqlClient;
using System.Diagnostics;
using FOReserva.Models.Diarios;
namespace FOReserva.DataAccess.DataAccessObject
{
    public class DAODiario :  DAO, IDAODiario
    {
        int IDAO.Agregar(Entidad e)
        {
            CDiarioModel nDiar = (CDiarioModel)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = @"INSERT INTO Diario_Viaje
            (nombre_diario,fecha_ini_diar,descripcion_diar,
            fecha_carga_diar,calif_creador,rating,num_visita
            ,fk_usuario_id,fecha_fin_diar,fk_destino) 
            OUTPUT Inserted.id_diar
            VALUES(@nombre,CONVERT(varchar,@finicio,111),@descr,
            CONVERT(varchar,@fcarga,111),@calif,0,0,11,@ffin,@dest)";
                List<SqlParameter> par = new List<SqlParameter>();
                par.Add(new SqlParameter("@nombre", nDiar.Nombre));
                par.Add(new SqlParameter("@finicio", nDiar.Fecha_ini));
                par.Add(new SqlParameter("@descr", nDiar.Descripcion));
                par.Add(new SqlParameter("@fcarga", nDiar.Fecha_carga));
                par.Add(new SqlParameter("@calif", nDiar.Calif_creador));
                par.Add(new SqlParameter("@ffin", nDiar.Fecha_fin));
                par.Add(new SqlParameter("@dest", nDiar.Destino));

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
    }
}