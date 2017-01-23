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
    /// Comando Modificar Cabinas
    /// </summary>
    public class M14_COModificarCabina : Command<String>
    {

        Cabina _cabina;
        int _idmodificar;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="cabina">Cabina a modificar</param>
        /// <param name="id">Identificador del cabina a modificar</param>
        public M14_COModificarCabina(Entidad cabina, int id, int fk)
        {
            this._cabina = (Cabina)cabina;
            this._cabina._id = id;
            this._cabina._fkCrucero = fk;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
            IDAO daoCabina = FabricaDAO.instanciarDaoCabina();
            Entidad test = daoCabina.Modificar(_cabina);
            Cabina cabina = (Cabina)test;
            return cabina._nombreCabina;
        }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}