using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M14
{
    /// <summary>
    /// Comando Modificar Cabinas
    /// </summary>
    public class M14_COModificarCamarote : Command<String>
    {

        Camarote _camarote;
        int _idmodificar;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="cabina">Cabina a modificar</param>
        /// <param name="id">Identificador del cabina a modificar</param>
        public M14_COModificarCamarote(Entidad cabina, int id, int fk)
        {
            this._camarote = (Camarote)cabina;
            this._camarote._id = id;
            this._camarote._fkCabina = fk;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
            IDAO daoCamarote = FabricaDAO.instanciarDaoCamarote();
            Entidad test = daoCamarote.Modificar(_camarote);
            Camarote camarote = (Camarote)test;
            return camarote._nombreCabina;
        }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}