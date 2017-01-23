using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para agregar un a avion a la BD
    /// </summary>
    public class M02_COAgregarAvion : Command<String>
    {
        Avion _avion;

        public M02_COAgregarAvion(Avion avion)
        {
            this._avion = avion;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override String ejecutar()
        {
            IDAO daoAvion = FabricaDAO.instanciarDaoAvion();
            int test = daoAvion.Agregar(_avion);
            return test.ToString();
        }

    }

}