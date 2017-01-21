using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M16_COConsultarReclamo : Command<Dictionary<int, Entidad>>
    {
            /// <summary>
            /// Sobre escritura del metodo ejecutar de la clase Comando.
            /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
            /// </summary>
            /// <returns>
            /// Retorna un Identity map, de tipo int, Entidad
            /// </returns>
            public override Dictionary<int, Entidad> ejecutar()
            {
                IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
                Dictionary<int, Entidad> mapReclamos = daoReclamo.ConsultarTodos();
                return mapReclamos;
            }

        
    }
}