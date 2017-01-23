using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M09;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Clase M09_COEliminar Hotel.
    /// Hereda de Comando
    /// </summary>
    public class M09_COEliminarHotel: Command<String>
    {
        Hotel _hotel;

        /// <summary>
        /// Constructor  del Comando Eliminar Hotel
        /// </summary>
        /// <param name="hotel">
        /// Recibe el Hotel que se va a eliminar
        /// </param>
        /// <param name="id">
        /// Recibe el Id del Hotel que se va a eliminar
        /// </param>
        public M09_COEliminarHotel(Entidad hotel, int id)
        { 
            this._hotel = (Hotel) hotel;
            this._hotel._id = id;
        }


        /// <summary>
        /// Sobre escritura del Ejecutar de Comando
        /// </summary>
        /// <returns>
        /// Devuelve un String, en el cual se indica el mensaje que sera llevado a la vista
        /// </returns>
        public override String ejecutar(){
            try
            {
                IDAOHotel daoHotel = (DAOHotel)FabricaDAO.instanciarDaoHotel();
                String test = daoHotel.eliminarHotel(_hotel._id);
                return test;
            }
            catch (ReservaExceptionM09 ex)
            {
                //este throw esta incorrecto
                throw ex;
            }
        }

    }
}