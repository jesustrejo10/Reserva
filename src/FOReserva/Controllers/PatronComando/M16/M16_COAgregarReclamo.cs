using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M16
{
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

        public override string ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
            daoReclamo.Agregar(_reclamo);
            return "1";
        }
    }
}