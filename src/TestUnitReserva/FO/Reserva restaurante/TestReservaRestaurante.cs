using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Models.Restaurantes;
using FOReserva.Servicio;


namespace TestUnitReserva.FO.Reserva_restaurante
{

    [TestFixture]
    class TestReservaRestaurante
    {
        ManejadorSQLReservaRestaurant manejador = new ManejadorSQLReservaRestaurant();
        List<CRestaurantModel> restaurante = new List<CRestaurantModel>();
        CReservation_Restaurant reserva_prueba = new CReservation_Restaurant("alexander perez", "2016-01-01", "12:00", 10, 5, 1);
        
        
        [Test]
        public void buscar_restaunte_nombre_test() {
            restaurante = manejador.buscarRestName("taxco");
            Assert.NotNull(restaurante);
            Assert.AreEqual(restaurante[0].Name, "taxco");
            Assert.IsInstanceOf(typeof(List<CRestaurantModel>),manejador.buscarRestName("taxco"));
        }

        [Test]
        public void buscar_restaunte_ciudad_test()
        {
            restaurante = manejador.buscarRestCity("caracas");
            Assert.NotNull(restaurante);
            Assert.IsInstanceOf(typeof(List<CRestaurantModel>), manejador.buscarRestCity("caracas"));
            Assert.AreEqual(restaurante[0].CityName, "caracas");
        }

        [Test]
        public void buscar_restaunte_test()
        {
            CRestaurantModel restaurante = manejador.buscarRest(1);
            Assert.NotNull(restaurante);
            Assert.IsInstanceOf(typeof(CRestaurantModel), manejador.buscarRest(1));
            Assert.AreEqual(restaurante.CityName, "caracas");
            Assert.AreEqual(restaurante.Name, "taxco");
        }

        [Test]
        public void crear_reserva_test()
        {
            int id_reserva = reserva_prueba.Id;
            manejador.CrearReserva(reserva_prueba);
            CRestaurantModel restaurante = manejador.buscarRest(reserva_prueba.IdRestaurant);
            Assert.NotNull(restaurante);
            Assert.IsInstanceOf(typeof(CReservation_Restaurant), reserva_prueba);
        }

        [Test]
        public void busqueda_reserva_test()
        {
            List<CReservation_Restaurant> lista_reservas = manejador.buscarReservas();
            Assert.NotNull(lista_reservas);
            Assert.IsInstanceOf(typeof(List<CReservation_Restaurant>), lista_reservas);

        }
    }
}
