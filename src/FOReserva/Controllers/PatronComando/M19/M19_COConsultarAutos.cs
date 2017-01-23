using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.gestion_reserva_automovil;

namespace FOReserva.Controllers.PatronComando.M19
{
    public class M19_COConsultarAutos: Command<List<Entidad>>
    {
        #region Atributos
        Entidad _objeto;
        #endregion

        public M19_COConsultarAutos(Entidad _objeto)
        {

            System.Diagnostics.Debug.WriteLine("LLEGA A COCONSULTAR AUTOS");
            
            this._objeto = _objeto;
        }

        public override List<Entidad> ejecutar()
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("LLEGA A EJECUTAR");
                CVistaReservaAuto obj = (CVistaReservaAuto)_objeto;
                System.Diagnostics.Debug.WriteLine("ATRIBUTOS DEL OBJETO ---- idorigen: " + obj._ciudadOrigen + ", iddestino: " + obj._ciudadDestino + ", fechaini: " + obj._fechaini + ", fechafin: " + obj._fechafin + ", horaini: " + obj._horaIni + ", horafin: " + obj._horaFin);
            
                
                IDAOReservaAutomovil reservaAutomovilDao = FabricaDAO.ReservaAutomovilBD();
                return reservaAutomovilDao.ConsultarAutosPorIdCiudades(this._objeto);

            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}