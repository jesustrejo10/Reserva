using FOReserva.Models.ReservaHabitacion;
using FOReserva.Models.Revision;
using FOReserva.Models.Usuarios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FOReserva.Models.Revision.CRevision;

namespace TestUnitReserva.FO.Revision
{
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
            var revision = new CRevision
            {
                Id = 84,
                Mensaje = "Test RHotel.",
                Puntuacion = 0,
                Tipo = TipoRevision.Hotel,
                Usuario = new CUsuario
                {
                    ID = 1,
                    Nombre = "Usuari Prueba"
                },
                Referencia = new CReservaHabitacion
                {
                    ID = 37
                }
            };

            var result = DAORevision.Singleton().GuardarRevision(revision, usuario, reservaHabitacion);
            Debug.WriteLine($"Message: {result.Message}");
            Assert.IsTrue(result.ProcessFinishCorrectly);
        }
    }
}
