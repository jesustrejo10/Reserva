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
    /// Comando Modificar Paquetes
    /// </summary>
    public class M11_COModificarPaquete : Command<String>
    {
        Paquete _paquete;
        int _idmodificar;

        public M11_COModificarPaquete(Entidad paquete, int id)
        {
            this._paquete = (Paquete) paquete;
            this._paquete._id = id;
        }

     /*   public override String ejecutar()
        {
            IDAO daoPaquete = FabricaDAO.instanciarDaoPaquete();
            Entidad test = daoPaquete.Modificar(_paquete);
            Paquete paquete = (Paquete)test;
            return paquete._nombre;

        }*/

           public override String ejecutar()
        {
            
            return null; //por ahora porque lo de arriba es lo que se debe descomentar

        }
    }
}