using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando.M16
{

    /// <summary>
    /// Comando que instancia el metodo de consultar los reclamos totales de un usuario
    /// </summary>
    public class M16_COConsultarReclamos: Command<List<Reclamo>>
    {
        #region Atributos
        int _idUsuario;
        #endregion
        /// <summary>
        /// Metodo que instancia el comando
        /// </summary>
        /// <param name="_idUsuario">id del usuario que se desea saber que reclamos tiene</param>
        public M16_COConsultarReclamos(int _idUsuario)
        {
            this._idUsuario = _idUsuario;
        }


        /// <summary>
        /// Instanciacion de la consulta a la base de datos de este comando
        /// </summary>
        /// <returns>Lista con los reclamos del usuario</returns>
       
        public override List<Reclamo> ejecutar()
        {
            try
            {
                IDAOReclamo reclamoDao = FabricaDAO.reclamoPersonalizado();
                return reclamoDao.ConsultarReclamosPorUsuario(_idUsuario);
            }
            catch (NotImplementedException)
            {

                throw;
            }

        }
    }
}