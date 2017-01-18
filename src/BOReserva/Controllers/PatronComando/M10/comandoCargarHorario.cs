using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    public class comandoCargarHorario : Command<List<String>>
    {

        public override List<string> ejecutar()
        {
            return FabricaDAO.listarHorario();
        }
    }
}