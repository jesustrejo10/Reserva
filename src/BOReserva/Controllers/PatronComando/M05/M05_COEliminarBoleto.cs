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
    public class M05_COEliminarBoleto : Command<String>
    {
        int _id;


        public M05_COEliminarBoleto(int id)
        {
            this._id = id;
        }

        public override String ejecutar()
        {
            IDAO daoBoleto = FabricaDAO.instanciarDaoBoleto();
            int test = daoBoleto.Eliminar(_id);
            return test.ToString();
        }

    }
}