using BOReserva.Servicio;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.Models.gestion_seguridad_ingreso;
using BOReserva.Models.gestion_usuarios;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System.Data.SqlClient;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.M01;
using BOReserva.Controllers.PatronComando;
using BOReserva.Excepciones;

namespace TestUnitReserva.BO.gestion_seguridad_ingreso
{
    [TestFixture]
    class M01_TestLogin
    {
        Cgestion_seguridad_ingreso modelo;
        Usuario usuarioAConsultar;
        
        [SetUp]
        public void TestSetUp()
        {
             modelo = new Cgestion_seguridad_ingreso("prueba@reserva.com",
                "12345", "pruebaNombre", "pruebaApellido", "activo");
            usuarioAConsultar = FabricaEntidad.crearUsuario("the.wise.mage@gmail.com");
        }

        #region Pruebas Fábrica
        [Test]
        public void M01_FabricaCrearUsuario()
        {
            var usuarioNuevo = FabricaEntidad.crearUsuario();
            Assert.IsInstanceOf<Usuario>(usuarioNuevo);
        }

        [Test]
        public void M01_FabricaCrearDAOLogin()
        {
            DAOLogin dao = (DAOLogin)FabricaDAO.instanciarDaoLogin();
            Assert.IsInstanceOf<DAOLogin>(dao);
        }

        [Test]
        public void M01_FabricaCrearComando()
        {
            Command<Entidad> comandoConsultarUsuario = FabricaComando.M01ConsultarUsuario(usuarioAConsultar);
            Command<Boolean> comandoBloquearUsuario = FabricaComando.M01BloquearUsuario(usuarioAConsultar);
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<Boolean> comandoIncrementarIntentos = FabricaComando.M01IncrementarIntentos(usuarioAConsultar);
            Command<Boolean> comandoInsertarLogin = FabricaComando.M01InsertarLogin(usuarioAConsultar);
            Command<Boolean> comandoEliminarLogin = FabricaComando.M01EliminarLogin(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);

            Assert.IsInstanceOf<Command<Entidad>>(comandoConsultarUsuario);
            Assert.IsInstanceOf<Command<Boolean>>(comandoBloquearUsuario);
            Assert.IsInstanceOf<Command<Boolean>>(comandoResetearIntentos);
            Assert.IsInstanceOf<Command<Boolean>>(comandoIncrementarIntentos);
            Assert.IsInstanceOf<Command<Boolean>>(comandoInsertarLogin);
            Assert.IsInstanceOf<Command<Boolean>>(comandoEliminarLogin);
            Assert.IsInstanceOf<Command<int>>(comandoNumeroIntentos);
        }

        #endregion

        #region Pruebas Modelo

        /// <summary>
        /// Dado la información de login, verificar que se retorne un objeto de estado de sesión completo.
        /// </summary>
        [Test]
        public void M01_ModeloVerificarUsuario()
        {
            var prueba = modelo.verificarUsuario("the.wise.mage@gmail.com", "reserva321");
            Assert.IsNotNull(prueba);
        }

        /// <summary>
        /// Dado un inicio de sesión válido, verificar si un usuario está activo o no.
        /// </summary>
        [Test]
        public void M01_ModeloVerificacionEstatus()
        {
            Command<String> comandoResetUsuario = FabricaComando.crearM12StatusUsuario(usuarioAConsultar, "Activo");
            comandoResetUsuario.ejecutar();
            var prueba = modelo.verificarUsuario("the.wise.mage@gmail.com", "reserva321");
            Assert.IsTrue(prueba.EstaActivo());
        }

        /// <summary>
        /// Valida el chequeo de intentos de contraseña en modelo
        /// </summary>
        [Test]
        public void M01_ModeloVerificarIntentos()
        {
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);
            Boolean resultado = (Boolean)comandoResetearIntentos.ejecutar();
            int resultado2 = (int)comandoNumeroIntentos.ejecutar();
            var prueba = modelo.verificarUsuario("the.wise.mage@gmail.com", "reserva321");
            Assert.IsTrue(prueba.VerificarIntentos());
        }

        #endregion

        #region Pruebas Comandos

