﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COConsultarPermisosAsociados : Command<String>
    {

        Rol _rol;
        int _idEliminar;

        public M13_COConsultarPermisosAsociados(Entidad rol, int id)
        {
            this._rol = (Rol)rol;
            this._rol._idRol = id;
        }

        public override String ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            String test = daoRol.eliminarRol(_rol._idRol);
            return test;
        }
    }
}