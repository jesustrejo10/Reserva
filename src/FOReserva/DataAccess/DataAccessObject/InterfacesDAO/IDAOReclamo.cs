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

        //bool Crear(Entidad objeto);

        //bool Modificar(Entidad objeto);

        //bool Eliminar(Entidad objeto);

        //List<Entidad> Consultar(Entidad objeto);
    }
    
}
