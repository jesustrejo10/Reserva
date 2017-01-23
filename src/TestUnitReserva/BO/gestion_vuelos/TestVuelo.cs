using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Data.SqlClient;

using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M04;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;

namespace TestUnitReserva.BO.gestion_vuelos
{
    [TestFixture]
    public class TestVuelo
    {
        #region Atributos
        public Entidad vuelo1;
        public Entidad vuelo2;
        public Entidad vuelo3;
        public Ruta rutaPrueba;
        public Avion avionPrueba;
        public bool pregunta1;
        public bool pregunta2;
        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
            avionPrueba = new Avion(8, "1111", "1111", 100, 20, 10, 100, 100, 100, 100, 1);
            rutaPrueba = new Ruta(1, 111, "activa", "aerea", "Valencia", "Valencia");
            vuelo1 = FabricaEntidad.InstanciarVuelo(1, "AA111", rutaPrueba, new DateTime(2015, 2, 10), "activo", new DateTime(2015, 2, 10), avionPrueba);
            vuelo2 = FabricaEntidad.InstanciarVuelo(1, "AA222", rutaPrueba, new DateTime(2015, 2, 10), "activo", new DateTime(2015, 2, 10), avionPrueba);
        }

        [TearDown]
        public void clean()
        {
            vuelo1 = null;
            vuelo2 = null;
            vuelo3 = null;
            avionPrueba = null;
            rutaPrueba = null;
        }
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        /// Prueba que permite verificar el agregar un vuelo a la base de datos.
        /// </summary>
        [Test]
        public void TestComandoAgregarCompania()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<bool> Comando = FabricaComando.crearM04_AgregarVuelo(vuelo1);
            Assert.IsTrue(Comando.ejecutar());
            Command<Entidad> Comand2 = FabricaComando.ConsultarM04_Vuelo(1);
            vuelo3 = Comand2.ejecutar();
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).IdVuelo == 1);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).CodigoVuelo == "AA111");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getRuta == rutaPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaDespegue == new DateTime(2015, 2, 10));
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).StatusVuelo == "activo");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getAvion == avionPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaAterrizaje == new DateTime(2015, 2, 10));

            Assert.IsTrue(daoVuelo.Eliminar(1));
        }
        /// <summary>
        /// Prueba que permite verificar el buscar un vuelo por su id en la base de datos.
        /// </summary>
        [Test]
        public void TestComandoBuscarCompania()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<bool> Comando = FabricaComando.crearM04_AgregarVuelo(vuelo1);
            pregunta2 = Comando.ejecutar();
            Command<Entidad> Comand2 = FabricaComando.ConsultarM04_Vuelo(1);
            Assert.IsNotNull(vuelo3 = Comand2.ejecutar());
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).IdVuelo == 1);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).CodigoVuelo == "AA111");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getRuta == rutaPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaDespegue == new DateTime(2015, 2, 10));
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).StatusVuelo == "activo");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getAvion == avionPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaAterrizaje == new DateTime(2015, 2, 10));

            Assert.IsTrue(daoVuelo.Eliminar(1));
        }
        /// <summary>
        /// Prueba que permite verificar el consultar de todas los vuelos en la base de datos.
        /// </summary>
        [Test]
        public void TestComandoConsultarVuelos()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<List<Entidad>> Comando = FabricaComando.ConsultarM04_ConsultarTodos();
            List<Entidad> vuelos;
            Assert.IsNotNull(vuelos = Comando.ejecutar());
            foreach (Entidad vuelo in vuelos)
            {
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).IdVuelo);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).CodigoVuelo);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).getRuta);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).FechaDespegue);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).StatusVuelo);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).getAvion);
                Assert.IsNotNull(((BOReserva.DataAccess.Domain.Vuelo)vuelo).FechaAterrizaje);
            }

        }

        /// <summary>
        /// Prueba que permite verificar si se puede cambiar el status de un vuelo.
        /// </summary>
        [Test]
        public void TestComandoCambiarStatus()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<bool> Comando = FabricaComando.crearM04_AgregarVuelo(vuelo1);
            pregunta1 = Comando.ejecutar();
            Command<bool> Comando2 = FabricaComando.M04_CambiarStatus(1);
            Assert.IsTrue(Comando2.ejecutar());
            Command<Entidad> Comand2 = FabricaComando.ConsultarM04_Vuelo(1);
            vuelo3 = Comand2.ejecutar();
            Assert.IsFalse(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).StatusVuelo == ((BOReserva.DataAccess.Domain.Vuelo)vuelo1).StatusVuelo);

            Assert.IsTrue(daoVuelo.Eliminar(1));
        }
        /// <summary>
        /// Prueba que permite eliminar un vuelo de la base de datos
        /// </summary>
        [Test]
        public void TestComandoEliminarVuelo()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<bool> Comando = FabricaComando.crearM04_AgregarVuelo(vuelo1);
            pregunta1 = Comando.ejecutar();
            Command<bool> Comando2 = FabricaComando.EliminarM04_Vuelo(1);
            Assert.IsTrue(Comando2.ejecutar());
            Command<Entidad> Comand3 = FabricaComando.ConsultarM04_Vuelo(1);
            Assert.IsNull(Comand3.ejecutar());
        }
        /// <summary>
        /// Prueba que permite modificar un vuelo de la base de datos
        /// </summary>
        [Test]
        public void TestComandoModificarVuelo()
        {
            BOReserva.DataAccess.DataAccessObject.InterfacesDAO.IDAOVuelo daoVuelo = (IDAOVuelo)BOReserva.DataAccess.DataAccessObject.FabricaDAO.instanciarDAOVuelo();
            Command<bool> Comando = FabricaComando.crearM04_AgregarVuelo(vuelo1);
            pregunta1 = Comando.ejecutar();
            Command<Entidad> Comando2 = FabricaComando.ModificarM04_ModificarVuelo(vuelo2);
            Assert.IsNotNull(vuelo3 = Comando2.ejecutar());
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).IdVuelo == 1);
            Assert.IsFalse(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).CodigoVuelo == "AA111");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getRuta == rutaPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaDespegue == new DateTime(2015, 2, 10));
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).StatusVuelo == "activo");
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).getAvion == avionPrueba);
            Assert.IsTrue(((BOReserva.DataAccess.Domain.Vuelo)vuelo3).FechaAterrizaje == new DateTime(2015, 2, 10));

            Assert.IsTrue(daoVuelo.Eliminar(1));
        }

        #endregion
    }
}
