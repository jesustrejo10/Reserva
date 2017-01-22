using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    /// <summary>
    /// Comando Modificar Cruceros
    /// </summary>
    public class M14_COModificarCrucero : Command<String>
    {

        Crucero _crucero;
        int _idmodificar;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="crucero">Crucero a modificar</param>
        /// <param name="id">Identificador del crucero a modificar</param>
        public M14_COModificarCrucero(Entidad crucero, int id)
        {
            this._crucero = (Crucero)crucero;
            this._crucero._id = id;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
            IDAO daoCrucero = FabricaDAO.instanciarDaoCrucero();
            Entidad test = daoCrucero.Modificar(_crucero);
            Crucero crucero = (Crucero)test;
            return crucero._nombreCrucero;
        }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}