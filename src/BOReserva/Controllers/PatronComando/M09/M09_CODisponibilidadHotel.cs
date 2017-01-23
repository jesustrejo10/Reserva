using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M09;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Clase del comando de cambiar la disponibilidad de un hotel
    /// </summary>
    public class M09_CODisponibilidadHotel: Command<String>
    {
        Hotel _hotel;
        int _disponibilidad;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="hotel">Hotel a moficar</param>
        /// <param name="disponibilidad">Estatus nuevo</param>
        public M09_CODisponibilidadHotel(Entidad hotel, int disponibilidad)
        { 
            this._hotel = (Hotel) hotel;
            this._disponibilidad = disponibilidad;
        }

        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
                IDAOHotel daoHotel = (DAOHotel)FabricaDAO.instanciarDaoHotel();
                Entidad ent = daoHotel.disponibilidadHotel(_hotel, _disponibilidad);

                Cache.actualizarMapHotelesDisponibilidad(ent._id, _disponibilidad);
                return ResourceM09Command.DisponibilidadCorrectamente;
            }
            catch (ReservaExceptionM09 ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);               
                return ex.Codigo;
            }
        }

    }
}