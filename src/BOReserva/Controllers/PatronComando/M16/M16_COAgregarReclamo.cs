using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.Excepciones.M16;

namespace BOReserva.Controllers.PatronComando
{
    public class M16_COAgregarReclamo: Command<String>
    {
        Reclamo _reclamo;
        /// <summary>
        /// Constructor de la clase M16_COAgregarReclamo
        /// </summary>
        /// <param name="reclamo">reciba la entidad reclamo</param>
        public M16_COAgregarReclamo(Reclamo reclamo) 
        {
            this._reclamo = reclamo;
        }

        /// <summary>
        /// Sobre escritura del método ejecutar de la clase Comando. Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>un string con la respuesta </returns>
        public override String ejecutar()
        {
            try
            {
                IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
                int respuesta = daoReclamo.Agregar(_reclamo);
                return respuesta.ToString();
            }
            catch(ReservaExceptionM16 ex)
            {
                return ex.Mensaje;
            }
        }
    }
}