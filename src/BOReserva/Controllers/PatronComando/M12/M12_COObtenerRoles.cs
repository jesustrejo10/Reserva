using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;

namespace BOReserva.Controllers.PatronComando.M12
{
    /// <summary>
    /// Clase para el comando de obtencion de roles
    /// </summary>
    public class M12_COObtenerRoles : Command<Dictionary<int, Entidad>>
    {
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Dictionary<int,Entidad></returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoRol = FabricaDAO.instanciarDAORol();
            Dictionary<int, Entidad> roles = daoRol.ConsultarTodos();
            Dictionary<int, Entidad> listaRoles = new Dictionary<int, Entidad>();

            foreach (var rol in roles)
            {
                Rol r = (Rol)rol.Value;
                listaRoles.Add(rol.Key, r);
            }

            return listaRoles;
        }
    }
}