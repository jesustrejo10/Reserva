using FOReserva.DataAccess.DataAccessObject.M20;
using FOReserva.DataAccess.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitReserva.FO.Revision
{
    using EntidadRevision = FOReserva.DataAccess.Domain.Revision;
    [TestClass]
    public class TestRevision
    {
        [TestMethod]
        public void TestRevisionEcho()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestRevisionAgregarRevisionHotel()
        {
            var revision = new EntidadRevision
            {
                Id = 84,
                Mensaje = "Test RHotel.",
                Puntuacion = 0,
                Tipo = FOReserva.DataAccess.Domain.Revision.TipoRevision.Hotel,
                Usuario = new FOReserva.DataAccess.Domain.Entidad(1),
                Referencia = new FOReserva.DataAccess.Domain.Entidad(37)
            };

            var result = DAORevision.Singleton().GuardarRevision(revision);
            Assert.IsTrue(result);
        }
    }
}
