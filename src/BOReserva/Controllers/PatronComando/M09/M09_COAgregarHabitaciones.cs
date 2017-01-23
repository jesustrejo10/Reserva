using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Clase comando para agregar habitaciones de los hoteles
    /// </summary>
    public class M09_COAgregarHabitaciones : Command<int>
    {
        Hotel _hotel;
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="hotel">Hotel que posee las habitaciones a agregar</param>
        /// <param name="precio">Precio de las habitaciones del mismo</param>
        public M09_COAgregarHabitaciones(Hotel hotel, int precio)
        {
            this._hotel = hotel;
            _hotel._precio = precio;
        }
        /// <summary>
        /// Implementacion del metodo ejecutar de la clase abstracta Command para esta situacion
        /// </summary>
        /// <returns>Retorna un valor entero</returns>
        public override int ejecutar()
        {
            try
            {
                IDAOHabitacion habdao = (IDAOHabitacion)FabricaDAO.instanciarDaoHabitacion();
                String resp = habdao.Agregarhab(_hotel, _hotel._precio);
                if (resp.Equals("1"))
                    return 1;
                else 
                    return 0;
            }
            catch (ReservaExceptionM09 ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                return 0;
            }

        }
    }
}