using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace FOReserva.Controllers.PatronComando.M22
{
    /// <summary>
    /// Comando que se encarga de consultar todas las reservas de automovil a la BD
    /// </summary>
    public class M22_COConsultarTodasReservas : Command<Dictionary<int, Entidad>>
    {
        int id;
        /// <summary>
        /// Metodo para setear la reserva para agregar
        /// </summary>
        /// <param name="value2">La reserva que viene del controlador</param>
            public M22_COConsultarTodasReservas (int value){
                this.id= value;
            }
            ///// <summary>
            ///// Sobreescritura del metodo ejecutar de la clase Comando.
            ///// Se encarga de llamar al IDAOReservaHabitacion y devolver la respuesta al controlador.
            ///// </summary>
            ///// <returns>
            ///// Retorna un Dictionary
            ///// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            try
            {
                IDAOReservaHabitacion reserva = FabricaDAO.instanciarDaoReservaHabitacion();
                Dictionary<int, Entidad> reservasusuario = reserva.ConsultarTodosHabitacion(id);
                return reservasusuario;
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