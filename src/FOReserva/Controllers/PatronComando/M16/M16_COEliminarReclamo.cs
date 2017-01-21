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
    public class M16_COEliminarReclamo : Command<int>
    {
        int _idReclamo;

        public M16_COEliminarReclamo(int _idReclamo)
        {
            this._idReclamo = _idReclamo;
        }

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