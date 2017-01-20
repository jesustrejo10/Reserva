using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOReserva.DataAccess.Domain;
namespace FOReserva.DataAccess.DataAccessObject.Common.Interface
{
    interface IDAOReclamo: IDAO
    {
        DAOResult AgregarReclamo();
    }
}
