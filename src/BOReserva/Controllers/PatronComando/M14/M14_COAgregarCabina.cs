using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando


/// <summary>
/// Comando destinado a Realizar las respectivas operaciones necesarias
/// para agregar una cabina a la BD
/// </summary>
{
    public class M14_COAgregarCabina : Command<String>
    {
        Cabina _cabina;

        public M14_COAgregarCabina(Cabina cabina) { 
            this._cabina = cabina;
        }


        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un String 
        ///// </returns>
        public override String ejecutar(){
            IDAO daoCabina = FabricaDAO.instanciarDaoCabina();       
            int test = daoCabina.Agregar(_cabina);
            return test.ToString();
        }
    }
}