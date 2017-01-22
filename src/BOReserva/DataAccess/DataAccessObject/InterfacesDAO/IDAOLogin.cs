using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;

namespace BOReserva.DataAccess.DataAccessObject.InterfacesDAO
{
    interface IDAOLogin : IDAO
    {
        Entidad Consultar(Entidad _usuario);
        Boolean BloquearUsuario(Entidad _usuario);
        Boolean IncrementarIntentos(Entidad _usuario);
        Boolean ResetearIntentos(Entidad _usuario);
        int EjecutarStoredProcedureTuplasFilasAfectadas(string query, List<Parametro> parametros);
        
    }
}
