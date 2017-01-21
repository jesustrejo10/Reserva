using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para agregar un boleto a la DB
    /// </summary>
    public class M05_COCrearBoleto : Command<String>
    {
        Boleto _boleto;


        public M05_COCrearBoleto(Boleto boleto)
        {
            this._boleto = boleto;
        }

        public override String ejecutar()
        {
            IDAO daoBoleto = FabricaDAO.instanciarDaoBoleto();
            int test = daoBoleto.Agregar(_boleto);
            return test.ToString();
        }

    }
}