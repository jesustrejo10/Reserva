using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Collections.Generic;

namespace BOReserva.Controllers.PatronComando
{
    public class M05_COConsultarBoletosVuelo : Command<List<Entidad>>
    {
        private int _id;
        public M05_COConsultarBoletosVuelo(int id) {
            this._id = id;
        }
        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override List<Entidad> ejecutar()
        {
            IDAOCheckIn instanciarCheckin = (IDAOCheckIn)FabricaDAO.instanciarDaoCheckIn();
            List<Entidad> boletos = instanciarCheckin.M05ListarVuelosBoleto(_id);
            return boletos;
        }
    }
}