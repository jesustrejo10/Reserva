using System;
using NUnit.Framework;
using FOReserva.Models.Restaurantes;
using FOReserva.Servicio;

namespace TestUnitReserva.FO.Reserva_restaurante
{
    [TestFixture]
    class TestInsertReserva
    {
        private CReservation_Restaurant reserva;

        [SetUp]
        public void init()
        {
            reserva = new CReservation_Restaurant(null, "carlos Herrera", new DateTime(), "09:00", 6);
            
        }
    }
}
