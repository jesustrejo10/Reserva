using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M11;
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
        int _disponibilidad;


        public M11_CODeshabilitarPaquete(Entidad paquete, int id)
        {
            this._paquete = (Paquete) paquete;
            this._paquete._id = id;
        }
  
        public override String ejecutar(){
                IDAOPaquete daoPaquete = (DAOPaquete)FabricaDAO.instanciarDaoPaquete();
                String test = daoPaquete.disponibilidadPaquete(_paquete, _disponibilidad);
                return test;
            }
    }
}