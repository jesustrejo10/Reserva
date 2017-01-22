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
using BOReserva.Excepciones.M09;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestGestionHoteles
    {
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Hotel mockHotel;
        private Hotel mockHotell;

        private Hotel mockHotel2;
       // DAOHotel daoHotel;

        IDAOHotel daoHotel;

        

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

        /// <summary>
        /// Metedo caso de exitido de insertar hotel, Dao
        /// </summary>
        [Test]
        public void M09_DaoHotelInsertarHotel()
        {
            //Probando caso de exito de la prueba
            int resultadoAgregar = daoHotel.Agregar(mockHotel);
            Assert.AreEqual(resultadoAgregar, 1);

            
        }
        /// <summary>
        /// Metedo caso fallido de insertar hotel, Dao
        /// </summary>
        [Test]
        public void M09_DaoHotelInsertarHotelFallido()
        {
            Assert.Throws<ReservaExceptionM09>(() => daoHotel.Agregar(null));

        }

        /// <summary>
        /// Metodo caso modificar hotel,dao
        /// </summary>
        [Test]
        public void M09_DaoHotelModificarHotel()
        {
            mockHotel = new Hotel("HOtel desde preuba u", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            Entidad modificar = daoHotel.Modificar(mockHotel);
            Assert.AreEqual(modificar, mockHotel);
          
        }
        /// <summary>
        /// Metodo caso modificar hotel,dao,fallido
        /// </summary>
        [Test]
        public void M09_DaoHotelModificarHotelFallido()
        {
            Assert.Throws<ReservaExceptionM09>(() => daoHotel.Modificar(null));

        }
        /// <summary>
        /// Metodod caso eliminar hotel, dao
        /// </summary>
        [Test]
       public void M09_DaoHotelEliminar()
        {

            daoHotel.Agregar(mockHotell);
            String prueba1= daoHotel.eliminarHotel(999);
            Assert.AreEqual(prueba1,"1");            

            /*
>>>>>>> fc35b8d09d2d782b82e3c6aaccec715a86f7b23d
            int resultadoAgregar = daoHotel.Agregar(mockHotell);
            //int eliminar = pruebadao.;
            Assert.AreEqual(eliminar, "1");
            */

        }
        /// <summary>
        /// Metodo caso fallido, eliminar Hotel
        /// </summary>
        [Test]
        public void M09_DaoHotelElilimarHotelFallido()
        {
            Assert.Throws<ReservaExceptionM09>(() => daoHotel.eliminarHotel(656465));

        }
        /// <summary>
        /// 
        /// </summary>
       /* [Test]
        public void M09_DaoContultaSimple()
        {
            int resultadoAgregar = daoHotel.Agregar(mockHotell);
            Entidad consulta = daoHotel.Consultar(999);
            Assert.AreEqual(consulta, mockHotell);
            /*
            daoHotel.Eliminar(999);
            Assert.NotNull(daoHotel.Agregar(null));
<<<<<<< HEAD

        }*/

      
   

        /// <summary>
        /// Metodo que verifica la disponiblididad del hotel
        /// </summary>
        [Test]
        public void M09_DaoDisponibilidadHotel()
        {
         ////////////////   
        }
        ///Esta biene ste?????????????????????????????????????????????????????????
        /// <summary>
        /// Metodo que prueba cada metodo de overload Hotel
        /// </summary>
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

        /// <summary>
        /// Metodo Agregar hotel
        /// </summary>
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
           
            prueba._precioHabitacion = 200;
            Assert.AreEqual(prueba._email, "hola@gmail.com");
            Assert.AreEqual(prueba._capacidadHabitacion,3);
            Assert.AreEqual(prueba._clasificacion,5);
            Assert.AreEqual(prueba._direccion,"prueba");
            Assert.AreEqual(prueba._email, "hola@gmail.com");
            Assert.AreEqual(prueba._paginaWeb, "www.hola.com");
            Assert.AreEqual(prueba._pais, "Venezuela");

        }
        /// <summary>
        /// Metodo de Crear Hoteles
        /// </summary>
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
            prueba._nombre = "prueba";
            prueba._paginaweb = "www.prueba.com";
            prueba._pais = "Venezuela";
            prueba._puntuacion = 4;

            Assert.AreEqual(prueba._canthabitaciones, 4);
            Assert.AreEqual(prueba._ciudad, "Caracas");
            Assert.AreEqual(prueba._estrellas, 5);
            Assert.AreEqual(prueba._id, 150);
            Assert.AreEqual(prueba._nombre, "prueba");
            Assert.AreEqual(prueba._paginaweb, "www.prueba.com");
            Assert.AreEqual(prueba._email, "email@gmail.com");        
            Assert.AreEqual(prueba._direccion, "prueba");
            Assert.AreEqual(prueba._email, "email@email.com");
            Assert.AreEqual(prueba._pais, "Venezuela");
        }
        /// <summary>
        /// Metodo Que edita un hotel existente
        /// </summary>
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
            prueba._nombre = "prueba";
            prueba._paginaweb = "www.prueba.com";
            prueba._pais = "Venezuela";
            prueba._puntuacion = 4;
            Assert.AreEqual(prueba._canthabitaciones, 4);
            Assert.AreEqual(prueba._ciudad, "Caracas");
            Assert.AreEqual(prueba._estrellas, 5);
            Assert.AreEqual(prueba._id, 150);
            Assert.AreEqual(prueba._nombre, "prueba");
            Assert.AreEqual(prueba._paginaweb, "www.prueba.com");
            Assert.AreEqual(prueba._email, "email@gmail.com");
            Assert.AreEqual(prueba._direccion, "prueba");

            Assert.AreEqual(prueba._pais, "Venezuela");
            
        }
        
     /// <summary>
     /// 
     /// </summary>
        [Test]
        public void CGestionHoteles_SelectEstrellalsModel()
        {
            CGestionHoteles_SelectEstrellasModel prueba = new CGestionHoteles_SelectEstrellasModel();
        
            prueba._CategoryId =new int[10];
            prueba._CategoryId[1] = 1;
            Assert.AreEqual(prueba._CategoryId[1], 1);

        }
       /// <summary>
       /// Metodo de instancia al hote y prueba la lista de hoteles
       /// </summary>
        [Test]
        public void CHotel()
        {
            CHotel prueba = new CHotel();
            prueba._canthabitaciones =4;
            prueba._ciudad="Caracas";
            prueba._direccion="prueba";
            prueba._disponibilidad=1;
            prueba._email="email@email.com";
            prueba._estrellas=5;
            prueba._id=5;
          
            prueba._nombre="prueba";
            prueba._paginaweb="www.prueba.com";
            prueba._pais="Venezuela";
            prueba._puntuacion=5;
            Assert.AreEqual(prueba._canthabitaciones, 4);
            Assert.AreEqual(prueba._ciudad, "Caracas");
            Assert.AreEqual(prueba._estrellas, 5);
            Assert.AreEqual(prueba._id, 5);
            Assert.AreEqual(prueba._nombre, "prueba");
            Assert.AreEqual(prueba._paginaweb, "www.prueba.com");
            Assert.AreEqual(prueba._email, "email@gmail.com");
            Assert.AreEqual(prueba._direccion, "prueba");
            Assert.AreEqual(prueba._disponibilidad, 1);
            Assert.AreEqual(prueba._pais, "Venezuela");
            CManejadorSQL_Hoteles listar = new CManejadorSQL_Hoteles();
           List<CHotel> pru=  prueba.MListarHoteles();
           Assert.AreEqual(pru, listar.MListarHotelesBD());


        }
        /// <summary>
        /// Metodo que verifica la modificacion del hotel, asigna en las variables
        /// </summary>
        [Test]
        public void CModificarHotel()
        {
            CModificarHotel prueba = new CModificarHotel();
            prueba._capacidadHabitacion = 4;
            prueba._ciudad = "Caracas";
            prueba._clasificacion = 5;
            prueba._direccion="prueba";
            prueba._email = "email@email.com";
            prueba._nombre="prueba";
            prueba._paginaWeb="www.prueba.com";
            prueba._pais="venezuela";
            prueba._precioHabitacion=200;
            Assert.AreEqual(prueba._capacidadHabitacion, 4);
            Assert.AreEqual(prueba._ciudad, "Caracas"); 
            Assert.AreEqual(prueba._nombre, "prueba");
            Assert.AreEqual(prueba._paginaWeb, "www.prueba.com");
            Assert.AreEqual(prueba._email, "email@gmail.com");
            Assert.AreEqual(prueba._direccion, "prueba");
            Assert.AreEqual(prueba._clasificacion, 5);
            Assert.AreEqual(prueba._pais, "Venezuela");

        }
        /// <summary>
        /// Metodo que se encarga de recibir el Hotel para visualizarlo
        /// </summary>
        [Test]
        public void CVerHotel()
        {
            CVerHotel prueba = new CVerHotel();
            prueba._capacidadHabitacion = 4;
            prueba._ciudad = "Caracas";
            prueba._clasificacion = 5;
            prueba._direccion = "prueba";
            prueba._email = "email@email.com";
            prueba._nombre = "prueba";
            prueba._paginaWeb = "www.prueba.com";
            prueba._pais = "venezuela";
            prueba._precioHabitacion = 200;
            Assert.AreEqual(prueba._capacidadHabitacion, 4);
            Assert.AreEqual(prueba._ciudad, "Caracas");
            Assert.AreEqual(prueba._nombre, "prueba");
            Assert.AreEqual(prueba._paginaWeb, "www.prueba.com");
            Assert.AreEqual(prueba._email, "email@gmail.com");
            Assert.AreEqual(prueba._direccion, "prueba");
            Assert.AreEqual(prueba._clasificacion, 5);
            Assert.AreEqual(prueba._pais, "Venezuela");
            
        }
         //controller/patron comando/M09

        /// <summary>
        /// Metodo que prueba Agregar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]

        public void M09_AgregarHotel()
        {
            M09_COAgregarHotel prueba = new M09_COAgregarHotel(mockHotell,200);
          
            String  prueba1= prueba.ejecutar();
           //probar
            M09_COEliminarHotel pruebaf = new M09_COEliminarHotel(mockHotell, 999);
            pruebaf.ejecutar();
      
        }
        /// <summary>
        /// Metodo que prueba consultar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_COCOnsultarHotel()
        {
            M09_COConsultarHotel prueba = new M09_COConsultarHotel(10);
            Entidad hotel =prueba.ejecutar();
            Assert.AreEqual(hotel, "1");
            //prueba fallida
        }
        /// <summary>
        /// Metodo que prueba disponiblididad un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_CODisponibilidadHotel()
        {
            M09_CODisponibilidadHotel prueba = new M09_CODisponibilidadHotel(mockHotel,0);
            String test =  prueba.ejecutar();
            Assert.AreEqual(test, "1");
            //fallida

        }
        /// <summary>
        /// Metodo que prueba Eliminar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_COEliminarHotel()
        {
            daoHotel.Agregar(mockHotell);
            M09_COEliminarHotel prueba = new M09_COEliminarHotel(mockHotell,999);
            String test =  prueba.ejecutar();
            Assert.AreEqual(test, "1");
            ///fallida

        
        }
        /// <summary>
        /// Metodo que prueba Modificar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_COModificarHotel()
        { 
            daoHotel.Agregar(mockHotell);
            mockHotel2 = new Hotel(999, "HOtel desde p", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            M09_COModificarHotel prueba = new M09_COModificarHotel(mockHotel2, 999);
            String nombre =prueba.ejecutar();
            Assert.AreEqual(nombre, "1");

            M09_COEliminarHotel prueba1 = new M09_COEliminarHotel(mockHotell, 999);
            prueba1.ejecutar();
        }
        //Faltaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// Metodo que Obtiene la lista de paises
        /// </summary>
        [Test]
        public void M09_COObtenerpaises()
        {
            M09_COObtenerPaises prueba = new M09_COObtenerPaises();
            Dictionary<int, Entidad> prueb1 = prueba.ejecutar();

        }
        /// <summary>
        /// Metodo que trae el mapa de los hoteles 
        /// </summary>
        [Test]
        public void M09_C0VisualizarHoteles()
        {
            M09_COVisualizarHoteles prueba = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> mapHoteles = prueba.ejecutar();
           //// dalta
        
        }
        //controller 
        /// <summary>
        /// Método que verifica si se retorna un JasonResult cuando se guarda un hotel
        /// </summary>
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
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se borra un hotel
        /// </summary>
        [Test]
        public void deleteHotel()
        {       daoHotel.Agregar(mockHotell);
                gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deleteHotel(999);
            Assert.IsInstanceOf(typeof(JsonResult),probar);
        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se activa un hotel
        /// </summary>
        [Test]

        public void activateHotel()
        {
            daoHotel.Agregar(mockHotell);
            gestion_hotelesController prueba = new gestion_hotelesController();
           JsonResult probar= prueba.activateHotel(999);
           Assert.IsInstanceOf(typeof(JsonResult), probar);
           prueba.deleteHotel(999);

        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se desactiva un hotel
        /// </summary>
        [Test]
        public void deactivateHotel()
        {
            daoHotel.Agregar(mockHotell);
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deactivateHotel(999);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
            prueba.deleteHotel(999);
        }
        /// <summary>
        /// Método que verifica si se retorna un Result de la lista de paises
        /// </summary>
        [Test]
        public void pais()
        {
            // List<SelectListItem> pais()
        }

        /// <summary>
        /// Método que verifica si se retorna un ActionResult de la lista de ciudades
        /// </summary>
        [Test]
        public void listaciudades()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
           ActionResult probar = prueba.listaciudades("Venezuela");
           Assert.IsInstanceOf(typeof(ActionResult), probar);

        }

        /// <summary>
        /// Método que verifica si se retorna un ActionResult visualizar hoteles
        /// </summary>
        [Test]
        public void M09_VisualizarHoteles()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();

            ActionResult probar = prueba.M09_VisualizarHoteles();
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        /// <summary>
        /// Método que verifica si se retorna un ActionResult en detalle del hotel
        /// </summary>
        [Test]
        public void M09_DetalleHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            ActionResult probar = prueba.M09_DetalleHotel(15);
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);
        }
        /// <summary>
        /// Método que verifica si se retorna un ActionResult en modificar un hotel
        /// </summary>
        [Test]
        public void M09_ModificarHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
           ActionResult probar = prueba.M09_ModificarHotel(10);
            Assert.IsInstanceOf(typeof(PartialViewResult),probar);

        
        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult en Modificarhotel
        /// </summary>
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
        /// <summary>
        /// Metodo dao que verifica la consulta de todos los hoteles
        /// </summary>
        [Test]        
        public void M09_DaoHotelConsultarTodos() {
            Dictionary<int,Entidad> hoteles = daoHotel.ConsultarTodos();
            Assert.NotNull(hoteles);
            Hotel e = (Hotel) hoteles[99];
            Assert.AreEqual(e._nombre, "hotelDePruebasUnitarias");
        }
        /// <summary>
        /// Método que verifica si se retorna un ActionResult en listaciudades
        /// </summary>
        [Test]
        public void M09_ComandoConsultarTodos()
        {
            M09_COVisualizarHoteles comando = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> hoteles = comando.ejecutar();
            Assert.NotNull(hoteles);
            Hotel e = (Hotel)hoteles[99];
            Assert.AreEqual(e._nombre, "hotelDePruebasUnitarias");
        }
        /// <summary>
        /// Método que verifica agregar habitacion
        /// </summary>
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
        ///Servico

        /// <summary>
        /// Método de verificacion del manejador SQL
        /// </summary>
        [Test]
        public void CManejadorSQL_Hoteles()
        {
            CManejadorSQL_Hoteles prueba = new CManejadorSQL_Hoteles();
            
        
        
        
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

         * */


    }
}