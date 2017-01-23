using BOReserva.DataAccess.DAO;
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
    ///Comando que consulta permiso
    ///</summary>
    public class M13_COConsultarPermiso : Command<List<Entidad>>
    {
        int valor;
        ///<summary>
        ///Constructor
        ///</summary>
        public M13_COConsultarPermiso(int value)
        {
            this.valor = value;
        }


        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna una lista de Entidad
        /// </returns>
        public override List<Entidad> ejecutar()
        {
            IDAORol daoRol = (IDAORol)FabricaDAO.instanciarDAORol();
            List<Entidad> permiso = daoRol.ConsultarPermisos(valor);
            return permiso;
        }
    }
}