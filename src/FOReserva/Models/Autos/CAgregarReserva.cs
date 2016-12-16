using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Autos
{
    public class CAgregarReserva
    {
        public int raut_id { get; set; }
        public String raut_fechaentrega{ get; set; }
        public String raut_fechadevolucion { get; set; }
        public String raut_horaini { get; set; }
        public String raut_horafin { get; set; }
        public int raut_usuario { get; set; }
        public String  raut_automovil{ get; set; }
        public int raut_ciudadentrega { get; set; }
        public int raut_ciudaddevolucion { get; set; }
        public int raut_estatus { get; set; }


    }
}