using BOReserva.Controllers.PatronComando;
using BOReserva.Controllers.PatronComando.M10;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.M10;
using BOReserva.M10.Comando.gestion_restaurantes;
using BOReserva.Models.gestion_restaurantes;
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
            //Parametro p = new Parametro("Numero", SqlDbType.Int, "32", false);
            Parametro p2 = FabricaDAO.asignarParametro("Numero", SqlDbType.Int, "32", false);
            /*bool igual = false;
            if ((p.etiqueta.Equals(p2.etiqueta)) && (p.tipoDato.Equals(p2.tipoDato))
                && (p.valor.Equals(p2.valor)) && (p.esOutput.Equals(p2.esOutput)))
                igual = true;
            Assert.IsTrue(igual);*/
            Assert.IsInstanceOf(typeof(Parametro), p2);
        }

        [Test]
        public void M10_PruebaAsignarParametroSinValor()
        {
            //Parametro p = new Parametro("Numero", SqlDbType.Int, false);
            Parametro p2 = FabricaDAO.asignarParametro("Numero", SqlDbType.Int, false);
            /*bool igual = false;
            if ((p.etiqueta.Equals(p2.etiqueta)) && (p.tipoDato.Equals(p2.tipoDato))
                 && (p.esOutput.Equals(p2.esOutput)))
                igual = true;
            Assert.IsTrue(igual);*/
            Assert.IsInstanceOf(typeof(Parametro), p2);
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

        #region FabricaEntidad
        [Test]
        public void M10_PruebaCrearRestaurant()
        {
            Assert.IsInstanceOf(typeof(CRestauranteModelo), FabricaEntidad.crearRestaurant("nombre", "direccion", "telefono", "descripcion", "horarioApertura", "horarioCierre", 0));
        }

        [Test]
        public void M10_PruebaCrearRestaurantConID()
        {
            Assert.IsInstanceOf(typeof(CRestauranteModelo), FabricaEntidad.crearRestaurant(0,"nombre", "direccion", "telefono", "descripcion", "horarioApertura", "horarioCierre", 0));
        }

        [Test]
        public void M10_PruebaCrearRestaurantSinValor()
        {
            Assert.IsInstanceOf(typeof(CRestauranteModelo), FabricaEntidad.crearRestaurant());
        }

        [Test]
        public void M10_PruebaCrearLugar()
        {
            Assert.IsInstanceOf(typeof(Lugar), FabricaEntidad.crearLugar(0, "lugar"));
        }

        [Test]
        public void M10_PruebaCrearListaLugar()
        {
            Assert.IsInstanceOf(typeof(List<Lugar>), FabricaEntidad.crearListaLugar());
        }

        [Test]
        public void M10_PruebaCrearListaRestaurant()
        {
            Assert.IsInstanceOf(typeof(List<CRestauranteModelo>), FabricaEntidad.crearListaRestarant());
        }

        [Test]
        public void M10_PruebaAsignarListaDeEntidades()
        {
            Assert.IsInstanceOf(typeof(List<Entidad>), FabricaEntidad.asignarListaDeEntidades());
        }
        #endregion

        #region FabricaComando

        [Test]
        public void M10_PruebaComandosRestaurant_Crear()
        {
            Assert.IsInstanceOf(typeof(M10_COCrearRestaurant),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CREAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO,null));
        }

        [Test]
        public void M10_PruebaComandosRestaurant_Eliminar()
        {
            Assert.IsInstanceOf(typeof(M10_COEliminarRestaurant),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ELIMINAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO,null));
        }

        [Test]
        public void M10_PruebaComandosRestaurant_Actualizar()
        {
            Assert.IsInstanceOf(typeof(M10_COActualizarRestaurant),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.ACTUALIZAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, null));
        }

        [Test]
        public void M10_PruebaComandosRestaurant_ConsultarNulo()
        {
            Assert.IsInstanceOf(typeof(M10_COConsultarRestaurant),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.NULO, null));
        }

        [Test]
        public void M10_PruebaComandosRestaurant_ConsultarID()
        {
            Assert.IsInstanceOf(typeof(M10_COConsultarRestaurantId),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.CONSULTAR_ID, null));
        }

        [Test]
        public void M10_PruebaComandosRestaurant_ListarRestaurant()
        {
            Assert.IsInstanceOf(typeof(M10_COListarRestaurantId),
                FabricaComando.comandosRestaurant(FabricaComando.comandosGlobales.CONSULTAR,
                BOReserva.Controllers.PatronComando.FabricaComando.comandoRestaurant.LISTAR_RESTAURANT, null));
        }

        [Test]
        public void M10_PruebaComandosVistaRestaurant_CargarLugar()
        {
            Assert.IsInstanceOf(typeof(M10_COConsultarLugar),
                FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_LUGAR));
        }

        [Test]
        public void M10_PruebaComandosVistaRestaurant_CargarHora()
        {
            Assert.IsInstanceOf(typeof(M10_COCargarHorario),
                FabricaComando.comandosVistaRestaurant(FabricaComando.comandoVista.CARGAR_HORA));
        }

        
        #endregion

    }
}
