using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_ruta_comercial;
using System.Diagnostics;

namespace TestUnitReserva.BO.gestion_ruta_comercial
{
    [TestFixture]
    class TestRutaComercial
    {
        CBasededatos_ruta_comercial sql = new CBasededatos_ruta_comercial();

        [Test]
        public void TestAgregarRuta()
        {
            CAgregarRuta prueba = new CAgregarRuta
            {
                _origenRuta = "Caracas - Venezuela",
                _destinoRuta = "Miami - Estados Unidos",
                _estadoRuta = "Activa",
                _tipoRuta = "Aerea",
                _distanciaRuta = 155,
            };
            Assert.IsTrue(sql.MAgregarRuta(prueba));
        }

        [Test]
        public void TestConsultarRuta()
        {
            List<CRuta> prueba = new List<CRuta>();
            prueba = sql.MListarRutasBD();
            Assert.IsNotNull(prueba);
        }
    }
}
