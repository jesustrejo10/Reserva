﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M07
{
    public class M07_COConsultarReclamoEquipaje: Command<Dictionary<int, Entidad>>
    {
        /// <summary>
        /// Sobrescritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna un Identity map, de tipo int, Entidad
        /// </returns>
        public override Dictionary<int, Entidad> ejecutar()
        {
            IDAO daoReclamoE = FabricaDAO.instanciarDaoReclamoEquipaje();
            Dictionary<int, Entidad> mapReclamos = daoReclamoE.ConsultarTodos();
            return mapReclamos;
        }
    }
}