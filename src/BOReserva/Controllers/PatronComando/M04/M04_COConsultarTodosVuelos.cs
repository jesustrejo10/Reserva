﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.DataAccess.DAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.DataAccessObject;
using System.Data.SqlClient;

namespace BOReserva.Controllers.PatronComando.M04
{
    /// <summary>
    /// Clase patron comando consultar todos los vuelos
    /// </summary>
    public class M04_COConsultarTodosVuelos : Command<List<Entidad>>
    {
        /// <summary>
        /// ejecuta el comando DAO.ConsultarTodos
        /// </summary>
        /// <returns>lista con todos los vuelos</returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                IDAOVuelo daoVuelo = (IDAOVuelo)FabricaDAO.instanciarDAOVuelo();
                List<Entidad> listaVuelos = daoVuelo.ConsultarTodos();
                return listaVuelos;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}