using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FOReserva.DataAccess.DataAccessObject.Common.DAO;

namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    public interface IDAO
    {
        DAOResult OpenConexion(string conexion);
        DAOResult ExcecuteQuery(string query, ForEachRow doThis = null);
        DAOResult ExcecuteNoQuery(string query);
        DAOResult CloseConexion();
    }
}
