using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FOReserva.Models.gestion_reserva_automovil;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando.M19;
using System.Threading.Tasks;
using FOReserva.DataAccess.DataAccessObject.M19;
using FOReserva.DataAccess;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Model;
using FOReserva.Controllers.PatronComando;
using System.Web.Mvc;
using FOReserva.Controllers;

namespace TestUnitReserva.FO.gestion_reserva_automovil
{
    class TestReservaAutomovil
    {
        // Declaro las variables a probar
        private CLugar mockLugar;
        private CUsuario mockUsuario;
        private CAutomovil mockAutomovil;
        private CReservaAutomovil mockReservaAutomovil;
        private int id;
        private String fecha_ini;
        private String fecha_fin;
        private String horario_ini;
        private String horario_fin;
        private int idUsuario;
        private int estatus;
        FOReserva.Controllers.gestion_reserva_autoController controller = new FOReserva.Controllers.gestion_reserva_autoController();
        DAOReservaAutomovil daoReservaAutomovil;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// </summary>
        [SetUp]
        public void Before()
        {
            fecha_ini = "2017-10-03";
            fecha_fin = "2017-10-04";
            horario_ini = "16:00";
            horario_fin = "15:00";
            idUsuario = 163;
            estatus = 1;
            mockLugar = new CLugar(11, "Venezuela");
            mockUsuario = new CUsuario(164);
            mockReservaAutomovil = new CReservaAutomovil(11, "2017-10-03", "2017-10-04", "16:00", "15:00", 163, "AUT223", 12, 15, 1);
            daoReservaAutomovil = new DAOReservaAutomovil();
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockLugar = null;
            mockUsuario = null;
            mockReservaAutomovil = null;
            daoReservaAutomovil = null;
        }

        [Test]
        public void M19_FabricasEntidad()
        {
            //constructor vacio
            id = 11;
            CReservaAutomovil prueba = FabricaEntidad.inicializarReserva();
            Assert.IsInstanceOf(typeof(CReservaAutomovil), prueba);
            //constructor con parametros
            prueba = FabricaEntidad.inicializarReserva(id, fecha_ini, fecha_fin, horario_ini, horario_fin, idUsuario, estatus, mockAutomovil, mockLugar, mockLugar);
            Assert.IsInstanceOf(typeof(Entidad), prueba);
        }

        //Prueba para agregar una reserva
        [Test]
        public void M19_COAgregarReserva()
        {
            mockReservaAutomovil = new CReservaAutomovil("2017-10-03", "2017-10-04", "16:00", "15:00", 163, "AUT223", 12, 15, 1);

            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CREAR, FabricaComando.comandoReservaAuto.NULO, mockReservaAutomovil);
            bool test = comando.ejecutar();
            Assert.IsTrue(test);


        }
        //Prueba para Eliminar una reserva
        [Test]
        public void M19_COEliminarReserva()
        {
            mockReservaAutomovil = new CReservaAutomovil(11, "2017-10-03", "2017-10-04", "16:00", "15:00", 163, "AUT223", 12, 15, 1);
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.ELIMINAR, FabricaComando.comandoReservaAuto.NULO, mockReservaAutomovil);
            bool test = comando.ejecutar();
            Assert.IsTrue(test);


        }
        // Prueba para modificar una reserva
        [Test]
        public void M19_COModificarReserva()
        {
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.ACTUALIZAR, FabricaComando.comandoReservaAuto.NULO, mockReservaAutomovil);
            bool test = comando.ejecutar();
            Assert.IsTrue(test);

        }
        // Prueba para consultar una reserva dependiendo del usuario loggeado
        [Test]
        public void M19_DaoReservaConsultarPorId()
        {
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoReservaAuto.NULO, mockUsuario);

            Assert.NotNull(comando);
        }

        //Prueba para ver el detalle de una reserva 
        [Test]
        public void M19_DaoReservaConsultarDetalle()
        {

            mockReservaAutomovil = new CReservaAutomovil(11, "2017-10-03", "2017-10-04", "16:00", "15:00", 163, "AUT223", 12, 15, 1);
            Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosReservaAutomovil(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoReservaAuto.CONSULTAR_ID, mockReservaAutomovil);

            Assert.NotNull(comando);
        }

        // Prueba para probar el controlador de gestion_reserva_autoController
        [Test]
        public void M19_PruebasDelControlador()
        {
            CReservaAutomovil model = new CReservaAutomovil();
            Assert.IsInstanceOf(typeof(ActionResult), controller.M19_Modificar_reserva(mockReservaAutomovil));
            Assert.IsInstanceOf(typeof(ActionResult), controller.M19_Eliminar_reserva(mockReservaAutomovil));
            Assert.IsInstanceOf(typeof(ActionResult), controller.M19_Detalle_reserva(mockReservaAutomovil));
        }


    }
}