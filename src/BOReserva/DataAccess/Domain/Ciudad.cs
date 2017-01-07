using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Ciudad : Entidad
    {
        public String _nombre { get; set; }
        public Pais _pais { get; set; }
    }
}