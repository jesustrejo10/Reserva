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

        
  // ME FALTAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void modificarAvionNulo()
        {
            prueba.modificarAvion(null);
        } 
        

        
    }

}
