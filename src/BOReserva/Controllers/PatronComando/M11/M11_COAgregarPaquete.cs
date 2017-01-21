using BOReserva.DataAccess.DAO;
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
    /// /// Comando destinado a realizar operaciones necesarias
    /// para añadir paquetes a la BD
    /// </summary>
    public class M11_COAgregarPaquete : Command<String>
    {
        Paquete _paquete;

        public M11_COAgregarPaquete(Paquete paquete) { 
            this._paquete = paquete;
        }

        public override String ejecutar(){
            IDAO daoPaquete = FabricaDAO.instanciarDaoPaquete();       
            int test = daoPaquete.Agregar(_paquete);
            return test.ToString();
        }
    }
}