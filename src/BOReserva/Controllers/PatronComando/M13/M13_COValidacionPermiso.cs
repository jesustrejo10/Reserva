using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    ///<summary>
    ///Comando que valida si un permiso tiene rol asignado
    ///</summary>
    public class M13_COValidacionPermiso : Command<List<int>>
    {
        int _idPermiso;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COValidacionPermiso(int id)
        {
            this._idPermiso = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>Lista de enteros</returns>
        public override List<int> ejecutar()
        {
            DAOPermiso daoPermiso = (DAOPermiso)FabricaDAO.instanciarDAOPermiso();
            List<int> test = daoPermiso.validacionPermiso(_idPermiso);
            return test;
        }

    }
}