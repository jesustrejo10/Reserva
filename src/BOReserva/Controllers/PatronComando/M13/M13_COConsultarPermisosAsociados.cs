using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    ///<summary>
    ///Comando que consulta los permisos asociados a un rol
    ///</summary>
    public class M13_COConsultarPermisosAsociados : Command<List<Entidad>>
    {

        Rol _rol;

        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COConsultarPermisosAsociados(Entidad rol, int id)
        {
            this._rol = (Rol)rol;
            this._rol._idRol = id;
        }

        ///<summary>
        ///Metodo que ejecuta el comando
        ///</summary>
        ///<returns>Lista de entidad</returns>
        public override List<Entidad> ejecutar()
        {
            DAORol daoRol = (DAORol)FabricaDAO.instanciarDAORol();
            List<Entidad> test = daoRol.consultarLosPermisosAsignados(_rol._idRol);
            return test;
        }
    }
}