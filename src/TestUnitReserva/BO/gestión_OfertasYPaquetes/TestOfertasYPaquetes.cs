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
using BOReserva.Controllers.PatronComando.M11;
using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M11;
using System.Web.Mvc;
using BOReserva.Models.gestion_ofertas;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestOfertasYPaquetes
    {
        private Oferta mockOfertaInt;
        private Oferta mockOfertaString;
        private List<String> mockListaPaquetes;
        private List<Paquete> mockListaPaquetesP;
        private List<CPaquete> mockListaPaquetesCP;
        private Paquete mockPaquete;
        DAOOferta daoOferta;
        IDAO prueba;
        CModificarOferta mockCModificarOferta;
        int idPruebas;

        /// <summary>
        /// Metodo que se ejecuta antes que se ejecute cada prueba
        /// Esta encargado de instanciar el manejadorSQL
        /// </summary>
        [SetUp]
        public void Before()
        {
            mockOfertaInt = new Oferta(25, "Oferta de Verano", 30, new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                    new DateTime(2008, 4, 9, 16, 5, 7, 123), true);
            mockOfertaString = new Oferta("25", "Oferta de Verano", 30, new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                    new DateTime(2008, 4, 9, 16, 5, 7, 123), true);
            mockListaPaquetes = new List<String>();
            mockListaPaquetesP = new List<Paquete>();
            mockListaPaquetesCP = new List<CPaquete>();            
            daoOferta = new DAOOferta();
            idPruebas = 25;

        }
        /// <summary>
        /// Método que se ejecuta cada vez que termina de correr una prueba;
        /// Se encanga de limpiar las variables utilizadas en la prueba
        /// </summary>
        [TearDown]
        public void After()
        {

            mockOfertaInt = null;
            mockOfertaString = null;
            daoOferta = null;

           
            mockListaPaquetes = null;
            mockListaPaquetesP = null;
            mockListaPaquetesCP = null;
            daoOferta = null;
        }

        /// <summary>
        /// Método para probar la inserción de la oferta en la
        /// Base de Datos.
        /// Prueba que no se haya pasado una entidad nula.
        /// </summary>
        [Test]
        public void M11_DaoOfertaInsertarOferta()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoOferta.Agregar(mockOfertaInt);
            Assert.AreEqual(resultadoAgregar, 1);
            //Probando caso de fallo
            int resultadoAgregarIncorrecto = daoOferta.Agregar(null);
            Assert.AreEqual(resultadoAgregarIncorrecto, 0);
        }

        /// <summary>
        /// Método para probar la inserción de la oferta en la
        /// Base de Datos.
        /// Prueba que no se haya pasado una entidad nula.
        /// </summary>
        [Test]
        public void Modificar()
        {
             //Probando caso de exito de la prueba
            Entidad resultadoModificar = daoOferta.Modificar(mockOfertaInt);
            Assert.AreEqual(resultadoModificar, 1);
            //Probando caso de fallo
            int resultadoModificarIncorrecto = daoOferta.Agregar(null);
            Assert.AreEqual(resultadoModificarIncorrecto, 0);
        }

        /// <summary>
        /// Prueba que no se haya enviado una oferta nula
        /// a Modificar en la BAse de Datos.
        /// </summary>
        [Test]
        public void M11_DaoOfertaModificarOferta()
        {
            Entidad modificar = daoOferta.Modificar(mockOfertaInt);
            Assert.AreEqual(modificar, mockOfertaInt);
            Entidad resultadoincorrecto = daoOferta.Modificar(null);
            Assert.AreEqual(resultadoincorrecto, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void M11_DaoDisponibilidadOferta()
        {
        }

        /// <summary>
        /// Prueba todos los cronstructores de la clase
        /// Dominio Oferta.
        /// </summary>
        [Test]
        public void DomainOferta()
        {

            Oferta prueba = new Oferta(25, "Oferta de Verano", 30, new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                    new DateTime(2008, 3, 9, 16, 5, 7, 123), true);
            Oferta prueba1 = new Oferta("25", "Oferta de Verano", 30, new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                    new DateTime(2008, 4, 9, 16, 5, 7, 123), true);
            Oferta prueba2 = new Oferta("Oferta de Verano", 30, new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                    new DateTime(2008, 4, 9, 16, 5, 7, 123), true);
            Oferta prueba3 = new Oferta(25, "Oferta de Verano", mockListaPaquetes, 30, 
                                        new DateTime(2008, 3, 9, 16, 5, 7, 123), 
                                        new DateTime(2008, 4, 9, 16, 5, 7, 123), true);
            Oferta prueba4 = new Oferta("25", "Oferta de Verano", mockListaPaquetes, 30, 
                                        new DateTime(2008, 3, 9, 16, 5, 7, 123),
                                        new DateTime(2008, 4, 9, 16, 5, 7, 123), true);

            Assert.AreEqual(prueba._nombreOferta, "Prueba Oferta");
            Assert.AreEqual(prueba._nombreOferta, "Prueba Oferta 1");
            Assert.AreEqual(prueba._nombreOferta, "Prueba Oferta 2");
            Assert.AreEqual(prueba._nombreOferta, "Prueba Oferta 3");
            Assert.AreEqual(prueba._nombreOferta, "Prueba Oferta 4");
        }

        /// <summary>
        /// Prueba el constructor de la clase
        /// CagregarOferta
        /// </summary>
        [Test]
        public void CAgregarOferta()
        {
            CAgregarOferta prueba = new CAgregarOferta();
            prueba._idOferta = 3;
            prueba._nombreOferta = "Prueba Unitaria";
            prueba._porcentajeOferta = 25;
            prueba._fechaIniOferta = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            prueba._fechaFinOferta = new DateTime(2008, 4, 9, 16, 5, 7, 123);
            prueba._estadoOferta = true;
        }

        /// <summary>
        /// Prueba la construcción de la clase CGestionOfertas_CrearOferta
        /// </summary>
   /*     [Test]
        public void CAgregarPaquete()
        {
            CAgregarPaquete prueba = new CAgregarPaquete();
            prueba._canthabitaciones = 4;
            prueba._ciudad = "Caracas";
            prueba._direccion = "Prueba";
            prueba._email = "email@email.com";
            prueba._estrellas = 5;
            prueba._id = 150;

            //prueba._listaciudades.Add
            //prueba._listapaises;
            prueba._nombre = "prueba";
            prueba._paginaweb = "www.prueba.com";
            prueba._pais = "Venezuela";
            prueba._puntuacion = 4;
        }*/

        /// <summary>
        /// Prueba la creación del la clase CModificar-oferta
        /// een el Modelo.
        /// </summary>
        [Test]
        public void CModificarOferta()
        {
            CModificarOferta prueba = new CModificarOferta();
            prueba._idOferta = 3;
            prueba._nombreOferta = "Prueba Unitaria";
            prueba._porcentajeOferta = 25;
            prueba._fechaIniOferta = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            prueba._fechaFinOferta = new DateTime(2008, 4, 9, 16, 5, 7, 123);
            prueba._estadoOferta = "Activa";
            prueba._listaPaquetes = mockListaPaquetesCP;
            prueba._nombrePaquete = "Paquete Familiar";
        }

        /// <summary>
        /// Prueba la construcción de la clase COferta
        /// de la capa modelo.
        /// </summary>
        [Test]
        public void COferta()
        {
            COferta prueba = new COferta();
            prueba._idOferta = 3;
            prueba._nombreOferta = "Prueba Unitaria";
            prueba._porcentajeOferta = 25;
            prueba._fechaIniOferta = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            prueba._fechaFinOferta = new DateTime(2008, 4, 9, 16, 5, 7, 123);
            prueba._estadoOferta = true;
            prueba._nombrePaquete = "Paquete Familiar";
        }
        /// <summary>
        /// Prueba la construcción de la clase CVisualizarOferta
        /// de la capa modelo.
        /// </summary>
        [Test]
        public void CVisualizarOferta()
        {
            CVisualizarOferta prueba = new CVisualizarOferta();
            prueba._idOferta = "3";
            prueba._nombreOferta = "Prueba Unitaria";
            prueba._porcentajeOferta = 25;
            prueba._fechaIniOferta = "2008-03-20";
            prueba._fechaFinOferta = "2008-04-20";
            prueba._estadoOferta = "Activa";
            prueba._nombrePaquete = "Paquete Familiar";
        }

        /// <summary>
        /// Prueba la construcción de la clase CConsultar
        /// de la capa modelo.
        /// </summary>
        [Test]
        public void CConsultar()
        {
            CConsultar prueba = new CConsultar();
            prueba._id = 3;
            prueba._nombre= "Prueba Unitaria";
            prueba._codigoVuelo = "A7232C";
            prueba._nombreSalida = "Caracas";
            prueba._nombreLlegada = "Roma";
        }

        //controller/patron comando/M11


        /// <summary>
        /// Prueba la construcción de la clase M11_COAgregarOferta
        /// de la capa modelo.
        /// </summary>
        [Test]
        public void M11_COAgregarOferta()
        {
            M11_COAgregarOferta prueba = new M11_COAgregarOferta(mockOfertaInt);
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_COAgregarPaquete
        /// de la capa modelo.
        /// </summary>
        public void M11_COAgregarPaquete()
        {
            M11_COAgregarPaquete prueba = new M11_COAgregarPaquete(mockPaquete);
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_COConsultarOferta
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_COCOnsultarOferta()
        {
            M11_COConsultarOferta prueba = new M11_COConsultarOferta(10);
            Entidad oferta = prueba.ejecutar();
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_CODeshabilitarPaquete
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_CODeshabilitarPaquete()
        {
            M11_CODeshabilitarPaquete prueba = new M11_CODeshabilitarPaquete(mockPaquete, 1);
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_CODeshabilitarOferta
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_CODeshabilitarOferta()
        {
            M11_CODeshabilitarOferta prueba = new M11_CODeshabilitarOferta(mockOfertaInt, 1);
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_COModificarOferta
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_COModificarOferta()
        {
            M11_COModificarOferta prueba = new M11_COModificarOferta(mockOfertaInt, 25);
            String res = prueba.ejecutar();
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_COModificarPaquete
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_COModificarPaquete()
        {
            M11_COModificarOferta prueba = new M11_COModificarOferta(mockOfertaInt, 25);
            String res = prueba.ejecutar();
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_VisualizarOfertas
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_C0VisualizarOfertas()
        {
            M11_COVisualizarOfertas prueba = new M11_COVisualizarOfertas();
            List<Entidad> mapOfertas = prueba.ejecutar();
        }

        /// <summary>
        /// Prueba la construcción de la clase M11_VisualizarPaquetes
        /// del patrón Comando.
        /// </summary>
        [Test]
        public void M11_C0VisualizarPaquetes()
        {
            M11_COVisualizarPaquetes prueba = new M11_COVisualizarPaquetes();
            List<Entidad> mapOfertas = prueba.ejecutar();
        }
        //controller 

  /*      [Test]
        public void M09_VisualizarHoteles()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();

            ActionResult probar = prueba.M09_VisualizarHoteles();
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        [Test]
        public void M09_DetalleHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            ActionResult probar = prueba.M09_DetalleHotel(15);
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }

        */

        /// <summary>
        /// Prueba el Método modifyOferta de la clase
        /// gestion_ofertasController
        /// </summary>
        [Test]
        public void modifyOferta()
        {
            gestion_ofertasController pruebaController = new gestion_ofertasController();
            CModificarOferta prueba = new CModificarOferta();
            prueba._idOferta = 3;
            prueba._nombreOferta = "Prueba Unitaria";
            prueba._porcentajeOferta = 25;
            prueba._fechaIniOferta = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            prueba._fechaFinOferta = new DateTime(2008, 4, 9, 16, 5, 7, 123);
            prueba._estadoOferta = "Activa";
            prueba._listaPaquetes = mockListaPaquetesCP;
            prueba._nombrePaquete = "Paquete Familiar";
            JsonResult probar = pruebaController.modifyOferta(prueba);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        } 
/*
        [Test]
        public void M09_DaoHotelConsultarTodos()
        {
            Dictionary<int, Entidad> hoteles = daoHotel.ConsultarTodos();
            Assert.NotNull(hoteles);
            Hotel e = (Hotel)hoteles[99];
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
