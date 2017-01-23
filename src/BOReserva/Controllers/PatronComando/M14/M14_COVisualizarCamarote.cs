using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    public class M14_COVisualizarCamarote : Command<Dictionary<int, Entidad>>
    {

        int valor;        
        public M14_COVisualizarCamarote(int value){
            this.valor = value;
        }       

        public M14_COVisualizarCamarote()
        {
            // TODO: Complete member initialization
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAOCamarote daoCamarote = (IDAOCamarote) FabricaDAO.instanciarDaoCamarote();
            Dictionary<int, Entidad> mapCamarotes = daoCamarote.ConsultarTodos(valor);
            return mapCamarotes;
        }

    }
}