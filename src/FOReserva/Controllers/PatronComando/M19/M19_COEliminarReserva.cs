using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M19
{
    public class M19_COEliminarReserva : Command<Boolean>
    {

        #region Atributos
        Entidad _objeto;
        #endregion

        public M19_COEliminarReserva(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override bool ejecutar()
        {
            try
            {
                IDAOReservaAutomovil reservaDao = FabricaDAO.ReservaAutomovilBD();
                reservaDao.Eliminar(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}