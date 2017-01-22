using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace FOReserva.Controllers.PatronComando.M14
{
    public class M14_COModificarPerfil : Command<bool>
    {
        private Entidad _nodo;

        /// <summary>
        /// Metodo para setear el usuario
        /// </summary>
        /// <param name="usuario">El usuario que viene del controlador</param>
        public M14_COModificarPerfil(Entidad usuario)
        {
            this._nodo = usuario;
        }

        public override bool ejecutar()
        {
            IDAORegistroU daoUsuario = FabricaDAO.instanciarDaoUsuario();
            return daoUsuario.ModificarPerfil(_nodo);
        }
    }
}