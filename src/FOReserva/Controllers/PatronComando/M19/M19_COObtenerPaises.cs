using FOReserva.Controllers.PatronComando.M19;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando
{
    /// <summary>
    /// 
    /// </summary>
    public class M19_COObtenerPaises : Command<Dictionary<int, Entidad>>, IM19_COObtenerPaises
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoPais = FabricaDAO.instanciarDaoPais();
            Dictionary<int, Entidad> paisesSinCiudad = daoPais.ConsultarTodos();
            IDAO daoCiudad = FabricaDAO.instanciarDaoCiudad();
            Dictionary<int, Entidad> ciudades = daoCiudad.ConsultarTodos();
            Dictionary<int, Entidad> paisesConCiudad = new Dictionary<int, Entidad>();

            foreach (var pais in paisesSinCiudad)
            {
                Pais p = (Pais)pais.Value;
                p._ciudades = obtenerCiudadesPorPais(ciudades, p._id);
                paisesConCiudad.Add(pais.Key, p);
            }



            return paisesConCiudad;
        }



        Dictionary<int, Entidad> IM19_COObtenerPaises.obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais)
        {
            Dictionary<int, Entidad> ciudadesPorPais = new Dictionary<int, Entidad>();
            foreach (var item in ciudades)
            {
                Ciudad ciudad = (Ciudad)item.Value;
                if (ciudad._fkPais == fkPais)
                {
                    ciudadesPorPais.Add(item.Key, item.Value);
                }
                // do something with entry.Value or entry.Key
            }

            return ciudadesPorPais;
        }

        private Dictionary<int, Entidad> obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais)
        {
            Dictionary<int, Entidad> ciudadesPorPais = new Dictionary<int, Entidad>();
            foreach (var item in ciudades)
            {
                Ciudad ciudad = (Ciudad)item.Value;
                if (ciudad._fkPais == fkPais)
                {
                    ciudadesPorPais.Add(item.Key, item.Value);
                }
                // do something with entry.Value or entry.Key
            }

            return ciudadesPorPais;
        }


        public int obtenerIdentificadorCiudad(String ciudad)
        {
            int id;
            DAOCiudad daoPais = (DAOCiudad)FabricaDAO.instanciarDaoCiudad();
            id = daoPais.obtenerIDciudad(ciudad);
            return id;
        }
    }
}