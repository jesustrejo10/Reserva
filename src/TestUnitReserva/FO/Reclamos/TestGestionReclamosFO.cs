using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.Models.Reclamos;
using System.Web.Mvc;
using FOReserva.Controllers;

namespace TestUnitReserva.FO.TestGestionReclamosFO
{
    /// <summary>
    /// Clase encargada de realizar las pruebas unitarios del modulo reclamos en FO
    /// </summary>
    [TestFixture]
    class TestGestionReclamosFO
    {
        private Reclamo mockReclamo;
      
        IDAO daoReclamo;
        IDAOReclamo daoPersonalizado;
        String tituloReclamo = "prueba";
        String detalleReclamo = "prueba";
        String fechaReclamo = "2017-01-21";
        FOReserva.Controllers.gestion_reclamosController controlador = new FOReserva.Controllers.gestion_reclamosController();
        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockReclamo = new Reclamo(1, "Reclamo mock", "detalle mock reclamo", "2017-01-21", 1, 73);
            daoReclamo = (DAOReclamo) FabricaDAO.instanciarDaoReclamo();
            daoPersonalizado = FabricaDAO.reclamoPersonalizado();
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
        /// Metodo que prueba que se pueda insertar un reclamo 
        /// </summary>
        [Test]
        public void M16_DaoReclamoInsertarReclamoFO()
        {
            mockReclamo._usuarioReclamo = 1;
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoReclamo.Agregar(mockReclamo);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            Assert.AreEqual(daoReclamo.Agregar(null), 3);
        }
        /// <summary>
        /// Metodo que prueba que se pueda consultar todos los reclamo de un usuario
        /// </summary>
        [Test]
        public void M16_DaoReclamoConsultar() {
            List<Reclamo> reclamos = daoPersonalizado.ConsultarReclamosPorUsuario(1);
            Assert.NotNull(reclamos);
        }
        /// <summary>
        /// Metodo que prueba que se pueda consultar un reclamo por id
        /// </summary>
        [Test]
        public void M16_DaoReclamoConsultarPorIdFO()
        {
            Assert.NotNull(daoReclamo.Consultar(53));
        }

        /// <summary>
        /// Metodo que prueba que se pueda modificar un reclamo
        /// </summary>
        [Test]
        public void M16_DaoReclamoModificarFO()
        {
            mockReclamo._idReclamo = 9;
            //prueba de que lo hace
            Assert.AreEqual(daoPersonalizado.ModificarReclamo(mockReclamo), 1);
            //prueba de que falla al pasarle un parametro invaliddo
            Assert.AreEqual(daoPersonalizado.ModificarReclamo(null), 3);
        }

        /// <summary>
        /// Metodo que prueba que se pueda eliminar un reclamo
        /// </summary>

        [Test]
        public void M16_DaoReclamoEliminarReclamoFO()
        {
            //HAY QUE CAMBIAR EL NUMERO DE ID QUE SE ELIMINA MANUALMENTE
            //Probando caso de exito de la prueba
            int resultadoEliminar = daoPersonalizado.EliminarReclamo(25);
            Assert.AreEqual(resultadoEliminar, 1);
        }


        #endregion
        #region Pruebas de la fabrica
        /// <summary>
        /// Metodo que prueba el funcionamiento de entidades y metodos
        /// </summary>
        [Test]
        public void M16_FabricasFO()
        {


            int estadoReclamo = 1;
            int usuario = 1;
            //constructor vacio
            Entidad prueba = FabricaEntidad.InstanciarReclamo();
            Assert.IsInstanceOf(typeof(Entidad),prueba);
           
            Assert.IsInstanceOf(typeof(Entidad), prueba);
            //constructor con asignandole una id
            prueba = FabricaEntidad.InstanciarReclamo(1, tituloReclamo, detalleReclamo, fechaReclamo, estadoReclamo, usuario);
            Assert.IsInstanceOf(typeof(Entidad), prueba);

            ////Parte de la fabrica de comandos
            Command<String> comando = FabricaComando.crearM16AgregarReclamo(prueba);
            Assert.NotNull(comando);
            Command<List<Reclamo>> comando2 = FabricaComando.consultarReclamosDeUsuario(1);
            Assert.NotNull(comando2);
            Command<Entidad> comando3 = FabricaComando.consultarReclamo(1);
            Assert.NotNull(comando3);
            Command<int> comando4 = FabricaComando.eliminarReclamo(1);
            Assert.NotNull(comando4);
            Command<int> comando5 = FabricaComando.modificarReclamo(mockReclamo);
            Assert.NotNull(comando5);



        }
        #endregion
        #region Pruebas del controlador
        /// <summary>
        /// Metodo que prueba el funcionamiento del controlador
        /// </summary>
        [Test]
        public void M16_PruebasControladorFO()
        {
            CAgregarReclamo model = new CAgregarReclamo();
            model._tituloReclamo = tituloReclamo;
            model._detalleReclamo = detalleReclamo;
            model._fechaReclamo = fechaReclamo;
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M16_AgregarReclamo());
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M16_ModificarReclamo(50));
            Assert.IsInstanceOf(typeof(JsonResult), controlador.guardarReclamo(model));
            Assert.IsInstanceOf(typeof(JsonResult), controlador.eliminarReclamo(1));
            Assert.IsInstanceOf(typeof(JsonResult), controlador.guardarModificacionReclamo(model._tituloReclamo,model._detalleReclamo,model._fechaReclamo,19));
        }
        #endregion
    }
}