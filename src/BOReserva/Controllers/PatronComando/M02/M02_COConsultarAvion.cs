using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M02
{

    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para consultar un a avion a la BD
    /// </summary>
    public class M02_COConsultarAvion : Command<Entidad>
    {
        int valor;

        public M02_COConsultarAvion(int value){
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
            IDAO daoAvion = FabricaDAO.instanciarDaoAvion();
            Entidad avion = daoAvion.Consultar(valor);
            return avion;
        }
    }
}