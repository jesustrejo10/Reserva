using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BOReserva.Models.gestion_aviones;
using BOReserva.Models;
using BOReserva.Servicio;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest_Aviones
    {
        manejadorSQL prueba = new manejadorSQL();

        [TestMethod]
        public void M02_InsertarAvion()
        {
            CAgregarAvion avion = new CAgregarAvion();
            avion._matriculaAvion = Util.RandomString(7);
            avion._modeloAvion = "Boeing700";
            avion._capacidadPasajerosTurista = 100;
            avion._capacidadPasajerosEjecutiva = 100;
            avion._capacidadPasajerosVIP = 100;
            avion._capacidadEquipaje = 100;
            avion._distanciaMaximaVuelo = 200;
            avion._velocidadMaximaDeVuelo = 1000;
            avion._capacidadMaximaCombustible = 100;
            //Aquí pruebo que al insertar un avión de manera correcta la función devuelva true
            Boolean resultadoconavion = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadoconavion, true);
            //Aquí pruebo que el insertar avión no me deje agregar vacío
            Boolean resultadoconnull = prueba.insertarAvion(null);
            Assert.AreEqual(resultadoconnull, false);
            //Pruebo que no me deje insertar una matrícula en null
            avion._matriculaAvion =null;
            Boolean resultadosinmatricula = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadosinmatricula, false);
            //Aquí pruebo que no me deje insertar una matricula repetida
            avion._matriculaAvion = "Hk900";
            Boolean resultadomatricularepetida = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadomatricularepetida, false);    
        }

        [TestMethod]
        public void M02_ListarAvionesEnBd()
        {
            //pruebo que la lista no retorne vacia
            List<CAvion> respuesta = prueba.listarAvionesEnBD();
            Assert.IsNotNull(respuesta);
        }

        [TestMethod]
        public void consultarAvionIdInvalida()
        {
            int numeroNulo = 31211;
            Assert.IsNotInstanceOfType(prueba.consultarAvion(numeroNulo), typeof(CAvion));
        }

        [TestMethod]
        public void consultarAvionIdValida()
        {
            int numeroNulo = 1;
            Assert.IsInstanceOfType(prueba.consultarAvion(numeroNulo), typeof(CAvion));
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void modificarAvionNulo()
        {
            prueba.modificarAvion(null);
        }

        [TestMethod]
        public void modificarAvionInexistente()
        {
            CModificarAvion avion = new CModificarAvion();
            avion._matriculaAvion = "HK-45";
            avion._modeloAvion = "Boeing700";
            avion._capacidadPasajerosTurista = 100;
            avion._capacidadPasajerosEjecutiva = 100;
            avion._capacidadPasajerosVIP = 100;
            avion._capacidadEquipaje = 100;
            avion._distanciaMaximaVuelo = 200;
            avion._velocidadMaximaDeVuelo = 1000;
            avion._capacidadMaximaCombustible = 100;
            Boolean resultadoModificar = prueba.modificarAvion(avion);
            Assert.AreEqual(resultadoModificar, true);
        }
       
        [TestMethod]
        public void verificarDeshabilitarAvion()
        {
            Boolean resultado = prueba.deshabilitarAvion(1);
            Assert.AreEqual(resultado, true);
        }
       
        [TestMethod]
        public void verificarHabilitarAvion()
        {
            Boolean resultado = prueba.habilitarAvion(1);
            Assert.AreEqual(resultado, true);
        }


        
    }

}
