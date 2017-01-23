using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando para consultar por reclamo
    /// </summary>
    public class M16_COConsultarReclamoDetalle : Command<Entidad>
    {
        int valor;
        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="idReclamo"> recibe el id del reclamo</param>
        public M16_COConsultarReclamoDetalle(int idReclamo)
        {
            this.valor = idReclamo;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns> Retorna una Entidad </returns>
        public override Entidad ejecutar()
        {
            try
            {
                IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
                Entidad reclamo = daoReclamo.Consultar(valor);
                return reclamo;
            }
            catch (ReservaExceptionM16 ex) 
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}
