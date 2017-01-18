using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using FOReserva.DataAccess.DataAccessObject.Common.DAO;

namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    public interface IDAO
    {
        DAOResult OpenConnection();
        DAOResult ExecuteQuery(string query, FOReserva.DataAccess.DataAccessObject.Common.DAO.ForEachRow doThis = null);
        DAOResult ExecuteNoQuery(string query);
        DAOResult ExecuteStoreProcedure(string name, object parameters);
        DAOResult ExecuteStoreProcedureWithResult(string name, object parameters, FOReserva.DataAccess.DataAccessObject.Common.DAO.ForEachRow doThis = null);
        DAOResult CloseConnection();
    }
}
