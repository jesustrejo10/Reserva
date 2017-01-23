using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain.M14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    public class M14_COAgregarItinerario : Command<String>
    {

        Itinerario _itinerario;
        
        public M14_COAgregarItinerario(Itinerario itinerario) 
        {
            this._itinerario = itinerario;
 
        }


        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un String 
        ///// </returns>
        public override String ejecutar()
        {
            IDAO daoItinerario = FabricaDAO.instanciarDaoItinerario();
            int test = daoItinerario.Agregar(_itinerario);
            return test.ToString();
        }

    }
}