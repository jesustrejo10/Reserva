using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones.M09;
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
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="hotel">Hotel a modificar</param>
        /// <param name="id">Identificador del hotel a modificar</param>
        public M09_COModificarHotel(Entidad hotel, int id) { 
            this._hotel = (Hotel) hotel;
            this._hotel._id = id;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
                IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
                Entidad test = daoHotel.Modificar(_hotel);
                Hotel hotel = (Hotel)test;
                //Actualice un Hotel en BD. necesito refrescarlo en Cache
                Cache.actualizarMapHoteles(hotel);
                return ResourceM09Command.ModificoCorrectamente;
            }
            catch (ReservaExceptionM09 ex)
            {
                return (ex.Codigo);
            }
        }

    }
}