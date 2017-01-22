using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M14;
using BOReserva.Models.gestion_cruceros;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M14;
using NUnit.Framework;
using BOReserva.Controllers.PatronComando;

namespace TestUnitReserva.BO.gestion_cruceros
{
    [TestFixture]
    class TestCruceros
    {
        private Camarote mockCamarote;
        private Cabina mockCabina;
        private Crucero mockCrucero;
        private Itinerario mockItinerario;
        DAOCruceros daoCruceros;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockCamarote = new Camarote(400, 2, "Individual", "activo", 15);
            mockCabina = new Cabina(400,"Interior",99,"activo",2);
            mockCrucero = new Crucero();
            daoCruceros = new DAOCruceros();

        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockCamarote = null;
            mockCabina = null;
            mockCrucero = null;
            daoCruceros = null;
        }




        [Test]
        public void M14_DaoCruceroInsertarCrucero()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoCruceros.Agregar(mockCrucero);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoCruceros.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void M14_DaoCruceroConsultarTodos()
        {
            Dictionary<int, Entidad> Cruceros = daoCruceros.ConsultarTodos();
            Assert.NotNull(Cruceros);
            Crucero e = (Crucero)Cruceros[51];
            Assert.AreEqual(e._nombreCrucero, "Crucero Dev");
        }

        [Test]
        public void M14_ComandoConsultarTodos()
        {
            M14_COVisualizarCruceros comando = new M14_COVisualizarCruceros();
            Dictionary<int, Entidad> cruceros = comando.ejecutar();
            Assert.NotNull(cruceros);
            Crucero e = (Crucero)cruceros[51];
            Assert.AreEqual(e._nombreCrucero, "Crucero Dev");
        }
    }
}
