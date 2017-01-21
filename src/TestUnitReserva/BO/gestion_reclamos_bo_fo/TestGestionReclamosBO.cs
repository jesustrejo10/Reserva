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
using BOReserva.DataAccess.DataAccessObject.M09;

namespace TestUnitReserva.BO.gestion_reclamos_bo_fo
{
    [TestFixture]
    class TestGestionReclamosBO
    {
        private Reclamo mockReclamo;
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Hotel mockHotel;
        DAOHotel daoHotel;
        IDAO daoReclamo;
        IDAOReclamo daoPersonalizado;

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
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockReclamo = null;
            mockPais = null;
            mockCiudad = null;
            mockHotel = null;
            daoHotel = null;
        }

        [Test]
        public void M16_DaoReclamoInsertarReclamo()
        {
           
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoReclamo.Agregar(mockReclamo);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            Assert.Throws<NullReferenceException>(() => daoReclamo.Agregar(null));
        }

        [Test]
        public void M16_DaoReclamoConsultarTodos() {
            Dictionary<int, Entidad> reclamos = daoReclamo.ConsultarTodos();
            Assert.NotNull(reclamos);
        }

        [Test]
        public void M16_DaoReclamoConsultarPorId()
        {
            Assert.NotNull(daoReclamo.Consultar(11));
        }


        [Test]
        public void M16_DaoReclamoModificar()
        {
            //prueba de que lo hace
            Assert.NotNull(daoReclamo.Modificar(mockReclamo));
            //prueba de que falla al pasarle un parametro invaliddo
            Assert.IsNull(daoReclamo.Modificar(null));
        }

        [Test]
        public void M16_DaoReclamoEliminarReclamo()
        {
            //HAY QUE CAMBIAR EL NUMERO DE ID QUE SE ELIMINA MANUALMENTE
            //Probando caso de exito de la prueba
            int resultadoEliminar = daoPersonalizado.Eliminar(25);
            Assert.AreEqual(resultadoEliminar, 1);
        }

        [Test]
        public void M16_DaoReclamoActualizarReclamo()
        {

            //Probando caso de exito de la prueba
            int resultadomodificar = daoPersonalizado.modificarEstado(11, 1);
            Assert.AreEqual(resultadomodificar, 1);
        }


    }
}