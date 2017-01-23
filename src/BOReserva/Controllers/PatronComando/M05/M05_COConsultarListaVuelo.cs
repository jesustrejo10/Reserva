using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System.Collections.Generic;

namespace BOReserva.Controllers.PatronComando
{
    public class M05_COConsultarListaVuelo : Command<List<Entidad>>
    {
        string _fechaida;
        string _fechavuelta;
        int _idorigen;
        int _iddestino;
        string _tipo;
        
        public M05_COConsultarListaVuelo(string fechaida, string fechavuelta, int idorigen, int iddestino, string tipo)
        {
            this._fechaida = fechaida;
            this._fechavuelta = fechavuelta;
            this._idorigen = idorigen;
            this._iddestino = iddestino;
            this._tipo = tipo;
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
            IDAOBoleto instanciarBoleto = (IDAOBoleto)FabricaDAO.instanciarDaoBoleto();
            List<Entidad> lista = instanciarBoleto.M05ListarVuelosIdaBD(_fechaida, _fechavuelta, _idorigen, _iddestino, _tipo);
            return lista;
        }
    }
}