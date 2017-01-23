using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject;

namespace BOReserva.Controllers.PatronComando.M03
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para a;adir una Ruta a la BD
    /// </summary>
    public class M03_COAgregarRuta : Command<String>
    {
        private Entidad _ruta;

        #region Constructores

        /// <summary>
        /// Constructor simple
        /// </summary>
        public M03_COAgregarRuta() { }

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="ruta">Es el objeto que se quiere agregar</param>
        public M03_COAgregarRuta(Entidad ruta)
        {
            _ruta = ruta;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override String ejecutar()
        {
            try
            {
                IDAO rutaAdd = FabricaDAO.instanciarDAORuta();
                rutaAdd.Agregar(_ruta);
                return "1";
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }

        }
        #endregion
    }
}