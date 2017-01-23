using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M12
{
    /// <summary>
    /// Clase del comando para consultar los usuarios de la BD
    /// </summary>
    public class M12_COConsultarUsuario : Command<Entidad>
    {
        int valor;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="value">Identificador del usuario a buscar</param>
        public M12_COConsultarUsuario(int value)
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
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            Entidad Usuario = daoUsuario.Consultar(valor);

            return Usuario;
        }
        
    }
}