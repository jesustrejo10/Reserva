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
    public class M14_COVisualizarCabinas : Command<Dictionary<int, Entidad>>
    {

        int valor;

        public M14_COVisualizarCabinas()
        {
            
        }

        public M14_COVisualizarCabinas(int value){
            this.valor = value;
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
            IDAOCabina daoCabina = (IDAOCabina) FabricaDAO.instanciarDaoCabina();
            Dictionary<int, Entidad> mapCruceros = daoCabina.ConsultarTodos(valor);
            return mapCruceros;
        }

    }
}