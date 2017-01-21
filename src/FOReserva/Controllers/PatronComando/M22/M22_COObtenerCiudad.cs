using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M22
{
    public class M22_COObtenerCiudad : Command<Dictionary<int, Entidad>>
    {
        public override Dictionary<int,Entidad> ejecutar()
        {
            try
            {
                IDAOReservaHabitacion ciudades= FabricaDAO.instanciarDaoReservaHabitacion();
                return ciudades.ObtenerCiudades();
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