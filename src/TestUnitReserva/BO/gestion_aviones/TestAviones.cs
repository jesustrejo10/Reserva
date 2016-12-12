using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_aviones;
using BOReserva.Servicio;
using System.Diagnostics;

namespace TestUnitReserva.BO.gestion_aviones
{
    [TestFixture]
    class TestAviones
    {
        [Test]
        public void M02_InsertarAvion()
        {
            CAgregarAvion avion = new CAgregarAvion();
            avion._matriculaAvion="Hk900";
            avion._modeloAvion = "Boeing700";
            avion._capacidadPasajerosTurista = 100;
            avion._capacidadPasajerosEjecutiva = 100;
            avion._capacidadPasajerosVIP = 100;
            avion._capacidadEquipaje = 100;
            avion._distanciaMaximaVuelo = 200;
            avion._velocidadMaximaDeVuelo = 1000;
            avion._capacidadMaximaCombustible = 100;
            manejadorSQL prueba = new manejadorSQL();
            //Aquí pruebo que al insertar un avión de manera correcta la función devuelva true
            Boolean resultadoconavion = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadoconavion, true);
            //Aquí pruebo que el insertar avión no me deje agregar vacío
            Boolean resultadoconnull = prueba.insertarPlato(null);
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
    }
}
