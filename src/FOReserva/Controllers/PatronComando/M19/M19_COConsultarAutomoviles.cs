using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.M19.Comando.gestion_reserva_automovil
{
    public class M19_COConsultarAutomoviles : Command<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M19_COConsultarAutomoviles(Entidad _objeto)
        {
            this._objeto = _objeto;
        }

        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAOReservaAutomovil reservaAutomovilDao = FabricaDAO.ReservaAutomovilBD();
                return reservaAutomovilDao.Consultar(this._objeto);
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}