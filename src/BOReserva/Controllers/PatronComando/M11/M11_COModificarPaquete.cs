using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.Excepciones.M11;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        int _idmodificar;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="paquete">Paquete a modificar</param>
        /// <param name="id">Identificador del paquete a modificar</param>
        public M11_COModificarPaquete(Entidad paquete, int id)
        {
            this._paquete = (Paquete) paquete;
            this._idmodificar = id;
        }

        public override String ejecutar()
        {
            Debug.WriteLine("ENTRÓ A EJECUTAR");
            Debug.WriteLine("ENTRÓ A EJECUTAR " + _paquete._nombrePaquete);

            try
            {
                IDAOPaquete daoPaquete = FabricaDAO.instanciarDaoPaquete();
                int test = daoPaquete.Modificar(_paquete,_idmodificar);
                return test.ToString();
            }
            catch (ReservaExceptionM11 ex)
            {
                throw ex;
            }

        }

       
    }
}