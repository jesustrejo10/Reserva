using BOReserva.DataAccess.DAO;
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
    /// Comando Modificar Permisos
    /// </summary>
    public class M13_COModificarPermiso : Command<String>
    {
        Permiso _permiso;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COModificarPermiso(Entidad permiso, int id) { 
            this._permiso = (Permiso)permiso;
            this._permiso._id = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override String ejecutar(){
            IDAOPermiso daoPermiso = (IDAOPermiso)FabricaDAO.instanciarDAOPermiso();
            Entidad test = daoPermiso.Modificar(_permiso);
            Permiso permiso = (Permiso)test;
            return permiso.nombrePermiso;
        }

    }
}