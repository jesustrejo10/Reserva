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
    /// Comando Modificar Rutas
    /// </summary>
    public class M03_COModificarRuta : Command<Boolean>
    {
        Ruta _ruta;
        int _idmodificar;

        public M03_COModificarRuta(Entidad ruta, int id)
        {
            this._ruta = (Ruta)ruta;
            this._ruta._id = id;
        }

        public override Boolean ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Boolean test = daoRuta.MModificarRuta(_ruta);
            return test;
        }

    }
}