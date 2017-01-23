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
    /// Comando Mostrar Rutas
    /// </summary>
    public class M03_COMostrarRuta : Command<Entidad>
    {
        Ruta _ruta;
        int _id;

        public M03_COMostrarRuta(Entidad ruta, int id)
        {
            this._ruta = (Ruta)ruta;
            this._ruta._id = id;
        }

        public override Entidad ejecutar()
        {
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Entidad test = daoRuta.MMostrarRutaBD(_ruta._id);
            return test;
        }

    }
}