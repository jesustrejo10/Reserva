using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M16
{
    public class M16_COModificarReclamo : Command<int>
    {
        Reclamo _reclamo;

        /// <summary>
        /// Metodo para setear el reclamo a modificar
        /// </summary>
        /// <param name="reclamo">El reclamo que viene del controlador</param>
        public M16_COModificarReclamo(Reclamo reclamo)
        {
            this._reclamo = reclamo;
        }

        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un int con el codigo de error
        ///// </returns>
        public override int ejecutar()
        {
            IDAOReclamo daoReclamo = FabricaDAO.reclamoPersonalizado();
            return daoReclamo.ModificarReclamo(_reclamo);
        }
    }
}