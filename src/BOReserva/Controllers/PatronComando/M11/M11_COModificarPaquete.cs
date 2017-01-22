using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Modificar Paquete
    /// </summary>
    public class M11_COModificarPaquete : Command<String>
    {
        Paquete _paquete;
        //int _idmodificar;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="paquete">Paquete a modificar</param>
        /// <param name="id">Identificador del paquete a modificar</param>
        public M11_COModificarPaquete(Entidad paquete, int id)
        {
            this._paquete = (Paquete) paquete;
            this._paquete._id = id;
        }

        public override String ejecutar()
        {
            try
            {
                IDAO daoPaquete = FabricaDAO.instanciarDaoPaquete();
                Entidad test = daoPaquete.Modificar(_paquete);
                Paquete paquete = (Paquete)test;
                return paquete._nombrePaquete;
            }
            catch (ReservaExceptionM11 ex)
            {
                throw ex;
            }

        }

       
    }
}