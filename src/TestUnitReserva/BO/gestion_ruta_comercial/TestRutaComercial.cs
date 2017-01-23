using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_hoteles;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M03;

namespace TestUnitReserva.BO.gestion_ruta_comercial
{
    [TestFixture]
    class TestRutaComercial
    {
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Ruta mockRuta;
        DAORuta daoRuta;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {

            mockRuta = new Ruta(555, 1000, "Activa", "Aerea", "Texas - Estados Unidos", "Merida - Venezuela");
            daoRuta = new DAORuta();
             
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockPais = null;
            mockCiudad = null;
            mockRuta = null;
            daoRuta = null;
        }

        [Test]
        public void TestConsultarDestino()
        {
            Dictionary<int, Entidad> listaLugares = daoRuta.consultarDestinos();
            Assert.NotNull(listaLugares);
            Ruta e = (Ruta)listaLugares[99];
            Assert.AreEqual(e._destinoRuta, "rutaDestinoDePruebasUnitarias");

        }
        
        [Test]
        public void TestValidarRuta()
        {
            Boolean ValidarRuta = daoRuta.ValidarRuta(mockRuta);
             Assert.IsTrue(ValidarRuta);
        }

        [Test]
        public void TestHabilitarRuta()
        {
            int prueba = 42;
            Assert.IsTrue(daoRuta.habilitarRuta(prueba));

        }

        [Test]
        public void TestdeshabilitarRuta()
        {
            int prueba = 5;
            Assert.IsTrue(daoRuta.deshabilitarRuta(prueba));

        }

        [Test]
        public void TestModificarRuta()
        {

           /* CAgregarRuta prueba = new CAgregarRuta();
            prueba._idRuta = 5;
            prueba._estadoRuta = "Activa";
            prueba._distanciaRuta = 765;
            Assert.IsTrue(sql.MModificarRuta(prueba));
        
            */}

        [Test]
        public void TestListar()
        {
            List<String> prueba = new List<String>();
            prueba = sql.listarLugares();
            Assert.IsNotNull(prueba);
        }

        [Test]
        public void TestConsultarDestinos()
        {
            List<String> prueba = new List<String>();
            prueba = sql.consultarDestinos("Caracas - Venezuela");
            Assert.IsNotNull(prueba);
        }

        [Test]
        public void TestMostrarRuta()
        {
            CAgregarRuta prueba = new CAgregarRuta();
            prueba = sql.MMostrarRutaBD(5);
            Assert.AreEqual(765,prueba._distanciaRuta);
            Assert.AreEqual("Valencia - Venezuela", prueba._origenRuta);
            Assert.AreEqual("Valencia - España", prueba._destinoRuta);
            Assert.AreEqual("Activa", prueba._estadoRuta);
            Assert.AreEqual("Aerea", prueba._tipoRuta);
        }

        [Test]
        public void TestInhabilitarRuta()
        {
            int prueba = 44;
            Assert.IsTrue(sql.deshabilitarRuta(prueba));
        }

        
    }
}
