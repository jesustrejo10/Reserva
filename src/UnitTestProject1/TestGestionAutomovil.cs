using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOReserva.Models.gestion_automoviles;
using BOReserva.Models;
using System.Diagnostics;

namespace UnitTestProject1
{
    /// <summary>
    /// Clase que realiza pruebas unitarias
    /// </summary>
    [TestClass]
    public class TestGestionAutomovil
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
        public void M08_BuscarFkCiudad()
        {
            String pais = "Venezuela";
            String ciudad = "Caracas";
            //ya se que el id de la ciudad Caracas, Venezuela es: 12
            int response = daoAutomovil.MBuscaridciudadBD(ciudad, pais);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, 12);
            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MBuscaridciudadBD("", "");
            Assert.AreEqual(response, 0);
            //Verifico que si le paso 2 null funcione
            response = daoAutomovil.MBuscaridciudadBD(null, null);
            Assert.AreEqual(response, 0);

        }

        [TestMethod]
        public void M08_MIdpaisesBD()
        {

            String pais = "Venezuela";
            //ya se que el id de la ciudad Caracas, Venezuela es: 11
            int response = daoAutomovil.MIdpaisesBD(pais);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, 11);

            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MIdpaisesBD("");
            Assert.AreEqual(response, -1);
            //Verifico que si le paso 2 null funcione

            response = daoAutomovil.MIdpaisesBD(null);
            Assert.AreEqual(response, -1);

        }

        [TestMethod]
        public void M08_MBuscarnombrePaisBD()
        {
            int pais = 12;
            //ya se que el id de la ciudad caracas es: 12
            String response = daoAutomovil.MBuscarnombrePaisBD(pais);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Venezuela");

            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MBuscarnombrePaisBD(0);
            Assert.AreEqual(response, "Error al buscar");
        }

        [TestMethod]
        public void MListarpaisesBD()
        {
            String[] prueba = daoAutomovil.MListarpaisesBD();
            //prueba no vacia
            Assert.IsNotNull(prueba);
          //
            int contar = 0;
            bool verdad= true;
            
           while (verdad==true)
            {
                try
                {
                    string prueb1 = prueba[contar].ToUpper();
                    ++contar;
                }
                catch 
                {
                    verdad = false;    
                }
              

           }
           Assert.AreEqual(16, contar);

        }

        [TestMethod]
        public void MDisponibilidadVehiculoBD()
        {
            int prueba3 = daoAutomovil.MDisponibilidadVehiculoBD(placa1, 0);
            Assert.AreEqual(1, prueba3);

        }

        [TestMethod]
        public void MBorrarvehiculoBD()
        {
            int prueba2 = daoAutomovil.MBorrarvehiculoBD(placa1);
            Assert.AreEqual(1, prueba2);
        }

    }
}
