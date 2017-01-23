using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    public interface IDAOReservaAutomovil : IDAO
    {
        List<Entidad> ListarLugar();

        Entidad consultarReservaId(Entidad objeto);


        List<Entidad> ConsultarAutosPorIdCiudad(Entidad objeto);

        List<Entidad> ConsultarAutosPorIdCiudades(Entidad objeto);

        bool Crear(Entidad objeto);

        new bool Modificar(Entidad objeto);

        bool Eliminar(Entidad objeto);

        List<Entidad> Consultar(Entidad objeto);
    }
}