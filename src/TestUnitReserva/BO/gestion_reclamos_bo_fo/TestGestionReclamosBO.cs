using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Models.gestion_reclamos;
using System.Web.Mvc;
using BOReserva.Controllers;

namespace TestUnitReserva.BO.gestion_reclamos_bo_fo
{
    /// <summary>
    /// Clase encargada de realizar las pruebas unitarios del modulo reclamos en BO
    /// </summary>
    [TestFixture]
    class TestGestionReclamosBO
    {
       
        private Reclamo mockReclamo;
  
        IDAO daoReclamo;
        IDAOReclamo daoPersonalizado;
        String tituloReclamo = "prueba";
        String detalleReclamo = "prueba";
        String fechaReclamo = "2017-01-21";
        BOReserva.Controllers.gestion_reclamosController controlador = new BOReserva.Controllers.gestion_reclamosController();
        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockReclamo = new Reclamo(1, "Reclamo mock", "detalle mock reclamo", "2017-01-21", 1, 1);
            daoReclamo = FabricaDAO.instanciarDaoReclamo();
            daoPersonalizado = FabricaDAO.instanciarDaoReclamoPersonalizado();
            tituloReclamo = "prueba";
            detalleReclamo = "prueba";
            fechaReclamo = "2017-01-21";

        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockReclamo = null;
        }
        #region Pruebas del DAO
        /// <summary>
        /// Metodo que prueba que pueda insertar un reclamo
        /// </summary>
        [Test]
        public void M16_DaoReclamoInsertarReclamo()
        {
           
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoReclamo.Agregar(mockReclamo);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            Assert.Throws<NullReferenceException>(() => daoReclamo.Agregar(null));
        }
        /// <summary>
        /// Metodo que prueba que se puedan consultar todos los reclamos
        /// </summary>
        [Test]
        public void M16_DaoReclamoConsultarTodos() {
            Dictionary<int, Entidad> reclamos = daoReclamo.ConsultarTodos();
            Assert.NotNull(reclamos);
        }
        /// <summary>
        /// Metodo que prueba que se puedan consultar los reclamos por un id
        /// </summary>

        [Test]
        public void M16_DaoReclamoConsultarPorId()
        {
            Assert.NotNull(daoReclamo.Consultar(11));
        }

        /// <summary>
        /// Metodo que prueba que se puede modificar un reclamo
        /// </summary>
        [Test]
        public void M16_DaoReclamoModificar()
        {
            //prueba de que lo hace
            Assert.NotNull(daoReclamo.Modificar(mockReclamo));
            //prueba de que falla al pasarle un parametro invaliddo
            Assert.IsNull(daoReclamo.Modificar(null));
        }
        /// <summary>
        /// Metodo que prueba que se pueda eliminar un reclamo
        /// </summary>
        [Test]
        public void M16_DaoReclamoEliminarReclamo()
        {
            //HAY QUE CAMBIAR EL NUMERO DE ID QUE SE ELIMINA MANUALMENTE
            //Probando caso de exito de la prueba
            int resultadoEliminar = daoPersonalizado.Eliminar(25);
            Assert.AreEqual(resultadoEliminar, 1);
        }

        /// <summary>
        /// Metodo que prueba que se pueda cambiar el estado de un reclamo
        /// </summary>
        [Test]
        public void M16_DaoReclamoActualizarReclamo()
        {

            //Probando caso de exito de la prueba
            int resultadomodificar = daoPersonalizado.modificarEstado(11, 1);
            Assert.AreEqual(resultadomodificar, 1);
        }

        #endregion
        #region Pruebas de la fabrica
        /// <summary>
        /// Metodo que prueba el funcionamiento de entidades y metodos
        /// </summary>
        [Test]
        public void M16_Fabricas()
        {


            int estadoReclamo = 1;
            int usuario = 1;
            //constructor vacio
            Entidad prueba = FabricaEntidad.InstanciarReclamo();
            Assert.IsInstanceOf(typeof(Entidad),prueba);
            //constructor con parametros
            prueba = FabricaEntidad.InstanciarReclamo(tituloReclamo,detalleReclamo,fechaReclamo,estadoReclamo,usuario);
            Assert.IsInstanceOf(typeof(Entidad), prueba);
            //constructor con asignandole una id
            prueba = FabricaEntidad.InstanciarReclamo(1, tituloReclamo, detalleReclamo, fechaReclamo, estadoReclamo, usuario);
            Assert.IsInstanceOf(typeof(Entidad), prueba);

            ////Parte de la fabrica de comandos
            Command<String> comando = FabricaComando.crearM16AgregarReclamo(prueba);
            Assert.NotNull(comando);
            Command<Entidad> comando2 = FabricaComando.crearM16ConsultarUsuario(11);
            Assert.NotNull(comando2);
            Command<String> comando3 = FabricaComando.crearM16EliminarReclamo(11);
            Assert.NotNull(comando3);
            Command<String> comando4 = FabricaComando.crearM16ActualizarReclamo(11, 1);
            Assert.NotNull(comando4);
            Command<Dictionary<int, Entidad>> comando5 = FabricaComando.crearM16VisualizarReclamos();
            Assert.NotNull(comando5);



        }
        #endregion
        #region Pruebas del controlador
        /// <summary>
        /// Metodo que prueba el funcionamiento del controlador
        /// </summary>
        [Test]
        public void M16_PruebasControlador()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            model._tituloReclamo = tituloReclamo;
            model._detalleReclamo = detalleReclamo;
            model._fechaReclamo = fechaReclamo;
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M16_AgregarReclamo());
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M16_VisualizarReclamo());
            Assert.IsInstanceOf(typeof(JsonResult), controlador.actualizarReclamo(11,1));
        }
        #endregion
    }
}