using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
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
        int _idmodificar;
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
            return "Se modifico el hotel exitosamente, sera redirigido al listado de hoteles";
        }
            catch (ReservaExceptionM09 ex)
            {
                throw ex;
            }
        }

    }
}