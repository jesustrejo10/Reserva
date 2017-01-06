using BOReserva.Controllers.PatronComando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    abstract public class Command
    {
        abstract public String ejecutar();
    }
}