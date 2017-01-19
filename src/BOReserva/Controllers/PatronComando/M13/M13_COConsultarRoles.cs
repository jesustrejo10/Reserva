using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando Visualizar Roles
    /// </summary>
    public class M13_COConsultarRoles : Command<List<Entidad>>
    {

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, String
        /// </returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAORol daoRol = (IDAORol)FabricaDAO.instanciarDAORol();
                List<Entidad> listaroles = daoRol.ConsultarRoles();
                return listaroles;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}