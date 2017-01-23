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
    /// <summary>
    /// Comando que se encarga de modificar las reservas de automovil a la BD
    /// </summary>
    public class M22_COObtenerCiudad : Command<List<CiudadHab>>
    {
        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al IDAOReservaHabitacion y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna un lista de Ciudad Habitacion
        ///// </returns>
        public override List<CiudadHab> ejecutar()
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