using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    public class M05_COConsultarBoleto: Command<Entidad>
    {
        int valor;

        public M05_COConsultarBoleto(int value)
        {
            this.valor = value;
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
            IDAO daoBoleto = FabricaDAO.instanciarDaoBoleto();
            Entidad boleto = daoBoleto.Consultar(valor);
            return boleto;
        }
    }
}