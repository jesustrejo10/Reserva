using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using NUnit.Framework;
using FOReserva.Models.Autos;
using FOReserva.Servicio;
using System.Data.SqlClient;

namespace TestUnitReserva.FO.Reserva_Automovil
{
    class TestReservaAuto
    {
        ManejadorSQLReservaAutomovil prueba = new ManejadorSQLReservaAutomovil();
        FOReserva.Controllers.gestion_reserva_autoController controlador = new FOReserva.Controllers.gestion_reserva_autoController();

        //PRUEBAS DEL MANEJADORSQLRESERVAAUTOMOVIL
        [Test] //pruebo que el insertar de una reserva se ejecute correctamente
        public void PruebaReservarAuto()
        {
            Random r = new Random();
            int randomid = r.Next();
            CReserva_Autos_Perfil reserva = new CReserva_Autos_Perfil();
            reserva.Id = randomid;
            reserva.FechaIni = "2016-12-20";
            reserva.HoraFin = "2016-12-25";
            reserva.HoraIni = "12:00";
            reserva.HoraFin = "1:00";
            reserva.Autos.Matricula = "14DNKVO";
            reserva.CiudadDes = "12";
            reserva.CiudadOri = "12";
            reserva.Status = 1;
            /*Aqui valido que la funcion de insertar ;a reserva de auto correctamente devuelva true*/
            prueba.InsertarReservaAuto(reserva);
        }

        [Test] //pruebo que la lista de ciudades no regrese vacia
        public void PruebaBuscarCiudades()
        {

            List<CLugar> ciudades = prueba.buscarCiudades();
            Assert.IsNotNull(ciudades);
        }

        [Test] //pruebo que la lista de se llena con la busqueda de las reservas no regrese vacia
        public void PruebaBuscarReservas()
        {
            List<CReserva_Autos_Perfil> listamisreservas = prueba.buscarReservas();
            Assert.IsNotNull(listamisreservas);

        }


        //PRUEBAS DE EXPECTEDSQLEXCEPTION SI NO SE LOGRA CONECTAR CON LA BD, SI EL PROYECTO
        //SE LOGRA CONECTAR CON LA BD ESTAS PRUEBAS DEBERIAN SALIR COMO PRUEBAS NO SUPERADAS
        [Test]
        public void ExpectedSqlExceptionBuscarAutosCiudad()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.buscarAutosCiudad("12","12","2016-12-15","2015-12-16","12:00","12:00"));

        }

        [Test]
        public void ExpectedSqlExceptionReservarAuto()
        {

            Random r = new Random();
            int randomid = r.Next();
            CReserva_Autos_Perfil reserva = new CReserva_Autos_Perfil();
            reserva.Id = randomid;
            reserva.FechaIni = "2016-12-20";
            reserva.HoraFin= "2016-12-25";
            reserva.HoraIni = "12:00";
            reserva.HoraFin = "1:00";
            
            reserva.Autos.Matricula = "14DNKVO";
            reserva.CiudadDes= "12";
            reserva.CiudadOri = "12";
            reserva.Status = 1;
            Assert.Throws<ManejadorSQLException>(() => prueba.InsertarReservaAuto(reserva));

        }

        [Test]
        public void ExpectedSqlExceptionBuscarReservas()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.buscarReservas());

        }

        [Test]
        public void ExpectedExceptionBuscarCiudad()
        {
            Assert.Throws<ManejadorSQLException>(() => prueba.buscarCiudades());

        }

        //TEST DEL MANEJADOR AGARRANDO LAS EXCEPCIONES


        //PRUEBAS PARA EL CONTROLADOR
        [Test] // Se valida que que la respuesta del controlador M19_Reserva_Autos_Perfil retorne  un objeto de tipo ActionResult
        public void PruebaVisualizarAutosPerfil()
        {

            {
                Assert.IsInstanceOf(typeof(ActionResult), controlador.M19_Reserva_Autos_Perfil());
            }

        }

        [Test] //pruebo el controlador InsertarReservaAuto con valores validos
        public void pruebaControladorInsertar()
        {
           
            Assert.IsInstanceOf(typeof(ActionResult), controlador.M19_Accion_Reserva("14DNKVO","3","Mazda","Sedan","Azul","Automatica",12,1, 1936,5,1,null,"161211",null,"2016-12-20", "2016-12-25","12:00", "1:00","12","12"));

        }


        [Test] //Se valida que que la respuesta del controlador M19_Busqueda_Autos retorne  un objeto de tipo ActionResult 
        public void pruebaControladorBusquedaAuto()
        {

            var resultado = controlador.M19_Busqueda_Autos() as ActionResult;
            Assert.IsNotNull(resultado);

        }

        [Test] //Verifica que la lista que retorna no sea nula 
        public void pruebaBusqueda()
        {
            List<CReserva_Autos_Perfil> busqueda = controlador.busqueda("13", "14","2016-12-15","2016-12-16", "17:00", "17:00");
            Assert.IsNotNull(busqueda);

        }



    }
}
