using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    abstract public class Command
    {
        abstract public String ejecutar();

        abstract public Dictionary<int, Entidad> ejecutarComando();
    }
}