using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M19
{
    public class M19_COConsultarReserva : Command<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M19_COConsultarReserva(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAOReservaAutomovil reservaDao = FabricaDAO.ReservaAutomovilBD();
                return reservaDao.Consultar(this._objeto);
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}