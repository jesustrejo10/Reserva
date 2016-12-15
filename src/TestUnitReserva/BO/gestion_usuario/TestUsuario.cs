using BOReserva.Models.gestion_usuarios;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace TestUnitReserva.BO.gestion_usuarios
{
    [TestFixture]
    public class TestUsuario
    {
        #region Atributos

        public CUsuario elUsuario;
        List<ListarUsuario> lista;
        PersistenciaUsuario prueba;
        int id;
        ListarUsuario liastarusu;
        bool revision;

        #endregion

        #region SetUp And TearDown
        /// <summary>
        /// SetUp para las pruebas de DAOUsuario
        /// </summary>
        [SetUp]
        public void init()
        {
            // BOReserva.Models.gestion_usuarios.
            elUsuario = new CUsuario("nombre", "apellido", "contraseña456", "correosssssss@gmail.com", "activo", 1);
            prueba = new PersistenciaUsuario();
            liastarusu = new ListarUsuario();
        }

        /// <summary>
        /// TearDown para las pruebas de DAOUsuario
        /// </summary>
        [TearDown]
        public void clean()
        {
            elUsuario = null;
            prueba = null;
            lista = null;
        }
        #endregion
        #region Test
        [Test]
        public void TestListar()
        {
            lista = prueba.ListaUsuarios();
            Assert.IsNotNull(lista);
        }

        [Test]
        public void TestModificar()
        {
            bool primero = prueba.AgregarUsuario(elUsuario);
            CUsuario elUsuario2 = new CUsuario("hola", "cambio", "1234678tghfhf", "correosssssss@gmail.com", "activo", 1);
            id = prueba.ultimoUsuarioID();
            bool segundo = prueba.ModificarUsuario(elUsuario2, id);
            CUsuario elUsuario3 = prueba.consultarUsuario(id);
            Assert.AreEqual(elUsuario2.nombreUsuario, elUsuario3.nombreUsuario);
            Assert.AreEqual(elUsuario2.correoUsuario, elUsuario3.correoUsuario);
            Assert.AreEqual(elUsuario2.apellidoUsuario, elUsuario3.apellidoUsuario);
            Assert.AreEqual(elUsuario2.activoUsuario, elUsuario3.activoUsuario);
            revision = prueba.eliminarUsuario(id);
        }

        [Test]
        public void TestAgregar()
        {
            int numero1 = prueba.contarUsuario();
            revision = prueba.AgregarUsuario(elUsuario);
            int numero2 = prueba.contarUsuario();
            Assert.AreEqual(numero1+1,numero2);
            id = prueba.ultimoUsuarioID();
            revision = prueba.eliminarUsuario(id);
        }
        [Test]
        public void TestBorrar()
        {
            int numero1 = prueba.contarUsuario();
            bool primero = prueba.AgregarUsuario(elUsuario);
            id = prueba.ultimoUsuarioID();
            bool segundo = prueba.eliminarUsuario(id);
            int numero2 = prueba.contarUsuario();
            Assert.AreEqual(numero1,numero2);
        }
        [Test]
        public void TestConsultar()
        {
            revision = prueba.AgregarUsuario(elUsuario);
            id = prueba.ultimoUsuarioID();
            elUsuario = prueba.consultarUsuario(id);
            Assert.IsNotNull(elUsuario);
            Assert.IsNotNull(elUsuario.apellidoUsuario);
            Assert.IsNotNull(elUsuario.correoUsuario);
            Assert.IsNotNull(elUsuario.nombreUsuario);
            revision = prueba.eliminarUsuario(id);
        }
        #endregion
    }
}
