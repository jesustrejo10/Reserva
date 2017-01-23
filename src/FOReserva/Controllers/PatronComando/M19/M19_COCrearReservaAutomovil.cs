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
    public class M19_COCrearReservaAutomovil : Command<Boolean>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        #region Constructor
        public M19_COCrearReservaAutomovil() { }

        public M19_COCrearReservaAutomovil(Entidad _objeto)
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