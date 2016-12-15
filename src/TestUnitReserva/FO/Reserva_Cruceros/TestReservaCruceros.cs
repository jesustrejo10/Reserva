using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Models.Cruceros;
using FOReserva.Servicio;
using FOReserva.Controllers;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace TestUnitReserva.FO.Reserva_Crucero
{
    [TestFixture]
    class TestReservaCruceros
    {
        manejadorSQLCrucero manejador = new manejadorSQLCrucero();
        FOReserva.Controllers.gestion_reserva_cruceroController controladora = new FOReserva.Controllers.gestion_reserva_cruceroController();
        /// <summary>
        /// Pruebas para verificar que la lista que se muestra en el visualizar no venga vacía
        /// Se crea la variable respuesta de tipo List<> y se le asigna lo que retorna la función listar cruceros
        /// Compruebo que la variable respuesta sea distinta a null
        /// </summary>
        [Test]
        public void TestConsultarCruceros()
        {
            //pruebo que la lista no retorne vacía
            List<Cruceros> respuesta = manejador.buscarCruceros();
            Assert.IsNotNull(respuesta);
        }

        /// <summary>
        /// Prueba del método consultar itinerarios de cruceros pasando parametros válidos
        /// </summary>
        [Test]
        public void TestBuscarItinerariosParametrosValidos()
        {
            string crucero = "1";
            string fechadeida = "2016-12-13";
            string fechadevuelta = "2016-12-31";

            Assert.IsInstanceOf(typeof(List<CReserva_Cruceros>), manejador.buscarItinerarios(crucero,fechadeida,fechadevuelta));
        }

        /// <summary>
        /// Prueba del método consultar buscar itinerarios pasando parametros inválidos
        /// </summary>
        [Test]
        public void TestBuscarItinerariosParametrosInvalidos()
        {
            string crucero = "10000";
            string fechadeida = "2014-12-13";
            string fechadevuelta = "2015-12-31";
            Assert.IsNotInstanceOf(typeof(List<CReserva_Cruceros>), manejador.buscarItinerarios(crucero, fechadeida, fechadevuelta));
        }

        /// <summary>
        /// Pruebas para verificar que la lista que se muestra en el visualizar no venga vacía
        /// Se crea la variable respuesta de tipo List<> y se le asigna lo que retorna la función listar cruceros
        /// Compruebo que la variable respuesta sea distinta a null
        /// </summary>
        [Test]
        public void TestConsultarReservasCruceros()
        {
            //pruebo que la lista no retorne vacía
            List<CReserva_Cruceros> respuesta = manejador.buscarReservasCruceros();
            Assert.IsNotNull(respuesta);
        }


        [Test]
        public void TestCrearReserva()
         {
            Assert.Inconclusive();

        }

        [Test]
        public void TestEliminarReserva()
        {
            Assert.Inconclusive();

        }

        [Test]
        public void TestModificarReserva()
        {
            Assert.Inconclusive();

        }



        //controller



        [Test]
        public void TestBusqueda()
        {
            string numcrucero="4";
            string fechaIda = "2016-12-09";
            string fechaVuelta = "2016-12-25";
            List<CReserva_Cruceros> respuesta = controladora.busqueda(numcrucero, fechaIda, fechaVuelta);
            Assert.IsNotNull(respuesta);
        }

        [Test]
        public void TestGestionReservaCruceroPerfil()
        {
            Assert.IsInstanceOf(typeof(ActionResult), controladora.gestion_reserva_crucero_perfil());
        }

        [Test]
        public void TestCrearReservaCrucero()
        {
            string fecha = "2016-12-14";
            int cantidadPasajeros = 5;
            int usuario = 1 ;
            int crucero=4;
            int ruta=30;
            string fkfecha = "2016-12-09";
            string estatus = "activo";
            Assert.IsInstanceOf(typeof(ActionResult), controladora.crearReservaCrucero(fecha, cantidadPasajeros, usuario, crucero, ruta, fkfecha, estatus));
        }

        [Test]
        public void TestEliminarReservaCruceroValido()
        {
            int id = 1; ;
            Assert.IsInstanceOf(typeof(JsonResult), controladora.eliminarReservaCrucero(id));
        }

        [Test]
        public void TestEliminarReservaCruceroInValido()
        {
            int id = 1000; ;
            Assert.IsInstanceOf(typeof(JsonResult), controladora.eliminarReservaCrucero(id));
        }

        [Test]
        public void TestModificarReservaCrucero()
        {
            string id_reserva="1";
            string cant_pasajero="5";
            string estatus="activo";
            Assert.IsInstanceOf(typeof(JsonResult), controladora.modificarReservaCrucero(id_reserva,cant_pasajero,estatus));
        }

        [Test]
        public void TestGestion_reserva_cruceroImagenes()
        {
            Assert.IsInstanceOf(typeof(ActionResult), controladora.gestion_reserva_cruceroImagenes());
        }



    }
}
