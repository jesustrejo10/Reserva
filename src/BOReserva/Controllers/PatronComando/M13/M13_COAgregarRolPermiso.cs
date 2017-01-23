using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    ///<summary>
    ///Comando para agregar permiso a rol
    ///</summary>
    public class M13_COAgregarRolPermiso : Command<String>
    {
        Rol _rol;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COAgregarRolPermiso(Rol rol)
        {
            this._rol = rol;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override string ejecutar()
        {
            IDAORol daoRol = (IDAORol)FabricaDAO.instanciarDAORol();
            daoRol.AgregarRolPermiso(_rol);
            return "1";
        }
    }
}