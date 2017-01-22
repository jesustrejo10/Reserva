using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    public class M09_COAgregarHabitaciones : Command<int>
    {
        Dictionary<int,Entidad> _habitaciones;

        public M09_COAgregarHabitaciones(Dictionary<int, Entidad> habitaciones)
        { 
            this._habitaciones = habitaciones;
        }

        public override int ejecutar() {
        
            return 0;
        }

    }
}