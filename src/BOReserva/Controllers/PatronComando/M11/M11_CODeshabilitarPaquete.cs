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
    /// Comando Deshabilitar Paquete
    /// </summary>
    public class M11_CODeshabilitarPaquete: Command<String>
    {
        Paquete _paquete;
        int _idmodificar;


        public M11_CODeshabilitarPaquete(Entidad paquete, int id)
        {
            this._paquete = (Paquete) paquete;
            this._paquete._id = id;
        }
  
     /*   public override String ejecutar()
        {
            DAOPaquete daoPaquete = (DAOPaquete)FabricaDAO.instanciarDaoPaquete();
            String test = daoPaquete.eliminarPaquete(_paquete._id);
            return test;
        } */

        public override String ejecutar()
        {

            return null;
        } // por ahora porque lo de arriba es lo que se debe descomentar
    }
}