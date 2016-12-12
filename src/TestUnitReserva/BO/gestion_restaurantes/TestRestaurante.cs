using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_restaurantes;
using BOReserva.Servicio;
using System.Diagnostics;

namespace TestUnitReserva.BO.gestion_restaurantes
{
    [TestFixture]
    class TestRestaurante
    {
        manejadorSQL sql = new manejadorSQL();

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
    }
}
