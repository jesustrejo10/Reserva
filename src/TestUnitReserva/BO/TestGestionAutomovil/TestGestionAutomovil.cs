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
        manejadorSQL _manejadorSql;
        Automovil _automovil;
        String _matriculaPrueba;
        String _matriculaPrueba2;

        /// <summary>
        /// Metodo que se ejecuta una sola vez durante toda la prueba;
        /// Guardo valores de _matriculaPrueba y _matriculaPrueba2;
        /// </summary>
        [SetUpFixture]
        public void BeforeAll() {
            _matriculaPrueba = Util.RandomString(7);
            _matriculaPrueba2 = Util.RandomString(7);
        }
        
        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            //daoAutomovil = new DAOAutomovil();
            _manejadorSql = new manejadorSQL();

        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            _manejadorSql = null;
            _automovil = null;
        }

        /// <summary>
        /// Método que verifica si el vehículo es agregado correctamente a la base de datos
        /// retornando 1
        /// </summary>
        [Test]
        public void M08_AgregarVehiculoBD()
        {

            _automovil = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String prueba1 = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
            Assert.AreEqual("1", prueba1);
        }

        /// <summary>
        /// Método que verifica si el vehículo es agregado correctamente a la base de datos
        /// retornando 1
        /// </summary>
        [Test]
        public void MAgregaraBD()
        {
            _automovil = new Automovil(_matriculaPrueba2, "4", "Jeep", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String respuestaAgregar=_automovil.MAgregaraBD(_automovil,12);
            Assert.AreEqual("1", respuestaAgregar);
        
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
            int response = _manejadorSql.MBuscaridciudadBD(ciudad, pais);
            Debug.WriteLine(response);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, 12);
            //Verifico que si le paso 2 vacios funcione
            response = _manejadorSql.MBuscaridciudadBD("", "");
            Debug.WriteLine(response);
            Assert.AreEqual(response, 0);
            //Verifico que si le paso 2 null funcione
            response = _manejadorSql.MBuscaridciudadBD(null, null);
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
            int response = _manejadorSql.MIdpaisesBD(pais);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, 11);

            //Verifico que si le paso 2 vacios funcione
            response = _manejadorSql.MIdpaisesBD("");
            Assert.AreEqual(response, -1);
            //Verifico que si le paso 2 null funcione

            response = _manejadorSql.MIdpaisesBD(null);
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
            String response = _manejadorSql.MBuscarnombrePaisBD(pais);
            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Venezuela");

            //Verifico que si le paso 2 vacios funcione
            response = _manejadorSql.MBuscarnombrePaisBD(0);
            Assert.AreEqual(response, "Error al buscar");
        }
        /// <summary>
        /// Método que cuenta todos los paises existentes en la base de datos 
        /// se realzia la prueba por ser un rango definido de paises y verifica si no llega vacio
        /// </summary>
        [Test]
        public void MListarpaisesBD()
        {
            String[] prueba = _manejadorSql.MListarpaisesBD();
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
            String prueba3 = _manejadorSql.MDisponibilidadVehiculoBD(_matriculaPrueba, 0);
            Assert.AreEqual("1", prueba3);

        }

        /// <summary>
        /// Método que verifica si la placa a buscar existe
        /// </summary>
        [Test]
        public void MDisponibilidadVehiculo()

        {
            Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String prueba = auto.MDisponibilidadVehiculoBD(_matriculaPrueba, 0);
            Assert.AreEqual("1", prueba);

        }
        /// <summary>
        /// Método validar buscarvehículo para ver si existe el automovil
        /// </summary>
        [Test]
        public void MMostrarvehiculoBD()
        {
            // si no consigue
            Automovil buscarvehiculo = _manejadorSql.MMostrarvehiculoBD("FALLAR");
            Assert.IsNull(buscarvehiculo);
            Automovil auto = new Automovil("PRUEBACON", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = _manejadorSql.MAgregarVehiculoBD(auto, 12);
            Automovil buscarvehiculo1 = _manejadorSql.MMostrarvehiculoBD("PRUEBACON");
            //si pasa..
            Assert.IsInstanceOf(typeof(Automovil), buscarvehiculo1);


        }
        /// <summary>
        /// Método validar buscarvehículo para ver si existe el automovil
        /// </summary>
        [Test]
        public void MConsultarvehiculo()
        {
            Automovil auto = new Automovil("PRUEBACON", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = _manejadorSql.MAgregarVehiculoBD(auto, 12);
            Automovil auto1 = auto.MConsultarvehiculo("PRUEBACON");
            Assert.IsInstanceOf(typeof(Automovil), auto1);
            String prueba2 = _manejadorSql.MBorrarvehiculoBD("PRUEBACON");
        
        }
        /// <summary>
        /// Método que verificar modificarvehiculo, si se logra modificar retorna 1 sino retorna 0
        /// </summary>
        [Test]
        public void MModificarVehiculoBD()
        {
            String placa = _matriculaPrueba;
            _automovil = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
            String prueba = _manejadorSql.MModificarVehiculoBD(_automovil, 13);
            Assert.AreEqual("1", prueba);
            _automovil = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
            String prueba2 = _manejadorSql.MModificarVehiculoBD(_automovil, 1000);
            Assert.AreNotEqual(0, prueba2);
        }

        /// <summary>
        /// Método que verificar modificarvehiculo, si se logra modificar retorna 1 sino retorna 0
        /// </summary>
        [Test]
        public void MModificarvehiculo()
        {
            String placa = _matriculaPrueba2;
            _automovil = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
            String prueba = _automovil.MModificarvehiculoBD(_automovil, 13);
            Assert.AreEqual("1", prueba);
            _automovil = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
            String prueba2 = _automovil.MModificarvehiculoBD(_automovil, 1000);
            Assert.AreNotEqual(0, prueba2);
        
        }
        /// <summary>
        /// Método que lista todos los vehículos existentes
        /// </summary>
        [Test]
        public void MListarvehiculosBD()
        {
            List<Automovil> prueba = _manejadorSql.MListarvehiculosBD();
            Assert.IsInstanceOf(typeof(List<Automovil>), prueba);
        }
        /// <summary>
        ///  Método que lista todos los vehículos existentes
        /// </summary>
        [Test]
        public void MListarvehiculos()
        {

            Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            List<Automovil> listado = auto.MListarvehiculos();
            Assert.IsInstanceOf(typeof(List<Automovil>), listado);
   

        }

        /// <summary>
        /// Método que realiza la busqueda del nombre de la ciudad si existe su id, si no lo consigue arroja "Error al buscar"
        /// </summary>
        [Test]
        public void MBuscarnombreciudadBD()
        {
            String prueba = _manejadorSql.MBuscarnombreciudadBD(12);
            Assert.AreEqual("Caracas", prueba);
            string prueba2 = _manejadorSql.MBuscarnombreciudadBD(1000);
            Assert.AreEqual("Error al buscar", prueba2);
        }

        /// <summary>
        /// Método que verifica si se ejecuta bien la revisión de placa
        /// </summary>
        [Test]
        public void MPlacarepetidaBD()
        {

            int repetida = _manejadorSql.MPlacarepetidaBD(_matriculaPrueba);
            Assert.AreEqual(1, repetida);
            int repetidano = _manejadorSql.MPlacarepetidaBD("SIUL1208");
            Assert.AreEqual(0, repetidano);
        }
        /// <summary>
        /// Método que verifica si el vehículo es borrado de la base de datos correctamente
        /// </summary>
        [Test]
        public void MBorrarvehiculoBD()
        {
            String prueba2 = _manejadorSql.MBorrarvehiculoBD(_matriculaPrueba);
            Assert.AreEqual("1", prueba2);
        }
        /// <summary>
        ///  Método que verifica si el vehículo es borrado de la base de datos correctamente
        /// </summary>
        [Test]
        public void MBorrarvehiculo()
        {
            Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
            String Prueba3 = auto.MBorrarvehiculoBD(_matriculaPrueba2);
            Assert.AreEqual("1", Prueba3);
        }
        /// <summary>
        /// Método que verifica si se retorna la cantidad de ciudades 
        /// </summary>
        [Test]
        public void MListarciudadesBD()
        {
            List<String> h = _manejadorSql.MListarciudadesBD(11);

            Assert.AreEqual(5, h.Count);
        }



        
    }
}
﻿