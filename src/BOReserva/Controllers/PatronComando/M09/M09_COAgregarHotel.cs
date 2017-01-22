using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M09;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para añadir un hotel a la BD
    /// </summary>
    public class M09_COAgregarHotel : Command<String>
    {
        Hotel _hotel;
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="hotel">Hotel a agregar</param>
        /// <param name="precio">Precio de las habitaciones del mismo</param>
        public M09_COAgregarHotel(Hotel hotel, int precio) { 
            this._hotel = hotel;
            _hotel._precio = precio;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
                IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
                int resultadoAgregarHotel = daoHotel.Agregar(_hotel);
                if (resultadoAgregarHotel == 1)
                {
                    Command<int> add = FabricaComando.crearM09AgregarHabitaciones(_hotel, _hotel._precio);
                    int ad = add.ejecutar();
                }
                if (resultadoAgregarHotel == 1)
                {
                    return "Se registro el hotel exitosamente";
                }
                else
                {
                    return "Hubo un error";
                }
            }
            catch (ReservaExceptionM09 ex)
            {
                return ex.Mensaje;
            }
        }
    }
}