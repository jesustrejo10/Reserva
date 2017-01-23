using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FOReserva.Models.Itinerario;
using FOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;


namespace TestUnitReserva.FO.Planificacion_Vacaciones
{
    [TestFixture]
    class TestPlanificacionVacacion
    {
        //Cvista_Itinerario iti;

        ManejadorSQLItinerario prueba = new ManejadorSQLItinerario();
       // FOReserva.Controllers.gestion_planificacion_vacacionesController controlador = new FOReserva.Controllers.gestion_planificacion_vacacionesController();
        //PRUEBAS DEL MANEJADORSQLITINERARIO

        [Test] //PRUEBA DEL INSERTAR ITINERARIO
        public void PruebaAgregarItinerarioFallo()
        {
            Random r = new Random();
            //int randomid = r.Next();
            Cvista_Itinerario itinerario = new Cvista_Itinerario();
            itinerario._id = 0;
            itinerario._fecha = null ;

            itinerario._actividad = null;
            itinerario._boleto = 0;
            itinerario._crucero = 0;

            //Aqui valido que la funcion de insertar no inserte con los campos incompletos
            Boolean insertitinerario = prueba.insertarItinerario(itinerario);
            Assert.AreEqual(insertitinerario, false);
        }
        [Test] //PRUEBA DEL INSERTAR ITINERARIO
        public void PruebaAgregarItinerarioExito()
        {
            Random r = new Random();
            //int randomid = r.Next();
            Cvista_Itinerario itinerario = new Cvista_Itinerario();
            itinerario._id = 60;
            itinerario._fecha = "3";
            itinerario._actividad = "hoy quiero comer helado en milano";
            itinerario._boleto = 8;
            itinerario._crucero = 0;

     
            Boolean insertitinerario = prueba.insertarItinerario(itinerario);
            Assert.AreEqual(insertitinerario, true);
           
        }
        [Test] //PRUEBA DEL MODIFICAR ITINERARIO
        public void PruebaModificarItinerarioFallo()
        {
            Random r = new Random();
            int randomid = r.Next();
            Cvista_Itinerario itinerario = new Cvista_Itinerario();
            itinerario._id = 99;
            itinerario._fecha = "4";
            itinerario._actividad = "hoy quiero comer helado en suiza";
            itinerario._boleto = 9;
            itinerario._crucero = 0;

            
            Boolean modificaritinerario = prueba.modificarItinerario(itinerario);
            Assert.AreEqual(modificaritinerario, false);

            

        }

        [Test] //PRUEBA DEL ELIMINAR ITINERARIO
        public void PruebaEliminarItinerario()
        {
            Random r = new Random();
            int randomid = r.Next();
            Cvista_Itinerario itinerario = new Cvista_Itinerario();
            itinerario._fecha = "80";
            //itinerario._actividad = "hoy quiero comer helado en milano";
            itinerario._boleto = 7;


           
            Boolean EliminarItinerario = prueba.eliminarItinerario(itinerario);
            Assert.AreEqual(EliminarItinerario, false);

            
            Boolean resultadonull = prueba.eliminarItinerario(null);
            Assert.AreEqual(resultadonull, false);


        }

        //AQUI FALTARIA LA DE CONSULTAR

        private SqlDataReader Executer(string consulta)
        {
            throw new NotImplementedException();
        }



        [Test] //PRUEBO QUE LA LISTA DE LUGARES NO RETORNE VACIA
        public void PruebaBuscarLugares()
        {

            List<string> lugares = prueba.listarLugares();
            Assert.IsNotNull(lugares);
        }

        [Test] //PRUEBO QUE LA LISTA DE FECHAS POR LUGARES NO RETORNE VACIA
        public void PruebaBuscarFecha()
        {

            List<string> buscarFecha = prueba.consultarFechas("Caracas-15/12/2016 07:00:00 p.m.-08:00:00 p.m.-Maritima-9 ");
            Assert.IsNotNull(buscarFecha);

        }




        [Test]
        public void ExpectedSqlExceptionListarLugares()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.listarLugares());

        }

        [Test]
        public void ExpectedExceptionConsultarFecha()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.consultarFechas("Caracas-15/12/2016 07:00:00 p.m.-08:00:00 p.m.-Maritima-9"));

        }
       

        [Test]//prueba de excepciones
        public void ExpectedSqlExceptionBuscarActividad()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.buscarActividad(null,null));

        }



    }



}
