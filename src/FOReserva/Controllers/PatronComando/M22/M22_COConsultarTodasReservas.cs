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
    public class M22_COConsultarTodasReservas : Command<Dictionary<int, Entidad>>
    {
        int id;
            public M22_COConsultarTodasReservas (int value){
                this.id= value;
            }
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