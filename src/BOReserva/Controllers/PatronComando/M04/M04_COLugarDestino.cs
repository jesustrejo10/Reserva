using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COLugarDestino : Command<List<Entidad>>
    {
        private int _lugar;

        #region Constructores


        /// <summary>
        /// Constructor del comando lugar destino
        /// </summary>
        /// <param name="idLugar">id del lugar origen</param>
        public M04_COLugarDestino(int idLugar)
        {
            this._lugar = idLugar;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DAOVuelo y usa el método ConsultarLugarDestino
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return (exec.ConsultarLugarDestino(_lugar));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
