﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para agregar un boleto a la DB
    /// </summary>
    public class M05_COMostrarIdaVuelta : Command<int>
    {
        int _id;


        public M05_COMostrarIdaVuelta(int id)
        {
            this._id = id;
        }

        public override int ejecutar()
        {
            IDAOBoleto daoBoleto = (IDAOBoleto)FabricaDAO.instanciarDaoBoleto();
            int resultado = daoBoleto.MBuscarIdaVuelta(_id);
            return resultado;
        }

    }
}