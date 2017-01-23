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
    public class M04_COFechaAterrizaje : Command<Entidad>
    {
         private int _idRuta;
         private int _idAvion;
         private DateTime _fechaDespegue;
        #region Constructores


        /// <summary>
        /// Constructor del comando Fecha Aterrizaje
        /// </summary>
        /// <param name="idRuta">id de la ruta</param>
        /// <param name="idAvion">id del avion</param>
        /// <param name="fechaDespegue">fecha de despegue</param>
        public M04_COFechaAterrizaje(int idRuta, int idAvion, DateTime fechaDespegue)
        {
            _fechaDespegue = fechaDespegue;
            _idAvion = idAvion;
            _idRuta = idRuta; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoVuelo y usa el método CambiarStatus
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override Entidad ejecutar()
        {
            try
            {
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return (exec.ConsultarDatosAterrizaje(_idRuta, _fechaDespegue, _idAvion));
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
