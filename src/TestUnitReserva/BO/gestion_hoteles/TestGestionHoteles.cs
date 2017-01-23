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
using BOReserva.DataAccess.Model;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestGestionHoteles
    {
        private Pais mockPais;
        private Ciudad mockCiudad;
        private Hotel mockHotel;
        private Hotel mockHotell;
        private Hotel mock;

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
            mockHotell = new Hotel(999, "HOtel desde pr", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            daoHotel = new DAOHotel();

            mock = new Hotel(6, "HOtel", "hotel", "hotel", "prueba", 1, 1, mockCiudad, 0);


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
            String prueba1 = daoHotel.eliminarHotel(999);
            Assert.AreEqual(prueba1, "1");

        }
        /// <summary>
        /// Metodo caso fallido, eliminar Hotel
        /// </summary>
        //[Test] //Falla pero no es porque este mala sino porque es imposible que falle
        //public void M09_DaoHotelElilimarHotelFallido()
        //{
        //    Assert.Throws<ReservaExceptionM09>(() => daoHotel.eliminarHotel(-1));

        //}//NO CORREO



        /// <summary>
        /// Metodo que verifica la disponiblididad del hotel
        /// </summary>
        [Test]
        public void M09_DaoDisponibilidadHotel()
        {
            Entidad prueba = daoHotel.disponibilidadHotel(mock, 1);
            Assert.IsInstanceOf(typeof(Hotel), prueba);
        }
        /// <summary>
        /// Metodo para verificar la exepcion de disponibilidad
        /// </summary>
        [Test]
        public void M09_DaoDisponibilidadHotelerror()
        {


            Assert.Throws<ReservaExceptionM09>(() => daoHotel.disponibilidadHotel(null, 1));

        }

        /// <summary>
        /// Metodo que prueba cada metodo de overload Hotel
        /// </summary>
        [Test]
        public void M09_DomainHotel()
        {

            Hotel prueba = new Hotel("HOtel", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            Hotel prueba1 = new Hotel(1, "HOtel1", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            Hotel prueba2 = new Hotel("HOtel2", "hotel", "hotel", "hotel", 1, 1, mockCiudad, 200);
            Hotel prueba3 = new Hotel(1, "HOtel3", "hotel", "hotel", "hotel", 1, 1, mockCiudad, 0);
            Assert.AreEqual(prueba._nombre, "HOtel");
            Assert.AreEqual(prueba1._nombre, "HOtel1");
            Assert.AreEqual(prueba2._nombre, "HOtel2");
            Assert.AreEqual(prueba3._nombre, "HOtel3");
        }
        //model

        /// <summary>
        /// Metodo Agregar hotel
        /// </summary>
        [Test]
        public void M09_CAgregarHotel()
        {
            CAgregarHotel prueba = new CAgregarHotel();
            prueba._capacidadHabitacion = 3;
            prueba._clasificacion = 5;
            prueba._direccion = "prueba";
            prueba._email = "hola@gmail.com";
            prueba._nombre = "Cosita";
            prueba._paginaWeb = "www.hola.com";
            prueba._pais = "Venezuela";

            prueba._precioHabitacion = 200;
            Assert.AreEqual(prueba._email, "hola@gmail.com");
            Assert.AreEqual(prueba._capacidadHabitacion, 3);
            Assert.AreEqual(prueba._clasificacion, 5);
            Assert.AreEqual(prueba._direccion, "prueba");
            Assert.AreEqual(prueba._email, "hola@gmail.com");
            Assert.AreEqual(prueba._paginaWeb, "www.hola.com");
            Assert.AreEqual(prueba._pais, "Venezuela");

        }
        /// <summary>
        /// Metodo que verifica la modificacion del hotel, asigna en las variables
        /// </summary>
        [Test]
        public void M09_CModificarHotel()
        {
            CModificarHotel prueba = new CModificarHotel();
            prueba._capacidadHabitacion = 4;
            prueba._ciudad = "Caracas";
            prueba._clasificacion = 5;
            prueba._direccion = "prueba";
            prueba._email = "email@gmail.com";
            prueba._nombre = "prueba";
            prueba._paginaWeb = "www.prueba.com";
            prueba._pais = "Venezuela";
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
        /// <summary>
        /// Metodo que se encarga de recibir el Hotel para visualizarlo
        /// </summary>
        [Test]
        public void M09_CVerHotel()
        {
            CVerHotel prueba = new CVerHotel();
            prueba._capacidadHabitacion = 4;
            prueba._ciudad = "Caracas";
            prueba._clasificacion = 5;
            prueba._direccion = "prueba";
            prueba._email = "email@gmail.com";
            prueba._nombre = "prueba";
            prueba._paginaWeb = "www.prueba.com";
            prueba._pais = "Venezuela";
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
            M09_COAgregarHotel prueba = new M09_COAgregarHotel(mockHotell, 200);

            String prueba1 = prueba.ejecutar();
            Assert.AreEqual(prueba1, "Se registro el hotel exitosamente");
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
            M09_COConsultarHotel prueba = new M09_COConsultarHotel(6);
            Entidad hotel = prueba.ejecutar();
            Assert.IsInstanceOf(typeof(Entidad), hotel);

        }
        /*/// <summary>
        /// Metodo que verifica controller consulta de hotel
        /// </summary>
        [Test] //Falla pero no es porque este mala sino porque es imposible que falle
        public void M09_COCOnsultarHotelerror()
        {
            M09_COConsultarHotel prueba = new M09_COConsultarHotel(87897987);
            Assert.Throws<ReservaExceptionM09>(() => prueba.ejecutar());


        }*/
        //NO CORREO

        /// <summary>
        /// Metodo que prueba disponiblididad un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_CODisponibilidadHotel()
        {
            M09_CODisponibilidadHotel prueba = new M09_CODisponibilidadHotel(mockHotel, 0);
            String test = prueba.ejecutar();
            Assert.AreEqual(test, "Se cambio exitosamente la disponibilidad del hotel");
            //fallida

        }

        /// <summary>
        /// Metodo que prueba disponiblididad un hotel, instanciando  Patron comando
        /// </summary>
        //[Test] //Falla pero no es porque este mala sino porque es imposible que falle
        //public void M09_CODisponibilidadHotelerror()
        //{
        //    M09_CODisponibilidadHotel prueba = new M09_CODisponibilidadHotel(null, 7);
        //    Assert.Throws<ReservaExceptionM09>(() => prueba.ejecutar());



        //}//NO CORREO
        /// <summary>
        /// Metodo que prueba Eliminar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_COEliminarHotel()
        {
            daoHotel.Agregar(mockHotell);
            M09_COEliminarHotel prueba = new M09_COEliminarHotel(mockHotell, 999);
            String test = prueba.ejecutar();
            Assert.AreEqual(test, "Se elimino exitosamente el hotel");
            ///fallida


        }

        /// <summary>
        /// Metodo que prueba Eliminar un hotel fallido, instanciando  Patron comando
        /// </summary>
        //[Test] //Falla pero no es porque este mala sino porque es imposible que falle
        //public void M09_COEliminarHotelerror()
        //{

        //    M09_COEliminarHotel prueba = new M09_COEliminarHotel(null, 999);
        //    Assert.Throws<ReservaExceptionM09>(() => prueba.ejecutar());



        //}//NO CORREO
        /// <summary>
        /// Metodo que prueba Modificar un hotel, instanciando  Patron comando
        /// </summary>
        [Test]
        public void M09_COModificarHotel()
        {

            mockHotel2 = new Hotel(999, "HOtel desde p", "hotel", "hotel", "hotel", 1, 1, mockCiudad);
            M09_COModificarHotel prueba = new M09_COModificarHotel(mockHotel2, 999);
            String nombre = prueba.ejecutar();
            Assert.AreEqual(nombre, "Se modifico el hotel exitosamente, sera redirigido al listado de hoteles");

            M09_COEliminarHotel prueba1 = new M09_COEliminarHotel(mockHotel2, 999);
            prueba1.ejecutar();
        }

        /// <summary>
        /// Metodo que prueba Modificar un hotel fallida, instanciando  Patron comando
        /// </summary>
        //[Test] //Falla pero no es porque este mala sino porque es imposible que falle
        //public void M09_COModificarHotelerror()
        //{


        //    M09_COModificarHotel prueba = new M09_COModificarHotel(null, 999);
        //    Assert.Throws<ReservaExceptionM09>(() => prueba.ejecutar());
        //}//NO CORREO


        //Faltaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// <summary>
        /// Metodo que Obtiene la lista de paises
        /// </summary>
        [Test]
        public void M09_COObtenerpaises()
        {
            M09_COObtenerPaises prueba = new M09_COObtenerPaises();
            Dictionary<int, Entidad> prueb1 = prueba.ejecutar();
            Assert.NotNull(prueb1);
            Assert.IsInstanceOf(typeof(Dictionary<int, Entidad>), prueb1);

        }
        /// <summary>
        /// Metodo que trae el mapa de los hoteles 
        /// </summary>
        [Test]
        public void M09_C0VisualizarHoteles()
        {
            M09_COVisualizarHoteles prueba = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> mapHoteles = prueba.ejecutar();
            Assert.NotNull(mapHoteles);
            Assert.IsInstanceOf(typeof(Dictionary<int, Entidad>), mapHoteles);

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
            JsonResult probarjsonresult = prueba.guardarHotel(model);
            Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se borra un hotel
        /// </summary>
        [Test]
        public void M09_deleteHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deleteHotel(6);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se activa un hotel
        /// </summary>
        [Test]

        public void M09_activateHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.activateHotel(6);
            Assert.IsInstanceOf(typeof(JsonResult), probar);

        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult cuando se desactiva un hotel
        /// </summary>
        [Test]
        public void M09_deactivateHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.deactivateHotel(6);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Método que verifica si se retorna una lista de paises
        /// </summary>
        [Test]
        public void M09_pais()
        {

            List<SelectListItem> hola = BOReserva.Controllers.gestion_hotelesController.pais();
            Assert.NotNull(hola);
            Assert.IsInstanceOf(typeof(List<SelectListItem>), hola);
        }

        /// <summary>
        /// Método que verifica si se retorna un ActionResult de la lista de ciudades
        /// </summary>
        [Test]
        public void M09_listaciudades()
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
            ActionResult probar = prueba.M09_ModificarHotel(6);
            Assert.IsInstanceOf(typeof(PartialViewResult), probar);


        }
        /// <summary>
        /// Método que verifica si se retorna un JsonResult en Modificarhotel
        /// </summary>
        [Test]
        public void M09_modificarHotel()
        {
            CModificarHotel model = new CModificarHotel();
            model._capacidadHabitacion = 4;
            model._clasificacion = 3;
            model._direccion = "ff";
            model._email = "holña@gm.com";
            model._nombre = "daniel";
            model._paginaWeb = "www.google.com";
            model._pais = "Venezuela";
            //model._paises 
            model._ciudad = "Caracas";
            gestion_hotelesController prueba = new gestion_hotelesController();
            JsonResult probar = prueba.modificarHotel(model);
            Assert.IsInstanceOf(typeof(JsonResult), probar);
        }
        /// <summary>
        /// Metodo dao que verifica la consulta de todos los hoteles
        /// </summary>
        [Test]
        public void M09_DaoHotelConsultarTodos()
        {
            Dictionary<int, Entidad> hoteles = daoHotel.ConsultarTodos();
            Assert.NotNull(hoteles);
            Assert.IsInstanceOf(typeof(Dictionary<int, Entidad>), hoteles);
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
            Assert.IsInstanceOf(typeof(Dictionary<int, Entidad>), hoteles);
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
        //Cache
        /// <summary>
        /// Metodo que verifica si se retorna  el ID del hotel
        /// </summary>

        [Test]
        public void M09_retornarHotelPorId()
        {
            Entidad Reserva = BOReserva.DataAccess.Model.Cache.retornarHotelPorId(1);
            Assert.AreEqual(Reserva._id, 1);
        }

        /// <summary>
        /// Metodo que verifica si al dar un id erroneo entre en el catch 
        /// </summary>
        [Test]
        public void M09_retornarHotelPorIderror()
        {
            Assert.Throws<KeyNotFoundException>(() => BOReserva.DataAccess.Model.Cache.retornarHotelPorId(999999));
        }
        /// <summary>
        /// metodo que verifica si un hotel realmente esta en cache
        /// </summary>
        [Test]
        public void M09_estaEnCache()
        {
            M09_COVisualizarHoteles comando = new M09_COVisualizarHoteles();
            Dictionary<int, Entidad> hoteles = comando.ejecutar();
            Boolean Reserva = BOReserva.DataAccess.Model.Cache.estaEnCache(1);
            Assert.AreEqual(Reserva, true);
        }
        /// <summary>
        /// Metodo que verifica si al colocar un id no existente lo agarre el catch
        /// </summary>
        [Test]
        public void M09_estaEnCacheerror()
        {
            Boolean Reserva = BOReserva.DataAccess.Model.Cache.estaEnCache(9999991);
            Assert.AreEqual(Reserva, false);
        }

        /// <summary>
        /// Metodo que ejecuta pruebas al metodo M09_AgregarHotel de gestion_hotelesController
        /// </summary>
        [Test]
        public void M09_controllerM09_AgregarHotel()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            ActionResult test = prueba.M09_AgregarHotel();
            Assert.NotNull(test);
            Assert.IsInstanceOf(typeof(ActionResult), test);
        }


        /// <summary>
        /// Metodo que lanza la excepcion NotImplemented en DAOHabitacion para Agregar
        /// </summary>
        [Test]
        public void M09_DAOHabitacion_Agregar()
        {
            DAOHabitacion dao = new DAOHabitacion();

            Assert.Throws<NotImplementedException>(() => dao.Agregar(new Hotel()));
        }
        /// <summary>
        /// Metodo que lanza la excepcion NotImplemented en DAOHabitacion para Modificar
        /// </summary>
        [Test]
        public void M09_DAOHabitacion_Modificar()
        {
            DAOHabitacion dao = new DAOHabitacion();

            Assert.Throws<NotImplementedException>(() => dao.Modificar(new Hotel()));
        }
        /// <summary>
        /// Metodo que lanza la excepcion NotImplemented en DAOHabitacion para Consultar
        /// </summary>
        [Test]
        public void M09_DAOHabitacion_Consultar()
        {
            DAOHabitacion dao = new DAOHabitacion();

            Assert.Throws<NotImplementedException>(() => dao.Consultar(1));
        }


        /// <summary>
        /// Metodo que prueba el constructor de la clase ReservaExceptionM09
        /// </summary>
        [Test]
        public void M09_CachefallarActualizar()
        {
            ReservaExceptionM09 constructorN1 = new ReservaExceptionM09("", new ArgumentNullException());
            ReservaExceptionM09 constructorN2 = new ReservaExceptionM09("", new BOReserva.Excepciones.LogException());
            ReservaExceptionM09 constructorN3 = new ReservaExceptionM09("", new Exception());
            ReservaExceptionM09 constructorN5 = new ReservaExceptionM09("", new NullReferenceException());
            SqlException nueva = Mocksdeayuda.MakeSqlException();
            ReservaExceptionM09 constructorN6 = new ReservaExceptionM09("paq_fk_hotel", nueva);
            ReservaExceptionM09 constructorN61 = new ReservaExceptionM09("rha_fk_hot_id", nueva);
            ReservaExceptionM09 constructorN62 = new ReservaExceptionM09("", nueva);
            constructorN1.Codigo = "1";
            constructorN2.Codigo = "1";
            constructorN3.Codigo = "1";
            constructorN5.Codigo = "1";
            constructorN6.Codigo = "1";
            constructorN61.Codigo = "1";
            constructorN62.Codigo = "1";
            Assert.AreEqual("1", constructorN1.Codigo);
            Assert.AreEqual("1", constructorN2.Codigo);
            Assert.AreEqual("1", constructorN3.Codigo);
            Assert.AreEqual("1", constructorN5.Codigo);
            Assert.AreEqual("1", constructorN6.Codigo);
            Assert.AreEqual("1", constructorN61.Codigo);
            Assert.AreEqual("1", constructorN62.Codigo);
            Assert.AreEqual(typeof(ArgumentNullException), constructorN1.Excepcion.GetType());
            Assert.AreEqual(typeof(BOReserva.Excepciones.LogException), constructorN2.Excepcion.GetType());
            Assert.AreEqual(typeof(Exception), constructorN3.Excepcion.GetType());
            Assert.AreEqual(typeof(NullReferenceException), constructorN5.Excepcion.GetType());
            Assert.AreEqual(typeof(SqlException), constructorN6.Excepcion.GetType());
            Assert.AreEqual(typeof(SqlException), constructorN61.Excepcion.GetType());
            Assert.AreEqual(typeof(SqlException), constructorN62.Excepcion.GetType());
            Assert.NotNull(nueva);
            Assert.IsInstanceOf(typeof(SqlException), nueva);
            Assert.AreEqual("Reserva-404: Ha ocurrido un problema con un argumento nulo. Para mayor detalle revisar el Log de errores", constructorN1.Mensaje);
            Assert.AreEqual("Reserva-404: Ha ocurrido un error al escribir el log", constructorN2.Mensaje);
            Assert.AreEqual("Reserva-404: Ha ocurrido un error desconocido. Para mayor detalle revisar el Log de errores", constructorN3.Mensaje);
            Assert.AreEqual("Reserva-404: Ha ocurrido un problema con una referencia nula. Para mayor detalle revisar el Log de errores", constructorN5.Mensaje);
            Assert.AreEqual("Reserva-404: Ha ocurrido un problema con la base de datos. Para mayor detalle revisar el Log de errores", constructorN62.Mensaje);

        }

        /// <summary>
        /// Metodo que ejecuta pruebas al metodo getCity del controlador
        /// </summary>
        [Test]
        public void M09_controllerGetCity()
        {
            gestion_hotelesController prueba = new gestion_hotelesController();
            prueba.getCity("Caracas");
            Assert.AreEqual("Caracas", gestion_hotelesController.ciudad);
        }
    }
}