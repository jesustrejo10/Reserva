using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    public class M09_CODisponibilidadHotel: Command<String>
    {
        Hotel _hotel;
        int _disponibilidad;

        public M09_CODisponibilidadHotel(Entidad hotel, int disponibilidad)
        { 
            this._hotel = (Hotel) hotel;
            this._disponibilidad = disponibilidad;
        }

        public override String ejecutar(){
            DAOHotel daoHotel = (DAOHotel)FabricaDAO.instanciarDaoHotel();
            String test = daoHotel.disponibilidadHotel(_hotel, _disponibilidad);
            return test;
        }

    }
}