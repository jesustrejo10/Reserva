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
    public class M19_COActualizarReserva : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M19_COActualizarReserva(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override bool ejecutar()
        {
            try
            {
                IDAOReservaAutomovil restaurantDao = FabricaDAO.ReservaAutomovilBD();
                restaurantDao.Modificar(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {

                //throw;
            }
         
            return true;
        }

    }
}