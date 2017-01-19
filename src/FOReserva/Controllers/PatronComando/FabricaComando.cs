using FOReserva.Controllers.PatronComando;
using FOReserva.Controllers.PatronComando.M16;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        #region M16 GestionReclamos
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarReclamo
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Reclamo</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM16AgregarReclamo(Entidad e)
        {

            return new M16_COAgregarReclamo((Reclamo)e);

        }
        #endregion
    }
}