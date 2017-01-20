using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M19
{
    public class M19_COConsultarLugar : Command<List<Entidad>>
    {
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAOReservaAutomovil reservaDao = FabricaDAO.ReservaAutomovilBD();
                return reservaDao.ListarLugar();
            }
            catch (NotImplementedException)
            {
                // exception implementada debido a que puede darse el caso 
                // en que algunos de los metodos  en la 
                //interfaz IDAO no se implemente y se lance esta excepcion

                throw;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("La exception arrojada es " + e);
                throw;

            }


        }
    }
}