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
    /// para agregar un crucero a la BD
    /// </summary>

    public class M14_COAgregarCrucero : Command<String>
    {
        Crucero _crucero;

        public M14_COAgregarCrucero(Crucero crucero ) { 
            this._crucero = crucero;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un String 
        ///// </returns>      
        public override String ejecutar(){
            IDAO daoCrucero = FabricaDAO.instanciarDaoCrucero();       
            int test = daoCrucero.Agregar(_crucero);
            return test.ToString();            
        }

    }
}