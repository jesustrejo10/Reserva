using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestHotel
    {
        CManejadorSQL_Hoteles hotelTest = new CManejadorSQL_Hoteles();

        [Test]
        public void M09_GestionHoteles_Crear()
        {
            CGestionHoteles_CrearHotel hotel = new CGestionHoteles_CrearHotel();
            hotel._canthabitaciones = 20;
            hotel._ciudad = "Caracas";
            hotel._direccion = "Av. La Estancia, CCCT, Chuao";
            hotel._email = "hotelccct@gmail.com";
            hotel._estrellas = 3;
            hotel._nombre = "Hotel CCCT";
                       
            //Aquí pruebo que al insertar un avión de manera correcta la función devuelva true
            Boolean resultadoconhotel = hotelTest.insertarHotel(hotel);
            Assert.AreEqual(resultadoconhotel, true);
            //Aquí pruebo que el insertar avión no me deje agregar vacío
            Boolean resultadoconnull = hotelTest.insertarHotel(null);
            Assert.AreEqual(resultadoconnull, false);            
        }

        [Test]
        public void MListarHotelesBD()
        {
            //pruebo que la lista no retorne vacia
            List<CHotel> respuesta = hotelTest.MListarHotelesBD();
            Assert.IsNotNull(respuesta);
        }

        [Test]
        public void consultarpkHotelInvalida()
        {
            int numeroNulo = 31211;
            Assert.IsNotInstanceOf(typeof(CHotel), hotelTest.consultarHotel(numeroNulo));
        }

        [Test]
        public void consultarHotelpkValida()
        {
            int numeroValido = 1;
            Assert.IsInstanceOf(typeof(CHotel), hotelTest.consultarHotel(numeroValido));
        }

/*
        [Test]
        public void modificarAvionInexistente()
        {
            CGestionHoteles_EditarHotel hotel = new CGestionHoteles_EditarHotel();
            hotel._canthabitaciones = 20;
            hotel._ciudad = "Caracas";
            hotel._direccion = "Av. La Estancia, CCCT, Chuao";
            hotel._email = "hotelccct@gmail.com";
            hotel._estrellas = 3;
            Boolean resultadoModificar = hotelTest.modificarHotel(hotel);
            Assert.AreEqual(resultadoModificar, true);
        }*/

        [Test]
        public void DesactivarHotelTest()
        {
            Boolean resultado = hotelTest.deshabilitarHotelBD(1);
            Assert.AreEqual(resultado, true);
        }

        [Test]
        public void ActivarHotelTest()
        {
            Boolean resultado = hotelTest.activarHotelBD(1);
            Assert.AreEqual(resultado, true);
        }
/*
        [Test]
        public void TestmodificarHotelNull()
        {
            Assert.That(() => hotelTest.modificarHotel(null),
            Throws.TypeOf<SqlException>());
        }

    */

    }
}