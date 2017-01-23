using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M03;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M03
{
    /// <summary>
    /// Comando Validar Rutas
    /// </summary>
    public class M03_COValidarRuta : Command<Boolean>
    {
        Ruta _ruta;
        int _idmodificar;

        public M03_COValidarRuta(Entidad ruta, int id)
        {
            this._ruta = (Ruta)ruta;
            this._ruta._id = id;
        }

        public override Boolean ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Boolean test = daoRuta.ValidarRuta(_ruta);
            return test;
        }

    }
}