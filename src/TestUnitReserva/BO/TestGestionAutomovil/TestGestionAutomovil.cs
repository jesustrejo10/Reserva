using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Models;

namespace TestUnitReserva.BO.TestGestionAutomovil
{
    [TestFixture]
    public class  TestGestionAutomovil
    {
        DAOAutomovil daoAutomovil;

        [SetUp]
        public void Before()
        {
            DAOAutomovil daoAutomovil = new DAOAutomovil();    
        }

        [TearDown]
        public void After() {
            daoAutomovil = null;
        }

        [Test]
        public void M08_AgregarVehiculoBD()
        {
            String placa = Util.RandomString(7);
            Automovil auto = new Automovil(placa,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            
            int prueba1 = daoAutomovil.MAgregarVehiculoBD(auto);
            Debug.WriteLine(prueba1);
            Assert.AreEqual(1, prueba1);
        }

        /*
        [Test]
        public void M08_BuscarFkCiudad()
        {
            String pais = "Venezuela";
            String ciudad = "Caracas";
            //ya se que el id de la ciudad Caracas, Venezuela es: 12
            int response = daoAutomovil.MBuscarfkciudad(ciudad, pais);
            Assert.AreEqual(response, 12);

        }

        */
    }
}
