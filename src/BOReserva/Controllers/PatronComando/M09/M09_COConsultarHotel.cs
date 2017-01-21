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
    /// Clase del comando para consultar los hoteles de la BD
    /// </summary>
    public class M09_COConsultarHotel: Command<Entidad>
    {
        int valor;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="value">Identificador del hotel a buscar</param>
        public M09_COConsultarHotel(int value){
            this.valor = value;
        }


        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override Entidad ejecutar()
        {
            try
            {
                IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
                Entidad hotel = daoHotel.Consultar(valor);
                return hotel;
            }
            catch (ReservaExceptionM09 ex)
            {
                throw ex;
            }
        }
    }
}