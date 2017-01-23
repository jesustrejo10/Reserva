using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_ruta_comercial;
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
            mockRuta = null;
            daoRuta = null;
        }

        [Test]
        public void TestConsultarDestino()
        {
            Dictionary<int, Entidad> listaDestinos = daoRuta.consultarDestinos();
            Assert.NotNull(listaDestinos);
            Ruta e = (Ruta)listaDestinos[99];
            Assert.AreEqual(e._destinoRuta, "Caracas - Venezuela");

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

        public void M03_DaoHotelInsertarHotel()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoRuta.Agregar(mockRuta);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoRuta.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void TestdeshabilitarRuta()
        {
            int prueba = 5;
            Assert.IsTrue(daoRuta.deshabilitarRuta(prueba));

        }


      

        [Test]
        public void TestMostrarRuta()
        {
            
            Command<Entidad> comando = FabricaComando.crearM03_MostrarRuta(5);
            Ruta prueba = (Ruta)comando.ejecutar();
            Assert.AreEqual(765,prueba._distancia);
            Assert.AreEqual("Valencia - Venezuela", prueba._origenRuta);
            Assert.AreEqual("Valencia - España", prueba._destinoRuta);
            Assert.AreEqual("Activa", prueba._status);
            Assert.AreEqual("Aerea", prueba._tipo);
        }

        [Test]
        public void TestInhabilitarRuta()
        {
            int prueba = 44;
            Assert.IsTrue(daoRuta.deshabilitarRuta(prueba));
        }

        [Test]
        public void TestM03_MListarRutasBD()
        {
            List<CRuta> listarutas = new List<CRuta>();
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM03_MListarRutasBD();
            Dictionary<int, Entidad> listaRutas = comando.ejecutar();
            Assert.IsNotNull(listarutas);
        }
       
    }
}
