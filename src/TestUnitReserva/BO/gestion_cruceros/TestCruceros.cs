//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BOReserva.Models.gestion_cruceros;
//using NUnit.Framework;

//namespace TestUnitReserva.BO.gestion_cruceros
//{
//    [TestFixture]
//    class TestCruceros
//    {
//        ConexionBD prueba = new ConexionBD();
//        BOReserva.Controllers.gestion_crucerosController controlador = new BOReserva.Controllers.gestion_crucerosController();

//        //<summary>
//        // Pruebas para insertar un crucero en la base de datos
//        // Se crea el crucero y es pasado como parámetro a la función    
//        //</summary>

//        [Test]
//        public void insertarCrucerosTest()
//        {
//            CGestion_crucero crucero = new CGestion_crucero();
//            crucero._nombreCrucero = "ABP Travel";
//            crucero._companiaCrucero = "Royal Caribbean";
//            crucero._capacidadCrucero = 1000;
//            //Prueba que al insertar un crucero de la forma correcta, retorna true
//            Boolean insertoCrucero = prueba.insertarCruceros(crucero);
//            Assert.AreEqual(insertoCrucero, true);
//        }

//        //<summary>
//        // Pruebas para insertar una cabina en la base de datos
//        // Se crea la cabina y es pasado como parámetro a la función    
//        //</summary>
//        public void insertarCabinaTest()
//        {
//            CGestion_cabina cabina = new CGestion_cabina();
//            cabina._nombreCabina = "Ocean View";
//            cabina._precioCabina= 100;
//            cabina._fkCrucero = 1;
//            //Prueba que al insertar una cabina de la forma correcta, retorna true
//            Boolean insertoCabina = prueba.insertarCabinas(cabina);
//            Assert.AreEqual(insertoCabina, true);
//        }

//        //<summary>
//        // Pruebas para insertar un camarote en la base de datos
//        // Se crea el camarote y es pasado como parámetro a la función    
//        //</summary>
//        public void insertarCamaroteTest()
//        {
//            CGestion_camarote camarote = new CGestion_camarote();
//            camarote._tipoCama = "Individual";
//            camarote._cantidadCama = 2;
//            camarote._fkCabina = 1;
//            //Prueba que al insertar un camarote de la forma correcta, retorna true
//            Boolean insertoCabina = prueba.insertarCamarote(camarote);
//            Assert.AreEqual(insertoCabina, true);
//        }

//        //<summary>
//        // Pruebas para insertar un itinerario en la base de datos
//        // Se crea el camarote y es pasado como parámetro a la función    
//        //</summary>
//        public void insertarItinerarioTest()
//        {
//            CGestion_itinerario itinerario = new CGestion_itinerario();
//            itinerario._fkCrucero = 1;
//            itinerario._fkRuta = 2;
//            itinerario._fechaInicio = DateTime.Parse("2016-08-12");
//            itinerario._fechaFin = DateTime.Parse("2016-12-12");
//            //Prueba que al insertar un itinerario de la forma correcta, retorna true
//            Boolean insertoCabina = prueba.insertarItinerario(itinerario);
//            Assert.AreEqual(insertoCabina, true);
//        }

//        //<summary>
//        // Prueba que se retorne una lista con un crucero agregado
//        //</summary>
//        public void listarCrucerosTest()
//        {
//            List<CGestion_crucero> listaCruceros = new List<CGestion_crucero>();
//            CGestion_crucero crucero = new CGestion_crucero();
//            crucero._nombreCrucero = "Good travel";
//            crucero._companiaCrucero = "MGS";
//            crucero._capacidadCrucero = 2;
//            listaCruceros.Add(crucero);
//            Assert.AreEqual(listaCruceros, prueba.listarCruceros());
//        }
//    }
//}
