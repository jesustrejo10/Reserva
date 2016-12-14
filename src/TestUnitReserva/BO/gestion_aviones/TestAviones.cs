using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_aviones;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestUnitReserva.BO.gestion_aviones
{
    [TestFixture]
    class TestAviones
    {
        manejadorSQL prueba = new manejadorSQL();

        [Test]
        public void M02_InsertarAvion()
        {
            CAgregarAvion avion = new CAgregarAvion();
            avion._matriculaAvion = BOReserva.Models.Util.RandomString(7);
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
            Boolean resultadoconnull = prueba.insertarPlato(null);
            Assert.AreEqual(resultadoconnull, false);
            //Pruebo que no me deje insertar una matrícula en null
            avion._matriculaAvion = null;
            Boolean resultadosinmatricula = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadosinmatricula, false);
            //Aquí pruebo que no me deje insertar una matricula repetida
            avion._matriculaAvion = "Hk900";
            Boolean resultadomatricularepetida = prueba.insertarAvion(avion);
            Assert.AreEqual(resultadomatricularepetida, false);    
          
        }

        [Test]
        public void M02_ListarAvionesEnBd()
        {
            //pruebo que la lista no retorne vacia
            List<CAvion> respuesta = prueba.listarAvionesEnBD();
            Assert.IsNotNull(respuesta);
        }

        [Test]
        public void consultarAvionIdInvalida()
        {
            int numeroNulo = 31211;
            Assert.IsNotInstanceOf(typeof(CAvion) ,prueba.consultarAvion(numeroNulo));
        }

        [Test]
        public void consultarAvionIdValida()
        {
            int numeroValido = 1;
            Assert.IsInstanceOf( typeof(CAvion) , prueba.consultarAvion(numeroValido));
        }

   
        [Test]
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

        [Test]
        public void verificarDeshabilitarAvion()
        {
            Boolean resultado = prueba.deshabilitarAvion(1);
            Assert.AreEqual(resultado, true);
        }

        [Test]
        public void verificarHabilitarAvion()
        {
            Boolean resultado = prueba.habilitarAvion(1);
            Assert.AreEqual(resultado, true);
       }

        [Test]
        public void verificarEliminarAvion()
        {
            int id = 65; //suponiendo que quiero eliminar el avion 65 si es que existe
            Boolean resultado = prueba.eliminarAvion(id);
            Assert.AreEqual(resultado, true);
        }

        [Test]        
        public void modificarAvionNulo()
        {
            Assert.That(() => prueba.modificarAvion(null),
            Throws.TypeOf<SqlException>());

        } 
        
    }
}