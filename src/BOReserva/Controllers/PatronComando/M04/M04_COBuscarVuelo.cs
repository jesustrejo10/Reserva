using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COBuscarVuelo : Command<Entidad>
    {
        private int _id;

        #region Constructores

        /// <summary>
        /// Constructor simple
        /// </summary>
        public M04_COBuscarVuelo() {}

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto que se quiere agregar</param>
        public M04_COBuscarVuelo(int id)
        {
            _id = id; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Entidad ejecutar()
        {
            try
            {
                IDAO buscarVuelo = FabricaDAO.instanciarDAOVuelo();
                return(buscarVuelo.Consultar(_id));
            }
            catch (ExceptionBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }
}