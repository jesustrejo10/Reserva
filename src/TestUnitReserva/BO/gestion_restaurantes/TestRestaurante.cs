using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Controllers;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Web.Mvc;

namespace TestUnitReserva.BO.gestion_restaurantes
{
    [TestFixture]
    class TestRestaurante
    {
        manejadorSQL sql = new manejadorSQL();

        /// <summary>
        /// Prueba del servicio SQL para la consulta de restaurantes.
        /// </summary>
        [Test]
        public void TestConsultarRestaurantes()
        {
            var lista = sql.consultarRestaurante();
            Assert.IsInstanceOf(typeof(List<CRestauranteModelo>), lista);
            foreach(var item in lista)
            {
                Debug.WriteLine("Encontrado restaurante: " + item._nombre);
            }
            Assert.IsInstanceOf(typeof(CRestauranteModelo), sql.consultarRestaurante(1));
        }

        /// <summary>
        /// Prueba del servicio SQL para la creación de restaurantes.
        /// </summary>
        [Test]
        public void TestCrearRestaurantes()
        {
            var prueba = new CRestauranteModelo
            {
                _nombre = "Restaurante de prueba",
                _tipoComida = "Mediterranea",
                _direccion = "Direccion de prueba",
                _descripcion = "Descripcion de prueba",
                _horarioApertura = "07:00",
                _horarioCierre = "19:00",
                _idLugar = 12
            };
            Assert.IsTrue(sql.insertarRestaurante(prueba));
        }

        /// <summary>
        /// Prueba del servicio SQL para la modificación de restuarantes.
        /// </summary>
        [Test]
        public void TestModificarRestaurantes()
        {
            var prueba = sql.consultarRestaurante().FirstOrDefault(x => x._nombre == "Restaurante de prueba"); //Debe existir al menos un restaurante de prueba
            prueba._descripcion = "X"; //Forzando una modificación
            Assert.IsTrue(sql.modificarRestaurante(prueba));
        }

        /// <summary>
        /// Prueba del servicio SQL para la eliminación de restaurantes.
        /// </summary>
        [Test]
        public void TestEliminarRestaurantes()
        {
            var prueba = sql.consultarRestaurante().FirstOrDefault(x => x._nombre == "Restaurante de prueba"); //Debe existir al menos un restaurante de prueba
            Assert.IsTrue(sql.eliminarRestaurante(prueba._id));
        }

        /// <summary>
        /// Test al controlador para comprobar la generación de los datos a la vista de visualizar restaurantes.
        /// </summary>
        [Test]
        public void TestControladorVer()
        {
            var prueba = new gestion_restaurantesController();
            Assert.IsInstanceOf(typeof(PartialViewResult), prueba.M10_GestionRestaurantes_Ver());
        }

        /// <summary>
        /// Test al controlador para comprobar la generación de los datos a la vista de agregar restaurantes.
        /// </summary>
        [Test]
        public void TestControladorAgregar()
        {
            var prueba = new gestion_restaurantesController();
            Assert.IsInstanceOf(typeof(PartialViewResult), prueba.M10_GestionRestaurantes_Agregar());
        }

        /// <summary>
        /// Test al controlador para comprobar la generación de los datos a la vista de modificar restaurantes.
        /// </summary>
        [Test]
        public void TestControladorModificar()
        {
            var prueba = new gestion_restaurantesController();
            Assert.IsInstanceOf(typeof(PartialViewResult), prueba.M10_GestionRestaurantes_Modificar(1));
        }
    }
}
