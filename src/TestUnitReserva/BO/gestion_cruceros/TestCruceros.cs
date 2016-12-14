using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.Models.gestion_cruceros;
using NUnit.Framework;

namespace TestUnitReserva.BO.gestion_cruceros
{
    [TestFixture]
    class TestCruceros
    {
        ConexionBD prueba = new ConexionBD();
        BOReserva.Controllers.gestion_crucerosController controlador = new BOReserva.Controllers.gestion_crucerosController();

        //<summary>
        // Pruebas para insertar un crucero en la base de datos
        // Se crea el crucero y es pasadocomo parámetro a la función    
        //</summary>

        [Test]
        public void insertarCrucerosTest()
        {
            CGestion_crucero crucero = new CGestion_crucero();
            crucero._nombreCrucero = "ABP Travel";
            crucero._companiaCrucero = "Royal Caribbean";
            crucero._capacidadCrucero = 1000;
            //Prueba que al insertar un crucero de la forma correcta, retorna true
            Boolean insertoCrucero = prueba.insertarCruceros(crucero);
            Assert.AreEqual(insertoCrucero, true);
        }
    }
}
