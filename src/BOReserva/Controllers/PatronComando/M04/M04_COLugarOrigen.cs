using BOReserva.DataAccess.DataAccessObject;
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
    /// <summary>
    /// Comando para buscar lugares de origen cuyas rutas esten activas
    /// </summary>
    public class M04_COLugarOrigen : Command<List<Entidad>>
    {
        private List<Lugar> _lugares;

        #region Constructores


        /// <summary>
        /// Constructor simple
        /// </summary>
        public M04_COLugarOrigen()
        {
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DAOVuelo y usa el método ConsultarLugarOrigen
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return(exec.ConsultarLugarOrigen());
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