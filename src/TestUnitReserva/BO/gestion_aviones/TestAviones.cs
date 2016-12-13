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
        /// <summary>
        /// Pruebas para insertar un avión en la base de datos
        /// Creo el avión y se lo paso como parámetro a la función
        /// el resultado lo guardo en un variable 
        /// la primera prueba es verificar que efectivamente inserta el avión, es decir, la función devuelve true
        /// la segunda prueba es pasar null a la función y que la misma retorne false
        /// la tercera prueba es asignarle null a la matrícula, lo cual no está permitido entonces debe retornar false
        /// la cuarta prueba es pasarle a la función un avión repetido, la misma debe retorna false
        /// </summary>
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
            Boolean resultadoconnull = prueba.insertarAvion(null);
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
        /// <summary>
        /// Pruebas para verificar que la lista que se muestra en el visualizar no venga vacía
        /// Creo la variable respuesta de tipo List<> y le asigno lo que retorna la función listar aviones
        /// Compruebo que la variable respuesta sea distinta a null
        /// </summary>
        [Test]
        public void M02_ListarAvionesEnBd()
        {
            //pruebo que la lista no retorne vacía
            List<CAvion> respuesta = prueba.listarAvionesEnBD();
            Assert.IsNotNull(respuesta);
        }
        /// <summary>
        /// Prueba del método consultar avión pasando un número inválido
        /// </summary>
        [Test]
        public void consultarAvionIdInvalida()
        {
            int numeroNulo = 31211;
            Assert.IsNotInstanceOf(typeof(CAvion) ,prueba.consultarAvion(numeroNulo));
        }
        /// <summary>
        /// Prueba del método consultar avión pasando un número válido
        /// </summary>
        [Test]
        public void consultarAvionIdValida()
        {
            int numeroValido = 1;
            Assert.IsInstanceOf( typeof(CAvion) , prueba.consultarAvion(numeroValido));
        }

   /// <summary>
   /// Prueba del método modificar con un avión que no existe
   /// </summary>
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
        /// <summary>
        /// Prueba para la verificación del método Deshabilitar un avión
        /// </summary>
        [Test]
        public void verificarDeshabilitarAvion()
        {
            Boolean resultado = prueba.deshabilitarAvion(1);
            Assert.AreEqual(resultado, true);
        }
        /// <summary>
        /// Prueba para verificar el método Habilitar un avión
        /// </summary>
        [Test]
        public void verificarHabilitarAvion()
        {
            Boolean resultado = prueba.habilitarAvion(1);
            Assert.AreEqual(resultado, true);
       }
        /// <summary>
        /// Prueba para ver verificar el método Eliminar avión 
        /// </summary>
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