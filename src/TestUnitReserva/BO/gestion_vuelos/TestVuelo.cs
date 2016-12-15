using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_vuelo;
using BOReserva.Servicio;
using BOReserva.Servicio.Servicio_Vuelos;
using System.Diagnostics;
using System.Data.SqlClient;

namespace TestUnitReserva.BO.gestion_vuelos
{
    [TestFixture]
    class TestVuelo
    {
        manejadorSQL_Vuelos sql = new manejadorSQL_Vuelos();
        String Codigo = "AA123";
        String Origen = "Caracas";
        String Destino = "Maracaibo";
        String Despegue = "2016-12-15 09:00:00";
        String Status = "activo";
        String Aterrizaje = "2016-12-15 10:10:00";
        String Matricula = "1";


        [Test]
        public void M04_CrearVuelo()
        {
            Boolean resultado = sql.insertarVuelo(Codigo, Origen, Destino, Despegue, Status, Aterrizaje, Matricula);

            //Aquí pruebo que al insertar un vuelo de manera correcta la función devuelva true
            Assert.Equals(resultado, true);
            //Aquí pruebo que el insertar vuelo no me deje agregar atributos vacíos
            Boolean resultadoconnull = sql.insertarVuelo(null, null, null, null, null, null, null);
            Assert.AreEqual(resultadoconnull, false);
            //Aquí pruebo que no me deje insertar una codigo de vuelo repetido
            String Codigo2 = "V507";
            Boolean resultadocodigorepetido = sql.insertarVuelo(Codigo2, Origen, Destino, Despegue, Status, Aterrizaje, Matricula);
            Assert.AreEqual(resultadocodigorepetido, false);
        }

