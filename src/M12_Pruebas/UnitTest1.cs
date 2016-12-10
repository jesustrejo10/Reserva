using BOReserva.Models.gestion_usuarios;
using NUnit.Framework;
using System.Collections.Generic;

namespace M12_Pruebas
{
    [TestFixture]
    public class UnitTest1
    {
        #region Atributos

        public CUsuario elUsuario;
        List<ListarUsuario> lista;
        PersistenciaUsuario prueba;
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
            elUsuario = new CUsuario("nombre","apellido","contraseña456","correo@gmail.com","activo", 1);
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
            lista= prueba.ListaUsuarios();
            Assert.IsNotNull(lista);
        }
        [Test]
        public void TestModificar()
        {
            bool primero = prueba.AgregarUsuario(elUsuario);
            CUsuario elUsuario2 = new CUsuario("hola", "cambio", "1234678tghfhf", "prueba@gmail.com", "activo", 1);
            bool segundo = prueba.ModificarUsuario(elUsuario2,5);
            Assert.IsTrue(segundo);
        }
        [Test]
        public void TestAgregar()
        {
            revision = prueba.AgregarUsuario(elUsuario);
            Assert.IsTrue(revision);
        }
        [Test]
        public void TestBorrar()
        {
            bool primero = prueba.AgregarUsuario(elUsuario);
            bool segundo = prueba.eliminarUsuario(5);
            Assert.IsTrue(segundo);
        }
        [Test]
        public void TestConsultar()
        {
            elUsuario = prueba.consultarUsuario(5);
            Assert.IsNotNull(elUsuario);
        }
        #endregion
    }
}