using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{

    public class M16_COConsultarReclamoDetalle : Command<Entidad>
    {
        int valor;

        public M16_COConsultarReclamoDetalle(int idReclamo)
        {
            this.valor = idReclamo;
        }
        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna una Entidad
        /// </returns>
        public override Entidad ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
            Entidad reclamo = daoReclamo.Consultar(valor);
            return reclamo;
        }
    }

}
