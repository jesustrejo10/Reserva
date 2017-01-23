using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M16
{
    /// <summary>
    /// Comando para realizar la operación
    /// eliminar un reclamo
    /// </summary>
    public class M16_COEliminarReclamo : Command<String>
    {
        /// <summary>
        /// atributos de la clase
        /// </summary>
        Reclamo _reclamo;
        int _idReclamo;
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="id">recibe el id del reclamo a eliminar</param>
        public M16_COEliminarReclamo(int id)
        { 
            this._idReclamo = id;
        }

        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override String ejecutar(){
            IDAOReclamo daoReclamo =  FabricaDAO.instanciarDaoReclamoPersonalizado();
            int respuesta = daoReclamo.Eliminar(_idReclamo);
            return respuesta.ToString();
        }
    }
}