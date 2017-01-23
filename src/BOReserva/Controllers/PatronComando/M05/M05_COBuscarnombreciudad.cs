using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Clase comando para la busqueda de la ciudad
    /// </summary>
    public class M05_COBuscarnombreciudad : Command<String>
    {

        int idciudad;

        /// <summary>
        /// Comando para la busqueda del nombre de una ciudad
        /// </summary>
        /// <param name="e"></param>
        public M05_COBuscarnombreciudad(Entidad e)
        {
            this.idciudad = e._id;
        }

        public override String ejecutar()
        {
            IDAOLugar daoLugar = (IDAOLugar) FabricaDAO.instanciarDaoLugar();
            String nombreCiudad = daoLugar.ciudad(idciudad);
            return nombreCiudad;
        }
    }
}