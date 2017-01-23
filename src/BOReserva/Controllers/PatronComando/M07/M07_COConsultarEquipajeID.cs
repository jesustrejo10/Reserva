using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M07
{
    public class M07_COConsultarEquipajeID  //: Command<Entidad>
    {
        /*
        int _idHotel;
        public M07_COConsultarEquipajeID(int id)
        {
            this._idHotel = id;
        }

        /// <summary>
        /// Sobrescritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna una Entidad
        /// </returns>
        public override Entidad ejecutar()
        {
            IDAO daoEquipaje = FabricaDAO.instanciarDaoEquipaje();
            Entidad equipaje = daoEquipaje.Consultar(_idHotel);
            return equipaje;
        }
         * */
    }
}