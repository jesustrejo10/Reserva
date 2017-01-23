using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers.PatronComando.M02;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M02;
using BOReserva.Models.gestion_aviones;
using System.Web.Mvc;
using BOReserva.Controllers;

namespace TestUnitReserva.BO.gestion_aviones
{
    /// <summary>
    /// Clase encargada de realizar las pruebas unitarios del modulo Avion en BO
    /// </summary>
    [TestFixture]
    class TestAviones
    {
        private Avion mockAvion;
        private Avion mockAvion2;
        IDAO daoAvion;
        IDAO prueba;
        BOReserva.Controllers.gestion_avionesController controlador = new BOReserva.Controllers.gestion_avionesController();
        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockAvion = new Avion("HK-1799", "Boeing747", 50, 50, 50, 50, 50, 50, 50);
            daoAvion = FabricaDAO.instanciarDaoAvion();
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockAvion = null;
        }
        /*
        /// <summary>
        /// Metodo que prueba que pueda insertar un avion
        /// </summary>
        [Test]
        public void M02_DaoAvionInsertarAvion()
        {

            //Probando caso de exito de la prueba
            int resultadoAgregar = daoAvion.Agregar(mockAvion);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoAvion.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 3);
        }
        /// <summary>
        /// Metodo que prueba que se puedan consultar todos los avion
        /// </summary>
        
         */
        [Test]
        public void M02_DaoAvionConsultarTodos()
        {
            Dictionary<int, Entidad> avion = daoAvion.ConsultarTodos();
            Assert.NotNull(avion);
        }
        /// <summary>
        /// Metodo que prueba que se puedan consultar los avion por un id
        /// </summary>
        [Test]
        public void M02_DaoAvionConsultarPorId()
        {
            Assert.NotNull(daoAvion.Consultar(314));
        }
        /// <summary>
        /// Metodo que prueba que se puede modificar un avion
        /// </summary>
        [Test]
        public void M02_DaoAvionModificar()
        {
            daoAvion.Agregar(mockAvion);
            M02_COModificarAvion prueba = new M02_COModificarAvion(mockAvion, 315);
            string test = prueba.ejecutar();
        }
        /// <summary>
        /// Metodo que prueba que se pueda eliminar un avion
        /// </summary>
        [Test]
        public void M02_DaoAvionEliminarAvion()
        {
            daoAvion.Agregar(mockAvion);
            M02_COEliminarAvion prueba = new M02_COEliminarAvion(mockAvion, 316);
            string test = prueba.ejecutar();
        }
        /*
        /// <summary>
        /// Metodo que prueba que se pueda eliminar un avion
        /// </summary>
        [Test]
        public void M02_deleteAvion()
        {
            daoAvion.Agregar(mockAvion);
            gestion_avionesController prueba = new gestion_avionesController();
            JsonResult probar = prueba.deleteAvion(316);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Metodo que prueba que se pueda probar la disponibilidad un avion
        /// </summary>
        
         */
        [Test]
        public void M02_DaoAvionDsiponibilidadAvion()
        {
            M02_CODisponibilidadAvion prueba = new M02_CODisponibilidadAvion(mockAvion2, 0);
        }
        /// <summary>
        /// Metodo que prueba que se pueda probar el activar un avion
        /// </summary>
        [Test]
        public void M02_activateAvion()
        {
            daoAvion.Agregar(mockAvion);
            gestion_avionesController prueba = new gestion_avionesController();
            JsonResult probar = prueba.activateAvion(315);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Metodo que prueba que se pueda probar el desactivar un avion
        /// </summary>
        [Test]
        public void M02_deactivateAvion()
        {
            daoAvion.Agregar(mockAvion);
            gestion_avionesController prueba = new gestion_avionesController();
            JsonResult probar = prueba.deactivateAvion(314);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Metodo que prueba que se pueda probar la vizualizacion de aviones
        /// </summary>
        [Test]
        public void M02_VisualizarAvion()
        {
            M02_COVisualizarAvion prueba = new M02_COVisualizarAvion();
            Dictionary<int, Entidad> mapAvion = prueba.ejecutar();
        }
        /// <summary>
        /// Metodo que prueba que se pueda probar guardar avion
        /// </summary>
        [Test]
        public void M02_guardarAvion()
        {
            CAgregarAvion model = new BOReserva.Models.gestion_aviones.CAgregarAvion();
            model._matriculaAvion = "HK-1800";
            model._modeloAvion = "Boeing747";
            model._capacidadPasajerosTurista = 70;
            model._capacidadPasajerosEjecutiva = 70;
            model._capacidadPasajerosVIP = 70;
            model._capacidadEquipaje = 70;
            model._distanciaMaximaVuelo = 70;
            model._velocidadMaximaDeVuelo = 70;
            model._capacidadMaximaCombustible = 70;
            gestion_avionesController prueba = new gestion_avionesController();
            JsonResult probarjsonresult = prueba.guardarAvion(model);
            Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
        }


    }
}