        [Test]
        public void M04_BuscarIdRutaVuelo()
        {

            int busqueda = sql.idRutaVuelo(Origen, Destino);
            //Pruebo que al buscar una ruta con una ciudad de origen y una ciudad destino dada me devuelva un id existente.
            Assert.NotNull(busqueda);
            Assert.That(() => sql.idRutaVuelo(null,null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void M04_BuscarCiudadesDestino()
        {

            List<CCrear_Vuelo> consulta = sql.consultarDestinos(Origen);
            //Pruebo que al buscar una lista de ciudades destino de una ciudad origen dada me devuelva una lista existente.
            Assert.IsNotNull(consulta);
            // Ya se que una de las ciudades destino de Caracas es Maracaibo
            //Assert.AreEqual(consulta, "Maracaibo");
            Assert.That(() => sql.consultarDestinos(null), Throws.TypeOf<NullReferenceException>());

        }
        [Test]
        public void M04_BuscarAviones()
        {
            List<CCrear_Vuelo> buscar = sql.buscarAviones(Origen, Destino);
            //Pruebo que al ingresar una cuidad origen y una ciudad destino me devuelva una lista existente de aviones que cubran la distancia de dicha ruta.
            Assert.IsNotNull(buscar);
            //Ya se que la matricula de uno de los aviones que cubre la ruta de Caracas a Maracaibo es IAM-123
            //Assert.AreEqual(buscar, "IAM-123");
        }

        [Test]
        public void M04_CargarOrigenes()
        {
            List<CCrear_Vuelo> cargar = sql.cargarOrigenes();
            // Pruebo que al cargar un Origen no me retorne una lista nula.
            Assert.IsNotNull(cargar);
            Assert.That(() => sql.cargarOrigenes(), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void M04_Detalle_Avion_Modelo()
        {
            String matriculaAvion = "IAM-123";
            String modelo = sql.modeloAvion(matriculaAvion);
            //verifico que modelo de avion le corresponde a la martricula IAM-123 el cual es Boeing 777.
            Assert.AreEqual(modelo, "Boeing 777");
            //Verifico que no me traiga un modelo nulo.
            Assert.IsNotNull(modelo);
            Assert.That(() => sql.modeloAvion(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void M04_DetalleAvion_Pasajeros()
        {
            String matriculaAvion = "IAM-123";
            String pasajeros = sql.pasajerosAvion(matriculaAvion);
            //verifico la capacidad maxima del avion con matricula IAM-123 la cual es 40
            Assert.AreEqual(pasajeros, 40);
            //Verifico que no me traiga una capacidad nula.
            Assert.IsNotNull(pasajeros);
            //pruebo que al buscar una capacidad de un avion con una matricula nula, dispare la excepcion de tipo NullReferenceException
            Assert.That(() => sql.pasajerosAvion(null), Throws.TypeOf<NullReferenceException>());

        }

         [Test]
        public void M04_distanciaAvion()
        {
            String matriculaAvion = "IAM-123";
            String distancia = sql.distanciaAvion(matriculaAvion);
            Assert.IsNotNull(distancia);
            Assert.AreEqual(distancia, 1900);
            Assert.That(() => sql.distanciaAvion(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void M04_VelocidadAvion()
         {
             String matriculaAvion = "IAM-123";
             String velocidad = sql.velocidadAvion(matriculaAvion);
             Assert.IsNotNull(velocidad);
             Assert.AreEqual(velocidad, 1900);
             Assert.That(() => sql.distanciaAvion(null), Throws.TypeOf<NullReferenceException>());


         }
        [Test]
        public void M04_ListarVuelos()
        {
            List<CVuelo> lista = sql.MListarvuelosBD();
            Assert.IsNotNull(lista);
        }


        [Test]
        public void M04_BuscarCiudadOrigen()
        {
            int id= 5;
            String origen = sql.MBuscarciudadOrigen(id);
            Assert.IsNotNull(origen);
        }

        [Test]
        public void M04_BuscarCiudadDestino()
        {
            int id = 5;
            String destino = sql.MBuscarciudadDestino(id);
            Assert.IsNotNull(destino);
        }

        [Test]
        public void M04_BuscarAvion()
        {
            int idavion = 1;
            String avion = sql.MBuscarciudadDestino(idavion);
            Assert.IsNotNull(avion);
        }

        [Test]
        public void M04_MostrarVuelo()
        {
            int idvuelo = 20;
            CVuelo avion = sql.MMostrarvueloBD(idvuelo);
            Assert.IsNotNull(avion);
        }

        [Test]
        public void M04_ModificarBD()
        {
            int idvuelo = 6;
            CVueloModificar vuelo = sql.MModificarBD(idvuelo);
            Assert.IsNotNull(vuelo);
        }



        [Test]
        public void M04_DesactivarVuelo()
        {
            int idvuelo = 20;
            Boolean resultado = sql.MDesactivarVuelo(idvuelo);

            //Aquí pruebo que al desactivar un vuelo de manera correcta la función devuelva true
            Assert.Equals(resultado, true);
            //Aqui pruebo que no me pueda desactivar un vuelo que ya ha sido desactivado
            Boolean resultadocodigorepetido = sql.MDesactivarVuelo(7);
            Assert.AreEqual(resultadocodigorepetido, false);
            Assert.That(() => sql.MDesactivarVuelo(null), Throws.TypeOf<NullReferenceException>());

        }


        [Test]
        public void M04_ActivarVuelo()
        {
            int idvuelo = 20;
            Boolean resultado = sql.MActivarVuelo(idvuelo);

            //Aquí pruebo que al activar un vuelo de manera correcta la función devuelva true
            Assert.Equals(resultado, true);
            //Aqui pruebo que no me pueda activar un vuelo que ya ha sido activado
            Boolean resultadocodigorepetido = sql.MDesactivarVuelo(7);
            Assert.AreEqual(resultadocodigorepetido, false);
            Assert.That(() => sql.MActivarVuelo(null), Throws.TypeOf<NullReferenceException>());

        }

        [Test]
        public void M04_CodigoUnicoVuelo()
        {
            String idvuelo = "CD780";
            String codigovuelo = sql.codVueloUnico(idvuelo);
            Assert.IsNotNull(codigovuelo);
            Assert.That(() => sql.codVueloUnico(null), Throws.TypeOf<NullReferenceException>());

        }
        [Test]
        public void M04_ListarciudadesOrigenBD()
        {
            String[] listaorigenes = sql.MListarciudadesOrigenBD();
            //Pruebo que al llamar la funcion MListarciudadesOrigenBD() no me traiga una lista nula; 
            Assert.IsNotNull(listaorigenes);

        }
        [Test]
        public void M04_ListarciudadesDestinoBD()
        {
            String origen = "Caracas";
            String[] listadestinos = sql.MListarciudadesDestinoBD();
            //Pruebo que al llamar la funcion MListarciudadesOrigenBD() no me traiga una lista nula; 
            Assert.IsNotNull(listadestinos);

        }

        [Test]
        public void M04_ConsultarDestinosModificar()
        {
            String origen = "Caracas";
            List<CVueloModificar> consultar = sql.consultarDestinosModificar(origen);
            // Pruebo que al consultar una lista de destinos no me retorne una lista nula.
            Assert.IsNotNull(consultar);
            Assert.That(() => sql.consultarDestinosModificar(), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void M04_ListaravionesValidadosBD()
        {
            String[] listaviones = sql.MListaravionesValidadosBD(Origen,Destino);
            //Pruebo que al llamar la funcion MListarciudadesOrigenBD() no me traiga una lista nula; 
            Assert.IsNotNull(listadestinos);

        }
        [Test]
        public void M04_BuscarAvionesModificar()
        {
            List <CVueloModificar> cargar = sql.buscarAvionesModificar(Origen, Destino);
            // Pruebo que al buscra una lista de aviones posibles para cubrir una ruta no me retorne una lista nula.
            Assert.IsNotNull(cargar);
            Assert.That(() => sql.cargarOrigenes(), Throws.TypeOf<NullReferenceException>());
        }
    }




}