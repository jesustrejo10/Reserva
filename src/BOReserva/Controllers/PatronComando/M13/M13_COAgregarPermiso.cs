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
    ///<summary>
    ///Comando para agregar permiso
    ///</summary>
    public class M13_COAgregarPermiso : Command<String>
    {
        Permiso _permiso;

        ///<summary>
        ///Instancia del comando
        ///</summary>
        public M13_COAgregarPermiso(Permiso permiso)
        {
            this._permiso = permiso;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override string ejecutar()
        {
            IDAO daoPermiso = FabricaDAO.instanciarDAOPermiso();
            daoPermiso.Agregar(_permiso);
            return "1";
        }
    }
}