using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    ///<summary>
    ///Comando que consulta los permisos que posee un usuario
    ///</summary>
    public class M13_COConsultarPermisosUsuario : Command<List<int>>
    {
        int idUsuario;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COConsultarPermisosUsuario(int id)
        {
            this.idUsuario = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>Lista de enteros</returns>
        public override List<int> ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            List<int> test = daoRol.consultarPermisosUsuario(idUsuario);
            return test;
        }
    }
}