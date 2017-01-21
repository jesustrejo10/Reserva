using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    /// <summary>
    /// Intefaz de los metodos detallados del modulo de reclamos
    /// </summary>
    public interface IDAOReclamo : IDAO
    {

        //Entidad consultarReservaId(Entidad objeto);

        List<Reclamo> ConsultarReclamosPorUsuario(int _idUsuario);

        int EliminarReclamo(int _idReclamo);
        //bool Crear(Entidad objeto);

        int ModificarReclamo(Reclamo reclamo);

        //

        //List<Entidad> Consultar(Entidad objeto);
    }
    
}
