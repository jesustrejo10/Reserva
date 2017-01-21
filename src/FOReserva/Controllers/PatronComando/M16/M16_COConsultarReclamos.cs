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
    public class M16_COConsultarReclamos: Command<List<Reclamo>>
    {
        #region Atributos
        int _idUsuario;
        #endregion

        public M16_COConsultarReclamos(int _idUsuario)
        {
            this._idUsuario = _idUsuario;
        }


               
        public override List<Reclamo> ejecutar()
        {
            try
            {
                IDAOReclamo reclamoDao = FabricaDAO.reclamoPersonalizado();
                return reclamoDao.ConsultarReclamosPorUsuario(_idUsuario);
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}