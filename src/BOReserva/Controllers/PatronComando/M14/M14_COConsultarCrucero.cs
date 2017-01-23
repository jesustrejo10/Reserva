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
    /// Clase del comando para consultar los cruceros de la BD
    /// </summary>
    public class M14_COConsultarCrucero : Command<Entidad>
    {
        int valor;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="value">Identificador del Crucero a buscar</param>
        public M14_COConsultarCrucero(int value)
        {
            this.valor = value;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override Entidad ejecutar()
        {
                IDAO daoCrucero = FabricaDAO.instanciarDaoCrucero();
                Entidad crucero = daoCrucero.Consultar(valor);
                return crucero;
        }
    }
}