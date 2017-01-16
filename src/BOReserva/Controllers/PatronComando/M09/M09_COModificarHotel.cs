using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Comando Modificar Hoteles
    /// </summary>
    public class M09_COModificarHotel : Command<String>
    {
        Hotel _hotel;
        int _idmodificar;

        public M09_COModificarHotel(Entidad hotel, int id) { 
            this._hotel = (Hotel) hotel;
            this._hotel._id = id;
        }

        public override String ejecutar(){
            IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
            Entidad test = daoHotel.Modificar(_hotel);
            Hotel hotel = (Hotel)test;
            return hotel._nombre;
        }

    }
}