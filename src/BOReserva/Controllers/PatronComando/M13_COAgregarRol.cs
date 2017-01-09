using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COAgregarRol : Command<String>
    {
        Rol _rol;

        public M13_COAgregarRol(Rol rol)
        {
            this._rol = rol;
        }

        public override string ejecutar()
        {
            IDAO daoRol = FabricaDAO.instanciarDAORol();
            daoRol.Agregar(_rol);
            return "1";
        }
    }
}