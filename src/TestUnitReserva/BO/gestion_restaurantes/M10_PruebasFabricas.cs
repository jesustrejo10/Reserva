using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Model;
using BOReserva.M10;
using BOReserva.Views.gestion_restaurantes.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace TestUnitReserva.BO.gestion_restaurantes
{
    [TestFixture]
    class M10_PruebasFabricas
    {
        #region FabricaVista
        [Test]
        public void M10_PruebaAsignarItemsComboBox()
        {
            Assert.IsInstanceOf(typeof(SelectList), FabricaVista.asignarItemsComboBox(new List<Object>(),"","")); 
        }

        [Test]
        public void M10_PruebaAsignarItemsConPosicion()
        {
            List<String> lista = new List<String> { "Posicion1", "Posicion2", "Posicion3" };
            SelectList listaS=FabricaVista.asignarItemsComboBoxConPosicion(new List<Object>(), "", "","Posicion2");
            Assert.AreEqual(listaS.SelectedValue, "Posicion2");
        }
        #endregion

        #region FabricaDAO
        [Test]
        public void M10_PruebaRestaurantBD()
        {
            Assert.IsInstanceOf(typeof(DAORestaurant), FabricaDAO.RestaurantBD());
        }

        [Test]
        public void M10_PruebaListarHorario()
        {
        List<String> lista = new List<String>
            { "07:00", "08:00", "09:00", "10:00", "11:00",
              "12:00", "13:00", "14:00", "15:00", "16:00",
              "17:00", "18:00", "19:00", "20:00", "21:00",
              "22:00", "23:00", "00:00" };
        Assert.AreEqual(lista, FabricaDAO.listarHorario());
        }

       

        [Test]
        public void M10_PruebaAsignarParametro()
        {
            Parametro p = new Parametro("Numero", SqlDbType.Int, "32", false);
            Assert.AreEqual(p, FabricaDAO.asignarParametro("Numero", SqlDbType.Int, "32", false));
        }

        [Test]
        public void M10_PruebaAsignarParametroSinValor()
        {
            Parametro p = new Parametro("Numero", SqlDbType.Int, false);
            Assert.AreEqual(p, FabricaDAO.asignarParametro("Numero", SqlDbType.Int, false));
        }

        [Test]
        public void M10_PruebaAsignarListaDeParametro()
        {
            Assert.IsInstanceOf(typeof(List<Parametro>), FabricaDAO.asignarListaDeParametro());
        }

      

     
        /*
        [Test]
        public void M10_PruebaAsignarTablaDeDatos()
        {
           Assert.IsInstanceOf(typeof(DataTable), FabricaDAO.asignarTablaDeDatos());
        }*/

      

        #endregion
    }
}
