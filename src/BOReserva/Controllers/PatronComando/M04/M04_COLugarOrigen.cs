﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    /// <summary>
    /// Comando para buscar lugares de origen cuyas rutas esten activas
    /// </summary>
    public class M04_COLugarOrigen : Command<List<Entidad>>
    {
        private List<Lugar> _lugares;

        #region Constructores


        /// <summary>
        /// Constructor simple
        /// </summary>
        public M04_COLugarOrigen()
        {
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DAOVuelo y usa el método ConsultarLugarOrigen
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override List<Entidad> ejecutar()
        {
            try
            {
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return(exec.ConsultarLugarOrigen());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }
}