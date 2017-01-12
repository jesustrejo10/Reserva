using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarHotel
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Hotel</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM09AgregarHotel(Entidad e) {

            return new M09_COAgregarHotel((Hotel)e);

        }

        #region M04_Vuelo
        public static Command<String> M04crearVuelo(Entidad vuelo)
        {
            return new M04.M04_COAgregarVuelo();
        }

        public static Command<List<Entidad>> M04consultarTodos()
        {
            return new M04.M04_COConsultarTodosVuelos();
        }
        #endregion

    }
}