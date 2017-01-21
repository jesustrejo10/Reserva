using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M16
{
    /// <summary>
    /// Instanciacion del comando para eliminar un reclamo
    /// </summary>
    public class M16_COEliminarReclamo : Command<int>
    {
        int _idReclamo;

        /// <summary>
        /// metodo constructor de la instancia del comando para eliminar un reclamo
        /// </summary>
        /// <param name="_idReclamo"> Id del reclamo que se desea eliminar</param>
        public M16_COEliminarReclamo(int _idReclamo)
        {
            this._idReclamo = _idReclamo;
        }

        /// <summary>
        /// Instanciacion de la consulta a la base de datos de este comando
        /// </summary>
        /// <returns>int con el codigo de ejecucion devuelto por la operacion</returns>
        public override int ejecutar()
        {
            try
            {
                IDAOReclamo reclamoDao = FabricaDAO.reclamoPersonalizado();
                return reclamoDao.EliminarReclamo(_idReclamo);
            }
            catch (NotImplementedException)
            {
                throw;
            }
        }
    }
}