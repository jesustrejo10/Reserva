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


        //[Test]
        //public void ExcepcionSQL()
        //{
        //    Assert.Throws<SqlException>(() => bd.UsuarioEnBD(null));
        //}

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

        #region Pruebas DAO



        #endregion

        #region Pruebas Comandos

        [Test]
        public void M01_PruebaConsultarUsuario()
        {
            Command<Entidad> comandoConsultarUsuario = FabricaComando.M01ConsultarUsuario(usuarioAConsultar);
            Usuario resultado = (Usuario)comandoConsultarUsuario.ejecutar();
            Assert.AreEqual("the.wise.mage@gmail.com", resultado.correo);
        }

        [Test]
        public void M01_PruebaIncrementarIntentos()
        {
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<Boolean> comandoIncrementarIntentos = FabricaComando.M01IncrementarIntentos(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);
            comandoResetearIntentos.ejecutar();
            Boolean resultado = (Boolean)comandoIncrementarIntentos.ejecutar();
            int resultado2 = (int)comandoNumeroIntentos.ejecutar();
            Assert.AreEqual(1, resultado2);
        }

        [Test]
        public void M01_PruebaResetearIntentos()
        {
            Command<Boolean> comandoResetearIntentos = FabricaComando.M01ResetearIntentos(usuarioAConsultar);
            Command<int> comandoNumeroIntentos = FabricaComando.M01NumeroIntentos(usuarioAConsultar);
            Boolean resultado = (Boolean)comandoResetearIntentos.ejecutar();
            int resultado2 = (int)comandoNumeroIntentos.ejecutar();
            Assert.AreEqual(true, resultado);
            Assert.AreEqual(0, resultado2);
        }

        #endregion

        ////Test de que no hubieron problemas en conectarse a la bd
        ////Querys que retornen null no significan que no retornan true
        ////El true solo significa que no hubo probelmas en el query
        //[Test]
        //public void PruebaUsuarioEnBD()
        //{
        //    var usuario = bd.UsuarioEnBD("drbr@reserva.com");
        //    Assert.IsInstanceOf(typeof(Cgestion_seguridad_ingreso), usuario);
        //    Assert.IsNotNull(usuario.correoCampoTexto);
        //    Assert.That(usuario.correoCampoTexto, Is.EqualTo("drbr@reserva.com"));

        //}

        //[Test]
        //public void PruebaResetearIntentos()
        //{    
        //    Assert.IsTrue(bd.ResetearIntentos("drbr@reserva.com"));    
        //}

        //[Test]       
        //public void PruebaIncrementarIntentos()
        //{
        //    Assert.IsTrue(bd.IncrementarIntentos("drbr@reserva.com"));            
        //}

        //[Test]
        //public void PruebaBloqueoUsuario()
        //{

        //    Assert.IsTrue(bd.BloquearUsuario("drbr@reserva.com"));
        //}

        //[Test]
        //public void PruebaInsertarLogin()
        //{
        //    Boolean insertar = bd.InsertarLogin("prueba@reserva.com");
        //    if (!insertar)
        //    {
        //        bd.EliminarLogin("prueba@reserva.com");
        //        Assert.IsTrue(bd.InsertarLogin("prueba@reserva.com"));
        //    }
        //    else
        //    {
        //        Assert.IsTrue(insertar);
        //    }

        //}



        //[Test]
        //public void PruebaNumeroIntentos()
        //{
        //    bd.ResetearIntentos("drbr@reserva.com");
        //    Assert.AreEqual(bd.NumeroIntentos("drbr@reserva.com"),0);
        //}
        ////Fin pruebas SQL

        ////Pruebas de modelo

        //[Test]
        //public void PruebaTipoModelo()
        //{

        //    Assert.IsInstanceOf<Cgestion_seguridad_ingreso>(modelo);
        //    Assert.IsNotNull(modelo);

        //}

        //[Test]
        //public void PruebaActivo()
        //{

        //    Assert.IsTrue(modelo.EstaActivo());
        //    Assert.IsNotNull(modelo);
        //}


        ////Fin de pruebas de modelo

        //[TearDown]
        //public void TestTearDown()
        //{
        //    bd = null;
        //    modelo = null;
        //}

    }
}
