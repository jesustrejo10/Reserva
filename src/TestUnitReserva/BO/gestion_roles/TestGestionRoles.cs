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
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M13;
using BOReserva.Models.gestion_roles;
using BOReserva.Controllers;

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
        gestion_rolesController controller;

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
            controller = new gestion_rolesController();

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
            ////Caso de fallo
            //int resultadoAgregarIncorrecto = daoRol.Agregar(null);
            //Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void M13_DAOTestAgregarPermisosRol()
        {
            //Caso de exito
            int resultadoAgregar = daoRol.AgregarRolPermiso(mockRolPermiso);
            Assert.AreEqual(resultadoAgregar, 1);
            ////Caso de fallo
            //int resultadoAgregarIncorrecto = daoRol.AgregarRolPermiso(null);
            //Assert.AreEqual(resultadoAgregarIncorrecto, 0);
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

        [Test]
        public void M13_DAOBuscarIDRol()
        {
            //Caso de exito
            Assert.AreEqual(daoRol.MBuscarid_IdRol("Administrador"), "1");
        }

        [Test]
        public void M13_DAOBuscarIDPermiso()
        {
            //Caso de exito
            Assert.AreEqual(daoRol.MBuscarid_Permiso("Gestion de aviones"), "6");
        }

        [Test]
        public void M13_DAOConsultarRol()
        {
            //Caso de exito
            Entidad rol = daoRol.Consultar(1);
            Rol _rol = new Rol();
            _rol = (Rol)rol;
            Assert.AreEqual(_rol._nombreRol, "Administrador");
            //Caso de exito
            Assert.AreNotEqual(_rol, null);
        }

        [Test]
        public void M13_DAOModificarRol()
        {
            Rol _rol = new Rol();
            _rol._nombreRol = "SuperAdminModificado";
            _rol._idRol = mockRol._idRol;
            Assert.AreNotEqual(daoRol.Modificar(_rol), null);
        }

        [Test]
        public void M13_DAOEliminarRol()
        {
            Assert.AreEqual(daoRol.eliminarRol(mockRol._idRol), "1");
        }

        [Test]
        public void M13_DAOEliminarPermisos()
        {
            Assert.AreEqual(daoRol.eliminarPermiso(mockRol._idRol), "1");
        }

        [Test]
        public void M13_DAOConsultarPermisosAsociados()
        {
            Assert.AreNotEqual(daoRol.consultarLosPermisosAsignados(mockRol._idRol), null);
        }

        [Test]
        public void M13_DAOConsultarPermisosNoAsociados()
        {
            Assert.AreNotEqual(daoRol.consultarPermisosNoAsignados(mockRol._idRol), null);
        }

        [Test]
        public void M13_DAOConsultarPermisosUsuario()
        {
            Assert.AreNotEqual(daoRol.consultarPermisosUsuario(34), null);
        }

        [Test]
        public void M13_DAOValidacionRol()
        {
            Assert.AreNotEqual(daoRol.validacionRol(mockRol._idRol), null);
        }

        [Test]
        public void M13_ControllerAgregarRol()
        {
            CRoles rol = new CRoles();
            rol.Nombre_rol = "Rol desde Prueba";
            Assert.AreNotEqual(controller.agregarrol(rol), null);
        }

        [Test]
        public void M13_ControllerCargaAgregarRol()
        {
            Assert.AreNotEqual(controller.M13_AgregarRol(), null);
        }

        [Test]
        public void M13_ControllerCargaModificarPermiso()
        {
            Assert.AreNotEqual(controller.M13_ModificarPermiso(32), null);
        }

        [Test]
        public void M13_ControllerModificarPermiso()
        {
            int id = 1;
            String nombre = "Permiso modificado";
            String url = "url";
            Assert.AreNotEqual(controller.ModificarPermiso(id, nombre, url), null);
        }

        [Test]
        public void M13_ControllerCargaModificarRol()
        {
            Assert.AreNotEqual(controller.M13_ModificarRol(1), null);
        }

        [Test]
        public void M13_ControllerCargaConsultarRol()
        {
            Assert.AreNotEqual(controller.M13_VisualizarRol(), null);
        }

        [Test]
        public void M13_ControllerCargaConsultarPermiso()
        {
            Assert.AreNotEqual(controller.M13_VisualizarPermiso(), null);
        }

        [Test]
        public void M13_ControllerPermisosNoAsignados()
        {
            Assert.AreNotEqual(controller.consultarLosPermisosNoAsignados(1), null);
        }

        //[Test]
        //public void M13_ControllerAsignarPermisos()
        //{
        //    Assert.AreNotEqual(controller.asignarpermisos("Gestion de aviones"), null);
        //}

        [Test]
        public void M13_ControllerAgregarPermiso()
        {
            CModulo_detallado md = new CModulo_detallado();
            md.Nombre = "PermisoPrueba";
            md.Url = "url/prueba";
            Assert.AreNotEqual(controller.agregarpermiso(md), null);
        }

        [Test]
        public void M13_ControllerEliminarPermisoRol()
        {
            Assert.AreNotEqual(controller.eliminarPermisoRol(1, 1), null);
        }

        [Test]
        public void M13_ControllerModificarRol()
        {
            Assert.AreNotEqual(controller.modificarrol(1, "Administrador"), null);
        }

        [Test]
        public void M13_ControllerQuitarPermiso()
        {
            Assert.AreNotEqual(controller.quitarPermisoRol(1), null);
        }

        [Test]
        public void M13_ControllerEliminarRol()
        {
            Assert.AreNotEqual(controller.eliminarRol(1), null);
        }

        [Test]
        public void M13_ControllerConsultarPermisos()
        {
            Assert.AreNotEqual(controller.Consultarpermisos(), null);
        }

        [Test]
        public void M13_ControllerCargarAgregarPermiso()
        {
            Assert.AreNotEqual(controller.M13_AgregarPermiso(), null);
        }

        [Test]
        public void M13_ControllerEliminarPermisoSeleccionado()
        {
            Assert.AreNotEqual(controller.eliminarPermisoSeleccionado(1), null);
        }

    }
}