using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.M10
{
    /// <summary>
    /// Inteface propia de clase DaoRestaurant
    /// </summary>
    public interface IDAORestaurant : IDAO
    {
        /// <summary>
        /// Metodo para listar las ciudades
        /// </summary>
        /// <returns></returns>
        List<Entidad> ListarLugar();

        /// <summary>
        /// Consultar restaurante por ID
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        Entidad consultarRestaurantId(Entidad objeto);

        /// <summary>
        /// Crear en la Base de Datos Restaurantes 
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        bool Crear(Entidad objeto);

        /// <summary>
        /// Modificar los restaurantes en la Base de Datos
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        bool Modificar(Entidad objeto);

        /// <summary>
        /// Eliminar Restaurant de Base de Datos
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        bool Eliminar(Entidad objeto);

        /// <summary>
        /// Consultar Todos los resturantes basados en el Id de la Ciudad
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        List<Entidad> Consultar(Entidad objeto);

        /// <summary>
        /// Listar todos los restaurantes nombre y Id
        /// </summary>
        /// <returns></returns>
        List<Entidad> ListarRestaurantes();
    }
}
