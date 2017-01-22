﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.M10;
using BOReserva.Models.gestion_restaurantes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitReserva.BO.gestion_restaurantes
{
    [TestFixture]
    class M10_TestDaoRestaurant
    {
        #region Atributos
        Entidad lugar;
        Entidad restaurant;
        List<Entidad> ListaRestaurant;
        Boolean Resultado;
        IDAORestaurant restaurantDao;
        #endregion

        #region Setup Tests
        [SetUp]
        public void Iniciar()
        {
            lugar = FabricaEntidad.crearLugar(12,"");
            restaurant = FabricaEntidad.crearRestaurant();
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
        public void DaoConsultarRestaurant()
        {
            restaurantDao = FabricaDAO.RestaurantBD();
            ListaRestaurant = restaurantDao.Consultar(lugar);

            //COmo se devuelve una lista de restaurantes segun el id de lugar se verifica si los 
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

        /// <summary>
        /// Metodo consultar restaurant por Id
        /// </summary>
        [Test]
        public void DaoConsultarRestaurantId()
        {
            restaurantDao = FabricaDAO.RestaurantBD();
            restaurant._id = 1;
            Entidad rest = restaurantDao.consultarRestaurantId(restaurant);
            //Verificacion si los parametros devueltos ara la base de datos son correctos
            Assert.AreEqual(((CRestauranteModelo)rest).id,1);
            Assert.AreEqual(((CRestauranteModelo)rest).nombre,"Taxco");
            Assert.AreEqual(((CRestauranteModelo)rest).descripcion, "Hamburgueseria");
            Assert.AreEqual(((CRestauranteModelo)rest).direccion, "La Paz");
            Assert.AreEqual(((CRestauranteModelo)rest).Telefono,"0212-5896663");
            Assert.AreEqual(((CRestauranteModelo)rest).horarioApertura, "09:00");
            Assert.AreEqual(((CRestauranteModelo)rest).horarioCierre, "21:00");
            Assert.AreEqual(((CRestauranteModelo)rest).idLugar,12);
         }

        /// <summary>
        /// Metodo para probar que ha sido creado en la base de datos 
        /// </summary>
        [Test]
        public void DaoCrear()
        {
            restaurantDao = FabricaDAO.RestaurantBD();

            //Parametros para crear el nuevo registro en la base de datos
            ((CRestauranteModelo)restaurant).nombre = "ItalyFood";
            ((CRestauranteModelo)restaurant).descripcion = "Comida Italiana";
            ((CRestauranteModelo)restaurant).direccion = "Antiamano";
            ((CRestauranteModelo)restaurant).Telefono = "0212-5896699";
            ((CRestauranteModelo)restaurant).horarioApertura = "09:00";
            ((CRestauranteModelo)restaurant).horarioCierre = "21:00";
            ((CRestauranteModelo)restaurant).idLugar = 12;
            Resultado = restaurantDao.Crear(restaurant);

            //Verificar si el resultado fue exitoso
            Assert.AreEqual(Resultado,true);
        }

        /// <summary>
        /// Metodo para modificar datos del restaurant
        /// </summary>
        [Test]
        public void DaoModificar()
        {
            restaurantDao = FabricaDAO.RestaurantBD();

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
            Resultado = restaurantDao.Modificar(restaurant);
            Assert.AreEqual(Resultado,true);

        }

        /// <summary>
        /// Metodo para verificar que se listan los restauntes nombre y id
        /// </summary>
        [Test]
        public void DaoListarRestaurantes()
        {
            restaurantDao = FabricaDAO.RestaurantBD();
            ListaRestaurant = restaurantDao.ListarRestaurantes();

            //Ciclo para verificar que la filas de la consulta no se encuentran en null
            foreach (Entidad rest in ListaRestaurant)
            {
                Assert.IsNotNull(((CRestauranteModelo)rest).id);
                Assert.IsNotNull(((CRestauranteModelo)rest).nombre);
            }

        }
        #endregion
    }
}
