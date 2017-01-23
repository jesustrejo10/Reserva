using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para Listar las cabinas de los cruceros a la BD
    /// </summary>

    public class M14_COListarCabinaCrucero : Command<Dictionary<int, Entidad>>
    {
        string valor;

        public M14_COListarCabinaCrucero(string crucero)
        {
            this.valor = crucero;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAOCabina daoCabina = (IDAOCabina) FabricaDAO.instanciarDaoCabina();
            Dictionary<int, Entidad> mapCruceros = daoCabina.ConsultarCabinasCrucero(valor);
            return mapCruceros;
        }

    }
}