using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.Models.gestion_usuarios;
using BOReserva.Servicio;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando.M12;
using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M12;
using System.Web.Mvc;



namespace TestUnitReserva.BO.gestion_usuarios
{
    /// <summary>
    /// Clase encargada de realizar las pruebas unitarios del modulo Usuarios de BO
    /// </summary>
    [TestFixture]
    public class TestUsuario
    {


        private Usuario mockUsuario;
        private Usuario mockUsuario2;
        private Rol mockRol;


        IDAO prueba;
        IDAO daoUsuario;

        BOReserva.Controllers.gestion_usuariosController controlador = new BOReserva.Controllers.gestion_usuariosController();


        /// <summary>
        /// Metodo que se ejecuta antes de ejecutar todas las pruebas 
        /// 
        /// </summary>
        [SetUp]
        public void Before()
        {
            DateTime fecha = new DateTime(2017, 06, 12, 11, 11, 11);


            mockRol = new Rol(1, "Administrador");
            mockUsuario = new Usuario("Ana", "Duran", "ana@reserva.com", "12345a", 1, fecha.Date, "Activo");
            //mockUsuario2 = new Usuario(999, "Ana", "Duran", "ana@reserva.com", "12345a", mockRol,null, "Activo");

            daoUsuario = new DAOUsuario();



        }


        /// <summary>
        /// Metodo que se ejecuta cada vez que se termina de correr una prueba, se
        /// encargar de limpiar las variables utilizadas
        /// </summary>
        [TearDown]
        public void After()
        {
            mockUsuario = null;
            mockUsuario2 = null;
            mockRol = null;
        }

        /*
        /// <summary>
        /// Metodo que prueba que se inserte un ususario a la BD
        /// </summary>
        [Test]
        public void M12_DaoUsuarioInsertarUsuario2()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoUsuario.Agregar(mockUsuario);
            Assert.AreEqual(resultadoAgregar, 1);

        }
        */

        /// <summary>
        /// Metodo que prueba que se modifique correctamente un usuario
        /// </summary>
        [Test]
        public void M12_DaoUsuarioModificar()
        {
            daoUsuario.Agregar(mockUsuario);
            M12_COModificarUsuario prueba = new M12_COModificarUsuario(mockUsuario, 156);
            string test = prueba.ejecutar();
        }

        /// <summary>
        /// Metodo que prueba que se elimine correctamente un usuario
        /// </summary>
        [Test]
        public void M12_DaoUsuarioEliminarUsuario()
        {
            daoUsuario.Agregar(mockUsuario);
            M12_COEliminarUsuario prueba = new M12_COEliminarUsuario(mockUsuario, 164);
            string test = prueba.ejecutar();
        }


        /// <summary>
        /// Metodo que prueba que se logre consultar todos los usuarios de la BD
        /// </summary>
        [Test]
        public void M12_DaoUsuarioConsultarTodos()
        {
            Dictionary<int, Entidad> usuario = daoUsuario.ConsultarTodos();
            Assert.NotNull(usuario);
        }


        /// <summary>
        /// Metodo que prueba que se cambia el estatus de un usuario a Activo
        /// </summary>
        [Test]
        public void M12_activateUsuario()
        {
            daoUsuario.Agregar(mockUsuario);
            gestion_usuariosController prueba = new gestion_usuariosController();
            JsonResult probar = prueba.activarUsuario(118, "Activo");
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }


        /// <summary>
        /// Metodo que prueba que se cambiar el estatus de un usuario a Inactivo
        /// </summary>
        [Test]
        public void M12_desactivateUsuario()
        {
            daoUsuario.Agregar(mockUsuario);
            gestion_usuariosController prueba = new gestion_usuariosController();
            JsonResult probar = prueba.activarUsuario(118, "Inactivo");
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }


        /// <summary>
        /// Metodo que prueba que el visualizar ususarios
        /// </summary>
        [Test]
        public void M12_VisualizarUsuario()
        {
            M12_COVisualizarUsuarios prueba = new M12_COVisualizarUsuarios();
            Dictionary<int, Entidad> mapUsuario = prueba.ejecutar();
        }


        /// <summary>
        /// Metodo que prueba que se inserta un usuario pasando por los patrones
        /// </summary>
        [Test]
        public void M12_guardarUsuario()
        {
            DateTime fecha = DateTime.Now;

            //Dictionary openWith = new Dictionary<int, Entidad>();
            CAgregarUsuario model = new BOReserva.Models.gestion_usuarios.CAgregarUsuario();
            model._nombre = "Maria";
            model._apellido = "Rodriguez";
            model._correo = "maria@reserva.com";
            model.contraseñaUsuario = ("12345a");
            model._activo = "activo";
            model._fechaCreacion = fecha.Date;



            gestion_usuariosController prueba = new gestion_usuariosController();
            JsonResult probarjsonresult = prueba.guardarUsuario(model);
            Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
        }

    }

}
