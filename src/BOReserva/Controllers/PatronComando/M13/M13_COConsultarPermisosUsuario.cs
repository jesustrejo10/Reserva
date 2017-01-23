using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M13_COConsultarPermisosUsuario : Command<List<String>>
    {
        int idUsuario;

        public M13_COConsultarPermisosUsuario(int id)
        {
            this.idUsuario = id;
        }

        public override List<String> ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            List<String> test = daoRol.consultarPermisosUsuario(idUsuario);
            return test;
        }
    }
}