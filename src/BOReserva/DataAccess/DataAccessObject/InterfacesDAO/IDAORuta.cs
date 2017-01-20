using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Models.gestion_ruta_comercial;


namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAORuta : IDAO
    {
        //metodos detallados
        Boolean ValidarRuta(Entidad e);
        Boolean habilitarRuta(int id);
        Boolean deshabilitarRuta(int id);
        Dictionary<int, Entidad> listarLugares();
        Dictionary<int, Entidad> consultarDestinos(String origen);
        Entidad MMostrarRutaBD(int idRuta);
        Boolean MModificarRuta(Entidad e);




    }
}
