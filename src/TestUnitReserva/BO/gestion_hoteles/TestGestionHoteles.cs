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
using BOReserva.Controllers.PatronComando.M09;
using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M09;
using System.Web.Mvc;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestGestionHoteles
    {
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Hotel mockHotel;
        private Hotel mockHotell;
        DAOHotel daoHotel;
        IDAO prueba;

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
            mockHotell = new Hotel(999,"HOtel desde pr", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
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

        //dataacces
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

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void M09_DaoHotelModificarHotel()
        {
            Entidad modificar = daoHotel.Modificar(mockHotel);
            Assert.AreEqual(modificar, mockHotel);
            Entidad resultadoincorrecto = daoHotel.Modificar(null);
            Assert.AreEqual(resultadoincorrecto, 0);

       
        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void M09_DaoHotelEliminar()
        {
            int resultadoAgregar = daoHotel.Agregar(mockHotell);
            int eliminar = daoHotel.Eliminar(999);
            Assert.AreEqual(eliminar, "1");


        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void M09_DaoContultaSimple()
        {
            int resultadoAgregar = daoHotel.Agregar(mockHotell);
            Entidad consulta = daoHotel.Consultar(999);
            Assert.AreEqual(consulta, mockHotell);
            daoHotel.Eliminar(999);
            Assert.NotNull(daoHotel.Agregar(null));

        }
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void M09_DaoDisponibilidadHotel()
        {
            
        }
        [Test]
        public void DomainHotel()
        {

            Hotel prueba = new Hotel("HOtel", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            Hotel prueba1 = new Hotel(1,"HOtel1", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            Hotel prueba2 = new Hotel("HOtel2", "hotel", "hotel", "hotel", 1, 1, mockCiudad,200);
            Hotel prueba3 = new Hotel(1,"HOtel3", "hotel", "hotel", "hotel", 1, 1, mockCiudad,0);
            Assert.AreEqual(prueba._nombre,"HOtel");
            Assert.AreEqual(prueba1._nombre, "HOtel1");
            Assert.AreEqual(prueba2._nombre, "HOtel2");
            Assert.AreEqual(prueba3._nombre, "HOtel3");
        }
        //model
        [Test]
        public void CAgregarHotel()
        {
            CAgregarHotel prueba = new CAgregarHotel();
            prueba._capacidadHabitacion = 3;
            prueba._clasificacion = 5;
            prueba._direccion= "prueba";
            prueba._email = "hola@gmail.com";
            prueba._nombre = "Cosita";
            prueba._paginaWeb = "www.hola.com";
            prueba._pais = "Venezuela";
           // prueba._paises;
            prueba._precioHabitacion = 200;
        }
        [Test]
        public void CGestionHoteles_CrearHotel()
        {
            CGestionHoteles_CrearHotel prueba = new CGestionHoteles_CrearHotel();
            prueba._canthabitaciones = 4;
            prueba._ciudad = "Caracas";
            prueba._direccion="Prueba";
            prueba._email = "email@email.com";
            prueba._estrellas = 5;
            prueba._id = 150;
       
            //prueba._listaciudades.Add
            //prueba._listapaises;
            prueba._nombre = "prueba";
            prueba._paginaweb = "www.prueba.com";
            prueba._pais = "Venezuela";
            prueba._puntuacion = 4;
        }
        [Test]
        public void CgestionHoteles_EditarHotel()
        {
            CGestionHoteles_EditarHotel prueba = new CGestionHoteles_EditarHotel();
            prueba._canthabitaciones = 4;
            prueba._ciudad = "Caracas";
            prueba._direccion = "Prueba";
            prueba._disponibilidad = 1;
            prueba._email = "email@email.com";
            prueba._estrellas = 5;
            prueba._id = 150;
            
            //prueba._listapaises.Add("Venezuela");
            prueba._nombre = "prueba";
            prueba._paginaweb = "www.prueba.com";
            prueba._pais = "Venezuela";
            prueba._puntuacion = 4;
            
        }
        [Test]
        public void CGestionHoteles_SelectCiudadModel()
        {
            CGestionHoteles_SelectCiudadModel prueba = new CGestionHoteles_SelectCiudadModel();
            
            
        }
        [Test]
        public void CGestionHoteles_SelectEstrellalsModel()
        {
            CGestionHoteles_SelectEstrellasModel prueba = new CGestionHoteles_SelectEstrellasModel();
            //prueba._Categories
            prueba._CategoryId =new int[10];
        }
        [Test]
        public void CGestionHoteles_SelectPaisModel()
        {
            CGestionHoteles_SelectPaisModel prueba = new CGestionHoteles_SelectPaisModel();
            //comprobar lista de paises 
           

        }
        [Test]
        public void CHotel()
        {
            CHotel prueba = new CHotel();
           //seguir 
        }
        [Test]
        public void CModificarHotel()
        {
            CModificarHotel pruena = new CModificarHotel();
            //seguir 
        }
        [Test]
        public void CVerHotel()
        {
            CVerHotel prueba = new CVerHotel();
            //seguir 
            
        }
         //controller/patron comando/M09

        [Test]
        public void IM09_COObtenerPaises()
        {
                
                
        }


        [Test]
        public void M09COAgregarHanitacion()
        {
                        
        }
        [Test]

        public void M09_AgregarHotel()
        {
            M09_COAgregarHotel prueba = new M09_COAgregarHotel(mockHotel);
           String  prueba1= prueba.ejecutar();
      
        }
        [Test]
        public void M09_COCOnsultarHotel()
        {
            M09_COConsultarHotel prueba = new M09_COConsultarHotel(10);
            Entidad hotel =prueba.ejecutar();
        }
        [Test]
        public void M09_CODisponibilidadHotel()
        {
            M09_CODisponibilidadHotel prueba = new M09_CODisponibilidadHotel(mockHotel,0);
            String test =  prueba.ejecutar();

        }
        [Test]
        public void M09_COEliminarHotel()
        {
            daoHotel.Agregar(mockHotell);
            M09_COEliminarHotel prueba = new M09_COEliminarHotel(mockHotell,999);
            String test =  prueba.ejecutar();

        
        }
        [Test]
        public void M09_COModificarHotel()
        { 
            daoHotel.Agregar(mockHotell);
            M09_COModificarHotel prueba = new M09_COModificarHotel(mockHotell, 999);
            String nombre =prueba.ejecutar();
            M09_COEliminarHotel prueba1 = new M09_COEliminarHotel(mockHotell, 999);
            prueba1.ejecutar();
        }
        [Test]
        public void M09_COObtenerpaises()
        {
            M09_COObtenerPaises prueba = new M09_COObtenerPaises();
            Dictionary<int, Entidad> prueb1 = prueba.ejecutar();

        }
        [Test]
        public void M09_C0VisualizarHoteles()
        {
            M09_COVisualizarHoteles prueba = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> mapHoteles = prueba.ejecutar();
        
        }
        //controller 

        [Test]
        public void M09_guardarHotel()
        {
            CAgregarHotel model = new BOReserva.Models.gestion_hoteles.CAgregarHotel();
            model._capacidadHabitacion = 4;
            model._clasificacion = 3;
            model._direccion = "ff";
            model._email = "holña@gmail.com";
            model._nombre = "daniel";
            model._paginaWeb = "www.google.com";
            model._pais = "Venezuela";
            //model._paises 
            model._precioHabitacion = 200;
            
        
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probarjsonresult =prueba.guardarHotel(model);
            Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
        }

        [Test]
        public void deleteHotel()
        {       daoHotel.Agregar(mockHotell);
                gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deleteHotel(999);
            Assert.IsInstanceOf(typeof(JsonResult),probar);
        }
        [Test]
        public void activateHotel()
        {
            daoHotel.Agregar(mockHotell);
            gestion_hotelesController prueba = new gestion_hotelesController();
           JsonResult probar= prueba.activateHotel(999);
           Assert.IsInstanceOf(typeof(JsonResult), probar);
           prueba.deleteHotel(999);

        }
        [Test]
        public void deactivateHotel()
        {
            daoHotel.Agregar(mockHotell);
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deactivateHotel(999);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
            prueba.deleteHotel(999);
        }
        [Test]
        public void pais()
        {
            // List<SelectListItem> pais()
        }
        [Test]
        public void listaciudades()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
           ActionResult probar = prueba.listaciudades("Venezuela");
           Assert.IsInstanceOf(typeof(ActionResult), probar);

        }

     
        [Test]
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

        [Test]
        public void M09_ModificarHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
           ActionResult probar = prueba.M09_ModificarHotel(10);
            Assert.IsInstanceOf(typeof(PartialViewResult),probar);

        
        }
        [Test]
        public void modificarHotel()
        {   CModificarHotel model = new CModificarHotel();
            model._capacidadHabitacion = 4;
            model._clasificacion = 3;
            model._direccion = "ff";
            model._email = "holña@gm.com";
            model._nombre = "daniel";
            model._paginaWeb = "www.google.com";
            model._pais = "Venezuela";
            //model._paises 
            model._ciudad="Caracas";
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.modificarHotel(model);
            Assert.IsInstanceOf(typeof(JsonResult),probar);
        }
        
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