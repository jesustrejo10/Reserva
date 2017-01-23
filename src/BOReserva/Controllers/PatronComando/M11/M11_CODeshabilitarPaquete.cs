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
    public class M11_CODeshabilitarPaquete : Command<String>
    {
        Paquete _paquete;
        int _valor;

        public M11_CODeshabilitarPaquete(Entidad paquete, int estadoPaquete)
        {
            this._paquete = (Paquete)paquete;
            this._valor = estadoPaquete;
        }

        public override String ejecutar()
        {
            Debug.WriteLine("Id en EJECUTAR DESHA "+ _paquete._id);
            IDAOPaquete daoPaquete = (DAOPaquete)FabricaDAO.instanciarDaoPaquete();
            String test = daoPaquete.disponibilidadPaquete(_paquete, _valor);
            return test;
        }

        /*    public override String ejecutar()
            {

                return null; //por ahora porque lo de arriba es lo que se debe descomentar
            } */
    }
}