using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Controllers.PatronComando;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.Controllers.PatronComando.M09;

namespace TestUnitReserva.BO.gestion_hoteles
{
    [TestFixture]
    class TestLugar
    {
       
        private Dictionary<int, Entidad> mapEntidad;
        private IDAO daoPais;
        private IDAO daoCiudad;

        [Test]
        public void M09_DAOPaisObtenerTodos()
        {
            daoPais = FabricaDAO.instanciarDaoPais();
            mapEntidad = daoPais.ConsultarTodos();
            Assert.NotNull(mapEntidad);
            Assert.AreEqual(mapEntidad.ContainsKey(65), true); 

        }

        [Test]
        public void M09_DAOCiudadObtenerTodos()
        {
            daoCiudad = FabricaDAO.instanciarDaoCiudad();
            mapEntidad = daoCiudad.ConsultarTodos();
            Assert.NotNull(mapEntidad);
            Assert.AreEqual(mapEntidad.ContainsKey(65), false);
            Assert.AreEqual(mapEntidad.ContainsKey(66), true);

        }

        [Test]
        public void M09_CO_ObtenerTodos()
        {
            Command<Dictionary<int, Entidad>> comando = FabricaComando.crearM09ObtenerPaises();
            Dictionary<int,Entidad> paisesConCiudad = comando.ejecutar();
            Assert.NotNull(paisesConCiudad);
            Pais venezuela = (Pais) paisesConCiudad[11];
            Assert.NotNull(venezuela);

            Assert.AreEqual(venezuela._ciudades.ContainsKey(18), false); 
        }

        [Test]
        public void M09_CO_obtenerCiudadesporFK()
        {
            daoCiudad = FabricaDAO.instanciarDaoCiudad();
            mapEntidad = daoCiudad.ConsultarTodos();

            IM09_COObtenerPaises comando = (IM09_COObtenerPaises)FabricaComando.crearM09ObtenerPaises();
            Dictionary<int, Entidad> paisesSinCiudad = comando.obtenerCiudadesPorPais(mapEntidad,11);
            Assert.NotNull(paisesSinCiudad);
            Assert.AreEqual(paisesSinCiudad.ContainsKey(18), false);
        }

    }
}
