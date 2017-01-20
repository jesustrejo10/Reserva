using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M11
{
    public class DAOPaquete : DAO, IDAOPaquete
    {
        public DAOPaquete() {}

        int IDAO.Agregar(Entidad e)
        {
            Paquete paquete = (Paquete)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);  //Para obtener la conexión a la 
                                                                                //base de datos
            try
            {
                conexion.Open();
                SqlCommand query = conexion.CreateCommand(); //Se usa SqlCommand para las instrucciones que se 
                                                             //ejecutan en una base de datos de SQL Server
            }
            catch (Exception)
            {
                
                throw;
            }
            return 0;
        }
    }
}