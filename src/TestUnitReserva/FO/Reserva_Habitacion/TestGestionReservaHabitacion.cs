using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Controllers.PatronComando;
using FOReserva.Controllers.PatronComando.M22;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.Controllers;
using FOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web.Mvc;
using FOReserva.DataAccess.DataAccessObject.M22;
using FOReserva.Models.ReservaHabitacion;

namespace TestUnitReserva.FO.Reserva_Habitacion
{
    [TestFixture]
    class TestGestionReservaHabitacion
    {
        /// <summary>
        /// Clase encargada de realizar las pruebas unitarios del modulo reserva de habitacion en FO
        /// </summary>
        DAOReservaHabitacion daoReservaHabitacion;
        IDAOReservaHabitacion personalizado;
        private ReservaHabitacion mockReserva;
        Cvista_ReservarHabitacion mockVistaHabitacion;
        int cant;
        String fecha;
        int hotel;
        int usuario;
        int prueba;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            cant = 1;
            fecha="2017-01-23";
            hotel=1;
            usuario=1;
            prueba = 1;
            mockReserva = new ReservaHabitacion(cant,fecha,hotel,usuario);
            mockVistaHabitacion = new Cvista_ReservarHabitacion();
            daoReservaHabitacion= new DAOReservaHabitacion();
        }

        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockReserva = null;
        }

        //Patron Comando

        [Test]
        public void M22_AgregarReservaHabitacion()
        {
            M22_COAgregarRerserva prueba = new M22_COAgregarRerserva(mockReserva);
            String prueba1 = prueba.ejecutar();
        }

        [Test]
        public void M22_COEliminarReservaHabitacion()
        {
            M22_COEliminarReserva prueba = new M22_COEliminarReserva(1);
            String test = prueba.ejecutar();
        }

        [Test]
        public void M22_COModificarReservaHabitacion()
        {
            M22_COModificarReserva prueba = new M22_COModificarReserva(1, 1);
            String nombre = prueba.ejecutar();
        }

        [Test]
        public void M22_C0ConsultarReservasHabitacion()
        {
            M22_COConsultarTodasReservas prueba = new M22_COConsultarTodasReservas(1);
            Dictionary<int, Entidad> mapHoteles = prueba.ejecutar();
        }

        [Test]
        public void M22_COObtenerCiudadesReservaHabitacion()
        {
            M22_COObtenerCiudad prueba = new M22_COObtenerCiudad();
            List<CiudadHab> prueb1 = prueba.ejecutar();
        }

        [Test]
        public void M22_COConsultarCiudadReservaHabitacion()
        {
            M22_COConsultarIdCiudad prueba = new M22_COConsultarIdCiudad(1);
            Dictionary<int, Entidad> prueb1 = prueba.ejecutar();
        }

        //Controller
        /*
        [Test]
        public void realizarReserva()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probarjsonresult = prueba.realizar_reserva(mockVistaHabitacion);
            Assert.IsInstanceOf(typeof(ActionResult), probarjsonresult);
        }
        */

        [Test]
        public void M22_CancelarReservaHabitacion()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probar = prueba.cancelar_reserva(1);
            Assert.IsInstanceOf(typeof(ActionResult), probar);
        }

        [Test]
        public void M22_ModificarReservaHabitacion()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probar = prueba.modificar_reserva(1,1);
            Assert.IsInstanceOf(typeof(ActionResult), probar);
        }
        /*
        [Test]
        public void M22_MisResevasReservaHabitacion()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probar = prueba.mis_reservas();
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        */
        /*
        [Test]
        public void M22_BuscarHotelesReservaHabitacion()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probar = prueba.buscar_hoteles();
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        */
        /*
        [Test]
        public void M22_DetalleReservaReservaHabitacion()
        {
            gestion_reserva_habitacionesController prueba = new gestion_reserva_habitacionesController();
            ActionResult probar = prueba.detalle_reserva();
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        */
        //DAO
        /*
        [Test]
        public void M22_DAOReservaHabitacionAgregar()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoReservaHabitacion.Agregar(mockReserva);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            //int resultadoAgregarIncorrecto = daoReservaHabitacion.Agregar(null);
            //Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }
        */
        /*
        /// <summary>
        /// Metodo que prueba que se pueda consultar todas las reservas de habitacion de un usuario
        /// </summary>
        [Test]
        public void M22_DAOReservaHabitacionConsultar()
        {
            List<ReservaHabitacion> reservas = personalizado.ConsultarTodosHabitacion(1);
            Assert.NotNull(reservas);
        }

        /// <summary>
        /// Metodo que prueba que se pueda eliminar un reclamo
        /// </summary>
        [Test]
        public void M22_DAOReservaHabitacionEliminar()
        {
            //HAY QUE CAMBIAR EL NUMERO DE ID QUE SE ELIMINA MANUALMENTE
            //Probando caso de exito de la prueba
            int resultadoEliminar = perzonalizado.Eliminar(1);
            Assert.AreEqual(resultadoEliminar, 1);
        }

        */
    }
}
