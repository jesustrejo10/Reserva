﻿using BOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M13
{
    ///<summary>
    ///Comando que quita permiso asociado a un rol
    ///</summary>
    public class M13_COQuitarPermiso : Command<String>
    {
        int _idRol;
        int _idPermiso;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COQuitarPermiso(int idRol, int idPermiso)
        {
            this._idRol = idRol;
            this._idPermiso = idPermiso;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override String ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            String test = daoRol.quitarPermiso(_idRol, _idPermiso);
            return test;
        }

    }
}