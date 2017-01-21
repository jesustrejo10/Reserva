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
    /// Comando Modificar Hoteles
    /// </summary>
    public class M13_COModificarRol : Command<String>
    {
        Rol _rol;
        int _idmodificar;

        public M13_COModificarRol(Entidad rol, int id) { 
            this._rol = (Rol)rol;
            this._rol._id = id;
        }

        public override String ejecutar(){
            IDAO daoRol = FabricaDAO.instanciarDAORol();
            Entidad test = daoRol.Modificar(_rol);
            Rol rol = (Rol)test;
            return rol._nombreRol;
        }

    }
}