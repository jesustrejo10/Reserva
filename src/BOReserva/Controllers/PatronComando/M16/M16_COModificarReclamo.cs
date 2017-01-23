using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M16
{
    public class M16_COModificarReclamo : Command<String>
    {
        Reclamo _reclamo;
        int _id;

        /// <summary>
        /// constructor de la clase 
        /// </summary>
        /// <param name="_reclamo"> recibe la entidad reclamo</param>
        /// <param name="_id">y el id del reclamo</param>
        public M16_COModificarReclamo(Entidad _reclamo,int _id)
        {
            this._reclamo = (Reclamo) _reclamo;
            this._reclamo._id = _id;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns> Retorna un string </returns>
        public override String ejecutar()
        {
            try
            {
                IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
                Entidad test = daoReclamo.Modificar(_reclamo);
                //Reclamo reclamo = (Reclamo)test;
                return "1";
            }
            catch(ReservaExceptionM16 ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }

    }
}