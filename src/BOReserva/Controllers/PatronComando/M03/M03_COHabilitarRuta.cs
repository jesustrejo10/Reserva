using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M03;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Domain.M03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Comando Habilitar Rutas
    /// </summary>
    public class M03_COHabilitarRuta : Command<Boolean>
    {
        Ruta _ruta;
        int _id;

        public M03_COHabilitarRuta(int id) { 
            this._ruta._id = id;
        }

        public override Boolean ejecutar(){
            DAORuta daoRuta = (DAORuta)FabricaDAO.instanciarDAORuta();
            Boolean test = daoRuta.habilitarRuta(_id);
            return test;
        }

    }
}