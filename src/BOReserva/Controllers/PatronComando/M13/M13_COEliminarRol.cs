using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    ///<summary>
    ///Comando que elimina un rol
    ///</summary>
    public class M13_COEliminarRol : Command<String>
    {
        Rol _rol;

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        public M13_COEliminarRol(Entidad rol, int id)
        {
            this._rol = (Rol)rol;
            this._rol._idRol = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override String ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            String test = daoRol.eliminarRol(_rol._idRol);
            return test;
        }

    }
}