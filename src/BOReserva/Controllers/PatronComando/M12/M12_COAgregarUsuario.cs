﻿using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a realizar las respectivas operaciones necesarias
    /// para añadir un usuario a la BD
    /// </summary>
    public class M12_COAgregarUsuario : Command<String>
    {
        Usuario _usuario;
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        public M12_COAgregarUsuario (Usuario usuario)
        {
            this._usuario = usuario;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override string ejecutar()
        {
            IDAO daoUsuario = FabricaDAO.instanciarDaoUsuario();
            int test = daoUsuario.Agregar(_usuario);
            return test.ToString();
        }
    }
}
