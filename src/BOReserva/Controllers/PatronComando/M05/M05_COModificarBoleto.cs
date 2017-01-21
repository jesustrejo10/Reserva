using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para ingresar un pasajero
    /// </summary>
    public class M05_COModificarBoleto : Command<int>
    {
        Boleto _boleto;

        public M05_COModificarBoleto(Boleto boleto)
        {
            this._boleto = boleto;
        }

        public override int ejecutar()
        {
            IDAO daoBoleto = FabricaDAO.instanciarDaoBoleto();
            Entidad resultado = daoBoleto.Modificar(_boleto); 
            return 1;
        }

    }
}