using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Interfaz que posee el metodo de obtenerCiudaddesPorPais
    /// </summary>
    public interface IM09_COObtenerPaises
    {
        
        /// <summary>
        /// Metodo que retorna las ciudades de un pais
        /// </summary>
        /// <param name="ciudades">Recibe todas las ciudades</param>
        /// <param name="fkPais">Recibe un id de pais especifico</param>
        /// <returns>Retorna para el pais indicado todas las ciudades</returns>
        Dictionary<int, Entidad> obtenerCiudadesPorPais(Dictionary<int, Entidad> ciudades, int fkPais);
    }
}
