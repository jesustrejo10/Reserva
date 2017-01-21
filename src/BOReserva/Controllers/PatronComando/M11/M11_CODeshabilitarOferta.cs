using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    public class M11_CODeshabilitarOferta: Command<String>
    {
        Oferta _oferta;
        int _idmodificar;

        public M11_CODeshabilitarOferta(Entidad oferta, int id)
        { 
            this._oferta = (Oferta) oferta;
            this._oferta._id = id;
        }

      /*  public override String ejecutar()
        {
            DAOOferta daoOferta = (DAOOferta)FabricaDAO.instanciarDaoOferta();
            String test = daoOferta.eliminarOferta(_oferta._id);
            return test;
        } */

        public override String ejecutar()
        {

            return null; //por ahora porque lo de arriba es lo que se debe descomentar
        } 
    }
}