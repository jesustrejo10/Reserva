using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Models;
using BOReserva.Servicio;
using BOReserva.Controllers;


namespace TestUnitReserva.BO.TestGestionAutomovil
{
    /// <summary>
    /// Clase que realiza pruebas unitarias
    /// </summary>
    [TestFixture]
    public class TestGestionAutomovil
    {

        //DAOAutomovil daoAutomovil;
        manejadorSQL daoAutomovil;
        Automovil auto;
        String placa1 = Util.RandomString(7);
        String placa3 = Util.RandomString(7);

        /// <summary>
        /// Método que intancia la base de datos antes de todo
        /// </summary>
        [SetUp]
        public void Before()
        {
            //daoAutomovil = new DAOAutomovil();
            daoAutomovil = new manejadorSQL();

        }
        /// <summary>
        /// Método que al finalizar las pruebas limpia las variables
        /// </summary>
        [TearDown]
        public void After()
        {
            daoAutomovil = null;
            auto = null;
        }

        /// <summary>
        /// Método que verifica si el vehículo es agregado correctamente a la base de datos
        /// retornando 1
        /// </summary>
        [Test]
        public void M08_AgregarVehiculoBD()
        {

            auto = new Automovil(placa1, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String prueba1 = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            Assert.AreEqual("1", prueba1);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MAgregaraBD()
        {
            auto = new Automovil(placa3, "4", "Jeep", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String h=auto.MAgregaraBD(auto,12);
            Assert.AreEqual("1", h);
        
        }



        /// <summary>
        /// Método que verifica si la cidudad que le estamos pasando existe o no
        /// </summary>
        [Test]
        public void M08_BuscarFkCiudad()
        {
            String pais = "Venezuela";
            String ciudad = "Caracas";
            //ya se que el id de la ciudad Caracas, Venezuela es: 12
            int response = daoAutomovil.MBuscaridciudadBD(ciudad, pais);
            Debug.WriteLine(response);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, 12);
            //Verifico que si le paso 2 vacios funcione
            response = daoAutomovil.MBuscaridciudadBD("", "");
            Debug.WriteLine(response);
            Assert.AreEqual(response, 0);
            //Verifico que si le paso 2 null funcione
            response = daoAutomovil.MBuscaridciudadBD(null, null);
            Debug.WriteLine(response);
            Assert.AreEqual(response, 0);

        }
        /// <summary>
        /// Método que verifica si el pais existe o no
        /// </summary>
        [Test]
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
        [Test]
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
        [Test]
        public void MListarpaisesBD()
        {
            String[] prueba = daoAutomovil.MListarpaisesBD();
            //prueba no vacia
            Assert.IsNotNull(prueba);
            //
            int contar = 0;
            bool verdad = true;

            while (verdad == true)
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
        [Test]
        public void MDisponibilidadVehiculoBD()
        {
            String prueba3 = daoAutomovil.MDisponibilidadVehiculoBD(placa1, 0);
            Assert.AreEqual("1", prueba3);

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MDisponibilidadVehiculo()

        {
            Automovil auto = new Automovil(placa1, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String prueba = auto.MDisponibilidadVehiculoBD(placa1, 0);
            Assert.AreEqual("1", prueba);

        }
        /// <summary>
        /// Método validar buscarvehículo para ver si existe el automovil
        /// </summary>
        [Test]
        public void MMostrarvehiculoBD()
        {
            // si no consigue
            Automovil buscarvehiculo = daoAutomovil.MMostrarvehiculoBD("HGJYJG");
            Assert.IsNull(buscarvehiculo);
            Automovil buscarvehiculo1 = daoAutomovil.MMostrarvehiculoBD("AUT223");
            //si pasa..
            Assert.IsInstanceOf(typeof(Automovil), buscarvehiculo1);


        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MConsultarvehiculo()
        {
            Automovil auto = new Automovil("PRUEBACON", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            Automovil auto1 = auto.MConsultarvehiculo("PRUEBACON");
            Assert.IsInstanceOf(typeof(Automovil), auto1);
            String prueba2 = daoAutomovil.MBorrarvehiculoBD("PRUEBACON");
        
        }
        /// <summary>
        /// Método que verificar modificarvehiculo, si se logra modificar retorna 1 sino retorna 0
        /// </summary>
        [Test]
        public void MModificarVehiculoBD()
        {
            String placa = placa1;
            auto = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            String prueba = daoAutomovil.MModificarVehiculoBD(auto, 13);
            Assert.AreEqual("1", prueba);
            auto = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
            String prueba2 = daoAutomovil.MModificarVehiculoBD(auto, 1000);
            Assert.AreNotEqual(0, prueba2);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MModificarvehiculo()
        {
            String placa = placa3;
            auto = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = daoAutomovil.MAgregarVehiculoBD(auto, 12);
            String prueba = auto.MModificarvehiculoBD(auto, 13);
            Assert.AreEqual("1", prueba);
            auto = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
            String prueba2 = auto.MModificarvehiculoBD(auto, 1000);
            Assert.AreNotEqual(0, prueba2);
        
        }
        /// <summary>
        /// Método que lista todos los vehículos existentes
        /// </summary>
        [Test]
        public void MListarvehiculosBD()
        {
            List<Automovil> prueba = daoAutomovil.MListarvehiculosBD();
            Assert.IsInstanceOf(typeof(List<Automovil>), prueba);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MListarvehiculos()
        {

            Automovil auto = new Automovil(placa1, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            List<Automovil> h= auto.MListarvehiculos();
            Assert.IsInstanceOf(typeof(List<Automovil>), h);
   

        }

        /// <summary>
        /// Método que realiza la busqueda del nombre de la ciudad si existe su id, si no lo consigue arroja "Error al buscar"
        /// </summary>
        [Test]
        public void MBuscarnombreciudadBD()
        {
            String prueba = daoAutomovil.MBuscarnombreciudadBD(12);
            Assert.AreEqual("Caracas", prueba);
            string prueba2 = daoAutomovil.MBuscarnombreciudadBD(1000);
            Assert.AreEqual("Error al buscar", prueba2);
        }

        /// <summary>
        /// Método que verifica si se ejecuta bien la revisión de placa
        /// </summary>
        [Test]
        public void MPlacarepetidaBD()
        {

            int repetida = daoAutomovil.MPlacarepetidaBD(placa1);
            Assert.AreEqual(1, repetida);
            int repetidano = daoAutomovil.MPlacarepetidaBD("SIUL1208");
            Assert.AreEqual(0, repetidano);
        }
        /// <summary>
        /// Método que verifica si el vehículo es borrado de la base de datos correctamente
        /// </summary>
        [Test]
        public void MBorrarvehiculoBD()
        {
            String prueba2 = daoAutomovil.MBorrarvehiculoBD(placa1);
            Assert.AreEqual("1", prueba2);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void MBorrarvehiculo()
        {
            Automovil auto = new Automovil(placa1, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String Prueba3 = auto.MBorrarvehiculoBD(placa3);
            Assert.AreEqual("1", Prueba3);
        }
        /// <summary>
        /// Método que verifica si se retorna la cantidad de ciudades 
        /// </summary>
        [Test]
        public void MListarciudadesBD()
        {
            List<String> h = daoAutomovil.MListarciudadesBD(11);

            Assert.AreEqual(5, h.Count);
        }



        
    }
}
