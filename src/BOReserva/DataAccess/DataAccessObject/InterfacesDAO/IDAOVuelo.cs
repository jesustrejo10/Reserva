using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;

namespace BOReserva.DataAccess.DAO
{
    interface IDAOVuelo : IDAO
    {
        List<Entidad> ConsultarTodos();

        bool Eliminar(Entidad entidad);

        bool CambiarStatus(int vuelo);

        List<Entidad> ConsultarAvionRuta(int idRuta);

        bool BuscarCodigo(String Codigo);

        Entidad ConsultarDatosAterrizaje(int idRuta, DateTime fechaTiempo, int idAvion);
        
        List<Entidad> ConsultarLugarDestino(int lugarO);

        List<Entidad> ConsultarLugarOrigen();

    }
}