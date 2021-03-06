﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    internal class M01_CONumeroIntentos : Command<int>
    {
        private Entidad usuario;

        public M01_CONumeroIntentos(Entidad _usuario)
        {
            this.usuario = _usuario;
        }

        public override int ejecutar()
        {
            IDAOLogin dao = (DAOLogin)FabricaDAO.instanciarDaoLogin();
            var respuesta = dao.NumeroIntentos(usuario);
            return respuesta;
        }
    }
}