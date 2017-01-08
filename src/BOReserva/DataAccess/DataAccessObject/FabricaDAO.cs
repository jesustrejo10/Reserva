using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    public class FabricaDAO
    {
        public static DAO instanciarDaoHotel() {
            return new DAOHotel();
        }

        public static DAO instanciarDaoReclamo() 
        {
            return new DAOReclamo();
        }

        #region M04_Vuelos
        /// <summary>
        /// Método que crea la instancia de DAOVuelo
        /// </summary>
        /// <returns>Retorna la instancia a la clase DAOVuelo</returns>
        public static DAO instanciarDAOVuelo()
        {
            return new DAOVuelo();
        }
        #endregion
    }
}