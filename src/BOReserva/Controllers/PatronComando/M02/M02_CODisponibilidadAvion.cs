using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M02
{

    /// <summary>
    /// Comando Disponibilidad del avion 
    /// </summary>
    public class M02_CODisponibilidadAvion : Command<String>
    {
        Avion _avion;
        int _disponibilidad;

        /// <summary>
        /// Constructor del comando Disponibilidad
        /// </summary>
        /// <param name="avion"></param>
        /// <param name="disponibilidad"></param>
        public M02_CODisponibilidadAvion(Entidad avion,int disponibilidad)
        { 
            this._avion = (Avion) avion;
            this._disponibilidad = disponibilidad;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override String ejecutar(){
            IDAOAvion daoAvion = (DAOAvion)FabricaDAO.instanciarDaoAvion();
            String test = daoAvion.disponibilidadAvion(_avion, _disponibilidad);
            return test;
        }
    }
}