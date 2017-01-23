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
    /// Comando Eliminar 
    /// </summary>
    public class M02_COEliminarAvion : Command<String>
    {
        Avion _avion;
        int _idmodificar;
        int _id;

        /// <summary>
        /// Constructor del comando Eliminar
        /// </summary>
        /// <param name="avion"></param>
        /// <param name="id"></param>
        public M02_COEliminarAvion(Entidad avion,int id)
        { 
            this._avion = (Avion) avion;
            this._id = id;
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
            //String test = daoAvion.EliminarAvion(_avion._id);
            String test = daoAvion.eliminarAvion(_avion._id);
            return test;
        } 
    }
}