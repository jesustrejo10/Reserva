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
    public class M19_COConsultarReservaId : Command<Entidad>
        {
            #region Atributos
            Entidad _objeto;
            #endregion

            public M19_COConsultarReservaId(Entidad _objeto)
            {
                this._objeto = _objeto;
            }

            public override Entidad ejecutar()
            {
                try
                {
                    IDAOReservaAutomovil reservaAutomovilDao = FabricaDAO.ReservaAutomovilBD();
                    return reservaAutomovilDao.consultarReservaId(this._objeto);
                }
                catch (NotImplementedException)
                {
                    // exception implementada debido a que puede darse el caso 
                    // en que algunos de los metodos  en la 
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