using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject.M03;

namespace BOReserva.Controllers.PatronComando.M03
{/// <summary>
    /// Comando Consultar Destinos
    /// </summary>
    public class M03_COConsultarDestinos : Command<Dictionary<int, Entidad>>
    {
        Ruta _ruta;
        string _origenRuta;

        public M03_COConsultarDestinos(string origen)
        {
            this._ruta._origenRuta = origen;
        }
        public override Dictionary<int, Entidad> ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Dictionary<int, Entidad> test = daoRuta.consultarDestinos(_ruta._origenRuta);
            return test;
        }

    }
}