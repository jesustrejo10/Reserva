using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    public class M09_COEliminarHotel: Command<String>
    {
        Hotel _hotel;
        int _idmodificar;

        public M09_COEliminarHotel(Entidad hotel, int id)
        { 
            this._hotel = (Hotel) hotel;
            this._hotel._id = id;
        }

        public override String ejecutar(){
            DAOHotel daoHotel = (DAOHotel)FabricaDAO.instanciarDaoHotel();
            String test = daoHotel.eliminarHotel(_hotel._id);
            return test;
        }

    }
}