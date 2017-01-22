using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    public class M05_COConsultarBoletoBD: Command<Entidad>
    {
        int _id;

        public M05_COConsultarBoletoBD(int value)
        {
            this._id = value;
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
            IDAOBoleto daoBoleto = (IDAOBoleto)FabricaDAO.instanciarDaoBoleto();
            Entidad boleto = daoBoleto.M05MostrarReservaBD(_id);
            return boleto;
        }
    }
}