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
    public class M19_COCrearReserva: Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M19_COCrearReserva() { }

        public M19_COCrearReserva(Entidad _objeto)
        {
            this._objeto = _objeto;
        }
        #endregion

        public override bool ejecutar()
        {
            try
            {
                IDAOReservaAutomovil reservaAutomovilDao = FabricaDAO.ReservaAutomovilBD();
                reservaAutomovilDao.Crear(this._objeto);
                return true;
            }
            catch (NotImplementedException)
            {
                // exception implementada debido a que puede darse el caso 
                // en que algunos de los metodos de implementados en la 
                //interfaz IDAO no se implemente y se lance esta excepcion
                throw;
            }
            catch (Exception)
            {
                throw;

            }


        }
    }
}