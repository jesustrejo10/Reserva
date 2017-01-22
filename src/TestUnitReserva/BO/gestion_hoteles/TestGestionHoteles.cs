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

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestGestionHoteles
    {
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Hotel mockHotel;
        DAOHotel daoHotel;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockPais = new Pais(11, "Venezuela");
            mockCiudad = new Ciudad(12, "Caracas", mockPais);
            mockHotel = new Hotel("HOtel desde preuba unit3", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            daoHotel = new DAOHotel();
             
        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {
            mockPais = null;
            mockCiudad = null;
            mockHotel = null;
            daoHotel = null;
        }




        [Test]
        public void M09_DaoHotelInsertarHotel()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoHotel.Agregar(mockHotel);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoHotel.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        [Test]
        public void M09_DaoHotelConsultarTodos() {
            Dictionary<int,Entidad> hoteles = daoHotel.ConsultarTodos();
            Assert.NotNull(hoteles);
            Hotel e = (Hotel) hoteles[99];
            Assert.AreEqual(e._nombre, "hotelDePruebasUnitarias");
        }

        [Test]
        public void M09_ComandoConsultarTodos()
        {
            M09_COVisualizarHoteles comando = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> hoteles = comando.ejecutar();
            Assert.NotNull(hoteles);
            Hotel e = (Hotel)hoteles[99];
            Assert.AreEqual(e._nombre, "hotelDePruebasUnitarias");
        }
        [Test]
        public void M09_DAOHAbitacionAgregar()
        {
            Entidad h1 = FabricaEntidad.InstanciarHabitacion(600, 99);
            Entidad h2 = FabricaEntidad.InstanciarHabitacion(100, 99);
            List<Entidad> habitaciones = new List<Entidad>();
            habitaciones.Add(h1);
            habitaciones.Add(h2);
            //sequenceHabitacion
         //   IDAOHabitacion dao = FabricaDAO.instanciarDaoHabitacion();

        }

        /* 
controller

        IM09_COObtenerPaises
        M09_COAgregarHabitaciones
        M09_COAgregarHotel
        M09_CocontultarHotel
        M09_COdisponibilidadHotel
        M09_COEliminarHotel
        M09_COModificarHotel
        M09_COObtenerCiudad
        M09_COObtenerPaises

dataAccess
	DataAccessObject
		M09 
			DAOHbitacion
			DaoHotel
	Domain
			Hotel
Model
	Gestion_hoteles
		CAgregarHotel
		CGestionHoteles_CrearHotel
		CGestionHoteles_EditarHotel
		CGestionHoteles_SelectCiudad
		CGestionHoteles_SelectEstrellasModel
		CGestionHoteles_SelectPaisModel
		Chotel
		CmodificarHotel
		CverHotel
Servicio
	CManejadorSQL_Hoteles
Views 
	Gestion_Hoteles
	M09_AgregarHotel
	M09_DetalleHotel
	M09_GestionHoteles_Crear
	M09_GestionHoteles_desactivar
	M09_GestionHoteles_ModificarHotel
	M09_GestionHoteles_Visu
         * */


    }
}