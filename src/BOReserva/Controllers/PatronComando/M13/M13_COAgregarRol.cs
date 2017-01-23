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
    ///Comando para agregar rol
    ///</summary>
    public class M13_COAgregarRol : Command<String>
    {
        Rol _rol;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COAgregarRol(Rol rol)
        {
            this._rol = rol;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>String</returns>
        public override string ejecutar()
        {
            IDAO daoRol = FabricaDAO.instanciarDAORol();
            daoRol.Agregar(_rol);
            return "1";
        }
    }
}