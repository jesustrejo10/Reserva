using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M11;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Deshabilitar Oferta
    /// </summary>
    public class M11_CODeshabilitarOferta: Command<String>
    {
        Oferta _oferta;
        int _estadoOferta;

        public M11_CODeshabilitarOferta(Entidad oferta, int estadoOferta)
        { 
            this._oferta = (Oferta) oferta;
            this._estadoOferta = estadoOferta;
        }

        public override String ejecutar()
        {
            Debug.WriteLine("Id en EJECUTAR DESHA ", _oferta._id);
            IDAOOferta daoOferta = (DAOOferta)FabricaDAO.instanciarDaoOferta();
            String test = daoOferta.disponibilidadOferta(_oferta, _estadoOferta);
            return test;
        } 

    /*    public override String ejecutar()
        {

            return null; //por ahora porque lo de arriba es lo que se debe descomentar
        } */
    }
}