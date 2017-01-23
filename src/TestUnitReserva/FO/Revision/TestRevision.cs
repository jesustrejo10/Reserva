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
    using EntidadValoracion = FOReserva.DataAccess.Domain.RevisionValoracion;
    using EntidadReferenciaValorada = FOReserva.DataAccess.Domain.ReferenciaValorada;
    using EntidadRestaurante = FOReserva.DataAccess.Domain.Restaurante;
    using EntidadHotel = FOReserva.DataAccess.Domain.Hotel;
    using EntidadUsuario = FOReserva.DataAccess.Domain.Usuario;    

    [TestClass]
    public class TestRevision
    {
        [TestMethod]
        public void TestRevisionEcho()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestRevisionGuardarRevision()
        {
            var revision = new EntidadRevision
            {
                Id = 0,
                Mensaje = "Test RHotel.",
                Estrellas = 0,
                Tipo = EnumTipoRevision.Hotel,
                Propietario = new EntidadUsuario(1),
                Referencia = new FOReserva.DataAccess.Domain.Entidad(37)
            };

            var result = DAORevision.Singleton().GuardarRevision(revision);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRevisionGuardarValoracion()
        {
            var valoracion = new EntidadValoracion
            {
                Id = 0,
                Punto = EnumCalificacion.Positiva,
                Propietario = new EntidadUsuario(id: 1),
                Revision = new EntidadRevision(95)
            };

            var result = DAORevision.Singleton().GuardarValoracion(valoracion);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestRevisionObtenerRevisionesPorReferencia()
        {
            var referencia = new EntidadRestaurante
            {
                _id = 1
            };

            var result = DAORevision.Singleton().ObtenerRevisionesPorReferencia(referencia);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestRevisionObtenerValoracionPorReferencia()
        {
            var referencia = new EntidadRestaurante
            {
                _id = 1
            };

            var result = DAORevision.Singleton().ObtenerValoracionPorReferencia(referencia);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestRevisionBorrarRevision()
        {
            var referencia = new EntidadRevision
            {
                _id = 95,
                Propietario = new EntidadUsuario(1)
            };

            var result = DAORevision.Singleton().BorrarRevision(referencia);
            Assert.IsTrue(result);
        }
    }
}
