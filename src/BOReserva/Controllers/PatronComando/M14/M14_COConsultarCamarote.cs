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
    /// Clase del comando para consultar los Camarotes de la BD
    /// </summary>
    public class M14_COConsultarCamarote : Command<Entidad>
    {

        int valor;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="value">Identificador del Cabina a buscar</param>
        public M14_COConsultarCamarote(int value)
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
                IDAO daoCamarote = FabricaDAO.instanciarDaoCamarote();
                Entidad camarote = daoCamarote.Consultar(valor);
                return camarote;
        }

    }
}