using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a realizar operaciones necesarias
    /// para a;adir oferta a la BD
    /// </summary>
    public class M11_COAgregarOferta : Command<String>
    {
        Oferta _oferta;

        public M11_COAgregarOferta(Oferta oferta) { 
            this._oferta = oferta;
        }

        public override String ejecutar(){
            IDAO daoOferta = FabricaDAO.instanciarDaoOferta();       
            int test = daoOferta.Agregar(_oferta);
            return test.ToString();
        }

    }
}