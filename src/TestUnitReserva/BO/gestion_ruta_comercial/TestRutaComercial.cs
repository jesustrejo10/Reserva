using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio.Servicio_Rutas;
using System.Diagnostics;

namespace TestUnitReserva.BO.gestion_ruta_comercial
{
    [TestFixture]
    class TestRutaComercial
    {
        CManejadorSQL_Rutas sql = new CManejadorSQL_Rutas();

        [Test]
        public void TestAgregarRuta()
        {
            CAgregarRuta prueba = new CAgregarRuta();
            prueba._origenRuta = "Caracas - Venezuela";
            prueba._destinoRuta = "Miami - Estados Unidos";
            prueba._estadoRuta = "Activa";
            prueba._tipoRuta = "Aerea";
            prueba._distanciaRuta = 55555555;
            Assert.IsTrue(sql.MAgregarRuta(prueba));
        }

        [Test]
        public void TestConsultarRuta()
        {
            List<CRuta> prueba = new List<CRuta>();
            prueba = sql.MListarRutasBD();
            Assert.IsNotNull(prueba);
        }
        
        [Test]
        public void TestValidarRuta()
        {
            CAgregarRuta prueba = new CAgregarRuta();
            prueba._origenRuta = "Valencia - Venezuela";
            prueba._destinoRuta = "Valencia - España";
            prueba._estadoRuta = "Activa";
            prueba._tipoRuta = "Aerea";
            prueba._distanciaRuta = 765;
             Assert.IsTrue(sql.ValidarRuta(prueba));
        }

        [Test]
        public void TestModificarRuta()
        {
            CAgregarRuta prueba = new CAgregarRuta();
            prueba._idRuta = 5;
            prueba._estadoRuta = "Activa";
            prueba._distanciaRuta = 765;
            Assert.IsTrue(sql.MModificarRuta(prueba));
        }

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

        [Test]
        public void TestHabilitarRuta()
        {
            int prueba = 42;
            Assert.IsTrue(sql.deshabilitarRuta(prueba));
        }
    }
}
