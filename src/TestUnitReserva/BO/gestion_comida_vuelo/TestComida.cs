using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;


namespace TestUnitReserva.BO.gestion_comida_vuelo
{
    [TestClass]
    class TestComida
    {
        [TestMethod]
        public void TestCrear() {
            Entidad comida = FabricaEntidad.instanciarComida("Cafe con leche andino", "Bebida", 1, "cafe tipico venezolano");

            bool resultado = DAOComida.Singleton().crear(comida);
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestAgregarComdiaVuelo()
        {
            Entidad comida_vuelo = FabricaEntidad.instanciarComidaVuelo(18,"1", 20);

            bool resultado = DAOComida.Singleton().agregarComidaVuelo(comida_vuelo);
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestCambiarEstadoComida()
        {
            Entidad comida = FabricaEntidad.instanciarComida(1,"----","---",0,"----");

            bool resultado = DAOComida.Singleton().cambiarEstadoComida(comida);
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestRellenarComida()
        {
            Entidad comida = FabricaEntidad.instanciarComida(1);

            Entidad resultado = DAOComida.Singleton().rellenarComida(comida);
            Assert.IsInstanceOfType(resultado, typeof(Comida));
        }

        [TestMethod]
        public void TestEditarComida()
        {
            Entidad comida = FabricaEntidad.instanciarComida("Guarapita Peruana", "Bebida", 1, "Bebida tipica de Lima");

            bool resultado = DAOComida.Singleton().crear(comida);
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestConsultarComidas()
        {

            List<Entidad> resultado = DAOComida.Singleton().consultarComidas();
            Assert.IsInstanceOfType(resultado, typeof(List<Entidad>));
        }


        [TestMethod]
        public void TestConsultarComidasVuelos()
        {

            List<Entidad> resultado = DAOComida.Singleton().consultarComidasVuelos();
            Assert.IsInstanceOfType(resultado, typeof(List<Entidad>));
        }


    }






}
