using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando Visualizar Hoteles
    /// </summary>
    public class M09_COVisualizarHoteles : Command<Dictionary<int, Entidad>>
    {

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            try
            {
                if (Cache.mapHoteles.Count == 0)
                {
                    IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
                    Cache.mapHoteles = daoHotel.ConsultarTodos();
                }
                return Cache.mapHoteles;

            }catch (ReservaExceptionM09 ex){
                throw ex;
            }
        }

    }
}