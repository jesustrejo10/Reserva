using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.M10;
using BOReserva.Models.gestion_restaurantes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitReserva.BO.gestion_restaurantes
{
    /// <summary>
    /// Clase para pruebas unitarias de Patron Comando M10
    /// </summary>
    [TestFixture]
    class M10_PruebaComandos
    {
        #region Atributos
        Entidad lugar;
        Entidad restaurant;
        Entidad restaurante;
        Boolean Resultado;
        IDAORestaurant restaurantDao;
        #endregion

        #region Setup Tests
        [SetUp]
        public void Iniciar()
        {
            lugar = FabricaEntidad.crearLugar(12, "");
            restaurant = FabricaEntidad.crearRestaurant();
            restaurante = FabricaEntidad.crearRestaurant();
        }
        #endregion

        #region TearDown
        [TearDown]
        public void Limpiar()
        {
            lugar = null;
            restaurant = null;
        }

        #endregion

        #region Pruebas

        /// <summary>
        /// Metodo consultar restaurant por id de ciudad
        /// </summary>
        [Test]
        public void M10_ComandoConsultarRestaurant()
        {
          
            Command<List<Entidad>> comando = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, lugar);
            List<Entidad> ListaRestaurant = comando.ejecutar();

            //Como se devuelve una lista de restaurantes segun el id de lugar se verifica si los 
            //no estan nulos
            foreach (Entidad rest in ListaRestaurant)
            {
                Assert.IsNotNull(((CRestauranteModelo)rest).id);
                Assert.IsNotNull(((CRestauranteModelo)rest).nombre);
                Assert.IsNotNull(((CRestauranteModelo)rest).descripcion);
                Assert.IsNotNull(((CRestauranteModelo)rest).direccion);
                Assert.IsNotNull(((CRestauranteModelo)rest).Telefono);
                Assert.IsNotNull(((CRestauranteModelo)rest).horarioApertura);
                Assert.IsNotNull(((CRestauranteModelo)rest).horarioCierre);
                Assert.IsNotNull(((CRestauranteModelo)rest).idLugar);

            }
        }
        /*
        /// <summary>
        /// Metodo consultar restaurant por Id
        /// </summary>
        [Test]
        public void M10_ComandoConsultarRestaurantId()
        {
            restaurant._id = 1;
            Command<Entidad> comando = (Command<Entidad>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.CONSULTAR_ID, restaurant);
            Entidad rest = comando.ejecutar();
            //Verificacion si los parametros devueltos ara la base de datos son correctos
            Assert.AreEqual(((CRestauranteModelo)rest).id, 1);
            Assert.AreEqual(((CRestauranteModelo)rest).nombre, "Taxco");
            Assert.AreEqual(((CRestauranteModelo)rest).descripcion, "Hamburgueseria");
            Assert.AreEqual(((CRestauranteModelo)rest).direccion, "La Paz");
            Assert.AreEqual(((CRestauranteModelo)rest).Telefono, "0212-5896663");
            Assert.AreEqual(((CRestauranteModelo)rest).horarioApertura, "09:00");
            Assert.AreEqual(((CRestauranteModelo)rest).horarioCierre, "21:00");
            Assert.AreEqual(((CRestauranteModelo)rest).idLugar, 12);
        }
        */
        /// <summary>
        /// Metodo para probar que ha sido creado en la base de datos 
        /// </summary>
        [Test]
        public void M10_ComandoCrear()
        {
            
            //Parametros para crear el nuevo registro en la base de datos
            ((CRestauranteModelo)restaurant).nombre = "Cometelo Todo";
            ((CRestauranteModelo)restaurant).descripcion = "Comida Criolla";
            ((CRestauranteModelo)restaurant).direccion = "La californea";
            ((CRestauranteModelo)restaurant).Telefono = "0212-5562199";
            ((CRestauranteModelo)restaurant).horarioApertura = "09:00";
            ((CRestauranteModelo)restaurant).horarioCierre = "21:00";
            ((CRestauranteModelo)restaurant).idLugar = 12;

            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CREAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, restaurant);

            Resultado = comando.ejecutar();

            //Verificar si el resultado fue exitoso
            Assert.AreEqual(Resultado, true);
        }

        /// <summary>
        /// Metodo para modificar datos del restaurant
        /// </summary>
        [Test]
        public void M10_ComandoModificar()
        {
           
            //Parametros a modificar en la base de datos

            //Id del restaurante a modificar
            ((CRestauranteModelo)restaurant).id = 107;

            //Parametros que va a ser modificados
            ((CRestauranteModelo)restaurant).nombre = "ItaliaFood";
            ((CRestauranteModelo)restaurant).descripcion = "Comida Italiana";
            ((CRestauranteModelo)restaurant).direccion = "Antimano";
            ((CRestauranteModelo)restaurant).Telefono = "0212-5896699";
            ((CRestauranteModelo)restaurant).horarioApertura = "09:00";
            ((CRestauranteModelo)restaurant).horarioCierre = "21:00";
            ((CRestauranteModelo)restaurant).idLugar = 12;

            //Veridicar si la modificacion fue exitosa
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ACTUALIZAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, restaurant);
            Assert.AreEqual(comando.ejecutar(), true);

        }

        /// <summary>
        /// Metodo para verificar que se listan los restauntes nombre y id
        /// </summary>
        [Test]
        public void M10_ComandoListarRestaurantes()
        {
            Command<List<Entidad>> comandos = (Command<List<Entidad>>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR, FabricaComando.comandoRestaurant.LISTAR_RESTAURANT, null);
            List<Entidad> ListaRestaurant = comandos.ejecutar();

            //Ciclo para verificar que la filas de la consulta no se encuentran en null
            foreach (Entidad rest in ListaRestaurant)
            {
                Assert.IsNotNull(((CRestauranteModelo)rest).id);
                Assert.IsNotNull(((CRestauranteModelo)rest).nombre);
            }

        }

        /// <summary>
        /// Metodo para verificar que se elimina registro de restaurant de la Base de Datos
        /// </summary>
        [Test]
        public void M10_ComandoEliminar()
        {
            restaurantDao = FabricaDAO.RestaurantBD();

            //Parametros para crear el nuevo registro en la base de datos
            ((CRestauranteModelo)restaurant).nombre = "ItalyFood";
            ((CRestauranteModelo)restaurant).descripcion = "Comida Italiana";
            ((CRestauranteModelo)restaurant).direccion = "Antimano";
            ((CRestauranteModelo)restaurant).Telefono = "0212-5896699";
            ((CRestauranteModelo)restaurant).horarioApertura = "09:00";
            ((CRestauranteModelo)restaurant).horarioCierre = "21:00";
            ((CRestauranteModelo)restaurant).idLugar = 12;
           
            Command<Boolean> comando = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CREAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, restaurant);
            //Verificar si el resultado fue exitoso
            Assert.AreEqual(comando.ejecutar(), true);

            Entidad rest = FabricaEntidad.crearRestaurant();
            String StringConection = restaurantDao.ConectionString();
            String sqlString = "SELECT TOP 1 rst_id FROM Restaurante where fk_lugar = 12 ORDER BY rst_id DESC;";
            SqlConnection conexion = new SqlConnection(StringConection);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sqlString, conexion);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int idRestaurant = int.Parse(reader["rst_id"].ToString());

            restaurante._id = idRestaurant;
            Command<Boolean> comando1 = (Command<Boolean>)FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ELIMINAR, BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, restaurante);
           
            //Verificar si el resultado fue exitoso
            Assert.AreEqual(comando1.ejecutar(), true);
        }
        #endregion
    }
}
