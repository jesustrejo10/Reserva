using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_comida_vuelo;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestUnitReserva.BO.gestion_comida_vuelo
{
    class TestComidaVuelo
    {
        [TestFixture]
        class TestAviones
        {
            manejadorSQL prueba = new manejadorSQL();

            [Test]
            public void M02_InsertarPlato()
            {
                CAgregarComida comida = new CAgregarComida();
                comida._nombrePlato = "Batido de Parchita";
                comida._tipoPlato = "Bebida";
                comida._estatusPlato = 1;
                comida._descripcionPlato = "Jugo de parchita natural";
                //Aquí pruebo que al insertar un plato de manera correcta la función devuelva true
                Boolean resultadoconplato = prueba.insertarPlato(comida);
                Assert.AreEqual(resultadoconplato, true);

            }

            [Test]
            public void M02_ListarPlatosEnBd()
            {
                //pruebo que la lista no retorne vacia
                List<CComida> respuesta = prueba.listarPlatosEnBD();
                Assert.IsNotNull(respuesta);
            }

            [Test]
            public void verificarDeshabilitarPlato()
            {
                Boolean resultado = prueba.deshabilitarPlato(1);
                Assert.AreEqual(resultado, true);
            }

            [Test]
            public void verificarHabilitarPlato()
            {
                Boolean resultado = prueba.habilitarPlato(1);
                Assert.AreEqual(resultado, true);
            }

        }
    }
}
