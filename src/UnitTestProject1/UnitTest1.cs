using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOReserva.Models.gestion_automoviles;
using BOReserva.Models;
using System.Diagnostics;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void setup() {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void M08_AgregarVehiculoBD()
        {
            DAOAutomovil daoAutomovil = new DAOAutomovil();    
            String placa = Util.RandomString(7);
            Automovil auto = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            int prueba1 = daoAutomovil.MAgregarVehiculoBD(auto, 12);

            Debug.WriteLine(prueba1);
            Assert.AreEqual(1, prueba1);
        }
    }
}
