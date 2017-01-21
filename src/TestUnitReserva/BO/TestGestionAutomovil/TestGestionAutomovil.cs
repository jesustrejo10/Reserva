using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_automoviles;
using System.Diagnostics;
using BOReserva.Models;
using BOReserva.Servicio;
using BOReserva.Controllers;
using System.Web;
using System.Web.Mvc;


namespace TestUnitReserva.BO.TestGestionAutomovil
{
    /// <summary>
    /// Clase que realiza pruebas unitarias
    /// </summary>
    //[TestFixture]
    //public class TestGestionAutomovil
    //{

    //    //DAOAutomovil daoAutomovil;
    //    manejadorSQL _manejadorSql;
    //    Automovil _automovil;
    //    String _matriculaPrueba = Util.RandomString(7);
    //    String _matriculaPrueba2 = Util.RandomString(7);
    //    gestion_automovilesController _controlador = new gestion_automovilesController();

    //    /// <summary>
    //    /// Metodo que se ejecuta antes que se ejecute cada prueba
    //    /// Esta encargado de instanciar el manejadorSQL
    //    /// </summary>
    //    [SetUp]
    //    public void Before()
    //    {
    //        //daoAutomovil = new DAOAutomovil();
    //        _manejadorSql = new manejadorSQL();

    //    }
    //    /// <summary>
    //    /// Método que se ejecuta cada vez que termina de correr una prueba;
    //    /// Se encanga de limpiar las variables utilizadas en la prueba
    //    /// </summary>
    //    [TearDown]
    //    public void After()
    //    {
    //        _manejadorSql = null;
    //        _automovil = null;
    //    }

    //    /// <summary>
    //    /// Método que verifica si el vehículo es agregado correctamente a la base de datos
    //    /// retornando 1
    //    /// </summary>
    //    [Test]
    //    public void M08_AgregarVehiculoBD()
    //    {

    //        _automovil = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String prueba1 = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        Assert.AreEqual("1", prueba1);
    //    }

    //    /// <summary>
    //    /// Método que verifica si el vehículo es agregado correctamente a la base de datos
    //    /// retornando 1
    //    /// </summary>
    //    [Test]
    //    public void M08_MAgregaraBD()
    //    {
    //        _automovil = new Automovil(_matriculaPrueba2, "4", "Jeep", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String respuestaAgregar=_automovil.MAgregaraBD(_automovil,12);
    //        Assert.AreEqual("1", respuestaAgregar);
        
    //    }



