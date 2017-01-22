using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M16
{
    /// <summary>
    /// Comando que se encarga de agregar los reclamos a la BD
    /// </summary>
    public class M16_COAgregarReclamo : Command<String>
    {
        Reclamo _reclamo;

        /// <summary>
        /// Metodo para setear el reclamo a agregar
        /// </summary>
        /// <param name="reclamo">El reclamo que viene del controlador</param>
        public M16_COAgregarReclamo (Reclamo reclamo)
        {
            this._reclamo = reclamo;
        }

        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override string ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
            daoReclamo.Agregar(_reclamo);
            return "1";
        }
    }
}