using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_ofertas;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
namespace TestUnitReserva.BO.gestion_OfertasYPaquetes
{
    [TestFixture]
    class TestOfertasYPaquetes
    {
        manejadorSQL prueba = new manejadorSQL();

        [Test]
        public void TestAgregarPaquete()
        {
            CPaquete paq = new CPaquete();
            Boolean resultadoAgregarPaquete = prueba.agregarPaquete(paq);
            Assert.AreEqual(resultadoAgregarPaquete, true);
            Boolean resultadoAgregarPaqueteNull = prueba.insertarAvion(null);
            Assert.AreEqual(resultadoAgregarPaqueteNull, true);
            paq._nombrePaquete = null;
            Boolean resultadoSinNombrePaquete = prueba.agregarPaquete(paq);
            Assert.AreEqual(resultadoSinNombrePaquete, false);

        }

        [Test]
        public void TestAgregarOferta()
        {
            CAgregarOferta ofe = new CAgregarOferta();
            Boolean resultadoAgregarOferta = prueba.agregarOferta(ofe);
            Assert.AreEqual(resultadoAgregarOferta, true);
            Boolean resultadoAgregarOfertaNull = prueba.agregarOferta(null);
            Assert.AreEqual(resultadoAgregarOfertaNull, true);
            ofe._nombreOferta = null;
            Boolean resultadoSinNombreOferta = prueba.agregarOferta(ofe);
            Assert.AreEqual(resultadoSinNombreOferta, false);

        }



        [Test]
        public void TestListarPaquetesEnBd()
        {
            //pruebo que la lista no retorne vacia
            List<CPaquete> paquetes = prueba.listarPaquetesEnBD();
            Assert.IsNotNull(paquetes);
        }

        [Test]
        public void TestListarOfertasEnBd()
        {
            //pruebo que la lista no retorne vacia
            List<COferta> ofertas = prueba.listarOfertasEnBD();
            Assert.IsNotNull(ofertas);
        }

        [Test]
        public void TestmodificarPaqueteËxistente()
        {
            CPaquete paq = new CPaquete();
            paq._nombrePaquete = "Paquete de Navidad";
            paq._precioPaquete = 23;
            paq._idOferta = 20;
            paq._idAuto = "08B1AOE";
            Boolean resultadoModificar = prueba.modificarPaquete(paq);
            Assert.AreEqual(resultadoModificar, true);
        }

        [Test]
        public void TestPaqueteNulo()
        {
            Assert.That(() => prueba.modificarPaquete(null),
            Throws.TypeOf<SqlException>());

        }

        [Test]
        public void TestActivarPAquete()
        {
            Boolean resultado = prueba.activarPaquete(19);
            Assert.AreEqual(resultado, true);
        }

        [Test]
        public void TestDesactivarPaquete()
        {
            Boolean resultado = prueba.desactivarPaquete(19);
            Assert.AreEqual(resultado, true);
        }



        [Test]
        public void TestDesactivarOferta()
        {
            Boolean resultado = prueba.desactivarPaquete(18);
            Assert.AreEqual(resultado, true);
        }


        [Test]
        public void TestActivarOferta()
        {
            Boolean resultado = prueba.desactivarPaquete(18);
            Assert.AreEqual(resultado, true);
        }



        [Test]
        public void TestListarOfertaBd()
        {

            COferta oferta = prueba.MMostrarOfertaBD(16);
            Assert.IsNotNull(oferta);
        }




    }
}