        /// <summary>
        /// Se realiza una consulta a la BD del usuario dado por el correo.
        /// </summary>
        [Test]
        public void M01_PruebaConsultarUsuario()
        {
            Command<Entidad> comandoConsultarUsuario = FabricaComando.M01ConsultarUsuario(usuarioAConsultar);
            Usuario resultado = (Usuario)comandoConsultarUsuario.ejecutar();
            Assert.AreEqual("the.wise.mage@gmail.com", resultado.correo);
        }

        /// <summary>
        /// Se resetean el numero de intentos de inicio de sesión, luego se procede a incrementarlos en 1 y
        /// a validad el resultado.
        /// </summary>
        [Test]
        public void M01_PruebaIncrementarYNumeroIntentos()
        {
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<Boolean> comandoIncrementarIntentos = FabricaComando.M01IncrementarIntentos(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);
            comandoResetearIntentos.ejecutar();
            Boolean resultado = (Boolean)comandoIncrementarIntentos.ejecutar();
            int resultado2 = (int)comandoNumeroIntentos.ejecutar();
            Assert.AreEqual(true, resultado);
            Assert.AreEqual(1, resultado2);
        }

        /// <summary>
        /// Se resetean el numero de intentos y luego se verifican los resultados.
        /// </summary>
        [Test]
        public void M01_PruebaResetearIntentos()
        {
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);
            Boolean resultado = (Boolean)comandoResetearIntentos.ejecutar();
            int resultado2 = (int)comandoNumeroIntentos.ejecutar();
            Assert.IsTrue(resultado);
            Assert.AreEqual(0, resultado2);
        }

        /// <summary>
        /// Se elimina el login de un usuario existente, para luego insertarse.
        /// </summary>
        [Test]
        public void M01_PruebaInsertarLogin()
        {
            Command<Boolean> comandoEliminarLogin = FabricaComando.M01EliminarLogin(usuarioAConsultar);
            Command<Boolean> comandoInsertarLogin = FabricaComando.M01InsertarLogin(usuarioAConsultar);
            comandoEliminarLogin.ejecutar();
            Boolean resultado = (Boolean)comandoInsertarLogin.ejecutar();
            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Se valida el comportamiento adecuado si se intentase crear un login para un usuario
        /// existente.
        /// </summary>
        [Test]
        public void M01_PruebaInsertarLoginYaExistente()
        {
            Command<Boolean> comandoEliminarLogin = FabricaComando.M01EliminarLogin(usuarioAConsultar);
            Command<Boolean> comandoInsertarLogin = FabricaComando.M01InsertarLogin(usuarioAConsultar);
            comandoEliminarLogin.ejecutar();
            comandoInsertarLogin.ejecutar();
            Boolean resultado = (Boolean)comandoInsertarLogin.ejecutar();
            Assert.IsFalse(resultado);
        }

        /// <summary>
        /// Se elimina el login de un usuario existente y se valida el comportamiento correcto.
        /// </summary>
        [Test]
        public void M01_PruebaEliminarLogin()
        {
            Command<Boolean> comandoEliminarLogin = FabricaComando.M01EliminarLogin(usuarioAConsultar);
            Command<Boolean> comandoInsertarLogin = FabricaComando.M01InsertarLogin(usuarioAConsultar);
            comandoInsertarLogin.ejecutar();
            Boolean resultado = (Boolean)comandoEliminarLogin.ejecutar();
            Assert.IsTrue(resultado);
        }

        #endregion

        #region Pruebas Excepciones

        /// <summary>
        /// Se valida que se esté tratando un usuario inexistente con una excepción personalizada.
        /// </summary>
        [Test]
        public void M01_PruebaUsuarioInexistente()
        {
            Usuario prueba = new Usuario();
            Command<Entidad> comandoConsultarUsuario = FabricaComando.M01ConsultarUsuario(prueba);
            Assert.That(() => comandoConsultarUsuario.ejecutar(), Throws.TypeOf<ExceptionReserva>());
        }

        /// <summary>
        /// Se simula la acción del inicio de sesión con un nombre de usuario y contraseña inválidos.
        /// </summary>
        [Test]
        public void M01_LoginInvalido()
        {
            Assert.That(() => modelo.verificarUsuario("usuario@noexiste.com", "1234"), 
                Throws.TypeOf<Cvalidar_usuario_Exception>());
        }
        #endregion

        [TearDown]
        public void TestTearDown()
        {
            modelo = null;
            usuarioAConsultar = null;
        }

    }
}
