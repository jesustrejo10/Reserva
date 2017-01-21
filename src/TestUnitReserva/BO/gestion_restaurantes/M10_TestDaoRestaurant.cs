using BOReserva.DataAccess.DataAccessObject;
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
            
        }
        #endregion

        #region TearDown
        [TearDown]
        public void Limpiar()
        {
       //     lugar = null;

        }

        #endregion

        #region Pruebas
        [Test]
        public void DaoConsultarRestaurant()
        {
            restaurantDao = FabricaDAO.RestaurantBD();
            ListaRestaurant = restaurantDao.Consultar(lugar);

            Assert.IsInstanceOf(typeof(Lugar), lugar);
            //foreach (Entidad rest in ListaRestaurant)
            //{
            //   Assert.IsNotNull(((CRestauranteModelo)rest).nombre);
            //}
        }


        #endregion
    }
}
