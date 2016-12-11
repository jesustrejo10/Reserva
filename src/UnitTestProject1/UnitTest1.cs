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

        DAOAutomovil daoAutomovil;
        Automovil auto;
        String placa1 = Util.RandomString(7);

       [TestInitialize()] 
        public void Before()
        {
            daoAutomovil = new DAOAutomovil();
            
        }

        [TestCleanup()]
         public void After()
        {
            daoAutomovil = null;
            auto = null;
        }
        

        [TestMethod]
        public void M08_AgregarVehiculoBD()
        {
            
            auto = new Automovil(placa1,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            int prueba1 = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            Assert.AreEqual(1, prueba1);
        }

        [TestMethod]
        public void MBorrarvehiculoBD()
        {

            
            //auto = new Automovil(placa1,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
           
           // daoAutomovil.MAgregarVehiculoBD(auto,12);
            int prueba2 = daoAutomovil.MBorrarvehiculoBD(placa1);
            Assert.AreEqual(1, prueba2);
        }
    }
}
