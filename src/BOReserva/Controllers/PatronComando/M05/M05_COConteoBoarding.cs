﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;


namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Comando destinado a Realizar las respectivas operaciones necesarias
    /// para ingresar un pasajero
    /// </summary>
    public class M05_COConteoBoarding : Command<int>
    {
         int _num_bol;
         int _num_vue;

         public M05_COConteoBoarding(int num_bol, int num_vue)
        {
            this._num_bol = num_bol;
            this._num_vue = num_vue;
        }

        public override int ejecutar()
        {
            IDAOCheckIn daoChaeckIn = (IDAOCheckIn)FabricaDAO.instanciarDaoCheckIn();
            int conteo = daoChaeckIn.MConteoBoarding(_num_bol,_num_vue);
            return conteo;
        }

    }
}