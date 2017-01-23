using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Collections.Generic;

namespace BOReserva.Controllers.PatronComando
{
    public class M05_COConsultarBoletosPasajero : Command<List<Entidad>>
    {
        int _id;

        public M05_COConsultarBoletosPasajero(int id) {
            this._id = id;
        }

        ///// <summary>
        ///// Sobre escritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override List<Entidad> ejecutar()
        {
            IDAOBoleto daoBoleto = (IDAOBoleto)FabricaDAO.instanciarDaoBoleto();
            List<Entidad> resultado = daoBoleto.ConsultarBoletosPasajero( _id);
            return resultado;
        }
    }
}