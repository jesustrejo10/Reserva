using System;
using NUnit.Framework;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.Models.gestion_roles;
using BOReserva.Controllers;
using BOReserva.Excepciones.M13;

namespace TestUnitReserva.BO.gestion_roles
{
    [TestFixture]
    class TestGestionRoles
    {
        private Rol mockRol;
        private Rol mockIdRol;
        private Permiso mockPermiso;
        DAORol daoRol;
        gestion_rolesController controller;
        String nombreRol;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockRol = new Rol("SuperAdmin");
            mockIdRol = new Rol(1, "Administrador");
            mockPermiso = new Permiso("Permiso Prueba Unitaria", "url");
            daoRol = new DAORol();
            controller = new gestion_rolesController();
            nombreRol = TestGestionRolesRand();
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockRol = null;
            mockIdRol = null;
            mockPermiso = null;
            daoRol = null;
            controller = null;
            nombreRol = null;
        }

        [Test]
        public void M13_DAOTestAgregar()
        {
            Rol rol = new Rol();
            rol._nombreRol = nombreRol;
            //Caso de exito
            int resultadoAgregar = daoRol.Agregar(rol);
            Assert.AreEqual(resultadoAgregar, 1);
            //Caso de fallo
            Assert.Throws<ReservaExceptionM13>(() => daoRol.Agregar(null));
            //Caso de fallo
            Assert.Throws<ReservaExceptionM13>(() => daoRol.Agregar(rol));
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

        public string TestGestionRolesRand()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

    }

}