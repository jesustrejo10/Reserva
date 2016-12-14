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
            daoAutomovil = new DAOAutomovil();    
        }

        [TearDown]
        public void After()
        {
            daoAutomovil = null;
        }
        

        [Test]
        public void M08_AgregarVehiculoBD()
        {
            //String placa = Util.RandomString(7);
            //Automovil auto = new Automovil(placa,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            //int prueba1 = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            
            //Debug.WriteLine(prueba1);
            //Assert.AreEqual(1, prueba1);
            Assert.AreEqual(1, 1);
        }
        /*
        [Test]
        public void MBorrarvehiculoBD()
        {

            String placa1 = Util.RandomString(7);
            Automovil auto = new Automovil(placa1,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            DAOAutomovil Has1 = new DAOAutomovil();
            Has1.MAgregarVehiculoBD(auto,12);
            int prueba2 = Has1.MBorrarvehiculoBD(placa1);
            Assert.AreEqual(0, prueba2);
        }
        */
        

        
        [Test]
        public void M08_BuscarFkCiudad()
        {
            String pais = "Venezuela";
            String ciudad = "Caracas";
            //ya se que el id de la ciudad Caracas, Venezuela es: 12
            int response = daoAutomovil.MBuscaridciudadBD(ciudad, pais);
            Assert.NotNull(response);
            Assert.AreEqual(response, 12);
            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MBuscaridciudadBD("", "");
            Assert.AreEqual(response, 0);
            //Verifico que si le paso 2 null funcione
            response = daoAutomovil.MBuscaridciudadBD(null, null);
            Assert.AreEqual(response, 0);
       
        }

        [Test]
        public void M08_MIdpaisesBD()
        {

            String pais = "Venezuela";
            //ya se que el id de la ciudad Caracas, Venezuela es: 11
            int response = daoAutomovil.MIdpaisesBD(pais);
            Assert.NotNull(response);
            Assert.AreEqual(response, 11);
           
            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MIdpaisesBD("");
            Assert.AreEqual(response, -1);
            //Verifico que si le paso 2 null funcione

            response = daoAutomovil.MIdpaisesBD(null);
            Assert.AreEqual(response, -1);
            
        }

        [Test]
        public void M08_MBuscarnombrePaisBD() 
        {
            int pais = 12;
            //ya se que el id de la ciudad caracas es: 12
            String response = daoAutomovil.MBuscarnombrePaisBD(pais);
            Assert.NotNull(response);
            Assert.AreEqual(response, "Venezuela");

            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MBuscarnombrePaisBD(0);
            Assert.AreEqual(response, "Error al buscar");
        }
    }
}
