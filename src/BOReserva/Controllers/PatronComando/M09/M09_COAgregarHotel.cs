using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M09;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para a;adir un hotel a la BD
    /// </summary>
    public class M09_COAgregarHotel : Command<String>
    {
        Hotel _hotel;

        public M09_COAgregarHotel(Hotel hotel, int precio) { 
            this._hotel = hotel;
            _hotel._precio = precio;
        }

        public override String ejecutar(){
            IDAO daoHotel = FabricaDAO.instanciarDaoHotel();       
            int resultadoAgregarHotel = daoHotel.Agregar(_hotel);
            if (resultadoAgregarHotel == 1) {
                String add = agregarhabitaciones(_hotel, _hotel._precio);
            }
            return resultadoAgregarHotel.ToString();
        }

        public String agregarhabitaciones(Hotel hotel, int precio)
        {
            IDAOHabitacion habdao = (IDAOHabitacion)FabricaDAO.instanciarDaoHabitacion();
            String resp = habdao.Agregarhab(hotel, precio);
            return resp;
        }

    }
}