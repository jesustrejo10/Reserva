using FOReserva.DataAccess;
using FOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject

{
    public class FabricaDAO
    {
        #region M16 Reclamos

        /// <summary>
        /// Metodo que instancia el DAO de reclamos
        /// </summary>
        /// <returns>una instancia del DAO de reclamos</returns>
        public static DAO instanciarDaoReclamo()
        {
            return new DAOReclamo();
        }
        #endregion
    }
}