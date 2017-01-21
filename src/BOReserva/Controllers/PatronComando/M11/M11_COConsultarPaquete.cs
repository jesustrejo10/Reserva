using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Consultar Paquete
    /// </summary>
    public class M11_COConsultarPaquete: Command<Entidad>
    {
        int valor;

        public M11_COConsultarPaquete(int value){
        this.valor = value;
    }

        ///// <summary>
        ///// Sobreescritura del método ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override Entidad ejecutar()
        {
            IDAO daoPaquete = FabricaDAO.instanciarDaoPaquete();
            Entidad paquete = daoPaquete.Consultar(valor);
            return paquete;
        }
}
}