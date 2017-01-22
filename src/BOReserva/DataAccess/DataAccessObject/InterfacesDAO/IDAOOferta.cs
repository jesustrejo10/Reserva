using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOOferta : IDAO
    {
        //Aquí van los métodos propios para las ofertas

        /// <summary>
        /// Consultar todas las ofertas
        /// </summary>
        /// <returns>Lista de las ofertas.</returns>
        List<Entidad> ConsultarTodos();

        /// <summary>
        /// Modifica la entdad
        /// </summary>
        /// <param name="e">Entidad para modificar en la bd</param>
        /// <returns>1 si modificó, 0 si no.</returns>
        int Modificar(Entidad e, int id);

        String disponibilidadOferta(Entidad e, int disponibilidad);
    }
}

