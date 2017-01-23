using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.M08;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitReserva.BO.gestion_automoviles
{
    using EntidadAutomovil = BOReserva.DataAccess.Domain.Automovil;
    using BOReserva.DataAccess.DataAccessObject;
    [TestClass]
    public class TestRevision
    {
        [TestMethod]
        public void TestRevisionEcho()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestRevisionAgregarAutomovil()
        {
            var automovil = new EntidadAutomovil
            {
                matricula          ="",
                modelo             ="",
                fabricante         ="",
                anio               =0,
                kilometraje        =0,
                cantpasajeros      =0,   
                tipovehiculo       ="",
                preciocompra       =0,
                precioalquiler     =0,
                penalidaddiaria    =0,
                fecharegistro      =new DateTime(2000, 01, 01),
                color              ="",
                disponibilidad     =0,
                transmision        ="",
                fk_ciudad          =0,
                ciudad             ="",
                pais               =""
            };

            var result = DAOAutomovil.Singleton().Agregar(automovil);
            Assert.IsTrue(result);
        }
    }
}
