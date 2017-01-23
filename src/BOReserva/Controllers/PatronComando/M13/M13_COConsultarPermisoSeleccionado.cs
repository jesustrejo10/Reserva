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
    public class M13_COConsultarPermisoSeleccionado : Command<Entidad>
    {
        int valor;

        public M13_COConsultarPermisoSeleccionado(int value)
        {
            this.valor = value;
        }


        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override Entidad ejecutar()
        {
            IDAOPermiso daoPermiso = (IDAOPermiso)FabricaDAO.instanciarDAOPermiso();
            Entidad permiso = daoPermiso.Consultar(valor);
            return permiso;
        }
    }
}