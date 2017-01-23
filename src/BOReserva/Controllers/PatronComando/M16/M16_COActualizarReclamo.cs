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
    /// <summary>
    /// Comando destinado a realizar las respectivas operaciones necesarias
    /// para actualizar el estado de un reclamo
    /// </summary>
    public class M16_COActualizarReclamo : Command<String>
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        Reclamo _reclamo;
        int _idReclamo;
        int _estado;

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="id"> recibe el id del reclamo</param>
        /// <param name="estado">recibe el estado en el que se encuentra el reclamo</param>
        public M16_COActualizarReclamo(int id, int estado)
        { 
            this._idReclamo = id;
            this._estado = estado;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns> Retorna un string </returns>
        public override String ejecutar(){
            try
            {
                IDAOReclamo daoReclamo = FabricaDAO.instanciarDaoReclamoPersonalizado();
                int respuesta = daoReclamo.modificarEstado(_idReclamo, _estado);
                return respuesta.ToString();
            }
            catch (ReservaExceptionM16 ex) 
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}