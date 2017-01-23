using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M04;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COBuscarAvionRuta : Command<List<Entidad>>
    {

        private int _idRuta;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto al que se le quiere cambiar el status</param>
        public M04_COBuscarAvionRuta(int idRuta)
        {
            _idRuta = idRuta; 
        }
        #endregion

         /// <summary>
        /// ejecuta el comando DAO.ConsultarAvionRuta
        /// </summary>
        /// <returns>lista con todos los vuelos</returns>
        public override List<Entidad> ejecutar()
        {

            try
            {
                IDAOVuelo daoVuelo = (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                List<Entidad> listaVuelos = daoVuelo.ConsultarAvionRuta(_idRuta);
                return listaVuelos;
            }
            catch (ReservaExceptionM04 ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
