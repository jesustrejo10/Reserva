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
        private Rol mockRolPermiso;
        private Rol mockIdRol;
        private Permiso mockPermiso;
        private int idAdministrador;
        DAORol daoRol;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockRol = new Rol("SuperAdmin");
            mockRolPermiso = new Rol("SuperAdmin", "Gestion de aviones");
            mockIdRol = new Rol(1, "Administrador");
            idAdministrador = 1;
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
            mockRolPermiso = null;
            daoRol = null;
        }

        [Test]
        public void M13_DAOTestAgregar()
        {
            //Caso de exito
            int resultadoAgregar = daoRol.Agregar(mockRol);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoRol.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void M13_DAOTestAgregarPermisosRol()
        {
            //Caso de exito
            int resultadoAgregar = daoRol.AgregarRolPermiso(mockRolPermiso);
            Assert.AreEqual(resultadoAgregar, 1);
            //Caso de fallo
            int resultadoAgregarIncorrecto = daoRol.AgregarRolPermiso(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void M13_DAOTestConsultarRol()
        {
            //Caso de exito
            Assert.AreNotEqual(daoRol.ConsultarRoles(), null);
        }

        [Test]
        public void M13_DAOTestConsultarPermisos()
        {
            //Caso de exito        
            Assert.AreNotEqual(daoRol.ConsultarPermisos(1), null);
            //Caso de exito
            Assert.AreNotEqual(daoRol.ConsultarPermisos(1).Count, 0);
            //Caso de fallo
            Assert.AreNotEqual(daoRol.ConsultarPermisos(0), null);
        }

        [Test]
        public void M13_DAOTestListarPermisos()
        {
            //Caso de exito
            Assert.AreNotEqual(daoRol.ListarPermisos(), null);
            //Caso de exito
            Assert.AreNotEqual(daoRol.ListarPermisos().Count, 0);
        }
    }
}