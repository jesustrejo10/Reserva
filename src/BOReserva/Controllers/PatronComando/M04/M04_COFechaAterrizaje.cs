﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M04
{
    public class M04_COFechaAterrizaje : Command<Entidad>
    {
         private int _idRuta;
         private int _idAvion;
         private DateTime _fechaDespegue;
        #region Constructores


        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="vuelo">Es el objeto al que se le quiere cambiar el status</param>
        public M04_COFechaAterrizaje(int idRuta, int idAvion, DateTime fechaDespegue)
        {
            _fechaDespegue = fechaDespegue;
            _idAvion = idAvion;
            _idRuta = idRuta; 
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Método para crear la instancia de la clase DaoVuelo y usa el método CambiarStatus
        /// </summary>
        /// <returns>Retorna true si la accion se realizo</returns>
        public override Entidad ejecutar()
        {
            try
            {
                DAOVuelo exec = (DAOVuelo)FabricaDAO.instanciarDAOVuelo();
                return (exec.ConsultarDatosAterrizaje(_idRuta, _fechaDespegue, _idAvion));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion
    }
}