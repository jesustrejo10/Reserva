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

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockReserva = new ReservaHabitacion();
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

        /*[Test]
        public void M22_AgregarReserva()
        {
            M22_COAgregarReserva prueba = new M22_COAgregarReserva(mockReserva);
            String prueba1 = prueba.ejecutar();

        }*/

        //Controller



        //DAO
/*
        [Test]
        public void M22_DAOReservaHabitacionAgregar()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoReservaHabitacion.Agregar(mockReserva);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoReservaHabitacion.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }
  
 * *//*
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
