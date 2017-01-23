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
    public class M22_COConsultarIdCiudad : Command<Dictionary<int, Entidad>>
    {
        int id;
            public M22_COConsultarIdCiudad (int value){
                this.id= value;
            }
        public override Dictionary<int, Entidad> ejecutar()
        {
            try
            {
                IDAOReservaHabitacion ciudades = FabricaDAO.instanciarDaoReservaHabitacion();
                Dictionary<int,Entidad> hoteles= ciudades.ConsultarHotelesPorIdCiudad(id);
                return hoteles;
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