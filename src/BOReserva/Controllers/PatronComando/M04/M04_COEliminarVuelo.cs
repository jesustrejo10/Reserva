using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DAO.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M04;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COEliminarVuelo : Command<Boolean>
    {
        private int _idVuelo;

        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COEliminarVuelo (int idVuelo)
        {
            _idVuelo = idVuelo; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoVuelo y usar el método Eliminar
        /// </summary>
        public override bool ejecutar()
        {
            try
            {
                IDAOVuelo vueloDel= (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                vueloDel.Eliminar(_idVuelo);
                return true;
            }
            catch (ReservaExceptionM04 ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
            
        }
        #endregion
    }
}