    //    /// <summary>
    //    /// Método que verifica si la cidudad que le estamos pasando existe o no
    //    /// </summary>
    //    [Test]
    //    public void M08_BuscarFkCiudad()
    //    {
    //        String pais = "Venezuela";
    //        String ciudad = "Caracas";
    //        //ya se que el id de la ciudad Caracas, Venezuela es: 12
    //        int response = _manejadorSql.MBuscaridciudadBD(ciudad, pais);
    //        Debug.WriteLine(response);
    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response, 12);
    //        //Verifico que si le paso 2 vacios funcione
    //        response = _manejadorSql.MBuscaridciudadBD("", "");
    //        Debug.WriteLine(response);
    //        Assert.AreEqual(response, 0);
    //        //Verifico que si le paso 2 null funcione
    //        response = _manejadorSql.MBuscaridciudadBD(null, null);
    //        Debug.WriteLine(response);
    //        Assert.AreEqual(response, 0);

    //    }
    //    /// <summary>
    //    /// Método que verifica si el pais existe o no
    //    /// </summary>
    //    [Test]
    //    public void M08_MIdpaisesBD()
    //    {

    //        String pais = "Venezuela";
    //        //ya se que el id de la ciudad Caracas, Venezuela es: 11
    //        int response = _manejadorSql.MIdpaisesBD(pais);
    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response, 11);

    //        //Verifico que si le paso 2 vacios funcione
    //        response = _manejadorSql.MIdpaisesBD("");
    //        Assert.AreEqual(response, -1);
    //        //Verifico que si le paso 2 null funcione

    //        response = _manejadorSql.MIdpaisesBD(null);
    //        Assert.AreEqual(response, -1);

    //    }
    //    /// <summary>
    //    /// Método que realiza búsqueda de los un pais, verifica si existe el pais 
    //    /// o no encuentra coincidencias
    //    /// </summary>
    //    [Test]
    //    public void M08_MBuscarnombrePaisBD()
    //    {
    //        int pais = 12;
    //        //ya se que el id de la ciudad caracas es: 12
    //        String response = _manejadorSql.MBuscarnombrePaisBD(pais);
    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response, "Venezuela");

    //        //Verifico que si le paso 2 vacios funcione
    //        response = _manejadorSql.MBuscarnombrePaisBD(0);
    //        Assert.AreEqual(response, "Error al buscar");
    //    }
    //    /// <summary>
    //    /// Método que cuenta todos los paises existentes en la base de datos 
    //    /// se realzia la prueba por ser un rango definido de paises y verifica si no llega vacio
    //    /// </summary>
    //    [Test]
    //    public void M08_MListarpaisesBD()
    //    {
    //        String[] prueba = _manejadorSql.MListarpaisesBD();
    //        //prueba no vacia
    //        Assert.IsNotNull(prueba);
    //        //
    //        int contar = 0;
    //        bool verdad = true;

    //        while (verdad == true)
    //        {
    //            try
    //            {
    //                string prueb1 = prueba[contar].ToUpper();
    //                ++contar;
    //            }
    //            catch
    //            {
    //                verdad = false;
    //            }


    //        }
    //        Assert.AreEqual(16, contar);

    //    }
    //    /// <summary>
    //    /// Método que verifica si la placa a buscar existe
    //    /// </summary>
    //    [Test]
    //    public void M08_MDisponibilidadVehiculoBD()
    //    {
    //        String prueba3 = _manejadorSql.MDisponibilidadVehiculoBD(_matriculaPrueba, 0);
    //        Assert.AreEqual("1", prueba3);

    //    }

    //    /// <summary>
    //    /// Método que verifica si la placa a buscar existe
    //    /// </summary>
    //    [Test]
    //    public void M08_MDisponibilidadVehiculo()

    //    {
    //        Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String prueba = auto.MDisponibilidadVehiculoBD(_matriculaPrueba, 0);
    //        Assert.AreEqual("1", prueba);

    //    }
    //    /// <summary>
    //    /// Método validar buscarvehículo para ver si existe el automovil
    //    /// </summary>
    //    [Test]
    //    public void M08_MMostrarvehiculoBD()
    //    {
    //        // si no consigue
    //        Automovil buscarvehiculo = _manejadorSql.MMostrarvehiculoBD("FALLAR");
    //        Assert.IsNull(buscarvehiculo);
    //        Automovil auto = new Automovil("PRUEBACON", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(auto, 12);
    //        Automovil buscarvehiculo1 = _manejadorSql.MMostrarvehiculoBD("PRUEBACON");
    //        //si pasa..
    //        Assert.IsInstanceOf(typeof(Automovil), buscarvehiculo1);


    //    }
    //    /// <summary>
    //    /// Método validar buscarvehículo para ver si existe el automovil
    //    /// </summary>
    //    [Test]
    //    public void M08_MConsultarvehiculo()
    //    {
    //        Automovil auto = new Automovil("PRUEBACON", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(auto, 12);
    //        Automovil auto1 = auto.MConsultarvehiculo("PRUEBACON");
    //        Assert.IsInstanceOf(typeof(Automovil), auto1);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("PRUEBACON");
        
    //    }
    //    /// <summary>
    //    /// Método que verificar modificarvehiculo, si se logra modificar retorna 1 sino retorna 0
    //    /// </summary>
    //    [Test]
    //    public void M08_MModificarVehiculoBD()
    //    {
    //        String placa = _matriculaPrueba;
    //        _automovil = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        String prueba = _manejadorSql.MModificarVehiculoBD(_automovil, 13);
    //        Assert.AreEqual("1", prueba);
    //        _automovil = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
    //        String prueba2 = _manejadorSql.MModificarVehiculoBD(_automovil, 1000);
    //        Assert.AreNotEqual(0, prueba2);
    //    }

    //    /// <summary>
    //    /// Método que verificar modificarvehiculo, si se logra modificar retorna 1 sino retorna 0
    //    /// </summary>
    //    [Test]
    //    public void M08_MModificarvehiculo()
    //    {
    //        String placa = _matriculaPrueba2;
    //        _automovil = new Automovil(placa, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        String prueba = _automovil.MModificarvehiculoBD(_automovil, 13);
    //        Assert.AreEqual("1", prueba);
    //        _automovil = new Automovil(placa, "", "", 1936, "", 5, 5, 1, 1, 1, DateTime.Now, "", 1, "", "", "");
    //        String prueba2 = _automovil.MModificarvehiculoBD(_automovil, 1000);
    //        Assert.AreNotEqual(0, prueba2);
        
    //    }
    //    /// <summary>
    //    /// Método que lista todos los vehículos existentes
    //    /// </summary>
    //    [Test]
    //    public void M08_MListarvehiculosBD()
    //    {
    //        List<Automovil> prueba = _manejadorSql.MListarvehiculosBD();
    //        Assert.IsInstanceOf(typeof(List<Automovil>), prueba);
    //    }
    //    /// <summary>
    //    ///  Método que lista todos los vehículos existentes
    //    /// </summary>
    //    [Test]
    //    public void M08_MListarvehiculos()
    //    {

    //        Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        List<Automovil> listado = auto.MListarvehiculos();
    //        Assert.IsInstanceOf(typeof(List<Automovil>), listado);
   

    //    }

    //    /// <summary>
    //    /// Método que realiza la busqueda del nombre de la ciudad si existe su id, si no lo consigue arroja "Error al buscar"
    //    /// </summary>
    //    [Test]
    //    public void M08_MBuscarnombreciudadBD()
    //    {
    //        String prueba = _manejadorSql.MBuscarnombreciudadBD(12);
    //        Assert.AreEqual("Caracas", prueba);
    //        string prueba2 = _manejadorSql.MBuscarnombreciudadBD(1000);
    //        Assert.AreEqual("Error al buscar", prueba2);
    //    }

    //    /// <summary>
    //    /// Método que verifica si se ejecuta bien la revisión de placa
    //    /// </summary>
    //    [Test]
    //    public void M08_MPlacarepetidaBD()
    //    {

    //        int repetida = _manejadorSql.MPlacarepetidaBD(_matriculaPrueba);
    //        Assert.AreEqual(1, repetida);
    //        int repetidano = _manejadorSql.MPlacarepetidaBD("XXXXXXXX");
    //        Assert.AreEqual(0, repetidano);
    //    }
    //    /// <summary>
    //    /// Método que verifica si el vehículo es borrado de la base de datos correctamente
    //    /// </summary>
    //    [Test]
    //    public void M08_MBorrarvehiculoBD()
    //    {
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD(_matriculaPrueba);
    //        Assert.AreEqual("1", prueba2);
    //    }
    //    /// <summary>
    //    ///  Método que verifica si el vehículo es borrado de la base de datos correctamente
    //    /// </summary>
    //    [Test]
    //    public void M08_MBorrarvehiculo()
    //    {
    //        Automovil auto = new Automovil(_matriculaPrueba, "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String Prueba3 = auto.MBorrarvehiculoBD(_matriculaPrueba2);
    //        Assert.AreEqual("1", Prueba3);
    //    }
    //    /// <summary>
    //    /// Método que verifica si se retorna la cantidad de ciudades 
    //    /// </summary>
    //    [Test]
    //    public void M08_MListarciudadesBD()
    //    {
    //        List<String> listaCiudades = _manejadorSql.MListarciudadesBD(11);
    //        //se que por defecto en el pais 11, hay solo 5 ciudades.
    //        Assert.AreEqual(5, listaCiudades.Count);
    //    }


    //    /// <summary>
    //    /// Método qe verifica si se retornan ActionResult por parte de las vistas parciales
    //    /// </summary>
    //    [Test]
    //    public void M08_Retornavistasparciales()
    //    {
    //        _automovil = new Automovil("KMKMKM", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        Assert.IsInstanceOf(typeof(ActionResult), _controlador.M08_AgregarAutomovil());
    //        Assert.IsInstanceOf(typeof(ActionResult), _controlador.M08_ModificarAutomovil("KMKMKM"));
    //        Assert.IsInstanceOf(typeof(ActionResult), _controlador.M08_VisualizarAutomovil("KMKMKM"));
    //        Assert.IsInstanceOf(typeof(ActionResult), _controlador.M08_VisualizarAutomoviles());
    //        String Prueba3 = _manejadorSql.MBorrarvehiculoBD("KMKMKM");
    //    }

    //    /// <summary>
    //    /// Método que verifica si se retornan los años de 1930 a 2016
    //    /// </summary>
    //    [Test]
    //    public void M08_Listaranios()
    //    {
    //        List<SelectListItem> ls = BOReserva.Controllers.gestion_automovilesController.listadeanios();
    //        int cantidad = 1;
    //        for (int i = 1; i <= ls.Count()-3; i++)
    //        {
    //            cantidad++;
    //        }
    //        Assert.AreEqual(86,cantidad);

    //    }

    //    /// <summary>
    //    /// Método que verifica si se retorna la cantidad pedida
    //    /// </summary>
    //    [Test]
    //    public void M08_Listarcantidad()
    //    {
    //        List<SelectListItem> ls = BOReserva.Controllers.gestion_automovilesController.cantidad(80);
    //        int cantidad = 1;
    //        for (int i = 1; i <= ls.Count()-2; i++)
    //        {
    //            cantidad++;
    //        }
    //        Assert.AreEqual(80, cantidad);

    //    }


    //    /// <summary>
    //    /// Método que verifica si se retornan los colores
    //    /// </summary>
    //    [Test]
    //    public void M08_Listarcolores()
    //    {
    //        List<SelectListItem> ls = BOReserva.Controllers.gestion_automovilesController.colores();
    //        int cantidad = 1;
    //        for (int i = 1; i <= ls.Count() - 1; i++)
    //        {
    //            cantidad++;
    //        }
    //        Assert.AreEqual(6, cantidad);

    //    }


    //    /// <summary>
    //    /// Método que verifica si se guarda una ciudad
    //    /// </summary>
    //    [Test]
    //    public void M08_getCity()
    //    {
    //        _controlador.getCity("Caracas");
    //        Assert.AreEqual("Caracas", BOReserva.Controllers.gestion_automovilesController.ciudad);

    //    }


    //    /// <summary>
    //    /// Método que verifica si se retorna un JsonResult en saveVehicle
    //    /// </summary>
    //    [Test]
    //    public void M08_saveVehicle()
    //    {
    //        CAgregarAutomovil auto = new CAgregarAutomovil();
    //        auto._anio = 1995;
    //        auto._cantpasajeros = 5;
    //        auto._color = "Azul";
    //        auto._disponibilidad = true;
    //        auto._fabricante = "Mazda";
    //        auto._fecharegistro = DateTime.Now;
    //        auto._kilometraje = 0;
    //        auto._matricula = "FATTTTT";
    //        auto._modelo = "prueba";
    //        auto._pais = "Venezuela";
    //        auto._penalidaddiaria = 0;
    //        auto._precioalquiler = 0;
    //        auto._preciocompra = 0;
    //        auto._tipovehiculo = "Sedan";
    //        auto._transmision = "Automatica";
    //        JsonResult probarjsonresult = _controlador.saveVehicle(auto);
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("FATTTTT");
    //    }

    //    /// <summary>
    //    /// Método que verifica si se retorna un JsonResult en modifyVehicle
    //    /// </summary>
    //    [Test]
    //    public void M08_modifyVehicle()
    //    {
    //        CModificarAutomovil auto = new CModificarAutomovil();
    //        auto._anio = 1995;
    //        auto._cantpasajeros = 5;
    //        auto._color = "Azul";
    //        auto._disponibilidad = 1;
    //        auto._fabricante = "Mazda";
    //        auto._fecharegistro = DateTime.Now.ToString();
    //        auto._kilometraje = 0;
    //        auto._matricula = "FATTTTT";
    //        auto._modelo = "prueba";
    //        auto._pais = "Venezuela";
    //        auto._penalidaddiaria = 0;
    //        auto._precioalquiler = 0;
    //        auto._preciocompra = 0;
    //        auto._tipovehiculo = "Sedan";
    //        auto._transmision = "Automatica";
    //        JsonResult probarjsonresult = _controlador.modifyVehicle(auto);
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("FATTTTT");
    //    }

    //    /// <summary>
    //    /// Método que verifica si se retorna un JsonResult en viewVehicle
    //    /// </summary>
    //    [Test]
    //    public void M08_viewVehicle()
    //    {
    //        CVisualizarAutomovil auto = new CVisualizarAutomovil();
    //        auto._anio = 1995;
    //        auto._cantpasajeros = 5;
    //        auto._color = "Azul";
    //        auto._disponibilidad = 1;
    //        auto._fabricante = "Mazda";
    //        auto._fecharegistro = DateTime.Now.ToString();
    //        auto._kilometraje = 0;
    //        auto._matricula = "FATTTTT";
    //        auto._modelo = "prueba";
    //        auto._pais = "Venezuela";
    //        auto._penalidaddiaria = 0;
    //        auto._precioalquiler = 0;
    //        auto._preciocompra = 0;
    //        auto._tipovehiculo = "Sedan";
    //        auto._transmision = "Automatica";
    //        JsonResult probarjsonresult = _controlador.viewVehicle(auto);
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("FATTTTT");
    //    }

    //    /// <summary>
    //    /// Método que verifica si se retorna un JsonResult en deleteVehicle
    //    /// </summary>
    //    [Test]
    //    public void M08_deleteVehicle()
    //    {
    //        _automovil = new Automovil("FATTTT", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        JsonResult probarjsonresult = _controlador.deleteVehicle("FATTTT");
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //    }


    //    /// <summary>
    //    /// Método que verifica si se retorna un JsonResult en deactivateVehicle y en activateVehicle
    //    /// </summary>
    //    [Test]
    //    public void M08_disponibilityVehicle()
    //    {
    //        _automovil = new Automovil("FATTTT", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        JsonResult probarjsonresult = _controlador.deactivateVehicle("FATTTT");
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //        probarjsonresult = _controlador.activateVehicle("FATTTT");
    //        Assert.IsInstanceOf(typeof(JsonResult), probarjsonresult);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("FATTTTT");
    //    }


    //    /// <summary>
    //    /// Método que verifica si se retorna un ActionResult en checkplaca
    //    /// </summary>
    //    [Test]
    //    public void M08_checkplaca()
    //    {
    //        _automovil = new Automovil("FATTTT", "3", "Mazda", 1936, "Sedan", 5, 5, 1, 1, 1, DateTime.Now, "Azul", 1, "Automatica", "Venezuela", "Caracas");
    //        String agregar = _manejadorSql.MAgregarVehiculoBD(_automovil, 12);
    //        ActionResult probarjsonresult = _controlador.checkplaca("FATTTT");
    //        Assert.IsInstanceOf(typeof(ActionResult), probarjsonresult);
    //        String prueba2 = _manejadorSql.MBorrarvehiculoBD("FATTTTT");
    //    }

    //    /// <summary>
    //    /// Método que verifica si se retornan los países
    //    /// </summary>
    //    [Test]
    //    public void M08_Listarpaises()
    //    {
    //        List<SelectListItem> ls = BOReserva.Controllers.gestion_automovilesController.pais();
    //        int cantidad = 1;
    //        for (int i = 1; i <= ls.Count() - 1; i++)
    //        {
    //            cantidad++;
    //        }
    //        Assert.AreEqual(16, cantidad);

    //    }

    //    /// <summary>
    //    /// Método que verifica si se retorna un ActionResult en listaciudades
    //    /// </summary>
    //    [Test]
    //    public void M08_listaciudades()
    //    {
    //        ActionResult probarjsonresult = _controlador.listaciudades("Venezuela");
    //        Assert.IsInstanceOf(typeof(ActionResult), probarjsonresult);
    //    }
    //}
}﻿