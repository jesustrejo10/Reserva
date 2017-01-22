using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M03;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M03
{
    /// <summary>
    /// Comando Deshabilitar Rutas
    /// </summary>
    public class M03_CODeshabilitarRuta : Command<Boolean>
    {
        Ruta _ruta;
        int _idmodificar;

        public M03_CODeshabilitarRuta(int id)
        {
            this._ruta._id = id;
        }

        public override Boolean ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Boolean test = daoRuta.deshabilitarRuta(_ruta._id);
            return test;
        }

    }
}