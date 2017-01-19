using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COAgregarRolPermiso : Command<String>
    {
        Rol _rol;

        public M13_COAgregarRolPermiso(Rol rol)
        {
            this._rol = rol;
        }

        public override string ejecutar()
        {
            IDAORol daoRol = FabricaDAO.instanciarDAORolPermiso();
            daoRol.AgregarRolPermiso(_rol);
            return "1";
        }
    }
}