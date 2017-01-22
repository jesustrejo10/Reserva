using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_hoteles;
using BOReserva.Servicio.Servicio_Hoteles;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M13;

namespace TestUnitReserva.BO.gestion_roles
{
    [TestFixture]
    class TestGestionRoles
    {
        private Rol mockRol;
        private Permiso mockPermiso;
        DAORol daoRol;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockRol = new Rol("SuperAdmin");
            mockPermiso = new Permiso(90,"Permiso 1");
            daoRol = new DAORol();

        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockRol = null;
            mockPermiso = null;
            daoRol = null;
        }

        [Test]
        public void M13_DAOTestAgregar()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoRol.Agregar(mockRol);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoRol.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }
    }
}