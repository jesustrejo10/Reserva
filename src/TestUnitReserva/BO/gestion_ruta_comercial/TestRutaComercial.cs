using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_ruta_comercial;
using BOReserva.Servicio;
using System.Diagnostics;

namespace TestUnitReserva.BO.gestion_ruta_comercial
{
    [TestFixture]
    class TestRutaComercial
    {
        manejadorSQL sql = new manejadorSQL();

        [Test]
        public void TestCrearRestaurantes()
        {
            CAgregarRuta prueba = new CAgregarRuta
            {
                _origenRuta = "Caracas - Venezuela",
                _destinoRuta = "Miami - Estados Unidos",
                _estadoRuta = "Activa",
                _tipoRuta = "Aerea",
                _distanciaRuta = 155,
            };
            Assert.IsTrue(sql.InsertarRuta(prueba));
        }
    }
}
