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
using System.Web;
using System.Web.Mvc;

namespace TestUnitReserva.BO.gestion_aviones
{
    [TestFixture]
    class TestAviones
    {
        manejadorSQL prueba = new manejadorSQL();
        BOReserva.Controllers.gestion_avionesController controlador = new BOReserva.Controllers.gestion_avionesController();
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
            Assert.IsNotInstanceOf(typeof(CAvion), prueba.consultarAvion(numeroNulo));
        }
        /// <summary>
        /// Prueba del método consultar avión pasando un número válido
        /// </summary>
        [Test]
        public void consultarAvionIdValida()
        {
            int numeroValido = 1;
            Assert.IsInstanceOf(typeof(CAvion), prueba.consultarAvion(numeroValido));
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

        /// <summary>
        /// Prueba que se encarga de verificar que se produzca una excepcion si se pasa el parametro nulo
        /// </summary>
        [Test]
        public void modificarAvionNulo()
        {
            Assert.That(() => prueba.modificarAvion(null), Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Prueba que evalua la llamada al controlador de AgregarAvion de gestion_avionesController
        /// </summary>
        [Test]
        public void pruebaControladorAgregar()
        {
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M02_AgregarAvion());
        }

        /// <summary>
        /// Prueba que evalua al controlador si se pasa un valor nulo a la funcion guardarAvion
        /// </summary>
        [Test]
        public void pruebaGuardarAvionNulo()
        {
            Assert.That(() => controlador.guardarAvion(null), Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Prueba que evalua al controlador si se pasa un valor valido a la funcion guardarAvion
        /// </summary>
        [Test]
        public void pruebaGuardarAvion()
        {
            CAgregarAvion model = new CAgregarAvion();
            model._matriculaAvion = BOReserva.Models.Util.RandomString(7);
            model._modeloAvion = "Boeing700";
            model._capacidadPasajerosTurista = 100;
            model._capacidadPasajerosEjecutiva = 100;
            model._capacidadPasajerosVIP = 100;
            model._capacidadEquipaje = 100;
            model._distanciaMaximaVuelo = 200;
            model._velocidadMaximaDeVuelo = 1000;
            model._capacidadMaximaCombustible = 100;
            Assert.IsInstanceOf(typeof(JsonResult), controlador.guardarAvion(model));
        }

        /// <summary>
        /// Prueba que evalua que la respuesta del controlador en la funcion M02_VisualizarAviones
        /// sea un objeto del tipo ActionResult
        /// </summary>
        [Test]
        public void pruebaControladorVisualizar()
        {
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M02_VisualizarAviones());
        }

        /// <summary>
        /// Prueba que evalua que la respuesta del controlador en la funcion M02_ConsultarAvion
        /// sea un objeto del tipo ActionResult
        /// </summary>
        [Test]
        public void pruebaControladorConsultarValido()
        {
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M02_ConsultarAvion(1));
        }

        /// <summary>
        /// Prueba que evalua que se dispare la excepcion si se consulta un avion invalido
        /// </summary>
        [Test]
        public void pruebaControladorConsultarInvalido()
        {
            Assert.That(() => controlador.M02_ConsultarAvion(0), Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Prueba unitaria que prueba habilitar un avion que no exista, a pesar de que no exista
        /// igual retornara una respuesta vacia del tipo JsonResult.
        /// </summary>
        [Test]
        public void pruebaControladorHabilitarInvalido()
        {
            Assert.IsInstanceOf(typeof(JsonResult), controlador.habilitarAvion(0));
        }


        /// <summary>
        /// Prueba que evalua que la respuesta del controlador en la funcion habilitarAvion
        /// sea un objeto del tipo JsonResult
        /// </summary>
        [Test]
        public void pruebaControladorHabilitarValido()
        {
            Assert.IsInstanceOf(typeof(JsonResult), controlador.habilitarAvion(1));
        }

        /// <summary>
        /// Prueba unitaria que prueba deshabilitar un avion que no exista, a pesar de que no exista
        /// igual retornara una respuesta vacia del tipo jsonresult.
        /// </summary>
        [Test]
        public void pruebaControladorDeshabilitarInvalido()
        {
            Assert.IsInstanceOf(typeof(JsonResult), controlador.deshabilitarAvion(0));
        }


        /// <summary>
        /// Prueba unitaria que prueba deshabilitar un avion que exista y retorne una respuesta
        /// de tipo JsonResult
        /// </summary>
        [Test]
        public void pruebaControladorDeshabilitarValido()
        {
            Assert.IsInstanceOf(typeof(JsonResult), controlador.deshabilitarAvion(1));
        }

        /// <summary>
        /// Prueba unitaria que prueba eliminar un avion que no exista, a pesar de que no exista
        /// igual retornara una respuesta vacia del tipo jsonresult.
        /// </summary>
        [Test]
        public void pruebaControladorEliminarInvalido()
        {
            Assert.IsInstanceOf(typeof(JsonResult), controlador.eliminarAvion(0));
        }

        /// <summary>
        /// Prueba unitaria que prueba eliminar un avion que exista y retorne una respuesta
        /// de tipo JsonResult
        /// </summary>
        [Test]
        public void pruebaControladorEliminarValido()
        {
            //suponiendo que el avion con id 76 exista
            Assert.IsInstanceOf(typeof(JsonResult), controlador.eliminarAvion(76));
        }

        /// <summary>
        /// Prueba unitaria que prueba modificar un avion que exista y retorne una respuesta
        /// de tipo JsonResult
        /// </summary>
        [Test]
        public void pruebaModificarAvion()
        {
            CModificarAvion model = new CModificarAvion();
            model._matriculaAvion = "PEIAMRD";
            model._modeloAvion = "Boeing700";
            model._capacidadPasajerosTurista = 100;
            model._capacidadPasajerosEjecutiva = 100;
            model._capacidadPasajerosVIP = 100;
            model._capacidadEquipaje = 100;
            model._distanciaMaximaVuelo = 200;
            model._velocidadMaximaDeVuelo = 1000;
            model._capacidadMaximaCombustible = 100;
            Assert.IsInstanceOf(typeof(JsonResult), controlador.modificarAvion(model));
        }


        /// <summary>
        /// Prueba unitaria que prueba modificar un avion nulo y dispare la excepcion de tipo NullReferenceException
        /// </summary>
        [Test]
        public void pruebaModificarAvionNulo()
        {
            Assert.That(() => controlador.modificarAvion(null), Throws.TypeOf<NullReferenceException>());
        }
    }
}