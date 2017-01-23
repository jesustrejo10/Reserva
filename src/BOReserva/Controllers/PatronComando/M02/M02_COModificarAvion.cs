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
    /// Comando Modificar Avion
    /// </summary>
    public class M02_COModificarAvion : Command<String>
    {

          Avion _avion;
        int _idmodificar;
        
        /// <summary>
        /// Constructor del comando modificar
        /// </summary>
        /// <param name="avion"></param>
        /// <param name="id"></param>
        public M02_COModificarAvion(Entidad avion, int id) { 
            this._avion = (Avion) avion;
            this._avion._id = id;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override string ejecutar(){
            IDAO daoAvion = FabricaDAO.instanciarDaoAvion();
            Entidad test = daoAvion.Modificar(_avion);
            Avion avion = (Avion)test;
            return avion._matricula;
        }
    }
}