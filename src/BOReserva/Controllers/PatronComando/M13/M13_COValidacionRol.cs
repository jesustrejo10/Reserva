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
    ///Comando que valida si un rol tiene usuario asociado
    ///</summary>
    public class M13_COValidacionRol : Command<List<int>>
    {
        int _idRol;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COValidacionRol(int id)
        {
            this._idRol = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>Lista de enteros</returns>
        public override List<int> ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            List<int> test = daoRol.validacionRol(_idRol);
            return test;
        }

    }
}