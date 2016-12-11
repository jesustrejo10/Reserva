using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOReserva.Models.gestion_automoviles;
using BOReserva.Models;
using System.Diagnostics;
using System.Collections.Generic;

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

        /// <summary>
        /// Método que intancia la base de datos antes de todo
        /// </summary>
       [TestInitialize()] 
        public void Before()
        {
            daoAutomovil = new DAOAutomovil();
            
        }
        /// <summary>
        /// Método que al finalizar las pruebas limpia las variables
        /// </summary>
        [TestCleanup()]
         public void After()
        {
            daoAutomovil = null;
            auto = null;
        }
        
        /// <summary>
        /// Método que verifica si el vehículo es agregado correctamente a la base de datos
        /// retornando 1
        /// </summary>
        [TestMethod]
        public void M08_AgregarVehiculoBD()
        {
            
            auto = new Automovil(placa1,"3","Mazda",1936,"Sedan",5,5,1,1,1,DateTime.Now,"Azul",1,"Automatica","Venezuela","Caracas");
            int prueba1 = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            Assert.AreEqual(1, prueba1);
        }
         

        /// <summary>
        /// Método que verifica si la cidudad que le estamos pasando existe o no
        /// </summary>
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
        /// <summary>
        /// Método que verifica si el pais existe o no
        /// </summary>
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
        /// <summary>
        /// Método que realiza búsqueda de los un pais, verifica si existe el pais 
        /// o no encuentra coincidencias
        /// </summary>
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
        /// <summary>
        /// Método que cuenta todos los paises existentes en la base de datos 
        /// se realzia la prueba por ser un rango definido de paises y verifica si no llega vacio
        /// </summary>
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
        /// <summary>
        /// Método que verifica si la placa a buscar existe
        /// </summary>
        [TestMethod]
        public void MDisponibilidadVehiculoBD()
        {
            int prueba3 = daoAutomovil.MDisponibilidadVehiculoBD(placa1, 0);
            Assert.AreEqual(1, prueba3);

        }
        /// <summary>
        /// Método que verifica si el vehículo es borrado de la base de datos correctamente
        /// </summary>
        [TestMethod]
        public void MBorrarvehiculoBD()
        {
            int prueba2 = daoAutomovil.MBorrarvehiculoBD(placa1);
            Assert.AreEqual(1, prueba2);
        }
        [TestMethod]
        public void MListarciudadesBD()
        {
             List<String> h = daoAutomovil.MListarciudadesBD(11);

            try

            {
            }
            catch
            {
            
            }
            Assert.AreEqual(5, h.Count);
        }


    }
}
