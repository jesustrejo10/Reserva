using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOAutomovil : IDAO
    {
        bool ActivarDesactivar(Entidad e);
        bool Agregar(Entidad e);
        bool Modificar(Entidad e);
        bool Eliminar(Entidad e);
        Entidad Consultar(Entidad e);
        List<Entidad> ConsultarTodos();
        bool existeMatricula(Entidad e);
        List<SelectListItem> listarAnios();
        List<SelectListItem> listarCantidad(int cant);
        List<SelectListItem> listarColores();
    }
}
